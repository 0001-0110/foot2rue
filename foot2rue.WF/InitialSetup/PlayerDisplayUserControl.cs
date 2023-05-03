using foot2rue.DAL.Models;

namespace foot2rue.WF.InitialSetup
{
    public partial class PlayerDisplayUserControl : UserControl
    {
        public Player Player { get; private set; }

        public PlayerDisplayUserControl(Player player)
        {
            InitializeComponent();
            Player = player;
        }
    }
}
