using foot2rue.WF.Extensions;
using foot2rue.WF.Services;
using System.Collections.Specialized;
using Timer = System.Windows.Forms.Timer;

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
        private Timer clickTimer;
        private Control? clickedControl;
        private ICollection<Control> selectedControls;

        public FavoritesSelectionUserControl(Action onValidation)
        {
            this.onValidation = onValidation;
            clickTimer = new Timer()
            {
                Interval = 300,
            };
            clickTimer.Tick += DragControl;
            selectedControls = new List<Control>();
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
                // TODO
                throw new Exception("Tough luck");

            foreach (Control playerUserControl in playerUserControls)
            {
                playerUserControl.Parent = flowLayoutPanel_AllPlayers;
                playerUserControl.MouseDown += control_MouseDown;
                playerUserControl.MouseUp += control_MouseUp;
                // So that controls do not block from dropping in the panel
                playerUserControl.DragEnter += control_DragEnter;
                playerUserControl.DragDrop += control_DragDrop;
            }
        }

        #region Drag and drop event handlers

        private void control_MouseDown(object? sender, MouseEventArgs e)
        {
            clickedControl = sender as Control;
            clickTimer.Start();
        }

        private void control_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!clickTimer.Enabled)
                // If the timer already stopped, the drag already started
                return;

            clickTimer.Stop();
            if (sender is Control control)
                SelectControl(control);
        }

        private void SelectControl(Control control)
        {
            if (selectedControls.Contains(control))
            {
                selectedControls.Remove(control);
                // TODO Show deselected
                control.ShowDeselected();
            }
            else
            {
                selectedControls.Add(control);
                // TODO Show selected
                control.ShowSelected();
            }
        }

        private void DragControl(object? sender, EventArgs e)
        {
            if (clickedControl == null)
                return;

            clickedControl.DoDragDrop(clickedControl, DragDropEffects.Move);
            clickTimer.Stop();
        }

        private void control_DragEnter(object? sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void control_DragDrop(object? sender, DragEventArgs e)
        {
            // TODO change this to drag mutiple things at once
            Control? draggedControl = e.Data?.GetData(typeof(PlayerDisplayUserControl)) as Control;
            if (draggedControl == null)
                // TODO What to do ?
                return;

            // If the sender is a user control, the control must be dragged in the same panel as this on
            // If it is already a panel, then it's easy
            Panel? target_Panel = sender is Panel panel ? panel : ((sender as Control)?.Parent as Panel);
            if (target_Panel == null)
                // 
                return;

            // Changing parent will also move the controls since they are flowLayoutPanels
            draggedControl.SetParent(target_Panel);
            foreach (Control control in selectedControls)
            {
                control.SetParent(target_Panel);
                control.ShowDeselected();
            }
            selectedControls.Clear();
        }

        #endregion

        private void button_Validate_Click(object sender, EventArgs e)
        {
            // TODO It would be nice to add some display showing how many players are and must be selected

            StringCollection names = SettingsService.FavoritePlayers;
            names.Clear();
            names.AddRange(flowLayoutPanel_FavoritePlayers.Controls.OfType<PlayerDisplayUserControl>().Select(control => control.Player.Name).ToArray());

            if (names.Count != FAVORITECOUNT)
                return;

            //SettingsService.FavoritePlayers = names;
            SettingsService.Save();
            onValidation.Invoke();
        }
    }
}
