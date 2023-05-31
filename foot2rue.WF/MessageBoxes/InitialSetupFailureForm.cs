using foot2rue.WF.Extensions;
using LostInLocalization.Extensions;

namespace foot2rue.WF.MessageBoxes
{
    public partial class InitialSetupFailureForm : Form
    {
        public InitialSetupFailureForm()
        {
            InitializeComponent();
            this.LoadLocalization();
        }
    }
}
