using foot2rue.BLL.Services;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.DAL.Utilities;
using foot2rue.WF.Extensions;
using foot2rue.WF.MessageBoxes;
using foot2rue.WF.Services;
using foot2rue.WF.Settings;
using foot2rue.WF.Utilities;
using LostInLocalization.Extensions;
using System.Data;
using System.Globalization;

namespace foot2rue.WF.HomePage
{
    public partial class HomePageForm : Form
    {
        private const string QUITCONFIRMATIONLOCALIZATIONSTRING = "{QuitConfirmation}";
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

        private SettingsService settingsService;
        private DataService dataService;

        private DataDisplay? favoritesDataDisplay;
        private DataDisplay? allPlayersDataDisplay;
        // TODO Add data display
        private DataDisplay? matchesDataDisplay;

        public HomePageForm()
        {
            settingsService = SettingsService.Instance;
            dataService = new DataService();

            InitializeComponent();

            // Set the tool strip color
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());

            // Localization is done twice because of the refresh form, but otherwise it starts with ugly texts everywhere
            this.LoadLocalization();
        }

        private async Task RefreshForm(Genre? newGenre = null, Team? newTeam = null, bool? newOfflineMode = null, CultureInfo? newCulture = null)
        {
            // Some of these lines might be redundant, but its better to have everything centralized

            if (newGenre != null)
            {
                dataService.SetGenre((Genre)newGenre);
                settingsService.SelectedGenre = (Genre)newGenre;
                await RefreshSelectionComboBoxes();
            }

            if (newTeam != null)
            {
                settingsService.SelectedTeamFifaCode = newTeam.FifaCode;
            }

            if (newGenre != null || newTeam != null)
            {
                await RefreshDataDisplays();
            }

            if (newOfflineMode != null)
            {
                dataService.SetOfflineMode((bool)newOfflineMode);
                settingsService.OfflineMode = (bool)newOfflineMode;
            }

            if (newCulture != null)
            {
                this.LoadLocalization();
                await RefreshSelectionComboBoxes();
            }

            settingsService.SaveSettings();
        }

        #region Form event handlers

        private async void HomePageForm_Shown(object? sender, EventArgs e)
        {
            /*var thing = SettingsService.SelectedTeamFifaCode;
            SettingsService.SelectedTeamFifaCode = "FRA";
            SettingsService.Save();*/

            CenterToScreen();

            // If there already is a settings file, we can skip the initial setup
            if (!SettingsService.SettingsExists())
                this.InitialSetup(settingsService);

            // Get the genre from the settings
            // The genre is either loaded from the config file by the SettingsService
            // or in case of the first use, has been selected during the initial setup
            dataService.SetGenre(settingsService.SelectedGenre);

            InitDataDisplays();
            await RefreshForm(settingsService.SelectedGenre, GetSelectedTeam(), newCulture: settingsService.Culture);

            // No need to load the data for dataDisplays since this is handled by the tabControl
        }

