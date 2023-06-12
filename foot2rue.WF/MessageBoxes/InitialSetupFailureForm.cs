using foot2rue.WF.Extensions;

namespace foot2rue.WF.MessageBoxes
{
    public partial class InitialSetupFailureForm : Form
    {
        public InitialSetupFailureForm()
        {
            InitializeComponent();
            this.LoadLocalization();
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
