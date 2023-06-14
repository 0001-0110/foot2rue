using foot2rue.BLL.Extensions;
using BllPlayer = foot2rue.BLL.Models.Player;
using foot2rue.BLL.Services;
using foot2rue.BLL.Utilities;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.Settings.Extensions;

namespace foot2rue.WF.Services
{
    public class DataService
    {
        private static SettingsService settingsService = SettingsService.Instance;
        private IRepository repository;

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

        private IEnumerable<Match>? matches;
        public async Task<IEnumerable<Match>?> GetMatches()
        {
            if (matches == null)
                matches = await Task.Run(repository.GetMatches);
            return matches;
        }

        private Dictionary<string, IEnumerable<Match>?> matchesByFifaCode = new Dictionary<string, IEnumerable<Match>?>();
        public async Task<IEnumerable<Match>?> GetMatchesByFifaCode(string fifaCode)
        {
            if (!matchesByFifaCode.ContainsKey(fifaCode))
            {
                if (matches != null)
                    // If matches have already been loaded, just filter them
                    matchesByFifaCode.Add(fifaCode, (await Task.Run(GetMatches))?.Where(match => match.HomeTeam.FifaCode == fifaCode || match.AwayTeam.FifaCode == fifaCode));
                else
                    // If no matches have been loaded yet, only get the matches we need from API
                    matchesByFifaCode.Add(fifaCode, await Task.Run(() => repository.GetMatchesByFifaCode(fifaCode)));
            }
            return matchesByFifaCode[fifaCode];
        }

        private Dictionary<string, IEnumerable<BllPlayer>?> playersByFifaCode = new Dictionary<string, IEnumerable<BllPlayer>?>();
        public async Task<IEnumerable<BllPlayer>?> GetPlayersByFifaCode(string fifaCode)
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
                playersByFifaCode.Add(fifaCode, ExtendPlayers(players, statistics, events));
            }

            return playersByFifaCode[fifaCode];
        }

        private IEnumerable<Team>? teams;
        public async Task<IEnumerable<Team>?> GetTeams()
        {
            if (teams == null)
                teams = await Task.Run(repository.GetTeams);
            return teams;
        }

        public async Task<Team?> GetTeamByFifaCode(string fifaCode)
        {
            if (teams == null)
                await GetTeams();
            return teams?.FirstOrDefault(team => team.FifaCode == fifaCode);
        }

        private IEnumerable<TeamResult>? teamResults;
        public async Task<IEnumerable<TeamResult>?> GetTeamResults()
        {
            if (teamResults == null)
                teamResults = await Task.Run(repository.GetTeamResults);
            return teamResults;
        }

        private IEnumerable<GroupResult>? groupResults;
        public async Task<IEnumerable<GroupResult>?> GetGroupResults()
        {
            if (groupResults == null)
                groupResults = await Task.Run(repository.GetGroupResults);
            return groupResults;
        }

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

        private IEnumerable<BllPlayer> ExtendPlayers(IEnumerable<Player>? players, IEnumerable<Statistics>? statistics, IEnumerable<Event>? events)
        {
            if (players == null)
                return Enumerable.Empty<BllPlayer>();

            // Copy all the data from DAL Players
            // We store players in a dictionary so that the search complexity is O(1)
            // Check if this player is a favorite
            Dictionary<string, BllPlayer> extendedPlayers = new Dictionary<string, BllPlayer>();
            foreach (Player player in players)
            {
                BllPlayer extendedPlayer = player.ExtendParentClass<Player, BllPlayer>();
                extendedPlayer.IsFavorite = IsFavorite(extendedPlayer);
                extendedPlayer.Image = PictureUtility.LoadPlayerPicture(extendedPlayer);
                extendedPlayers.Add(player.Name, extendedPlayer);
            }

            // If statistics is null, skip this count
            // Players that are present at the start of the match
            foreach (Statistics stats in statistics.IfNotNull())
                foreach (Player player in stats.StartingEleven)
                {
                    // We check before if the player is in the dictionnary to avoid crashes when the API contains typos
                    // It will return a wrong result, but it's better than no result at all
                    BLL.Models.Player extendedPlayer;
                    if (extendedPlayers.TryGetValue(player.Name, out extendedPlayer!))
                        extendedPlayer.MatchesPalyed++;
                }

            // If event is null, skip this part
            // Count players that are:
            // Scoring
            // Gets a yellow card
            // Joining during a match (If a player joins a match twice, it will be counted for two different matches)
            foreach (Event matchEvent in events ?? Enumerable.Empty<Event>())
            {
                BLL.Models.Player? player = extendedPlayers.GetValueOrDefault(matchEvent.Player);
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
                        player.MatchesPalyed++;
                        break;
                }
            }

            return extendedPlayers.Select(pair => pair.Value).AsEnumerable();
        }

        #region Favorites

        public bool IsFavorite(BllPlayer player)
        {
            return settingsService.FavoritePlayers.Contains(player.Name);
        }

        public void AddFavorite(BllPlayer player)
        {
            settingsService.FavoritePlayers.Add(player.Name);
        }

        public void RemoveFavorite(BllPlayer player) 
        {
            settingsService.FavoritePlayers.Remove(player.Name);
        }

        #endregion
    }
}
