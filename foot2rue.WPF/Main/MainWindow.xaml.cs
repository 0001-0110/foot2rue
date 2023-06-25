using foot2rue.BLL.Services;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.DAL.Utilities;
using foot2rue.WF.Services;
using foot2rue.WPF.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SettingsService settingsService;
        private readonly DataService dataService;

        private string? SelectedTeamFifaCode { get; set; }
        private string? OpposingTeamFifaCode { get; set; }

        public MainWindow()
        {
            settingsService = SettingsService.Instance;
            dataService = new DataService();
            InitializeComponent();
            this.LoadLocalization();
        }

        #region Event handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGenre();
            // Automatically call ComboBox_GenreSelectionChanged when loading genres
            //await LoadTeams();
        }

        private async void ComboBox_GenreSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataService.SetGenre(GetSelectedGenre());
            await LoadTeams();
        }

        public async void SelectedTeamChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTeamFifaCode = ComboBox_SelectedTeam.GetSelectedItem<Team>()?.FifaCode;
            ClearStatistics();
            // When changing the secleted team, user must select a new opposing team
            await LoadOpposingTeams();
        }

        public async void OpposingTeamChanged(object sender, SelectionChangedEventArgs e)
        {
            OpposingTeamFifaCode = ComboBox_OpposingTeam.GetSelectedItem<Team>()?.FifaCode;
            string? selectedFifaCode = SelectedTeamFifaCode;
            if (selectedFifaCode == null)
                return;

            IEnumerable<Match>? matches = await this.Wait(() => dataService.GetMatchesByFifaCode(selectedFifaCode));
            Match? match = matches?.SingleOrDefault(match => (match.HomeTeam.FifaCode == selectedFifaCode ? match.AwayTeam : match.HomeTeam).FifaCode == OpposingTeamFifaCode);
            if (match != null)
                await LoadMatch(match);
        }

        #endregion

        #region Getters

        private Genre GetSelectedGenre()
        {
            return ComboBox_GenreSelection.GetSelectedItem<Genre>();
        }

        private (TeamMatch, TeamMatch) GetSelectedAndOpposingTeams(Match match)
        {
            return match.HomeTeam.FifaCode == SelectedTeamFifaCode ?
                (match.HomeTeam, match.AwayTeam) :
                (match.AwayTeam, match.HomeTeam);
        }

        private (Statistics, Statistics) GetSelectedAndOpposingStatistics(Match match)
        {
            return match.HomeTeam.FifaCode == SelectedTeamFifaCode ?
                (match.HomeTeamStatistics, match.AwayTeamStatistics) :
                (match.AwayTeamStatistics, match.HomeTeamStatistics);
        }

        private (Event[], Event[]) GetSelectedAndOpposingEvents(Match match)
        {
            return match.HomeTeam.FifaCode == SelectedTeamFifaCode ?
                (match.HomeTeamEvents, match.AwayTeamEvents) :
                (match.AwayTeamEvents, match.HomeTeamEvents);
        }

        #endregion

        #region Header

        private void LoadGenre()
        {
            ComboBox_GenreSelection.SetItems(EnumUtility.GetEnumValues<Genre>(), settingsService.SelectedGenre);
        }

        private async Task LoadTeams()
        {
            ComboBox_OpposingTeam.Items.Clear();
            IEnumerable<Team>? teams = await this.Wait(dataService!.GetTeams);
            // When swithcing genre, this line might output a null
            Team? selectedTeam = teams?.SingleOrDefault(team => team.FifaCode == settingsService.SelectedTeamFifaCode);
            ComboBox_SelectedTeam.SetItems(await dataService.GetTeams(), selectedTeam);
        }

        private async Task LoadOpposingTeams()
        {
            // TODO Handle nulls
            string? selectedFifaCode = SelectedTeamFifaCode;
            if (selectedFifaCode == null)
                return;

            IEnumerable<Match> matches = await this.Wait(() => dataService.GetMatchesByFifaCode(selectedFifaCode));
            IEnumerable<Team> opposingTeams = matches.Select(match => match.HomeTeam.FifaCode == selectedFifaCode ? match.AwayTeam : match.HomeTeam);
            ComboBox_OpposingTeam.SetItems(opposingTeams);
            OpposingTeamStartingEleven.Children.Clear();
            OpposingTeamSubstitutes.Children.Clear();
        }

        #endregion

        #region Statistics tab

        private void ClearStatistics()
        {
            SelectedTeamStartingEleven.Children.Clear();
            SelectedTeamSubstitutes.Children.Clear();
            SelectedTeamEvents.Children.Clear();

            StatsComparator.Children.Clear();

            OpposingTeamEvents.Children.Clear();
            OpposingTeamStartingEleven.Children.Clear();
            OpposingTeamSubstitutes.Children.Clear();
        }
      
        private async Task LoadMatch(Match match)
        {
            (Statistics selectedTeam, Statistics opposingTeam) = GetSelectedAndOpposingStatistics(match);
            (Event[] selectedTeamEvents, Event[] opposingTeamEvents) = GetSelectedAndOpposingEvents(match);

            SelectedTeamStartingEleven.SetChildren(selectedTeam.StartingEleven.Select(player => new PlayerStatsUserControl(player)));
            SelectedTeamSubstitutes.SetChildren(selectedTeam.Substitutes.Select(player => new PlayerStatsUserControl(player)));
            //SelectedTeamEvents.SetChildren(selectedTeamEvents.Select(@event => ));

            //foreach (var thing in selectedTeam.)
                //StatsComparator.SetChildren();

            //OpposingTeamEvents.SetChildren(opposingTeamEvents.Select(@event => ));
            OpposingTeamStartingEleven.SetChildren(selectedTeam.StartingEleven.Select(player => new PlayerStatsUserControl(player)));
            OpposingTeamSubstitutes.SetChildren(selectedTeam.Substitutes.Select(player => new PlayerStatsUserControl(player)));
        }

        #endregion
    }
}
