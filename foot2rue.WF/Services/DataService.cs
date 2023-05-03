﻿using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;

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

        private Dictionary<string, IEnumerable<Player>?> playersByFifaCode = new Dictionary<string, IEnumerable<Player>?>();
        public async Task<IEnumerable<Player>?> GetPlayersByFifaCode(string fifaCode)
        {
            if (!playersByFifaCode.ContainsKey(fifaCode))
            {
                Match? match = (await Task.Run(() => repository.GetMatchesByFifaCode(fifaCode)))?.ElementAt(0);
                Statistics? teamStatistics = match?.HomeTeam.FifaCode == fifaCode ? match?.HomeTeamStatistics : match?.AwayTeamStatistics;
                playersByFifaCode.Add(fifaCode, teamStatistics?.StartingEleven.Union(teamStatistics.Substitutes));
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
    }
}
