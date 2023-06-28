using foot2rue.BLL.Extensions;
using foot2rue.BLL.Models;
using foot2rue.BLL.Utilities;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;

namespace foot2rue.BLL.Services
{
    public class DataService
    {
        private static readonly SettingsService settingsService = SettingsService.Instance;
        private IRepository repository;

        #region Setters

        public Genre Genre { get; private set; }
        
        public void SetGenre(Genre genre)
        {
            // No need to reset everything if the value is unchanged
            if (genre == Genre)
                return;

            Genre = genre;
            UpdateRepository();
            ResetData();
        }

        public bool OfflineMode { get; private set; }
        
        public void SetOfflineMode(bool offlineMode)
        {
            // No need to change everything if the value is unchanged
            if (offlineMode == OfflineMode)
                return;

            OfflineMode = offlineMode;
            UpdateRepository();
        }

        #endregion

        #region Matches

        private IEnumerable<Match>? matches;
        
        public async Task<IEnumerable<Match>?> GetMatches()
        {
            matches ??= await Task.Run(repository.GetMatches);
            return matches;
        }

        #endregion

        #region Players

        // Because of the multiple threads running, we use try add to make sure we don't try to add twice the same key
        // Without it, if the user starts loading multiple tabs at once, creating an exception

        private readonly Dictionary<string, IEnumerable<Match>?> matchesByFifaCode = new();
        
        public async Task<IEnumerable<Match>?> GetMatchesByFifaCode(string fifaCode)
        {
            if (!matchesByFifaCode.ContainsKey(fifaCode))
            {
                if (matches != null)
                    // If matches have already been loaded, just filter them
                    matchesByFifaCode.TryAdd(fifaCode, (await Task.Run(GetMatches))?.Where(match => match.HomeTeam.FifaCode == fifaCode || match.AwayTeam.FifaCode == fifaCode));
                else
                    // If no matches have been loaded yet, only get the matches we need from API
                    matchesByFifaCode.TryAdd(fifaCode, await Task.Run(() => repository.GetMatchesByFifaCode(fifaCode)));
            }
            return matchesByFifaCode[fifaCode];
        }

