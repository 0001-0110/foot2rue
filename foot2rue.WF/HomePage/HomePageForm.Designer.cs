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
            toolStripButton_Settings = new ToolStripButton();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox_GenreSelection, toolStripSeparator1, toolStripComboBox_TeamSelection, toolStripButton_Settings });
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.Name = "toolStrip1";
            // 
            // toolStripComboBox_GenreSelection
            // 
            toolStripComboBox_GenreSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_GenreSelection.Name = "toolStripComboBox_GenreSelection";
            resources.ApplyResources(toolStripComboBox_GenreSelection, "toolStripComboBox_GenreSelection");
            toolStripComboBox_GenreSelection.SelectedIndexChanged += toolStripComboBox_GenreSelection_SelectedIndexChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripComboBox_TeamSelection
            // 
            toolStripComboBox_TeamSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_TeamSelection.Name = "toolStripComboBox_TeamSelection";
            resources.ApplyResources(toolStripComboBox_TeamSelection, "toolStripComboBox_TeamSelection");
            toolStripComboBox_TeamSelection.SelectedIndexChanged += toolStripComboBox_TeamSelection_SelectedIndexChanged;
            // 
            // toolStripButton_Settings
            // 
            toolStripButton_Settings.Alignment = ToolStripItemAlignment.Right;
            toolStripButton_Settings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(toolStripButton_Settings, "toolStripButton_Settings");
            toolStripButton_Settings.Name = "toolStripButton_Settings";
            toolStripButton_Settings.Click += toolStripButton_Settings_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(favoriteTabPage);
            tabControl1.Controls.Add(allPlayersTabPage);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // favoriteTabPage
            // 
            resources.ApplyResources(favoriteTabPage, "favoriteTabPage");
            favoriteTabPage.Name = "favoriteTabPage";
            favoriteTabPage.UseVisualStyleBackColor = true;
            // 
            // allPlayersTabPage
            // 
            resources.ApplyResources(allPlayersTabPage, "allPlayersTabPage");
            allPlayersTabPage.Name = "allPlayersTabPage";
            allPlayersTabPage.UseVisualStyleBackColor = true;
            // 
            // HomePageForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Name = "HomePageForm";
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
    }
}