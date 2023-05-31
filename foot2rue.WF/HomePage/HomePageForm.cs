using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.WF.Extensions;
using foot2rue.WF.MessageBoxes;
using foot2rue.WF.Services;
using foot2rue.WF.Settings;
using foot2rue.WF.Utilities;
using LostInLocalization.Extensions;
using System.Data;

namespace foot2rue.WF.HomePage
{
    public partial class HomePageForm : Form
    {
        private static readonly Color BACKCOLOR = ColorUtility.FromHex("#333333");
        private static readonly Color FONTCOLOR = Color.White;

        // This class defines the color for the tool strip
        private class CustomProfessionalColors : ProfessionalColorTable
        {
            public override Color ToolStripGradientBegin
            { get { return BACKCOLOR; } }

            public override Color ToolStripGradientEnd
            { get { return BACKCOLOR; } }
        }

        //private static LocalizationService localizationService = LocalizationService.Instance;
        private DataService? dataService;

        private DataDisplay? favoritesDataDisplay;
        private DataDisplay? allPlayersDataDisplay;

        public HomePageForm()
        {
            InitializeComponent();
            // Set the tool strip color
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());
            this.LoadLocalization();
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
            Genre selectedGenre = toolStripComboBox_GenreSelection.GetSelectedItem<Genre>();

            // If the value is the same than the previous one, no need to reload everything
            if (selectedGenre == SettingsService.SelectedGenre)
                return;

            dataService?.SetGenre(selectedGenre);
            SettingsService.SelectedGenre = selectedGenre;
            SettingsService.Save();
            // This line is refreshing genre comboBox for nothing, but it's not a big deal
            await InitSelectionComboBoxes();
            await RefreshDataDisplays();
        }

        private async void toolStripComboBox_TeamSelection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Team selectedTeam = toolStripComboBox_TeamSelection.GetSelectedItem<Team>();

            // If the value is the same than the previous one, no need to reload everything
            if (selectedTeam.FifaCode == SettingsService.SelectedTeamFifaCode)
                return;

            SettingsService.SelectedTeamFifaCode = selectedTeam.FifaCode;
            SettingsService.Save();
            await RefreshDataDisplays();
        }

        #endregion

        #region TabControl event handlers

        // This function is used to draw tabs manually, to be able to change their color
        // I have no idea how this works, please refer to:
        // https://stackoverflow.com/questions/5338587/set-tabpage-header-color
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs _event)
        {
            using (Brush brush = new SolidBrush(BACKCOLOR))
            {
                _event.Graphics.FillRectangle(brush, _event.Bounds);
                SizeF size = _event.Graphics.MeasureString(tabControl1.TabPages[_event.Index].Text, _event.Font!);
                // Draw the labels on the tabs
                _event.Graphics.DrawString(tabControl1.TabPages[_event.Index].Text, _event.Font!, new SolidBrush(FONTCOLOR), _event.Bounds.Left + (_event.Bounds.Width - size.Width) / 2, _event.Bounds.Top + (_event.Bounds.Height - size.Height) / 2 + 1);

                Rectangle rectangle = _event.Bounds;
                rectangle.Offset(0, 1);
                rectangle.Inflate(0, -1);
                _event.Graphics.DrawRectangle(Pens.DarkGray, rectangle);
                _event.DrawFocusRectangle();
            }
        }

        private async void tabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // TODO
            // Find the data grid view
            // There should be only one, if there is none or more, throw
            DataDisplay? dataDisplay = (sender as TabControl)?.SelectedTab.Controls.OfType<DataDisplay>().Single();
            if (dataDisplay == null)
                // TODO
                throw new Exception("HELP");

            await dataDisplay.RefreshData(GetSelectedTeam().FifaCode);
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
            toolStripComboBox_GenreSelection.SetItems(EnumUtility.GetEnumValues<Genre>(), genre => genre.GetLocalizedString(), SettingsService.SelectedGenre);

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
                // If favorite players is null, no player is a favorite
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

        private Team GetSelectedTeam()
        {
            return toolStripComboBox_TeamSelection.GetSelectedItem<Team>();
        }

        #region Data displays

        private void ResetDataDisplays()
        {
            favoritesDataDisplay?.Clear();
            allPlayersDataDisplay?.Clear();
            // TODO Add all data displays to clear here when adding more tabs
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

        #region Printing

        private void PrintDocument_PrintPage(object sender, EventArgs e)
        {
            /*var tab = tabControl1.SelectedTab;
            var bitmap = new Bitmap(tab.Width, tab.Height);
            tab.DrawToBitmap(bitmap, new Rectangle
            {
                X = 0,
                Y = 0,
                Width = pnlData.Size.Width,
                Height = pnlData.Size.Height
            });
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(Location.X, Location.Y, 0, 0, s);

            //printDocument1.Print();*/
        }

        #endregion

        private async void toolStripButton_Settings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.Cancel))
                return;
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.LanguageChanged))
            {
                this.LoadLocalization();
                await InitSelectionComboBoxes();
            }
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.OfflineModeChanged))
                dataService!.SetOfflineMode(SettingsService.OfflineMode);
        }
    }
}
