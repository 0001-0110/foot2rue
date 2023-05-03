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
            CultureInfo? currentCulture = SettingsService.Instance.Culture;
            List<CultureInfo> supportedLanguages = LocalizationUtility.GetAllSupportedLanguages().ToList();
            comboBox1.SetItems(supportedLanguages, supportedLanguages.IndexOf(currentCulture));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo selectedCulture = (CultureInfo)comboBox1.SelectedItem;
            LocalizationUtility.SetCulture(selectedCulture);
        }

        private void validate_Click(object sender, EventArgs e)
        {
            SettingsService.Instance.Culture = (CultureInfo)comboBox1.SelectedItem;
            // TODO Should we save ?
            onValidate.Invoke();
        }
    }
}
