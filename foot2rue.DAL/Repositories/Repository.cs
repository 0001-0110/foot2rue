using foot2rue.DAL.Models;

namespace foot2rue.DAL.Repositories
{
    public enum Genre
    {
        Men,
        Women,
    }

    public abstract class Repository : IRepository
    {
        protected Genre genre;

        public Repository(Genre genre)
        {
            this.genre = genre;
        }

        public abstract Task<IEnumerable<Match>?> GetMatches();
        public abstract Task<IEnumerable<Match>?> GetMatchesByFifaCode(string fifaCode);
        public abstract Task<IEnumerable<Team>?> GetTeams();
        public abstract Task<IEnumerable<TeamResult>?> GetTeamResults();
        public abstract Task<IEnumerable<GroupResult>?> GetGroupResults();
    }
}
