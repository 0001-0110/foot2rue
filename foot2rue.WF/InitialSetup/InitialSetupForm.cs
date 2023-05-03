using foot2rue.WF.InitialSetup;

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
                Controls.Remove(control);

            control = newControl;
            Controls.Add(control);
            control.Show();
        }

        private void InitialSetupForm_Load(object sender, EventArgs e)
        {
            SetControl(
                new LanguageSelectionUserControl(OnLanguageValidation)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left,
                    Dock = DockStyle.Fill,
                    Parent = panel1,
                });
        }

        private void OnLanguageValidation()
        {
            SetControl(
                new TeamSelectionUserControl(OnTeamValidation)
                {
                    Dock = DockStyle.Fill,
                    Parent = panel1,
                });
        }

        private void OnTeamValidation()
        {
            SetControl(
                new FavoritesSelectionUserControl(OnFavoritesValidation)
                {
                    Dock = DockStyle.Fill,
                    Parent = panel1,
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
