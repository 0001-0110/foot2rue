using foot2rue.WF.Extensions;

namespace foot2rue.WF.HomePage
{
    public partial class DataDisplay : UserControl
    {
        private enum DisplayMode
        {
            Error,
            Loading,
            NoData,
            Loaded,
        }

        private Func<string, Task<IEnumerable<Control>?>> loadDataFunction;

        public DataDisplay(Func<string, Task<IEnumerable<Control>?>> loadDataFunction)
        {
            InitializeComponent();

            this.loadDataFunction = loadDataFunction;
        }

        public bool HasData()
        {
            return flowLayoutPanel_DataPanel.Controls.Count > 0;
        }

        public void Clear()
        {
            flowLayoutPanel_DataPanel.Controls.Clear();
            // Display image showing no data
            SetDisplayMode(DisplayMode.NoData);
        }

        private void SetDisplayMode(DisplayMode displayMode)
        {
            pictureBox_Error.SetVisible(displayMode == DisplayMode.Error);
            pictureBox_NoData.SetVisible(displayMode == DisplayMode.NoData);
            pictureBox_Loading.SetVisible(displayMode == DisplayMode.Loading);
            flowLayoutPanel_DataPanel.SetVisible(displayMode == DisplayMode.Loaded);
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
            SetDisplayMode(DisplayMode.Loading);

            IEnumerable<Control>? data = await loadDataFunction(fifaCode);
            if (data == null)
            {
                // Loading of the data failed, displaying the error
                SetDisplayMode(DisplayMode.Error);
                return;
            }
            if (data.Count() == 0)
            {
                // Nothing to display
                SetDisplayMode(DisplayMode.NoData);
                return;
            }

            // Show the data
            flowLayoutPanel_DataPanel.Controls.AddRange(data.ToArray());
            SetDisplayMode(DisplayMode.Loaded);
            // DEBUG
            //SetDisplayMode(DisplayMode.Loading);
        }
    }
}
