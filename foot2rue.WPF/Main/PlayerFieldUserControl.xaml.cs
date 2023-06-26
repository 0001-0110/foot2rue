using foot2rue.BLL.Services;
using foot2rue.DAL.Models;
using foot2rue.WPF.Extensions;
using foot2rue.WPF.Utilities;
using System.Windows.Controls;
using System.Windows.Input;

namespace foot2rue.WPF.Main
{
    /// <summary>
    /// Interaction logic for PlayerFieldUserControl.xaml
    /// </summary>
    public partial class PlayerFieldUserControl : UserControl
    {
        private readonly DataService dataService;
        private readonly Match match;
        private readonly int teamIndex;
        private readonly Player player;

        public PlayerFieldUserControl(DataService dataService, Match match, int teamIndex, Player player)
        {
            this.dataService = dataService;
            this.match = match;
            this.teamIndex = teamIndex;
            this.player = player;
            InitializeComponent();

            Image_Player.Source = ResourcesUtility.ConvertToWpfImage(ResourcesUtility.GetPlayerImage(player));
            Label_PlayerName.SetLocalizationString($"{player.Name} ({player.ShirtNumber})");

            this.LoadLocalization();
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new PlayerOverviewWindow(dataService.GetPlayerMatchResults(match, teamIndex, player)).ShowDialog();
        }
    }
}
