using foot2rue.DAL.Models;

namespace foot2rue.DAL.Repositories
{
    public interface IRepository
    {
        public abstract Task<IEnumerable<Match>?> GetMatches();
        public abstract Task<IEnumerable<Match>?> GetMatchesByFifaCode(string fifaCode);
        public abstract Task<IEnumerable<Team>?> GetTeams();
        public abstract Task<IEnumerable<TeamResult>?> GetTeamResults();
        public abstract Task<IEnumerable<GroupResult>?> GetGroupResults();
    }
}
