using foot2rue.DAL.Models;
using foot2rue.DAL.Utilities;
using Newtonsoft.Json;

namespace foot2rue.DAL.Repositories
{
	public class JsonRepository : Repository
	{
		private const string APPDATAFOLDER = "foot2rue";
		private const string MENDATAFOLDER = "men";
		private const string WOMENDATAFOLDER = "women";
		private const string MATCHESFILE = "matches";
		private const string TEAMFILE = "teams";
		private const string TEAMRESULTFILE = "team_result";
		private const string GROUPRESULTFILE = "group_result";

		private static string GetFolderPath(Genre genre)
		{
			string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			return Path.Combine(appDataPath, APPDATAFOLDER, genre == Genre.Men ? MENDATAFOLDER : WOMENDATAFOLDER);
		}

		private static string GetFilePath(Genre genre, string filename)
		{
			return Path.Combine(GetFolderPath(genre), $"{filename}.json");
		}

		public static void CleanJsonFiles()
		{
			foreach (Genre genre in EnumUtility.GetEnumValues<Genre>())
				foreach (string file in new string[] { MATCHESFILE, TEAMFILE, TEAMRESULTFILE, GROUPRESULTFILE, })
					File.Delete(GetFilePath(genre, file));
		}

		public JsonRepository(Genre genre) : base(genre)
		{
			// When starting the offline mode, we first make sure that all the data has been saved locally
			foreach (Genre _genre in EnumUtility.GetEnumValues<Genre>())
			{
				ApiRepository apiRepository = new ApiRepository(_genre);
				Task.Run(() => EnsureJsonExists(MATCHESFILE, apiRepository.GetMatches));
				Task.Run(() => EnsureJsonExists(TEAMFILE, apiRepository.GetTeams));
				Task.Run(() => EnsureJsonExists(TEAMRESULTFILE, apiRepository.GetTeamResults));
				Task.Run(() => EnsureJsonExists(GROUPRESULTFILE, apiRepository.GetGroupResults));
			}
		}

		private string GetFolderPath()
		{
			return GetFolderPath(genre);
		}

		private string GetFilePath(string filename)
		{
			return Path.Combine(GetFolderPath(), $"{filename}.json");
		}

		private async Task<IEnumerable<T>?> LoadJson<T>(string filename)
		{
			string path = GetFilePath(filename);
			if (!File.Exists(path))
				return null;

			string content = await File.ReadAllTextAsync(path);
			return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
		}

		private async Task EnsureJsonExists<T>(string filename, Func<Task<IEnumerable<T>?>> loadingFunction)
		{
			string path = GetFilePath(filename);
			if (File.Exists(path))
				return;

			IEnumerable<T>? data = await loadingFunction();
			string content = JsonConvert.SerializeObject(data);
			Directory.CreateDirectory(GetFolderPath());
			await File.WriteAllTextAsync(path, content);
		}

		public override async Task<IEnumerable<Match>?> GetMatches()
		{
			return await LoadJson<Match>(MATCHESFILE);
		}

		public override async Task<IEnumerable<Match>?> GetMatchesByFifaCode(string fifaCode)
		{
			return (await LoadJson<Match>(MATCHESFILE))?.Where(match => match.HomeTeam.FifaCode == fifaCode || match.AwayTeam.FifaCode == fifaCode);
		}

		public override async Task<IEnumerable<Team>?> GetTeams()
		{
			return await LoadJson<Team>(TEAMFILE);
		}

		public override async Task<IEnumerable<TeamResult>?> GetTeamResults()
		{
			return await LoadJson<TeamResult>(TEAMRESULTFILE);
		}

		public override async Task<IEnumerable<GroupResult>?> GetGroupResults()
		{
			return await LoadJson<GroupResult>(GROUPRESULTFILE);
		}
	}
}
