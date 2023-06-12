using foot2rue.BLL.Services;
using foot2rue.WF.Extensions;
using foot2rue.WF.Services;
using System.Collections.Specialized;
using System.ComponentModel;
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

        private SettingsService settingsService;

        private Action onValidation;

        // Holding the mouse for less than this value is considered a click,
        // If longer, then it is considered a drag
        // Delay is in milliseconds
        private const int CLICKDURATION = 200;
        private Timer clickTimer;
        private Control? clickedControl;
        private ICollection<Control> selectedControls;

        public FavoritesSelectionUserControl(Action onValidation)
        {
            settingsService = SettingsService.Instance;
            this.onValidation = onValidation;
            clickTimer = new Timer()
            {
                Interval = CLICKDURATION,
            };
            clickTimer.Tick += DragControl;
            selectedControls = new List<Control>();
            InitializeComponent();
            this.LoadLocalization();
            // This must be loaded separalty since it is not one the the form's control
            contextMenuStrip.LoadLocalization();
        }

        private async void FavoritesSelectionUserControl_Load(object sender, EventArgs e)
        {
            RefreshLabel();
            await InitFlowLayoutPanels();
        }

        private void RefreshLabel()
        {
            int playerCount = flowLayoutPanel_FavoritePlayers.Controls.Count;
            label1.SetLocalizationString($"{{SelectedPlayers}}: {playerCount} / {FAVORITECOUNT}");
            label1.ForeColor = playerCount != FAVORITECOUNT ? Color.Red : Color.White;
        }

        private async Task InvalidInput()
        {
            Color backColor = label1.BackColor;
            for (int i = 0; i < 3; i++)
            {
                label1.BackColor = Color.Red;
                await Task.Delay(50);
                label1.BackColor = backColor;
                await Task.Delay(50);
            }
        }

        private async Task InitFlowLayoutPanels()
        {
            IEnumerable<Control>? playerUserControls =
                (await this.Wait(async () => await new DataService()
                .GetPlayersByFifaCode(settingsService.SelectedTeamFifaCode)))?
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
                playerUserControl.ContextMenuStrip = contextMenuStrip;
            }
        }

        #region Drag and drop event handlers

        private void control_MouseDown(object? sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    clickedControl = sender as Control;
                    clickTimer.Start();
                    break;
                    // No need to handle right click since the context menu is already linked to it
            }
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
                control.ShowDeselected();
            }
            else
            {
                selectedControls.Add(control);
                control.ShowSelected();
            }
        }

        private void DragControl(object? sender, EventArgs e)
        {
            // !-- sender is timer here, don't use it --!

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

            SetParent(selectedControls.Append(draggedControl), _ => target_Panel);
        }

        private void MoveControls(ToolStripItem item, Control[] controls)
        {
            if (item == addFavoriteToolStripMenuItem)
                AddFavorite(controls);
            else if (item == removeFavoriteToolStripMenuItem)
                RemoveFavorite(controls);
            else
                Inverse(controls);
        }

        private void SetParent(IEnumerable<Control> controls, Func<Control, Control> getParent)
        {
            // Changing parent will also move the controls since they are flowLayoutPanels
            foreach (Control control in controls)
            {
                control.SetParent(getParent(control));
                control.ShowDeselected();
            }
            selectedControls.Clear();
            RefreshLabel();
        }

        #region Context menu strip

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Retrieve the control that triggered the context menu
            clickedControl = ((ContextMenuStrip)sender).SourceControl;
            Action<ToolStripMenuItem, Panel> setToolStripVisible = (menuItem, panel) =>
            {
                // If the source control is in the panel, it can be moved with `This one`
                bool thisOne = clickedControl.Parent == panel;
                // If any of the selected controls are in this panel, they can be moved with `All selected`
                bool allSelected = selectedControls.Any(control => control.Parent == panel);
                // If any controls are in this panel, they can be moved with `All`
                bool all = panel.Controls.Count > 0;

                // Set the visiblity of all elements
                menuItem.Visible = thisOne || allSelected || all;
                menuItem.DropDownItems[0].Visible = thisOne;
                menuItem.DropDownItems[1].Visible = allSelected;
                menuItem.DropDownItems[2].Visible = all;
            };

            setToolStripVisible(addFavoriteToolStripMenuItem, flowLayoutPanel_AllPlayers);
            setToolStripVisible(removeFavoriteToolStripMenuItem, flowLayoutPanel_FavoritePlayers);

            // Inverse this one is always possible
            allSelectedToolStripMenuItem2.Visible = selectedControls.Count > 0;
            // Inverse all is always possible
            // Inverse is always available
        }

        private void thisOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedControl == null)
                return;

            MoveControls(((ToolStripMenuItem)sender).OwnerItem, new Control[] { clickedControl, });
        }

        private void allSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveControls(((ToolStripMenuItem)sender).OwnerItem, selectedControls.ToArray());
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveControls(((ToolStripMenuItem)sender).OwnerItem, GetAllControls());
        }

        private void AddFavorite(IEnumerable<Control> controls)
        {
            SetParent(controls, _ => flowLayoutPanel_FavoritePlayers);
        }

        private void RemoveFavorite(IEnumerable<Control> controls)
        {
            SetParent(controls, _ => flowLayoutPanel_AllPlayers);
        }

        private void Inverse(IEnumerable<Control> controls)
        {
            SetParent(controls, control => control.Parent == flowLayoutPanel_AllPlayers ? flowLayoutPanel_FavoritePlayers : flowLayoutPanel_AllPlayers);
        }

        #endregion
        #endregion

        private void button_Validate_Click(object sender, EventArgs e)
        {
            // TODO It would be nice to add some display showing how many players are and must be selected

            StringCollection names = settingsService.FavoritePlayers;
            names.Clear();
            names.AddRange(flowLayoutPanel_FavoritePlayers.Controls.OfType<PlayerDisplayUserControl>().Select(control => control.Player.Name).ToArray());

            if (names.Count != FAVORITECOUNT)
            {
                Task.Run(InvalidInput);
                return;
            }

            //SettingsService.FavoritePlayers = names;
            settingsService.SaveSettings();
            onValidation.Invoke();
        }

        private Control[] GetAllControls()
        {
            Control[] controls = new Control[flowLayoutPanel_AllPlayers.Controls.Count + flowLayoutPanel_FavoritePlayers.Controls.Count];
            flowLayoutPanel_AllPlayers.Controls.CopyTo(controls, 0);
            flowLayoutPanel_FavoritePlayers.Controls.CopyTo(controls, flowLayoutPanel_AllPlayers.Controls.Count);
            return controls;
        }
    }
}
