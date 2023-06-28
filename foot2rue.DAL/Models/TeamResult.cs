using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
	public class TeamResult : Team
	{
		[JsonProperty("wins")]
		public int Wins { get; set; }

		[JsonProperty("draws")]
		public int Draws { get; set; }

		[JsonProperty("losses")]
		public int Losses { get; set; }

		[JsonProperty("game_played")]
		public int GamePlayed { get; set; }

		[JsonProperty("points")]
		public int Points { get; set; }

		[JsonProperty("goals_for")]
		public int GoalsFor { get; set; }

		[JsonProperty("goals_against")]
		public int GoalsAgaisnt { get; set; }

		[JsonProperty("goal_differential")]
		public int GoalDifferential { get; set; }
	}
}
