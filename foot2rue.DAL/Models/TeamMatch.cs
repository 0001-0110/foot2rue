using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
	public class TeamMatch : Team
	{
		[JsonProperty("goals")]
		public int Goals { get; set; }

		[JsonProperty("penalties")]
		public int Penalties { get; set; }
	}
}
