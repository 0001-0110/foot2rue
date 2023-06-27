using foot2rue.BLL.Services;
using foot2rue.DAL.Models;
using foot2rue.DAL.Repositories;
using foot2rue.DAL.Utilities;
using foot2rue.WPF.Extensions;
using foot2rue.WPF.MessageBoxes;
using foot2rue.WPF.Settings;
using foot2rue.WPF.Utilities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
    public partial class MainWindow : Window
    {
        private const string SELECTEDTEAMGRID = "SelectedTeam";
        private const string OPPOSINGTEAMGRID = "OpposingTeam";
        private static readonly IEnumerable<PropertyInfo> Statistics = typeof(Statistics).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(property => property.PropertyType == typeof(int));

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

        #region Window

        #region Event handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!SettingsService.SettingsExists())
            {
                InitialSettingsWindow initialSettingsWindow = new() { Owner = this };
                if (!(bool)initialSettingsWindow.ShowDialog()!)
                {
                    new ErrorWindow().ShowDialog();
                    Application.Current.Shutdown();
                }
            }

            LoadGenre();
            // Automatically call ComboBox_GenreSelectionChanged when loading genres
            //await LoadTeams();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!(new ConfirmationWindow("{QuitConfirmation}").ShowDialog() ?? false))
                e.Cancel = true;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            settingsService.SaveSettings();
        }

        #endregion

        #endregion

        #region Header

        #region Event handlers

        private async void ComboBox_GenreSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Genre selectedGenre = GetSelectedGenre();
            settingsService.SelectedGenre = selectedGenre;
            dataService.SetGenre(selectedGenre);

            // No need to clear anything since Loading the teams will call SelectedTeamChanged
            await LoadTeams();
        }

        private async void SelectedTeamChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTeamFifaCode = ComboBox_SelectedTeam.GetSelectedItem<Team>()?.FifaCode;
            if (SelectedTeamFifaCode != null)
                settingsService.SelectedTeamFifaCode = SelectedTeamFifaCode;
            Image_SelectedTeam.Source = ResourcesUtility.ConvertToWpfImage(ResourcesUtility.GetCountryImage(SelectedTeamFifaCode));

            ClearTeamStatistics();
            ClearMatchStatistics();

            // When changing the secleted team, user must select a new opposing team
            await LoadOpposingTeams();
            LoadTeamStatistics();
        }

        private async void OpposingTeamChanged(object sender, SelectionChangedEventArgs e)
        {
            OpposingTeamFifaCode = ComboBox_OpposingTeam.GetSelectedItem<Team>()?.FifaCode;
            Image_OpposingTeam.Source = ResourcesUtility.ConvertToWpfImage(ResourcesUtility.GetCountryImage(OpposingTeamFifaCode));
            string? selectedFifaCode = SelectedTeamFifaCode;
            if (selectedFifaCode == null)
                return;

            IEnumerable<Match>? matches = await this.Wait(() => dataService.GetMatchesByFifaCode(selectedFifaCode));
            Match? match = matches?.SingleOrDefault(match => (match.HomeTeam.FifaCode == selectedFifaCode ? match.AwayTeam : match.HomeTeam).FifaCode == OpposingTeamFifaCode);
            if (match != null)
            {
                LoadMatchStatistics(match);
                LoadMatchField(match);
            }
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(sender is TabControl tabControl))
                return;

            Visibility visibility = tabControl.SelectedIndex == 0 ? Visibility.Hidden : Visibility.Visible;
            Image_VersusIcon.Visibility = visibility;
            ComboBox_OpposingTeam.Visibility = visibility;
            TextBlock_OpposingTeamScore.Visibility = visibility;
            Image_OpposingTeam.Visibility = visibility;
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Window settingsWindow = new SettingsWindow();
            if (!(bool)settingsWindow.ShowDialog()!)
                return;

            this.LoadLocalization();
            dataService.SetOfflineMode(settingsService.OfflineMode);
            this.Resize(settingsService.Resolution);
        }

        #endregion

        private Genre GetSelectedGenre()
        {
            return ComboBox_GenreSelection.GetSelectedItem<Genre>();
        }

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

        #region Team statistics tab

        private void ClearTeamStatistics()
        {
            
        }

        private void LoadTeamStatistics()
        {
            
        }

        #endregion

        #region Match statistics tab

        private void ClearMatchStatistics()
        {
            SelectedTeamStartingEleven.Children.Clear();
            SelectedTeamSubstitutes.Children.Clear();
            SelectedTeamEvents.Children.Clear();

            StatsComparator.Children.Clear();

            OpposingTeamEvents.Children.Clear();
            OpposingTeamStartingEleven.Children.Clear();
            OpposingTeamSubstitutes.Children.Clear();
        }

        private void LoadMatchStatistics(Match match)
        {
            (Statistics selectedTeamStats, Statistics opposingTeamStats) = GetSelectedAndOpposingStatistics(match);
            (Event[] selectedTeamEvents, Event[] opposingTeamEvents) = GetSelectedAndOpposingEvents(match);

            SelectedTeamStartingEleven.SetChildren(selectedTeamStats.StartingEleven.Select(player => new PlayerStatsUserControl(player)));
            SelectedTeamSubstitutes.SetChildren(selectedTeamStats.Substitutes.Select(player => new PlayerStatsUserControl(player)));
            SelectedTeamEvents.SetChildren(selectedTeamEvents.Select(@event => new EventUserControl(@event)));

            StatsComparator.SetChildren(Statistics.Select(property => new StatsCardUserControl(
                $"{{{property.Name}}}",
                ColorUtility.GetTeamColor(SelectedTeamFifaCode), (int)property.GetValue(selectedTeamStats)!,
                ColorUtility.GetTeamColor(OpposingTeamFifaCode), (int)property.GetValue(opposingTeamStats)!)));

            OpposingTeamEvents.SetChildren(opposingTeamEvents.Select(@event => new EventUserControl(@event)));
            OpposingTeamStartingEleven.SetChildren(opposingTeamStats.StartingEleven.Select(player => new PlayerStatsUserControl(player, true)));
            OpposingTeamSubstitutes.SetChildren(opposingTeamStats.Substitutes.Select(player => new PlayerStatsUserControl(player, true)));
        }

        #endregion

        #region Field tab

        private void LoadMatchField(Match match)
        {
            (Statistics, Statistics) statistics = GetSelectedAndOpposingStatistics(match);

            for (int teamIndex = 0; teamIndex < 2; teamIndex++)
            {
                IEnumerable<IGrouping<string, Player>> playerByPosition = statistics.GetIndex(teamIndex).StartingEleven.GroupBy(player => player.Position);
                foreach (IGrouping<string, Player> grouping in playerByPosition)
                {
                    string gridName = $"Grid_{(teamIndex == 0 ? SELECTEDTEAMGRID : OPPOSINGTEAMGRID)}{grouping.Key}";
                    (FindName(gridName) as FieldColumnUserControl)?.SetPlayers(dataService, grouping, match, teamIndex);
                }
            }
        }

        #endregion

        #region Others

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
    }
}
