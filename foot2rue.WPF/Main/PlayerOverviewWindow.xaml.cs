using foot2rue.BLL.Models;
using foot2rue.WPF.Extensions;
using foot2rue.WPF.Utilities;
using System.Windows;

namespace foot2rue.WPF.Main
{
    /// <summary>
    /// Interaction logic for PlayerOverviewWindow.xaml
    /// </summary>
    public partial class PlayerOverviewWindow : Window
    {
        public PlayerOverviewWindow(PlayerMatchResult player)
        {
            InitializeComponent();

            Image_PlayerPicture.Source = ResourcesUtility.ConvertToWpfImage(ResourcesUtility.GetPlayerImage(player));
            Label_PlayerName.SetLocalizationString($"{player.Name} ({player.ShirtNumber})");
            Label_Position.SetLocalizationString($"{{{player.Position}}}");
            // TODO This data must be from the match only
            Label_GoalScored.SetLocalizationString($"{{GoalScored}}: {player.Goals}");
            Label_YellowCards.SetLocalizationString($"{{YellowCards}}: {player.YellowCards}");

            this.LoadLocalization();
        }
    }
}
