using foot2rue.WPF.Extensions;
using foot2rue.WPF.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace foot2rue.WPF.Main
{
    /// <summary>
    /// Interaction logic for StatsCardUserControl.xaml
    /// </summary>
    public partial class StatsCardUserControl : UserControl
    {
        public StatsCardUserControl(string localizationString, System.Drawing.Color selectedTeamColor, int selectedTeamValue, System.Drawing.Color opposingTeamColor, int opposingTeamValue)
            : this(localizationString, ColorUtility.ToMediaColor(selectedTeamColor), selectedTeamValue, ColorUtility.ToMediaColor(opposingTeamColor), opposingTeamValue) { }

        public StatsCardUserControl(string localizationString, Color selectedTeamColor, int selectedTeamValue, Color opposingTeamColor, int opposingTeamValue)
        {
            InitializeComponent();

            Label_StatName.SetLocalizationString(localizationString);
            SelectedTeamValue.SetLocalizationString(selectedTeamValue.ToString());
            OpposingTeamValue.SetLocalizationString(opposingTeamValue.ToString());

            #region Progress bar

            float center = selectedTeamValue * 100f / (selectedTeamValue + opposingTeamValue);

            LinearGradientBrush newBrush = new()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0),
                GradientStops = new()
                {
                    new GradientStop(selectedTeamColor, 0),
                    new GradientStop(selectedTeamColor, center / 100.0 - 0.01),
                    new GradientStop(Color.FromRgb(0, 0, 0), center / 100.0),
                    new GradientStop(opposingTeamColor, center / 100.0 + 0.01),
                    new GradientStop(opposingTeamColor, 1)
                }
            };

            ProgressBar_Stats.Background = newBrush;

            #endregion

            this.LoadLocalization();
        }
    }
}
