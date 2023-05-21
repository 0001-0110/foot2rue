using foot2rue.WF.Extensions;
using foot2rue.WF.Services;
using System.Globalization;

namespace foot2rue.WF.Settings
{
    [Flags]
    public enum SettingsDialogResult
    {
        // The values of this enum must be power of two
        // so that they can be used as flags (multiple can be used at the same time)
        None = 0,
        Cancel = 1 << 0,
        LanguageChanged = 1 << 1,
        OfflineModeChanged = 1 << 2,
    }

    public partial class SettingsForm : Form
    {
        private LocalizationService localizationService;

        private SettingsDialogResult settingsDialogResult;
        public SettingsDialogResult SettingsDialogResult
        {
            get { return settingsDialogResult; }
            private set { settingsDialogResult = value; DialogResult = DialogResult.OK; }
        }

        private bool languageChanged;
        private bool offlineModeChanged;

        public SettingsForm()
        {
            localizationService = LocalizationService.Instance;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            comboBox_LanguageSelection.LoadLanguageSelection();
            checkBox_OfflineModeSelection.Checked = SettingsService.OfflineMode;
            // This needs to be set after loading the languages because otherwise index changed sets it back to true everytime
            languageChanged = false;
            offlineModeChanged = false;
        }

        private void comboBox_LanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            languageChanged = true;
            this.LoadLocalization((CultureInfo)comboBox_LanguageSelection.SelectedItem);
        }

        private void checkBox_OfflineModeSelection_CheckedChanged(object sender, EventArgs e)
        {
            offlineModeChanged = true;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            // TOCHECK Using a variable is necessary since setting the SettingsDialogResult would close the form
            SettingsDialogResult settingsDialogResult = SettingsDialogResult.None;
            if (languageChanged)
            {
                CultureInfo culture = (CultureInfo)comboBox_LanguageSelection.SelectedItem;
                SettingsService.Culture = culture;
                localizationService.Culture = culture;
                settingsDialogResult |= SettingsDialogResult.LanguageChanged;
            }
            if (offlineModeChanged)
            {
                SettingsService.OfflineMode = checkBox_OfflineModeSelection.Checked;
                settingsDialogResult |= SettingsDialogResult.OfflineModeChanged;
            }
            SettingsService.Save();
            SettingsDialogResult = settingsDialogResult;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            SettingsDialogResult = SettingsDialogResult.Cancel;
        }
    }
}
