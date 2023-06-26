using foot2rue.DAL.Models;
using foot2rue.WPF.Extensions;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
    /// <summary>
    /// Interaction logic for PlayerStatsUserControl.xaml
    /// </summary>
    public partial class PlayerStatsUserControl : UserControl
    {
        public PlayerStatsUserControl(Player player, bool opposingTeam = false)
        {
            InitializeComponent();

            PlayerNumber.SetLocalizationString($"{player.ShirtNumber}");
            PlayerName.SetLocalizationString(player.Name);
            PlayerPosition.SetLocalizationString($"{{{player.Position}}}");

            if (opposingTeam)
                Animation.From = -Animation.From;

            this.LoadLocalization();
        }
    }
}
