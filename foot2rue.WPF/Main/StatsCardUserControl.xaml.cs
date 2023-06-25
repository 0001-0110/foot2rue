using foot2rue.WPF.Extensions;
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
        public StatsCardUserControl(string localizationString, Color selectedTeamColor, int selectedTeamValue, Color opposingTeamColor, int opposingTeamValue)
        {
            InitializeComponent();

            Label_StatName.SetLocalizationString(localizationString);
            SelectedTeamValue.SetLocalizationString(selectedTeamValue.ToString());
            OpposingTeamValue.SetLocalizationString(opposingTeamValue.ToString());

            #region Progress bar

            float center = selectedTeamValue * 100f / (selectedTeamValue + opposingTeamValue);

            LinearGradientBrush newBrush = new LinearGradientBrush();
            newBrush.StartPoint = new Point(0, 0);
            newBrush.EndPoint = new Point(1, 0);

            // Create the gradient stops
            GradientStopCollection stops = new GradientStopCollection
            {
                new GradientStop(selectedTeamColor, 0),
                new GradientStop(selectedTeamColor, center / 100.0),
                new GradientStop(opposingTeamColor, center / 100.0),
                new GradientStop(opposingTeamColor, 1)
            };

            // Assign the gradient stops to the brush
            newBrush.GradientStops = stops;

            // Assign the new brush to the ProgressBar's Background property
            ProgressBar_Stats.Background = newBrush;
            ProgressBar_Stats.Background = new LinearGradientBrush(stops, 0);

            #endregion

            this.LoadLocalization();
        }
    }
}
