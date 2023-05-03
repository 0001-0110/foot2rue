using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
    // UNUSED FOR NOW
    public enum EventType
    {
        Goal,
        GoalPenalty,
        YellowCard,
        RedCard,
        SubstitutionIn,
        SubstitutionOut,
    }

    public class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