        private void HomePageForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // If the user is the one trying to close the app, ask for confirmation
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (new ConfirmationForm(QUITCONFIRMATIONLOCALIZATIONSTRING).ShowDialog() == DialogResult.Cancel)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    return;
                }
            }

            // Before exiting, we save his settings
            settingsService.SaveSettings();
            // Then the form is closed
        }

        #endregion

        #region ToolStripComboBox event handlers

        private async void toolStripComboBox_GenreSelection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Genre selectedGenre = toolStripComboBox_GenreSelection.GetSelectedItem<Genre>();

            // If the value is the same than the previous one, no need to reload everything
            if (selectedGenre == settingsService.SelectedGenre)
                return;

            // This line is refreshing genre comboBox for nothing, but it's not a big deal
            await RefreshForm(newGenre: selectedGenre);
        }

        private async void toolStripComboBox_TeamSelection_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Team? selectedTeam = toolStripComboBox_TeamSelection.GetSelectedItem<Team>();

            // If the value is null, no team is selected
            // If the value is the same than the previous one, no need to reload everything
            if (selectedTeam == null || selectedTeam.FifaCode == settingsService.SelectedTeamFifaCode)
                return;

            await RefreshForm(newTeam: selectedTeam);
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
                SizeF size = _event.Graphics.MeasureString(tabControl_Rankings.TabPages[_event.Index].Text, _event.Font!);
                // Draw the labels on the tabs
                _event.Graphics.DrawString(tabControl_Rankings.TabPages[_event.Index].Text, _event.Font!, new SolidBrush(FONTCOLOR), _event.Bounds.Left + (_event.Bounds.Width - size.Width) / 2, _event.Bounds.Top + (_event.Bounds.Height - size.Height) / 2 + 1);

                Rectangle rectangle = _event.Bounds;
                rectangle.Offset(0, 1);
                rectangle.Inflate(0, -1);
                _event.Graphics.DrawRectangle(Pens.DarkGray, rectangle);
                _event.DrawFocusRectangle();
            }
        }

        private async void tabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Find the data grid view
            // There should be only one, if there is none or more, throw
            DataDisplay? dataDisplay = (sender as TabControl)?.SelectedTab.Controls.OfType<DataDisplay>().Single();
            if (dataDisplay == null)
                // TODO ?
                throw new Exception("HELP");

            // No need to refresh the form here, we only want the active datadisplay to load its data if needed
            Team? selectedTeam = GetSelectedTeam();
            if (selectedTeam != null)
                await dataDisplay.RefreshData(selectedTeam.FifaCode);
        }

        #endregion

        #region Initialisation

        private async Task RefreshSelectionComboBoxes()
        {
            toolStripComboBox_GenreSelection.SetItems(EnumUtility.GetEnumValues<Genre>(), genre => genre.GetLocalizedString(), settingsService.SelectedGenre);

            IEnumerable<Team>? teams = await this.Wait(dataService!.GetTeams);
            // When swithcing genre, this line might output a null
            Team? selectedTeam = teams?.SingleOrDefault(team => team.FifaCode == settingsService.SelectedTeamFifaCode);
            // If that is the case, the comboBox removes its current selection
            toolStripComboBox_TeamSelection.SetItems(teams, selectedTeam);
        }

        private void InitDataDisplays()
        {
            // This whole function is hard to watch

            int tabIndex = 0;

            favoritesDataDisplay = new DataDisplay(
                async (string fifaCode) => (await dataService.GetPlayersByFifaCode(fifaCode))?
                // If favorite players is null, no player is a favorite
                .Where(player => settingsService.FavoritePlayers.Contains(player.Name))
                .Select(player => new PlayerDisplayUserControl(player)))
            {
                Parent = tabControl_Rankings.TabPages[tabIndex++],
                Dock = DockStyle.Fill,
            };

            allPlayersDataDisplay = new DataDisplay(
                async (string fifaCode) => (await dataService.GetPlayersByFifaCode(fifaCode))?
                .Select(player => new PlayerDisplayUserControl(player)))
            {
                Parent = tabControl_Rankings.TabPages[tabIndex++],
                Dock = DockStyle.Fill,
            };

            matchesDataDisplay = new DataDisplay(
                async (string fifaCode) => (await dataService.GetMatchesByFifaCode(fifaCode))?
                .Select(match => new MatchDisplayUserControl(match)))
            {
                Parent = tabControl_Rankings.TabPages[tabIndex++],
                Dock = DockStyle.Fill,
            };
        }

        #endregion

        private Team? GetSelectedTeam()
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

            DataDisplay activeDataDisplay = tabControl_Rankings.SelectedTab.Controls.OfType<DataDisplay>().Single();
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

            Genre? newGenre = null;
            Team? newTeam = null;
            bool? newOfflineMode = null;
            CultureInfo? newCulture = null;

            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.Cancel))
                return;
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.LanguageChanged))
                newCulture = settingsService.Culture;
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.OfflineModeChanged))
                newOfflineMode = settingsService.OfflineMode;
            if (settingsForm.SettingsDialogResult.HasFlag(SettingsDialogResult.SettingsReseted))
            {
                // No need to take care of the language here since a reset also triggers the language change
                newGenre = settingsService.SelectedGenre;
                newTeam = await dataService.GetTeamByFifaCode(settingsService.SelectedTeamFifaCode);
            }

            await RefreshForm(newGenre, newTeam, newOfflineMode, newCulture);
        }
    }
}
