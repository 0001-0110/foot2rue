using foot2rue.WF.Extensions;

namespace foot2rue.WF.MessageBoxes
{
    public partial class ExitConfirmationForm : Form
    {
        public ExitConfirmationForm()
        {
            InitializeComponent();
            this.LoadLocalization();
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
