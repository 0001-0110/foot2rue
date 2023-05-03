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
            button1 = new Button();
            flowLayoutPanel_FavoritePlayers = new FlowLayoutPanel();
            flowLayoutPanel_AllPlayers = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(183, 300);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_Validate_Click;
            // 
            // flowLayoutPanel_FavoritePlayers
            // 
            flowLayoutPanel_FavoritePlayers.AllowDrop = true;
            flowLayoutPanel_FavoritePlayers.AutoScroll = true;
            flowLayoutPanel_FavoritePlayers.Location = new Point(432, 37);
            flowLayoutPanel_FavoritePlayers.Name = "flowLayoutPanel_FavoritePlayers";
            flowLayoutPanel_FavoritePlayers.Size = new Size(410, 250);
            flowLayoutPanel_FavoritePlayers.TabIndex = 1;
            flowLayoutPanel_FavoritePlayers.DragDrop += flowLayoutPanel_DragDrop;
            flowLayoutPanel_FavoritePlayers.DragEnter += flowLayoutPanel_DragEnter;
            // 
            // flowLayoutPanel_AllPlayers
            // 
            flowLayoutPanel_AllPlayers.AllowDrop = true;
            flowLayoutPanel_AllPlayers.AutoScroll = true;
            flowLayoutPanel_AllPlayers.Location = new Point(37, 37);
            flowLayoutPanel_AllPlayers.Name = "flowLayoutPanel_AllPlayers";
            flowLayoutPanel_AllPlayers.Size = new Size(371, 250);
            flowLayoutPanel_AllPlayers.TabIndex = 2;
            flowLayoutPanel_AllPlayers.DragDrop += flowLayoutPanel_DragDrop;
            flowLayoutPanel_AllPlayers.DragEnter += flowLayoutPanel_DragEnter;
            // 
            // FavoritesSelectionUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel_AllPlayers);
            Controls.Add(flowLayoutPanel_FavoritePlayers);
            Controls.Add(button1);
            Name = "FavoritesSelectionUserControl";
            Size = new Size(873, 373);
            Load += FavoritesSelectionUserControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private FlowLayoutPanel flowLayoutPanel_FavoritePlayers;
        private FlowLayoutPanel flowLayoutPanel_AllPlayers;
    }
}
