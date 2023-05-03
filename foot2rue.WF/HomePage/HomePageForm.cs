using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.WF.Services;
using foot2rue.WF.Extensions;
using System.Data;
using foot2rue.WF.MessageBoxes;

namespace foot2rue.WF.HomePage
{
    public partial class HomePageForm : Form
    {
        private SettingsService settingsService => SettingsService.Instance;
        private DataService dataService;

        private DataDisplay? favoritesDataDisplay;
        private DataDisplay? allPlayersDataDisplay;

        // TODO Handle warning
        public HomePageForm()
        {
            InitializeComponent();
        }

        #region Form event handlers

        private async void HomePageForm_Shown(object? sender, EventArgs e)
        {
            // TODO
            // If there already is a settings file, we can skip the initial setup
            if (!File.Exists(""))
                InitialSetup();

            // Get the genre from the settings
            // The genre is either loaded from the config file by the SettingsService
            // or in case of the first use, has been selected during the initial setup
            dataService = new DataService(settingsService.SelectedGenre);

            // We need to run this on the main thread (so don't use Task.Run)
            await InitSelectionComboBoxes();
            await InitDataDisplays();

            // TODO Load and display data (no idea if this works)
            // TODO This should only be loaded when the datagrids are shown
        }

        private void HomePageForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // If the user is the one trying to close the app, ask for confirmation
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (new ExitConfirmationForm().ShowDialog() == DialogResult.Cancel)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    return;
                }
            }

            // Before exiting, we save his settings
            settingsService.Save();
            // Then the form is closed
        }

        #endregion

        #region ToolStripComboBox event handlers

        private void toolStripComboBox_GenreSelection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // TODO Check if value changed
            if (false)
                return;

            Genre selectedGenre = (Genre)toolStripComboBox_GenreSelection.SelectedItem;
            dataService?.SetGenre(selectedGenre);
            settingsService.SelectedGenre = selectedGenre;
            ResetDataDisplays();
        }

        private void toolStripComboBox_TeamSelection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // TODO Check if value changed
            if (false)
                return;

            Team selectedTeam = (Team)toolStripComboBox_TeamSelection.SelectedItem;
            settingsService.SelectedTeamFifaCode = selectedTeam.FifaCode;
            ResetDataDisplays();
        }

        #endregion

        #region TabControl event handlers

        private async void tabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // TODO
            // Find the data grid view
            // There should be only one, if there is none or more, throw
            DataDisplay? dataDisplay = (sender as TabControl)?.SelectedTab.Controls.OfType<DataDisplay>().Single();
            if (dataDisplay == null)
                // TODO
                throw new Exception("HELP");

            
        }

        #endregion

        #region Initialisation

        private void InitialSetup()
        {
            Form initialSetupForm = new InitialSetupForm();
            // We need to use ShowDialog to make sure that the initial setup is done before the user can interact with this form
            DialogResult dialogResult = initialSetupForm.ShowDialog();
            // We then check if the setup was succesful
            // Could have failed if the user forcefully close the form for example
            if (dialogResult != DialogResult.OK)
            {
                // TODO Replace by form
                MessageBox.Show("Failed to setup the app, now closing");
                // Force quit
                Application.Exit();
            }
        }

        private async Task InitSelectionComboBoxes()
        {
            toolStripComboBox_GenreSelection.SetItems(Enum.GetValues(typeof(Genre)).Cast<Genre>());
            // TODO Find the correct value to select according to the current selection
            toolStripComboBox_GenreSelection.SelectedIndex = 0;

            await this.Wait(async () => toolStripComboBox_TeamSelection.SetItems(await dataService!.GetTeams()));
            // TODO Find the correct value to select according to the current selection
            toolStripComboBox_TeamSelection.SelectedIndex = 0;
        }

        private async Task InitDataDisplays()
        {
            favoritesDataDisplay = new DataDisplay(async () => (await dataService.GetPlayersByFifaCode(GetSelectedTeam().FifaCode))?.Where(player => player.IsFavorite).Select(player => new PlayerDisplayUserControl(player)));
            allPlayersDataDisplay = new DataDisplay(async () => (await dataService.GetPlayersByFifaCode(GetSelectedTeam().FifaCode))?.Select(player => new PlayerDisplayUserControl(player)));
        }

        #endregion

        private Team GetSelectedTeam()
        {
            // TODO handle warning
            return toolStripComboBox_TeamSelection.SelectedItem as Team;
        }

        #region Data displays

        private void ResetDataDisplays()
        {
            favoritesDataDisplay?.Clear();
            allPlayersDataDisplay?.Clear();
            // TODO Add all data displays to clear here
        }

        private async Task RefreshDataGridView(DataDisplay dataDisplay)
        {
            ResetDataDisplays();
            DataDisplay activeDataDisplay = tabControl1.SelectedTab.Controls.OfType<DataDisplay>().Single();
            // Refresh the data of the current data display right now
            // Other data displays will be refreshed by themselves when shown again
            await activeDataDisplay.LoadData();
        }

        #endregion
    }
}
