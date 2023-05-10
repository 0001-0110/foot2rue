using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.WF.Extensions;
using foot2rue.WF.Models;
using foot2rue.WF.Utilities;
using System.Linq.Expressions;
using System.Reflection;

namespace foot2rue.WF.Services
{
    internal class DataService
    {
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

        private Dictionary<string, IEnumerable<Models.Player>?> playersByFifaCode = new Dictionary<string, IEnumerable<Models.Player>?>();
        public async Task<IEnumerable<Models.Player>?> GetPlayersByFifaCode(string fifaCode)
        {
            if (!playersByFifaCode.ContainsKey(fifaCode))
            {
                // Get players from the repo
                Match? match = (await Task.Run(() => repository.GetMatchesByFifaCode(fifaCode)))?.ElementAt(0);
                Statistics? teamStatistics = match?.HomeTeam.FifaCode == fifaCode ? match?.HomeTeamStatistics : match?.AwayTeamStatistics;
                IEnumerable<DAL.Models.Player>? players = teamStatistics?.StartingEleven.Concat(teamStatistics.Substitutes);

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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataService(Genre genre, bool offlineMode = false)
        {
            Genre = genre;
            OfflineMode = offlineMode;
            UpdateRepository();
        }

        public DataService() : this(SettingsService.SelectedGenre, SettingsService.OfflineMode) { }
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

        private IEnumerable<Models.Player> ExtendPlayers(IEnumerable<DAL.Models.Player>? players, IEnumerable<Statistics>? statistics,IEnumerable<Event>? events)
        {
            if (players == null)
                return Enumerable.Empty<Models.Player>();

            // Copy all the data from DAL Players
            // Check if this player is a favorite
            // TODO Get the image of the player
            Dictionary<string, Models.Player> extendedPlayers = new Dictionary<string, Models.Player>();
            foreach (DAL.Models.Player player in players)
            {
                Models.Player extendedPlayer = player.ExtendParentClass<DAL.Models.Player, Models.Player>();
                extendedPlayer.IsFavorite = SettingsService.FavoritePlayers?.Contains(player.Name) ?? false;
                // TODO How to get the image ?
                //BllPlayer.Image = ;
                extendedPlayers.Add(player.Name, extendedPlayer);
            }

            // If statistics is null, skip this count
            // Players that are present at the start of the match
            foreach (Statistics stats in statistics ?? Enumerable.Empty<Statistics>())
                foreach (var player in stats.StartingEleven)
                    extendedPlayers[player.Name].MatchesPalyed++;

            // If event is null, skip this part
            // Count players that are:
            // Scoring
            // Gets a yellow card
            // Joining during a match (If a player joins a match twice, it will be counted for two different matches)
            foreach (Event matchEvent in events ?? Enumerable.Empty<Event>())
            {
                Models.Player player = extendedPlayers[matchEvent.Player];
                switch (matchEvent.Type)
                {
                    // Hard coding is ugly, but it'll do
                    case "goal":
                    case "goal-penalty":
                    case "goal-own":
                        player.Goals++;
                        break;
                    case "yellow-card":
                        player.YellowCards++;
                        break;
                    case "substitution-in":
                        player.MatchesPalyed++;
                        break;
                }
            }

            return extendedPlayers.Select(pair => pair.Value).AsEnumerable();
        }
    }
}
