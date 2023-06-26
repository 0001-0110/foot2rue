using foot2rue.DAL.Models;

namespace foot2rue.BLL.Models
{
    public class PlayerMatchResult : Player
    {
        public int Goals { get; set; }

        public int YellowCards { get; set; }

        public int RedCards { get; set; }
    }
}
