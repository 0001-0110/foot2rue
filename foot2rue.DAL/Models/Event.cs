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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type_of_event")]
        public string Type { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
