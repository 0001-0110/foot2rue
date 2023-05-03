using foot2rue.WF.Services;
using foot2rue.DAL.Repositories;
using foot2rue.WF.Extensions;
using foot2rue.DAL.Models;

namespace foot2rue.WF.InitialSetup
{
    public partial class TeamSelectionUserControl : UserControl
    {
        private Action onValidate;

        public TeamSelectionUserControl(Action onValidate)
        {
            InitializeComponent();
            this.onValidate = onValidate;
        }

        private async void TeamSelectionUserControl_Load(object sender, EventArgs e)
        {
            // TODO
            comboBox1.SetItems((await new DataService(Genre.Men).GetTeams())?.Select(team => team.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onValidate.Invoke();
        }
    }
}
