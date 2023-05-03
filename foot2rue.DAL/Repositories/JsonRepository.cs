using foot2rue.DAL.Models;

namespace foot2rue.DAL.Repositories
{
    public class JsonRepository : Repository
    {
        public JsonRepository(Genre genre) : base(genre) { }

        public override Task<IEnumerable<Match>?> GetMatches()
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Match>?> GetMatchesByFifaCode(string fifaCode)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Team>?> GetTeams()
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<TeamResult>?> GetTeamResults()
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<GroupResult>?> GetGroupResults()
        {
            throw new NotImplementedException();
        }
    }
}
