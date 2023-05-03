using foot2rue.WF.Extensions;

namespace foot2rue.WF.HomePage
{
    public partial class DataDisplay : UserControl
    {
        private Func<string, Task<IEnumerable<Control>?>> loadDataFunction;

        public DataDisplay(Func<string, Task<IEnumerable<Control>?>> loadDataFunction)
        {
            InitializeComponent();

            this.loadDataFunction = loadDataFunction;
        }

        public bool HasData()
        {
            return dataGridView.Rows.Count > 0;
        }

        public void Clear()
        {
            dataGridView.Clear();
            // TODO Display image showing no data
            pictureBox_NoData.Show();
        }

        public async Task RefreshData(string fifaCode)
        {
            // This dataGridView is already filled, no need to do anything
            if (HasData())
                return;

            // The data hasn't been loaded yet, load it
            await LoadData(fifaCode);
        }

        public async Task LoadData(string fifaCode)
        {
            // Show loading screen
            pictureBox_NoData.Hide();
            pictureBox_Loading.Show();

            IEnumerable<Control>? data = await loadDataFunction(fifaCode);
            pictureBox_Loading.Hide();
            if (data == null)
                // Loading of the data failed, displaying the error
                pictureBox_NoData.Show();

            // Show the data
            foreach (Control control in data)
                // TODO
                throw new NotImplementedException();
        }
    }
}
