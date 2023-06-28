using foot2rue.DAL.Models;
using System.Windows;

namespace foot2rue.WPF.Main
{
    /// <summary>
    /// Interaction logic for TeamStatsUserWindow.xaml
    /// </summary>
    public partial class TeamStatsWindow : Window
    {
        public TeamStatsWindow(TeamResult? teamResult)
        {
            InitializeComponent();
            SetTeam(teamResult);
        }

        public void SetTeam(TeamResult? teamResult)
        {
            TeamStats.SetTeam(teamResult);
        }
    }
}
