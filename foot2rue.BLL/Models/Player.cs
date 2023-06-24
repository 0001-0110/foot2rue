namespace foot2rue.BLL.Models
{
	public class Player : DAL.Models.Player
	{
		public int Goals { get; set; }
		public int YellowCards { get; set; }
		public int RedCards { get; set; }
		public int MatchPlayed { get; set; }
		public bool IsFavorite { get; set; }

		[Obsolete]
		public Image? Image { get; set; }
	}
}
