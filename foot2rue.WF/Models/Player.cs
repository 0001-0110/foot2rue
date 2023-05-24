namespace foot2rue.WF.Models
{
    public class Player : DAL.Models.Player
    {
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int MatchesPalyed { get; set; }
        public bool IsFavorite { get; set; }
        public Image? Image { get; set; }
    }
}
