using Newtonsoft.Json;

namespace foot2rue.DAL.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
