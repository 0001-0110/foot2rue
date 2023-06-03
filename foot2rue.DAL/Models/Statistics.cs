using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Statistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("attempt_on_goal")]
        public int AttemptOnGoal { get; set; }

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

        [JsonProperty("clearances")]
        public int Clearances { get; set; }

        [JsonProperty("yellow_cards")]
        public int YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public int RedCards { get; set; }

        // This needs to be nullable because of the API
        // Don't blame me, I know how stupid it looks
        [JsonProperty("fouls_committed")]
        public int? FoulsCommitted { get; set; }


        [JsonProperty("tactics")]
        public string Tactics { get; set; }

        [JsonProperty("starting_eleven")]
        public Player[] StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public Player[] Substitutes { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
