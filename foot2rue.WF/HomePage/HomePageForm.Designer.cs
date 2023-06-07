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
            toolStrip1 = new ToolStrip();
            toolStripComboBox_GenreSelection = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripComboBox_TeamSelection = new ToolStripComboBox();
            toolStripButton_Settings = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_Print = new ToolStripButton();
            tabControl1 = new TabControl();
            favoriteTabPage = new TabPage();
            allPlayersTabPage = new TabPage();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox_GenreSelection, toolStripSeparator1, toolStripComboBox_TeamSelection, toolStripButton_Settings, toolStripSeparator2, toolStripButton_Print });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1582, 28);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
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
            // tabControl1
            // 
            tabControl1.Controls.Add(favoriteTabPage);
            tabControl1.Controls.Add(allPlayersTabPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Location = new Point(0, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1582, 825);
            tabControl1.TabIndex = 1;
            tabControl1.Tag = "";
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // favoriteTabPage
            // 
            favoriteTabPage.BackColor = Color.FromArgb(51, 51, 51);
            favoriteTabPage.Location = new Point(4, 29);
            favoriteTabPage.Name = "favoriteTabPage";
            favoriteTabPage.Padding = new Padding(3);
            favoriteTabPage.Size = new Size(1574, 792);
            favoriteTabPage.TabIndex = 0;
            favoriteTabPage.Tag = "{FavoritePlayers}";
            favoriteTabPage.Text = "Favorites";
            // 
            // allPlayersTabPage
            // 
            allPlayersTabPage.BackColor = Color.FromArgb(51, 51, 51);
            allPlayersTabPage.Location = new Point(4, 29);
            allPlayersTabPage.Name = "allPlayersTabPage";
            allPlayersTabPage.Padding = new Padding(3);
            allPlayersTabPage.Size = new Size(1574, 792);
            allPlayersTabPage.TabIndex = 1;
            allPlayersTabPage.Tag = "{AllPlayers}";
            allPlayersTabPage.Text = "All Players";
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1582, 853);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HomePageForm";
            Text = "Foot2rue";
            FormClosing += HomePageForm_FormClosing;
            Shown += HomePageForm_Shown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripComboBox toolStripComboBox_GenreSelection;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox toolStripComboBox_TeamSelection;
        private ToolStripButton toolStripButton_Settings;
        private TabControl tabControl1;
        private TabPage favoriteTabPage;
        private TabPage allPlayersTabPage;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton_Print;
    }
}