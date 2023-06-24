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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	}
}
