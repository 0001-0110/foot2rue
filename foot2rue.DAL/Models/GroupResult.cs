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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public TeamResult[] OrderedTeams { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		#region Acorn

		// Yahaha, you found me!

		#endregion
	}
}
