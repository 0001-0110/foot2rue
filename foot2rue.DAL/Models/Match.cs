using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Match
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("fifa_id")]
        public int FifaId { get; set; }

        [JsonProperty("weather")]
        public Weather Weather { get; set; }

        [JsonProperty("attendance")]
        public int Attendance { get; set; }

        [JsonProperty("officials")]
        public string[] Officials { get; set; }

        [JsonProperty("stage_name")]
        public string StageName { get; set; }

        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("home_team")]
        public TeamMatch HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public TeamMatch AwayTeam { get; set; }

        [JsonProperty("home_team_events")]
        public Event[] HomeTeamEvents { get; set; }

        [JsonProperty("away_team_events")]
        public Event[] AwayTeamEvents { get; set; }

        [JsonProperty("home_team_statistics")]
        public Statistics HomeTeamStatistics { get; set; }

        [JsonProperty("away_team_statistics")]
        public Statistics AwayTeamStatistics { get; set; }

        [JsonProperty("last_event_update")]
        public DateTime LastEventUpdate { get; set; }

        [JsonProperty("last_score_update")]
        public DateTime? LastScoreUpdate { get; set;}
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
