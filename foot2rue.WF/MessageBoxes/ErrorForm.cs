using foot2rue.WF.Extensions;

namespace foot2rue.WF.MessageBoxes
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string localizationString)
        {
            label1.SetLocalizationString(localizationString);
            InitializeComponent();
            this.LoadLocalization();
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
