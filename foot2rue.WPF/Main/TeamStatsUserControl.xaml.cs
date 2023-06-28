using foot2rue.DAL.Models;
using foot2rue.WPF.Extensions;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
	/// <summary>
	/// Interaction logic for TeamStatsUserControl.xaml
	/// </summary>
	public partial class TeamStatsUserControl : UserControl
    {
        public TeamStatsUserControl() : this(null) { }

        public TeamStatsUserControl(TeamResult? teamResult)
        {
            InitializeComponent();
            SetTeam(teamResult);
            this.LoadLocalization();
        }

        public void SetTeam(TeamResult? teamResult)
        {
            // When loading the new team, refresh everything that needs to be updated
            TextBlock_Name.SetLocalizationString($"{teamResult?.Country} ({teamResult?.FifaCode})", true);

            TextBlock_Wins.SetLocalizationString($"{{Wins}}: {teamResult?.Wins}", true);
            TextBlock_Losses.SetLocalizationString($"{{Losses}}: {teamResult?.Losses}", true);
            TextBlock_Draws.SetLocalizationString($"{{Draws}}: {teamResult?.Draws}", true);

            TextBlock_GoalsScored.SetLocalizationString($"{{GoalsFor}}: {teamResult?.GoalsFor}", true);
            TextBlock_GoalsConceded.SetLocalizationString($"{{GoalsAgaisnt}}: {teamResult?.GoalsAgaisnt}", true);
            TextBlock_GoalDifference.SetLocalizationString($"{{GoalDifferential}}: {teamResult?.GoalDifferential}", true);
        }
    }
}
