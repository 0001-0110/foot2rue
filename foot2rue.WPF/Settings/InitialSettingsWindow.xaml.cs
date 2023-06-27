using foot2rue.BLL.Models;
using foot2rue.BLL.Services;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.DAL.Utilities;
using foot2rue.WPF.Extensions;
using LostInLocalization;
using System.Globalization;
using System.Windows;

namespace foot2rue.WPF.Settings
{
    public partial class InitialSettingsWindow : Window
	{
        private readonly SettingsService settingsService;
        private readonly LocalizationService localizationService;

        public InitialSettingsWindow()
		{
            settingsService = SettingsService.Instance;
            localizationService = LocalizationService.Instance;

            InitializeComponent();

            ComboBox_LanguageSelection.LoadLanguageSelection(null);
            ComboBox_ResolutionSelection.SetItems(Resolution.GetAvailableResolutions());
            ComboBox_GenreSelection.SetItems(EnumUtility.GetEnumValues<Genre>());

            this.LoadLocalization();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Label_LanguageSelection.Visibility = Visibility.Visible;
            ComboBox_LanguageSelection.Visibility = Visibility.Visible;
        }

        private void ComboBox_LanguageSelection_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Label_ResolutionSelection.Visibility = Visibility.Visible;
            ComboBox_ResolutionSelection.Visibility = Visibility.Visible;
        }

        private void ComboBox_ResolutionSelection_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Label_GenreSelection.Visibility = Visibility.Visible;
            ComboBox_GenreSelection.Visibility = Visibility.Visible;
        }

        private async void ComboBox_GenreSelection_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox_TeamSelection.SetItems(await this.Wait(() 
                => new DataService(ComboBox_GenreSelection.GetSelectedItem<Genre>()).GetTeams()));
            Label_TeamSelection.Visibility = Visibility.Visible;
            ComboBox_TeamSelection.Visibility = Visibility.Visible;
        }

        private void ComboBox_TeamSelection_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ButtonSave.IsEnabled = true;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo? selectedCulture = ComboBox_LanguageSelection.GetSelectedItem<CultureInfo>();
            localizationService.Culture = selectedCulture;
            settingsService.Culture = selectedCulture;
            settingsService.Resolution = ComboBox_ResolutionSelection.GetSelectedItem<Resolution>();
            settingsService.SelectedGenre = ComboBox_GenreSelection.GetSelectedItem<Genre>();
            settingsService.SelectedTeamFifaCode = ComboBox_TeamSelection.GetSelectedItem<Team>()?.FifaCode;
            settingsService.SaveSettings();
            DialogResult = true;
        }
    }
}
