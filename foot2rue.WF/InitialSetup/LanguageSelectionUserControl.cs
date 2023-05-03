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
            // TODO Add all languages
            //comboBox1.Items.AddRange();
        }

        private void validate_Click(object sender, EventArgs e)
        {
            onValidate.Invoke();
        }
    }
}