        private readonly Dictionary<string, IEnumerable<PlayerCupResult>?> playersByFifaCode = new();
        public async Task<IEnumerable<PlayerCupResult>?> GetPlayersByFifaCode(string fifaCode)
        {
            if (!playersByFifaCode.ContainsKey(fifaCode))
            {
                // Get players from the repo
                Match? match = (await Task.Run(() => repository.GetMatchesByFifaCode(fifaCode)))?.ElementAt(0);
                Statistics? teamStatistics = match?.HomeTeam.FifaCode == fifaCode ? match?.HomeTeamStatistics : match?.AwayTeamStatistics;
                IEnumerable<Player>? players = teamStatistics?.StartingEleven.Concat(teamStatistics.Substitutes);

                // Convert those players to BLL model using the events of the matches
                IEnumerable<Match>? matches = await GetMatchesByFifaCode(fifaCode);
                IEnumerable<Statistics>? statistics = matches?.Select(
                    match => match.HomeTeam.FifaCode == fifaCode ? match.HomeTeamStatistics : match.AwayTeamStatistics);
                IEnumerable<Event>? events = matches?.SelectMany(
                    match => match.HomeTeam.FifaCode == fifaCode ? match.HomeTeamEvents : match.AwayTeamEvents);
                playersByFifaCode.TryAdd(fifaCode, ExtendPlayers(players, statistics, events));
            }

            return playersByFifaCode[fifaCode];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="match"></param>
        /// <param name="team">An integer showing in what team the player should be searched. 0 is the home team, 1 is the away team</param>
        /// <param name="player"></param>
        /// <returns></returns>
        public PlayerMatchResult GetPlayerMatchResults(Match match, int team, Player player)
        {
            if (team < 0 || team > 1)
                throw new ArgumentException("How many teams do you think there is in a football match ?");

            PlayerMatchResult playerResult = player.ExtendParentClass<Player, PlayerMatchResult>();

            foreach (Event @event in team == 0 ? match.HomeTeamEvents : match.AwayTeamEvents)
            {
                // We skip other players
                if (@event.Player != player.Name)
                    continue;

                switch (@event.Type)
                {
                    // TODO Could be improved with a bit of reflection
                    // Hard coding is ugly, but it'll do
                    case "goal":
                    case "goal-penalty":
                    case "goal-own":
                        playerResult.Goals++;
                        break;
                    case "yellow-card":
                        playerResult.YellowCards++;
                        break;
                    case "red-card":
                        playerResult.RedCards++;
                        break;
                }
            }

            return playerResult;
        }

        private IEnumerable<PlayerCupResult> ExtendPlayers(IEnumerable<Player>? players, IEnumerable<Statistics>? statistics, IEnumerable<Event>? events)
        {
            if (players == null)
                return Enumerable.Empty<PlayerCupResult>();

            // Copy all the data from DAL Players
            // We store players in a dictionary so that the search complexity is O(1)
            // Check if this player is a favorite
            Dictionary<string, PlayerCupResult> extendedPlayers = new();
            foreach (Player player in players)
            {
                PlayerCupResult extendedPlayer = player.ExtendParentClass<Player, PlayerCupResult>();
                extendedPlayer.IsFavorite = IsFavorite(extendedPlayer);

                // Obsolete
                extendedPlayer.Image = PictureUtility.LoadPlayerPicture(extendedPlayer);

                extendedPlayers.Add(player.Name, extendedPlayer);
            }

            // If statistics is null, skip this count
            // Players that are present at the start of the match
            foreach (Statistics stats in statistics.EmptyIfNull())
                foreach (Player player in stats.StartingEleven)
                {
                    // We check before if the player is in the dictionnary to avoid crashes when the API contains typos
                    // It will return a wrong result, but it's better than no result at all
                    PlayerCupResult extendedPlayer;
                    if (extendedPlayers.TryGetValue(player.Name, out extendedPlayer!))
                        extendedPlayer.MatchPlayed++;
                }

            // If event is null, skip this part
            // Count players that are:
            // Scoring
            // Gets a yellow card
            // Joining during a match (If a player joins a match twice, it will be counted for two different matches)
            foreach (Event matchEvent in events ?? Enumerable.Empty<Event>())
            {
                PlayerCupResult? player = extendedPlayers.GetValueOrDefault(matchEvent.Player);
                if (player == null)
                    continue;

                switch (matchEvent.Type)
                {
                    // TODO Could be improved with a bit of reflection
                    // Hard coding is ugly, but it'll do
                    case "goal":
                    case "goal-penalty":
                    case "goal-own":
                        player.Goals++;
                        break;
                    case "yellow-card":
                        player.YellowCards++;
                        break;
                    case "red-card":
                        player.RedCards++;
                        break;
                    case "substitution-in":
                        player.MatchPlayed++;
                        break;
                }
            }

            return extendedPlayers.Select(pair => pair.Value).AsEnumerable();
        }

        #endregion

        #region Teams

        private IEnumerable<Team>? teams;
        
        public async Task<IEnumerable<Team>?> GetTeams()
        {
            teams ??= await Task.Run(repository.GetTeams);
            return teams;
        }

        public async Task<Team?> GetTeamByFifaCode(string fifaCode)
        {
            if (teams == null)
                await GetTeams();
            return teams?.FirstOrDefault(team => team.FifaCode == fifaCode);
        }

        #endregion

        #region Team results

        private IEnumerable<TeamResult>? teamResults;

        public async Task<IEnumerable<TeamResult>?> GetTeamResults()
        {
            teamResults ??= await Task.Run(repository.GetTeamResults);
            return teamResults;
        }

        public async Task<TeamResult?> GetTeamResultByFifaCode(string fifaCode)
        {
            return (await GetTeamResults())?.Where(teamResult => teamResult.FifaCode == fifaCode).SingleOrDefault();
        }

        #endregion

        #region Group results

        private IEnumerable<GroupResult>? groupResults;
        public async Task<IEnumerable<GroupResult>?> GetGroupResults()
        {
            groupResults ??= await Task.Run(repository.GetGroupResults);
            return groupResults;
        }

        #endregion

        #region Initialization

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataService(Genre genre, bool offlineMode = false)
        {
            Genre = genre;
            OfflineMode = offlineMode;
            UpdateRepository();
        }

        public DataService() : this(settingsService.SelectedGenre, settingsService.OfflineMode) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private void ResetData()
        {
            matches = null;
            matchesByFifaCode.Clear();
            playersByFifaCode.Clear();
            teams = null;
            teamResults = null;
            groupResults = null;
        }

        private void UpdateRepository()
        {
            repository = OfflineMode ? new JsonRepository(Genre) : new ApiRepository(Genre);
        }

        #endregion

        #region Favorites

        public bool IsFavorite(PlayerCupResult player)
        {
            return settingsService.FavoritePlayers.Contains(player.Name);
        }

        public void AddFavorite(PlayerCupResult player)
        {
            settingsService.FavoritePlayers.Add(player.Name);
        }

        public void RemoveFavorite(PlayerCupResult player)
        {
            settingsService.FavoritePlayers.Remove(player.Name);
        }

        #endregion
    }
}
