using foot2rue.DAL.Models;
using foot2rue.WF.Extensions;
using foot2rue.WF.Utilities;

namespace foot2rue.WF.HomePage.Matches
{
	public partial class TeamDisplayUserControl : UserControl
	{
		public TeamDisplayUserControl(TeamMatch team, Statistics statistics, bool winner)
		{
			InitializeComponent();

			pictureBox_CountryFlag.Image = ResourcesUtility.GetCountryImage(team.FifaCode);
			if (pictureBox_CountryFlag.Image is Bitmap bitmap)
				this.SetBorder(ColorUtility.GetAverageColor(bitmap));
			pictureBox_Winner.Visible = winner;
			// This line is necessary so that the winning icon does not block the flag beneath it
			pictureBox_CountryFlag.Controls.Add(pictureBox_Winner);
			label_TeamName.SetLocalizationString(team.Country);
			label_Score.SetLocalizationString($"{{Goals}}: {team.Goals}");
			label_Attempts.SetLocalizationString($"{{AttemptsOnGoal}}: {statistics.AttemptsOnGoal}");
			label_Possession.SetLocalizationString($"{{BallPossession}}: {statistics.BallPossession}");
			label_YellowCardsCount.SetLocalizationString($"{{YellowCards}}: {statistics.YellowCards}");
			label_RedCardsCount.SetLocalizationString($"{{RedCards}}: {statistics.RedCards}");

			this.LoadLocalization();
		}
	}
}
