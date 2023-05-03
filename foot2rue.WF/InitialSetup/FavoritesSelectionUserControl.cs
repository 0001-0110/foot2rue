namespace foot2rue.WF.InitialSetup
{
    public partial class FavoritesSelectionUserControl : UserControl
    {
        private Action onValidation;

        public FavoritesSelectionUserControl(Action onValidation)
        {
            InitializeComponent();
            this.onValidation = onValidation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onValidation.Invoke();
        }
    }
}
