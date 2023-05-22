using foot2rue.WF.Utilities;
using foot2rue.WF.Extensions;
using System.Globalization;
using foot2rue.WF.Services;

namespace foot2rue.WF.InitialSetup
{
    public partial class LanguageSelectionUserControl : UserControl
    {
        private LocalizationService localizationService;

        private Action onValidate;

        public LanguageSelectionUserControl(Action onValidate)
        {
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
            CultureInfo selectedCulture = (CultureInfo)comboBox1.SelectedItem;

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

            SettingsService.Culture = (CultureInfo)comboBox1.SelectedItem;
            SettingsService.Save();
            onValidate.Invoke();
        }
    }
}
