using foot2rue.DAL.Models;
using foot2rue.WF.Extensions;

namespace foot2rue.WF.InitialSetup
{
    public partial class PlayerDisplayUserControl : UserControl
    {
        public Player Player { get; private set; }

        public PlayerDisplayUserControl(Player player)
        {
            Player = player;
            InitializeComponent();
            this.LoadLocalization();
        }
    }
}
