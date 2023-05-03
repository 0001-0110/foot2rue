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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageForm));
            toolStrip1 = new ToolStrip();
            toolStripComboBox_GenreSelection = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripComboBox_TeamSelection = new ToolStripComboBox();
            toolStripButton1 = new ToolStripButton();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox_GenreSelection, toolStripSeparator1, toolStripComboBox_TeamSelection, toolStripButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 28);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox_GenreSelection
            // 
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
            toolStripComboBox_TeamSelection.Name = "toolStripComboBox_TeamSelection";
            toolStripComboBox_TeamSelection.Size = new Size(121, 28);
            toolStripComboBox_TeamSelection.SelectedIndexChanged += toolStripComboBox_TeamSelection_SelectedIndexChanged;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.RightToLeft = RightToLeft.No;
            toolStripButton1.Size = new Size(29, 25);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(favoriteTabPage);
            tabControl1.Controls.Add(allPlayersTabPage);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 422);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // favoriteTabPage
            // 
            favoriteTabPage.Location = new Point(4, 29);
            favoriteTabPage.Name = "favoriteTabPage";
            favoriteTabPage.Padding = new Padding(3);
            favoriteTabPage.Size = new Size(792, 389);
            favoriteTabPage.TabIndex = 0;
            favoriteTabPage.Text = "Favorites";
            favoriteTabPage.UseVisualStyleBackColor = true;
            // 
            // allPlayersTabPage
            // 
            allPlayersTabPage.Location = new Point(4, 29);
            allPlayersTabPage.Name = "allPlayersTabPage";
            allPlayersTabPage.Padding = new Padding(3);
            allPlayersTabPage.Size = new Size(792, 389);
            allPlayersTabPage.TabIndex = 1;
            allPlayersTabPage.Text = "All Players";
            allPlayersTabPage.UseVisualStyleBackColor = true;
            // 
            // HomePageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
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
        private ToolStripButton toolStripButton1;
        private TabControl tabControl1;
        private TabPage favoriteTabPage;
        private TabPage allPlayersTabPage;
    }
}