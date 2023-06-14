using foot2rue.DAL.Models;
using foot2rue.WF.Extensions;
using foot2rue.WF.HomePage.Matches;

namespace foot2rue.WF.HomePage
{
    public partial class MatchDisplayUserControl : UserControl
    {
        private TeamDisplayUserControl homeTeamDisplay;
        private TeamDisplayUserControl awayTeamDisplay;

        public MatchDisplayUserControl(Match match)
        {
            InitializeComponent();

            label_Venue.SetLocalizationString(match.Venue);
            label_Location.SetLocalizationString(match.Location);
            label_VisitorCount.SetLocalizationString($"{{VisitorCount}}: {match.Attendance}");

            homeTeamDisplay = new TeamDisplayUserControl(match.HomeTeam, match.HomeTeamStatistics, match.HomeTeam.Goals > match.AwayTeam.Goals);
            panel_HomeTeam.Controls.Add(homeTeamDisplay);
            awayTeamDisplay = new TeamDisplayUserControl(match.AwayTeam, match.AwayTeamStatistics, match.AwayTeam.Goals > match.HomeTeam.Goals);
            panel_AwayTeam.Controls.Add(awayTeamDisplay);
        }
    }
}
