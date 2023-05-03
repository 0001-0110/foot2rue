using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
    public class Weather
    {
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_celsius")]
        public int TempCelsius { get; set; }

        [JsonProperty("temp_farenheit")]
        public int TempFarenheit { get; set; }

        [JsonProperty("wind_speed")]
        public int WindSpeed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
