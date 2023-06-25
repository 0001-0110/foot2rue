using Newtonsoft.Json;
using System.ComponentModel;

namespace foot2rue.DAL.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public class Statistics
	{
		[JsonProperty("country")]
		public string Country { get; set; }

        [JsonProperty("attempt_on_goal")]
		public int AttemptsOnGoal { get; set; }

		[JsonProperty("on_target")]
		public int OnTarget { get; set; }

		[JsonProperty("off_target")]
		public int OffTarget { get; set; }

		[JsonProperty("blocked")]
		public int Blocked { get; set; }

		[JsonProperty("woodwork")]
		public int Woodwork { get; set; }

		[JsonProperty("corners")]
		public int Corners { get; set; }

		[JsonProperty("offsides")]
		public int Offsides { get; set; }

		[JsonProperty("ball_possession")]
		public int BallPossession { get; set; }

		[JsonProperty("pass_accuracy")]
		public int PassAccuracy { get; set; }

		[JsonProperty("num_passes")]
		public int NumPasses { get; set; }

		[JsonProperty("passes_complete")]
		public int PassesComplete { get; set; }

		[JsonProperty("distance_covered")]
		public int DistanceCovered { get; set; }

		[JsonProperty("balls_recovered")]
		public int BallsRecovered { get; set; }

		[JsonProperty("tackles")]
		public int Tackles { get; set; }

		// These needs to be nullable because of the API
		// Don't blame me, I know how stupid it looks
		[JsonProperty("clearances")]
		private int? clearances;
		public int Clearances { get { return clearances ?? 0; } set { clearances = value; } }

		[JsonProperty("yellow_cards")]
		private int? yellowCards;
		public int YellowCards { get { return yellowCards ?? 0; } set { yellowCards = value; } }

		[JsonProperty("red_cards")]
		private int? redCards;
		public int RedCards { get { return redCards ?? 0; } set { redCards = value; } }

		[JsonProperty("fouls_committed")]
		private int? foulsCommited;
		public int FoulsCommitted { get { return foulsCommited ?? 0; } set { foulsCommited = value; } }


		[JsonProperty("tactics")]
		public string Tactics { get; set; }

		[JsonProperty("starting_eleven")]
		public Player[] StartingEleven { get; set; }

		[JsonProperty("substitutes")]
		public Player[] Substitutes { get; set; }
	}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
