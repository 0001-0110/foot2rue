using foot2rue.BLL.Models;
using foot2rue.BLL.Services;
using foot2rue.WPF.Extensions;
using foot2rue.WPF.MessageBoxes;
using LostInLocalization;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace foot2rue.WPF.Settings
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private readonly SettingsService settingsService;
        private readonly LocalizationService localizationService;

        public SettingsWindow()
        {
            settingsService = SettingsService.Instance;
            localizationService = LocalizationService.Instance;

            InitializeComponent();

            ComboBox_LanguageSelection.LoadLanguageSelection();
            CheckBox_OfflineMode.IsChecked = settingsService.OfflineMode;
            ComboBox_ResolutionSelection.SetItems(Resolution.GetAvailableResolutions(), resolution => resolution == Application.Current.MainWindow.GetResolution());

            this.LoadLocalization();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(bool)new ConfirmationWindow("{{SaveSettingsConfirmation}}").ShowDialog()!)
                // Cancel and stay in settings
                return;

            CultureInfo? selectedCulture = ComboBox_LanguageSelection.GetSelectedItem<CultureInfo>();
            localizationService.Culture = selectedCulture;
            settingsService.Culture = selectedCulture;
            settingsService.OfflineMode = (bool)CheckBox_OfflineMode.IsChecked;
            settingsService.Resolution = ComboBox_ResolutionSelection.GetSelectedItem<Resolution>();
            settingsService.SaveSettings();
            DialogResult = true;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if ((bool)new ConfirmationWindow("{{UnsavedSettingsConfirmation}}").ShowDialog()!)
                // Ok and exit the settings
                return;

            e.Cancel = true;
        }
    }
}
