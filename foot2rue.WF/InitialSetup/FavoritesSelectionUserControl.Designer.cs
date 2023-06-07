namespace foot2rue.WF.InitialSetup
{
    partial class FavoritesSelectionUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            flowLayoutPanel_FavoritePlayers = new FlowLayoutPanel();
            flowLayoutPanel_AllPlayers = new FlowLayoutPanel();
            contextMenuStrip = new ContextMenuStrip(components);
            addFavoriteToolStripMenuItem = new ToolStripMenuItem();
            thisOneToolStripMenuItem = new ToolStripMenuItem();
            allSelectedToolStripMenuItem = new ToolStripMenuItem();
            allToolStripMenuItem = new ToolStripMenuItem();
            removeFavoriteToolStripMenuItem = new ToolStripMenuItem();
            thisOneToolStripMenuItem1 = new ToolStripMenuItem();
            allSelectedToolStripMenuItem1 = new ToolStripMenuItem();
            allToolStripMenuItem1 = new ToolStripMenuItem();
            inverseSelectionToolStripMenuItem = new ToolStripMenuItem();
            thisOneToolStripMenuItem2 = new ToolStripMenuItem();
            allSelectedToolStripMenuItem2 = new ToolStripMenuItem();
            allToolStripMenuItem2 = new ToolStripMenuItem();
            label1 = new Label();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.Location = new Point(592, 613);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Tag = "{Ok}";
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_Validate_Click;
            // 
            // flowLayoutPanel_FavoritePlayers
            // 
            flowLayoutPanel_FavoritePlayers.AllowDrop = true;
            flowLayoutPanel_FavoritePlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel_FavoritePlayers.AutoScroll = true;
            flowLayoutPanel_FavoritePlayers.Location = new Point(685, 69);
            flowLayoutPanel_FavoritePlayers.Name = "flowLayoutPanel_FavoritePlayers";
            flowLayoutPanel_FavoritePlayers.Size = new Size(550, 506);
            flowLayoutPanel_FavoritePlayers.TabIndex = 1;
            flowLayoutPanel_FavoritePlayers.DragDrop += control_DragDrop;
            flowLayoutPanel_FavoritePlayers.DragEnter += control_DragEnter;
            // 
            // flowLayoutPanel_AllPlayers
            // 
            flowLayoutPanel_AllPlayers.AllowDrop = true;
            flowLayoutPanel_AllPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel_AllPlayers.AutoScroll = true;
            flowLayoutPanel_AllPlayers.Location = new Point(28, 69);
            flowLayoutPanel_AllPlayers.Name = "flowLayoutPanel_AllPlayers";
            flowLayoutPanel_AllPlayers.Size = new Size(617, 506);
            flowLayoutPanel_AllPlayers.TabIndex = 2;
            flowLayoutPanel_AllPlayers.DragDrop += control_DragDrop;
            flowLayoutPanel_AllPlayers.DragEnter += control_DragEnter;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { addFavoriteToolStripMenuItem, removeFavoriteToolStripMenuItem, inverseSelectionToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(188, 76);
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // addFavoriteToolStripMenuItem
            // 
            addFavoriteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thisOneToolStripMenuItem, allSelectedToolStripMenuItem, allToolStripMenuItem });
            addFavoriteToolStripMenuItem.Name = "addFavoriteToolStripMenuItem";
            addFavoriteToolStripMenuItem.Size = new Size(187, 24);
            addFavoriteToolStripMenuItem.Tag = "{Button_AddFavorite}";
            addFavoriteToolStripMenuItem.Text = "Add favorite";
            // 
            // thisOneToolStripMenuItem
            // 
            thisOneToolStripMenuItem.Name = "thisOneToolStripMenuItem";
            thisOneToolStripMenuItem.Size = new Size(169, 26);
            thisOneToolStripMenuItem.Tag = "{Button_ThisOne}";
            thisOneToolStripMenuItem.Text = "This one";
            thisOneToolStripMenuItem.Click += thisOneToolStripMenuItem_Click;
            // 
            // allSelectedToolStripMenuItem
            // 
            allSelectedToolStripMenuItem.Name = "allSelectedToolStripMenuItem";
            allSelectedToolStripMenuItem.Size = new Size(169, 26);
            allSelectedToolStripMenuItem.Tag = "{Button_AllSelected}";
            allSelectedToolStripMenuItem.Text = "All selected";
            allSelectedToolStripMenuItem.Click += allSelectedToolStripMenuItem_Click;
            // 
            // allToolStripMenuItem
            // 
            allToolStripMenuItem.Name = "allToolStripMenuItem";
            allToolStripMenuItem.Size = new Size(169, 26);
            allToolStripMenuItem.Tag = "{Button_All}";
            allToolStripMenuItem.Text = "All";
            allToolStripMenuItem.Click += allToolStripMenuItem_Click;
            // 
            // removeFavoriteToolStripMenuItem
            // 
            removeFavoriteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thisOneToolStripMenuItem1, allSelectedToolStripMenuItem1, allToolStripMenuItem1 });
            removeFavoriteToolStripMenuItem.Name = "removeFavoriteToolStripMenuItem";
            removeFavoriteToolStripMenuItem.Size = new Size(187, 24);
            removeFavoriteToolStripMenuItem.Tag = "{Button_RemoveFavorite}";
            removeFavoriteToolStripMenuItem.Text = "Remove favorite";
            // 
            // thisOneToolStripMenuItem1
            // 
            thisOneToolStripMenuItem1.Name = "thisOneToolStripMenuItem1";
            thisOneToolStripMenuItem1.Size = new Size(169, 26);
            thisOneToolStripMenuItem1.Tag = "{Button_ThisOne}";
            thisOneToolStripMenuItem1.Text = "This one";
            thisOneToolStripMenuItem1.Click += thisOneToolStripMenuItem_Click;
            // 
            // allSelectedToolStripMenuItem1
            // 
            allSelectedToolStripMenuItem1.Name = "allSelectedToolStripMenuItem1";
            allSelectedToolStripMenuItem1.Size = new Size(169, 26);
            allSelectedToolStripMenuItem1.Tag = "{Button_AllSelected}";
            allSelectedToolStripMenuItem1.Text = "All selected";
            allSelectedToolStripMenuItem1.Click += allSelectedToolStripMenuItem_Click;
            // 
            // allToolStripMenuItem1
            // 
            allToolStripMenuItem1.Name = "allToolStripMenuItem1";
            allToolStripMenuItem1.Size = new Size(169, 26);
            allToolStripMenuItem1.Tag = "{Button_All}";
            allToolStripMenuItem1.Text = "All";
            allToolStripMenuItem1.Click += allToolStripMenuItem_Click;
            // 
            // inverseSelectionToolStripMenuItem
            // 
            inverseSelectionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thisOneToolStripMenuItem2, allSelectedToolStripMenuItem2, allToolStripMenuItem2 });
            inverseSelectionToolStripMenuItem.Name = "inverseSelectionToolStripMenuItem";
            inverseSelectionToolStripMenuItem.Size = new Size(187, 24);
            inverseSelectionToolStripMenuItem.Tag = "{Button_Inverse}";
            inverseSelectionToolStripMenuItem.Text = "Inverse";
            // 
            // thisOneToolStripMenuItem2
            // 
            thisOneToolStripMenuItem2.Name = "thisOneToolStripMenuItem2";
            thisOneToolStripMenuItem2.Size = new Size(169, 26);
            thisOneToolStripMenuItem2.Tag = "{Button_ThisOne}";
            thisOneToolStripMenuItem2.Text = "This one";
            thisOneToolStripMenuItem2.Click += thisOneToolStripMenuItem_Click;
            // 
            // allSelectedToolStripMenuItem2
            // 
            allSelectedToolStripMenuItem2.Name = "allSelectedToolStripMenuItem2";
            allSelectedToolStripMenuItem2.Size = new Size(169, 26);
            allSelectedToolStripMenuItem2.Tag = "{Button_AllSelected}";
            allSelectedToolStripMenuItem2.Text = "All selected";
            allSelectedToolStripMenuItem2.Click += allSelectedToolStripMenuItem_Click;
            // 
            // allToolStripMenuItem2
            // 
            allToolStripMenuItem2.Name = "allToolStripMenuItem2";
            allToolStripMenuItem2.Size = new Size(169, 26);
            allToolStripMenuItem2.Tag = "{Button_All}";
            allToolStripMenuItem2.Text = "All";
            allToolStripMenuItem2.Click += allToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(685, 32);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // FavoritesSelectionUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel_AllPlayers);
            Controls.Add(flowLayoutPanel_FavoritePlayers);
            Controls.Add(button1);
            Name = "FavoritesSelectionUserControl";
            Size = new Size(1262, 673);
            Load += FavoritesSelectionUserControl_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private FlowLayoutPanel flowLayoutPanel_FavoritePlayers;
        private FlowLayoutPanel flowLayoutPanel_AllPlayers;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem addFavoriteToolStripMenuItem;
        private ToolStripMenuItem thisOneToolStripMenuItem;
        private ToolStripMenuItem allSelectedToolStripMenuItem;
        private ToolStripMenuItem allToolStripMenuItem;
        private ToolStripMenuItem removeFavoriteToolStripMenuItem;
        private ToolStripMenuItem thisOneToolStripMenuItem1;
        private ToolStripMenuItem allSelectedToolStripMenuItem1;
        private ToolStripMenuItem allToolStripMenuItem1;
        private ToolStripMenuItem inverseSelectionToolStripMenuItem;
        private ToolStripMenuItem thisOneToolStripMenuItem2;
        private ToolStripMenuItem allSelectedToolStripMenuItem2;
        private ToolStripMenuItem allToolStripMenuItem2;
        private Label label1;
    }
}
