using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.WF.Extensions;
using foot2rue.WF.MessageBoxes;
using foot2rue.WF.Services;
using foot2rue.WF.Settings;
using foot2rue.WF.Utilities;
using System.Data;

namespace foot2rue.WF.HomePage
{
    public partial class HomePageForm : Form
    {
        private DataService? dataService;

        private DataDisplay? favoritesDataDisplay;
        private DataDisplay? allPlayersDataDisplay;

        public HomePageForm()
        {
            InitializeComponent();
        }

        #region Form event handlers

        private async void HomePageForm_Shown(object? sender, EventArgs e)
        {
            // If there already is a settings file, we can skip the initial setup
            if (SettingsService.FirstLaunch)
                InitialSetup();

            // Get the genre from the settings
            // The genre is either loaded from the config file by the SettingsService
            // or in case of the first use, has been selected during the initial setup
            dataService = new DataService();

            // We need to run this on the main thread (so don't use Task.Run)
            await InitSelectionComboBoxes();
            InitDataDisplays();
            await RefreshDataDisplays();

            // No need to load the data for dataDisplays since this is handled by the tabControl
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
            SettingsService.Save();
            // Then the form is closed
        }

        #endregion

        #region ToolStripComboBox event handlers

        private async void toolStripComboBox_GenreSelection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Genre selectedGenre = (Genre)toolStripComboBox_GenreSelection.SelectedItem;

            // If the value is the same than the previous one, no need to reload everything
            if (selectedGenre == SettingsService.SelectedGenre)
                return;

            dataService?.SetGenre(selectedGenre);
            SettingsService.SelectedGenre = selectedGenre;
            // This line is refreshing genre comboBox for nothing, but it's not a big deal
            await InitSelectionComboBoxes();
            await RefreshDataDisplays();
        }

        private async void toolStripComboBox_TeamSelection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Team selectedTeam = (Team)toolStripComboBox_TeamSelection.SelectedItem;

            // If the value is the same than the previous one, no need to reload everything
            if (selectedTeam.FifaCode == SettingsService.SelectedTeamFifaCode)
                return;

            SettingsService.SelectedTeamFifaCode = selectedTeam.FifaCode;
            await RefreshDataDisplays();
        }

        #endregion

        #region TabControl event handlers

        private void tabControl1_SelectedIndexChanged(object? sender, EventArgs e)
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
                // TODO Do this form
                new InitialSetupFailureForm().ShowDialog();
                // Force quit
                Application.Exit();
            }
            SettingsService.FirstLaunch = false;
            SettingsService.Save();
        }

        private async Task InitSelectionComboBoxes()
        {
            toolStripComboBox_GenreSelection.SetItems(EnumUtility.GetEnumValues<Genre>(), SettingsService.SelectedGenre);

            IEnumerable<Team>? teams = await this.Wait(dataService!.GetTeams);
            // When swithcing genre, this line might output a null
            Team? selectedTeam = teams?.SingleOrDefault(team => team.FifaCode == SettingsService.SelectedTeamFifaCode);
            // If that is the case, the comboBox removes its current selection
            toolStripComboBox_TeamSelection.SetItems(teams, selectedTeam);
        }

        private void InitDataDisplays()
        {
            // This is hard to watch
            favoritesDataDisplay = new DataDisplay(
                async (string fifaCode) => (await dataService!.GetPlayersByFifaCode(fifaCode))?
                .Where(player => SettingsService.FavoritePlayers.Contains(player.Name))
                .Select(player => new PlayerDisplayUserControl(player)))
            {
                Parent = tabControl1.TabPages[0],
                Dock = DockStyle.Fill,
            };
            allPlayersDataDisplay = new DataDisplay(
                async (string fifaCode) => (await dataService!.GetPlayersByFifaCode(fifaCode))?
                .Select(player => new PlayerDisplayUserControl(player)))
            {
                Parent = tabControl1.TabPages[1],
                Dock = DockStyle.Fill,
            };
        }

        #endregion

        private Team? GetSelectedTeam()
        {
            return toolStripComboBox_TeamSelection.SelectedItem as Team;
        }

        #region Data displays

        private void ResetDataDisplays()
        {
            favoritesDataDisplay?.Clear();
            allPlayersDataDisplay?.Clear();
            // TODO Add all data displays to clear here
        }

        private async Task RefreshDataDisplays()
        {
            ResetDataDisplays();

            // If there is no team currently selected, don't load anything
            Team? selectedTeam = GetSelectedTeam();
            if (selectedTeam == null)
                return;

            DataDisplay activeDataDisplay = tabControl1.SelectedTab.Controls.OfType<DataDisplay>().Single();
            // Refresh the data of the current data display right now
            // Other data displays will be refreshed by themselves when shown again
            await this.Wait(async () => await activeDataDisplay.LoadData(selectedTeam.FifaCode));
        }

        #endregion

        private void toolStripButton_Settings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.Cancel))
                return;
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.LanguageChanged))
                this.LoadLocalization();
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.OfflineModeChanged))
                dataService!.SetOfflineMode(SettingsService.OfflineMode);
        }
    }
}
