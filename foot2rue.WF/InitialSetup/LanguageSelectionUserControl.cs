using foot2rue.BLL.Services;
using foot2rue.WF.Extensions;
using LostInLocalization;
using System.Globalization;

namespace foot2rue.WF.InitialSetup
{
    public partial class LanguageSelectionUserControl : UserControl
    {
        private readonly SettingsService settingsService;
        private readonly LocalizationService localizationService;

        private readonly Action onValidate;

        public LanguageSelectionUserControl(Action onValidate)
        {
            settingsService = SettingsService.Instance;
            localizationService = LocalizationService.Instance;
            this.onValidate += onValidate;
            InitializeComponent();
            this.LoadLocalization();
        }

        private void LanguageSelectionUserControl_Load(object sender, EventArgs e)
        {
            comboBox1.LoadLanguageSelection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo selectedCulture = comboBox1.GetSelectedItem<CultureInfo>();

            // Same language selected, no need to do anything
            if (localizationService.IsCurrentCulture(selectedCulture))
                return;

            localizationService.Culture = selectedCulture;
            ParentForm.LoadLocalization(selectedCulture);
        }

        private void validate_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                // Show invalid input
                return;
            }

            settingsService.Culture = comboBox1.GetSelectedItem<CultureInfo>();
            settingsService.SaveSettings();
            onValidate.Invoke();
        }
    }
}
