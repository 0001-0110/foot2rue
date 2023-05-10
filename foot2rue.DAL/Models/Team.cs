using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
    public class Team
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public string? AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("code")]
        public string Code { set { FifaCode = value; } }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        public override string ToString()
        {
            return $"{Country} ({FifaCode})";
        }
    }
}
