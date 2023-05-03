using foot2rue.WF.Utilities;
using foot2rue.WF.Extensions;
using System.Globalization;

namespace foot2rue.WF.InitialSetup
{
    public partial class LanguageSelectionUserControl : UserControl
    {
        private Action onValidate;

        public LanguageSelectionUserControl(Action onValidate)
        {
            InitializeComponent();
            this.onValidate += onValidate;
        }

        private void LanguageSelectionUserControl_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "DisplayName";
            CultureInfo systemCulture = CultureInfo.CurrentCulture;
            List<CultureInfo> supportedLanguages = LocalizationUtility.GetAllSupportedLanguages().ToList();
            // If the systemCulture is not part of the supported culture, the comboBox will stay empty
            comboBox1.SetItems(supportedLanguages, systemCulture);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo selectedCulture = (CultureInfo)comboBox1.SelectedItem;
            LocalizationUtility.SetCulture(selectedCulture);
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
