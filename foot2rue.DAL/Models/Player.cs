using Newtonsoft.Json;
using System.ComponentModel;

namespace foot2rue.DAL.Models
{
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

        // TODO how to handle this thing ?
        // This attributes is not part of the API
        [DefaultValue(false)]
        public bool IsFavorite { get; set; }
    }
}
