using foot2rue.DAL.Models;
using Newtonsoft.Json;

namespace foot2rue.DAL.Repositories
{
	public class ApiRepository : Repository
	{
		public ApiRepository(Genre genre) : base(genre) { }

		protected string Url(params string[] path)
		{
			return string.Join('/', "https://worldcup-vua.nullbit.hr", genre == Genre.Men ? "men" : "women", string.Join('/', path));
		}

		protected virtual async Task<IEnumerable<T>?> GetRequest<T>(string url)
		{
			// Kinda ugly, but it'll do
			try
			{
				using (HttpClient client = new HttpClient())
				using (HttpResponseMessage response = await client.GetAsync(url))
				using (HttpContent content = response.Content)
					return JsonConvert.DeserializeObject<IEnumerable<T>>(await content.ReadAsStringAsync());
			}
			catch (Exception)
			{
				return null;
			}
		}

		public override async Task<IEnumerable<Match>?> GetMatches()
		{
			return await GetRequest<Match>(Url("matches"));
		}

		public override async Task<IEnumerable<Match>?> GetMatchesByFifaCode(string fifaCode)
		{
			return await GetRequest<Match>(Url("matches", $"country?fifa_code={fifaCode}")); ;
		}

		public override async Task<IEnumerable<Team>?> GetTeams()
		{
			return await GetRequest<Team>(Url("teams"));
		}

		public override async Task<IEnumerable<TeamResult>?> GetTeamResults()
		{
			return await GetRequest<TeamResult>(Url("teams", "results"));
		}

		public override async Task<IEnumerable<GroupResult>?> GetGroupResults()
		{
			return await GetRequest<GroupResult>(Url("teams", "group_results"));
		}
	}
}
