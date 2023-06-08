namespace foot2rue.WF.HomePage
{

    partial class HomePageForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            toolStripComboBox_GenreSelection = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripComboBox_TeamSelection = new ToolStripComboBox();
            toolStripButton_Settings = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_Print = new ToolStripButton();
            tabControl_Rankings = new TabControl();
            tabPage_Favorites = new TabPage();
            tabPage_AllPlayers = new TabPage();
            tabPage_Matches = new TabPage();
            toolStrip.SuspendLayout();
            tabControl_Rankings.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripComboBox_GenreSelection, toolStripSeparator1, toolStripComboBox_TeamSelection, toolStripButton_Settings, toolStripSeparator2, toolStripButton_Print });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1582, 28);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripComboBox_GenreSelection
            // 
            toolStripComboBox_GenreSelection.BackColor = Color.Black;
            toolStripComboBox_GenreSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_GenreSelection.ForeColor = Color.White;
            toolStripComboBox_GenreSelection.Name = "toolStripComboBox_GenreSelection";
            toolStripComboBox_GenreSelection.Size = new Size(121, 28);
            toolStripComboBox_GenreSelection.SelectedIndexChanged += toolStripComboBox_GenreSelection_SelectedIndexChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // toolStripComboBox_TeamSelection
            // 
            toolStripComboBox_TeamSelection.BackColor = Color.Black;
            toolStripComboBox_TeamSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_TeamSelection.ForeColor = Color.White;
            toolStripComboBox_TeamSelection.Name = "toolStripComboBox_TeamSelection";
            toolStripComboBox_TeamSelection.Size = new Size(121, 28);
            toolStripComboBox_TeamSelection.SelectedIndexChanged += toolStripComboBox_TeamSelection_SelectedIndexChanged;
            // 
            // toolStripButton_Settings
            // 
            toolStripButton_Settings.Alignment = ToolStripItemAlignment.Right;
            toolStripButton_Settings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Settings.Image = Properties.Resources.settings;
            toolStripButton_Settings.ImageTransparentColor = Color.Magenta;
            toolStripButton_Settings.Name = "toolStripButton_Settings";
            toolStripButton_Settings.RightToLeft = RightToLeft.No;
            toolStripButton_Settings.Size = new Size(29, 25);
            toolStripButton_Settings.Tag = "{Settings}";
            toolStripButton_Settings.Text = "toolStripButton1";
            toolStripButton_Settings.Click += toolStripButton_Settings_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // toolStripButton_Print
            // 
            toolStripButton_Print.Alignment = ToolStripItemAlignment.Right;
            toolStripButton_Print.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Print.Image = Properties.Resources.print;
            toolStripButton_Print.ImageTransparentColor = Color.Magenta;
            toolStripButton_Print.Name = "toolStripButton_Print";
            toolStripButton_Print.RightToLeft = RightToLeft.No;
            toolStripButton_Print.Size = new Size(29, 25);
            toolStripButton_Print.Tag = "{Print}";
            toolStripButton_Print.Text = "toolStripButton1";
            // 
            // tabControl_Rankings
            // 
            tabControl_Rankings.Controls.Add(tabPage_Favorites);
            tabControl_Rankings.Controls.Add(tabPage_AllPlayers);
            tabControl_Rankings.Controls.Add(tabPage_Matches);
            tabControl_Rankings.Dock = DockStyle.Fill;
            tabControl_Rankings.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl_Rankings.Location = new Point(0, 28);
            tabControl_Rankings.Name = "tabControl_Rankings";
            tabControl_Rankings.SelectedIndex = 0;
            tabControl_Rankings.Size = new Size(1582, 825);
            tabControl_Rankings.TabIndex = 1;
            tabControl_Rankings.Tag = "";
            tabControl_Rankings.DrawItem += tabControl1_DrawItem;
            tabControl_Rankings.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage_Favorites
            // 
            tabPage_Favorites.BackColor = Color.FromArgb(51, 51, 51);
            tabPage_Favorites.Location = new Point(4, 29);
            tabPage_Favorites.Name = "tabPage_Favorites";
            tabPage_Favorites.Padding = new Padding(3);
            tabPage_Favorites.Size = new Size(1574, 792);
            tabPage_Favorites.TabIndex = 0;
            tabPage_Favorites.Tag = "{FavoritePlayers}";
            tabPage_Favorites.Text = "Favorites";
            // 
            // tabPage_AllPlayers
            // 
            tabPage_AllPlayers.BackColor = Color.FromArgb(51, 51, 51);
            tabPage_AllPlayers.Location = new Point(4, 29);
            tabPage_AllPlayers.Name = "tabPage_AllPlayers";
            tabPage_AllPlayers.Padding = new Padding(3);
            tabPage_AllPlayers.Size = new Size(1574, 792);
            tabPage_AllPlayers.TabIndex = 1;
            tabPage_AllPlayers.Tag = "{AllPlayers}";
            tabPage_AllPlayers.Text = "All Players";
            // 
            // tabPage_Matches
            // 
            tabPage_Matches.BackColor = Color.FromArgb(51, 51, 51);
            tabPage_Matches.Location = new Point(4, 29);
            tabPage_Matches.Name = "tabPage_Matches";
            tabPage_Matches.Size = new Size(1574, 792);
            tabPage_Matches.TabIndex = 2;
            tabPage_Matches.Tag = "{Matches}";
            tabPage_Matches.Text = "tabPage1";
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1582, 853);
            Controls.Add(tabControl_Rankings);
            Controls.Add(toolStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HomePageForm";
            Text = "Foot2rue";
            FormClosing += HomePageForm_FormClosing;
            Shown += HomePageForm_Shown;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            tabControl_Rankings.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripComboBox toolStripComboBox_GenreSelection;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox toolStripComboBox_TeamSelection;
        private ToolStripButton toolStripButton_Settings;
        private TabControl tabControl_Rankings;
        private TabPage tabPage_Favorites;
        private TabPage tabPage_AllPlayers;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton_Print;
        private TabPage tabPage_Matches;
    }
}