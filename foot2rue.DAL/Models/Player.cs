using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool IsCaptain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
