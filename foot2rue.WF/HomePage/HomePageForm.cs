using foot2rue.BLL.Services;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.DAL.Utilities;
using foot2rue.WF.Extensions;
using foot2rue.WF.MessageBoxes;
using foot2rue.WF.Settings;
using foot2rue.WF.Utilities;
using LostInLocalization.Extensions;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;

namespace foot2rue.WF.HomePage
{
    public partial class HomePageForm : Form
	{
		#region Localization

		private const string QUITCONFIRMATIONLOCALIZATIONSTRING = "{QuitConfirmation}";
		private const string PRINTERRORLOCALIZATIONSTRING = "{PrintError}";

		#endregion

		#region Colors

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

		#endregion

		private readonly SettingsService settingsService;
		private readonly DataService dataService;

		private DataDisplay? favoritesDataDisplay;
		private DataDisplay? allPlayersDataDisplay;
		private DataDisplay? matchesDataDisplay;
		// TODO Add data displays

		private readonly Queue<Image> imagesToPrint;

		public HomePageForm()
		{
			settingsService = SettingsService.Instance;
			dataService = new DataService();

			InitializeComponent();

			// Set the tool strip color
			ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());

			// Localization is done twice because of the refresh form, but otherwise it starts with ugly texts everywhere
			this.LoadLocalization();

			imagesToPrint = new Queue<Image>();
		}

		#region Initilization

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

                // Before exiting, we save his settings
                settingsService.SaveSettings();
            }

            // Then the form is closed
        }

		#endregion

		#region Tool Strip

		#region Printing

		private void toolStripButton_Print_Click(object sender, EventArgs e)
		{
			if (!GetSelectedDataDisplay().HasData())
			{
				new ErrorForm(PRINTERRORLOCALIZATIONSTRING).ShowDialog();
				return;
			}

			// Get the control to print
			DataDisplay dataDisplay = GetSelectedDataDisplay();

			// Get images for all controls that need to be printed
			imagesToPrint.EnqueueRange(dataDisplay.Print());

			if (printPreviewDialog.ShowDialog() == DialogResult.OK)
				printDocument.Print();
		}

        private static IEnumerable<(Image, Point)> GetImagePositions(Queue<Image> images, PrintPageEventArgs printPageEventArgs)
		{
			int minX = printPageEventArgs.MarginBounds.Left;
			int minY = printPageEventArgs.MarginBounds.Top;
			int maxX = printPageEventArgs.MarginBounds.Width;
			int maxY = printPageEventArgs.MarginBounds.Height;

			int currentX = minX;
			int currentY = minY;

			int currentRowHeight = 0;

			Image image;
			while (images.TryDequeue(out image!))
			{
				yield return (image, new Point(currentX, currentY));

				// Compute the next point
				currentRowHeight = Math.Max(currentRowHeight, image.Height);
				currentX += image.Width;
				if (currentX > maxX)
				{
					// If the width is larger than the page width, we go to the next row
					currentX = minX;
					currentY += currentRowHeight;
					currentRowHeight = 0;
				}

				// If the height is greater than the max, we need a new page
				// Stops dequeuing and start a new page that will start on the next image
				if (currentY > maxY)
				{
					printPageEventArgs.HasMorePages = true;
					break;
				}
			}
		}

		private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			// Draw each image on the document
			foreach ((Image image, Point position) nextImage in GetImagePositions(imagesToPrint, e))
				e.Graphics?.DrawImage(nextImage.image, nextImage.position);
		}

		#endregion

		#region Settings

		private async void toolStripButton_Settings_Click(object sender, EventArgs e)
		{
            SettingsForm settingsForm = new();
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

		#endregion

		#region Data

		private Team? GetSelectedTeam()
		{
			return toolStripComboBox_TeamSelection.GetSelectedItem<Team>();
		}

		private async void toolStripButton_Refresh_Click(object sender, EventArgs e)
		{
			await RefreshDataDisplays();
		}

		#region Tool strip combo box event handlers

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

		#endregion

		#endregion

		#region Tab control event handlers

		// This function is used to draw tabs manually, to be able to change their color
		// I have no idea how this works, please refer to:
		// https://stackoverflow.com/questions/5338587/set-tabpage-header-color
		private void tabControl1_DrawItem(object sender, DrawItemEventArgs @event)
		{
            using Brush brush = new SolidBrush(BACKCOLOR);
            @event.Graphics.FillRectangle(brush, @event.Bounds);
            SizeF size = @event.Graphics.MeasureString(tabControl_Rankings.TabPages[@event.Index].Text, @event.Font!);
            // Draw the labels on the tabs
            @event.Graphics.DrawString(tabControl_Rankings.TabPages[@event.Index].Text, @event.Font!, new SolidBrush(FONTCOLOR), @event.Bounds.Left + (@event.Bounds.Width - size.Width) / 2, @event.Bounds.Top + (@event.Bounds.Height - size.Height) / 2 + 1);

            Rectangle rectangle = @event.Bounds;
            rectangle.Offset(0, 1);
            rectangle.Inflate(0, -1);
            @event.Graphics.DrawRectangle(Pens.DarkGray, rectangle);
            @event.DrawFocusRectangle();
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

		#region Data displays

		private DataDisplay GetSelectedDataDisplay()
		{
			return tabControl_Rankings.SelectedTab.Controls.OfType<DataDisplay>().Single();
		}

		private void ResetDataDisplays()
		{
			favoritesDataDisplay?.Clear();
			allPlayersDataDisplay?.Clear();
			matchesDataDisplay?.Clear();
			// TODO Add all data displays to clear here when adding more tabs
		}

		private async Task RefreshDataDisplays()
		{
			ResetDataDisplays();

			// If there is no team currently selected, don't load anything
			Team? selectedTeam = GetSelectedTeam();
			if (selectedTeam == null)
				return;

			DataDisplay activeDataDisplay = GetSelectedDataDisplay();
			// Refresh the data of the current data display right now
			// Other data displays will be refreshed by themselves when shown again
			await this.Wait(async () => await activeDataDisplay.LoadData(selectedTeam.FifaCode));
		}

		#endregion
	}
}
