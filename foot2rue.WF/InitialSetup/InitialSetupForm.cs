using foot2rue.WF.InitialSetup;
using foot2rue.WF.Extensions;

namespace foot2rue.WF
{
    public partial class InitialSetupForm : Form
    {
        private Control? control;

        public InitialSetupForm()
        {
            InitializeComponent();
        }

        private void SetControl(Control newControl)
        {
            if (control != null)
                panel1.Controls.Remove(control);

            control = newControl;
            control.SetParent(panel1);
            control.Show();
        }

        private void InitialSetupForm_Load(object sender, EventArgs e)
        {
            SetControl(
                new LanguageSelectionUserControl(OnLanguageValidation)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left,
                    Dock = DockStyle.Fill,
                });
        }

        private void OnLanguageValidation()
        {
            SetControl(
                new TeamSelectionUserControl(OnTeamValidation)
                {
                    Dock = DockStyle.Fill,
                });
        }

        private void OnTeamValidation()
        {
            SetControl(
                new FavoritesSelectionUserControl(OnFavoritesValidation)
                {
                    Dock = DockStyle.Fill,
                });
        }

        private void OnFavoritesValidation()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
