using foot2rue.BLL.Models;
using foot2rue.WF.Extensions;
using foot2rue.WF.Utilities;
using System.Linq.Expressions;

namespace foot2rue.WF.InitialSetup
{
    public partial class PlayerDisplayUserControl : UserControl
    {
        public Player Player { get; private set; }

        public PlayerDisplayUserControl(Player player)
        {
            Player = player;
            InitializeComponent();

            // Only replace the default if there is an image available
            pictureBox_PlayerPicture.Image = ResourcesUtility.GetPlayerImage(player) ?? pictureBox_PlayerPicture.Image;
            label_Name.SetLocalizationString(player.Name);
            label_ShirtNumber.SetLocalizationString($"{{Number}} {player.ShirtNumber}");
            label_Position.SetLocalizationString($"{{{player.Position}}}");

            this.LoadLocalization();
        }
    }
}
