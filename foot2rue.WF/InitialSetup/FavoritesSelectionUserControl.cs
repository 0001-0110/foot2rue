using foot2rue.WF.Extensions;
using foot2rue.WF.Services;
using System.Collections.Specialized;

namespace foot2rue.WF.InitialSetup
{
    public partial class FavoritesSelectionUserControl : UserControl
    {
        /// <summary>
        /// The number of players that must be selected as a favorite during the initial setup
        /// </summary>
        /// <remarks>
        /// This has been defined in the project specifications
        /// </remarks>
        private const int FAVORITECOUNT = 3;

        private Action onValidation;

        public FavoritesSelectionUserControl(Action onValidation)
        {
            this.onValidation = onValidation;
            InitializeComponent();
            this.LoadLocalization();
        }

        private async void FavoritesSelectionUserControl_Load(object sender, EventArgs e)
        {
            await InitFlowPanelLayouts();
        }

        private async Task InitFlowPanelLayouts()
        {
            IEnumerable<Control>? playerUserControls =
                (await this.Wait(async () => await new DataService()
                .GetPlayersByFifaCode(SettingsService.SelectedTeamFifaCode)))?
                .Select(player => new PlayerDisplayUserControl(player));

            if (playerUserControls == null)
                throw new Exception("Tough luck");

            foreach (Control playerUserControl in playerUserControls)
            {
                playerUserControl.Parent = flowLayoutPanel_AllPlayers;
                playerUserControl.MouseDown += control_MouseDown;
            }
        }

        #region Drag and drop event handlers

        private void control_MouseDown(object? sender, MouseEventArgs e)
        {
            Control? control = sender as Control;
            control?.DoDragDrop(control, DragDropEffects.Move);
        }

        private void flowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            // TODO Could be improved so that controls do not block dropping other controls
            Control? draggedControl = e.Data?.GetData(typeof(PlayerDisplayUserControl)) as Control;
            if (draggedControl == null)
                // TODO What to do ?
                throw new Exception();

            // Changing parent will also move the control since they are flowLayoutPanels
            draggedControl?.SetParent((Control)sender);
        }

        #endregion

        private void button_Validate_Click(object sender, EventArgs e)
        {
            // TODO It would be nice to add some display showing how many players are and must be selected

            StringCollection names = new StringCollection();
            names.AddRange(flowLayoutPanel_FavoritePlayers.Controls.OfType<PlayerDisplayUserControl>().Select(control => control.Player.Name).ToArray());

            if (names.Count != FAVORITECOUNT)
                return;
            
            SettingsService.FavoritePlayers = names;
            SettingsService.Save();
            onValidation.Invoke();
        }
    }
}
