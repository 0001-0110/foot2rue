using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
    public class GroupResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("letter")]
        public char Letter { get; set; }

        [JsonProperty("ordered_teams")]
        public TeamResult[] OrderedTeams { get; set; }

		#region Acorn

		// Yahaha, you found me!

		#endregion
	}
}
