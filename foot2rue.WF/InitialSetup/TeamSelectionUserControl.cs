using foot2rue.BLL;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.DAL.Utilities;
using foot2rue.WF.Extensions;
using foot2rue.WF.Services;
using LostInLocalization;
using LostInLocalization.Extensions;

namespace foot2rue.WF.InitialSetup
{
    public partial class TeamSelectionUserControl : UserControl
    {
        private SettingsService settingsService;
        private LocalizationService localizationService;
        private DataService? dataService;

        private Action onValidate;

        public TeamSelectionUserControl(Action onValidate)
        {
            settingsService = SettingsService.Instance;
            localizationService = LocalizationService.Instance;
            this.onValidate = onValidate;
            InitializeComponent();
            this.LoadLocalization();
        }

        private void TeamSelectionUserControl_Load(object sender, EventArgs e)
        {
            comboBox_GenreSelection.SetItems(EnumUtility.GetEnumValues<Genre>(), genre => genre.GetLocalizedString(), -1);
        }

        private async void comboBox_GenreSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Genre selectedGenre = comboBox_GenreSelection.GetSelectedItem<Genre>();
            settingsService.SelectedGenre = selectedGenre;

            // Once we have the genre, load the teams
            dataService = new DataService();
            IEnumerable<Team>? teams = await this.Wait(dataService.GetTeams);
            // Set the selected item to null to clear the selection
            comboBox_TeamSelection.SetItems(teams, null);
        }

        private void comboBox_TeamSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Team selectedTeam = comboBox_TeamSelection.GetSelectedItem<Team>();
            settingsService.SelectedTeamFifaCode = selectedTeam.FifaCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox_TeamSelection.SelectedIndex == -1 || comboBox_GenreSelection.SelectedIndex == -1)
            {
                // TODO Display invalid input
                return;
            }

            settingsService.SaveSettings();
            onValidate.Invoke();
        }
    }
}
