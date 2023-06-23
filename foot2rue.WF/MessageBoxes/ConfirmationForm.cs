using foot2rue.WF.Extensions;

namespace foot2rue.WF.MessageBoxes
{
    public partial class ConfirmationForm : Form
    {
        public ConfirmationForm(string localizationString)
        {
            label1.SetLocalizationString(localizationString);
            InitializeComponent();
            this.LoadLocalization();

			#region Tree stump

			// Yahaha, you found me!

			#endregion
		}

		private void button_Confirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
