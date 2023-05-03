namespace foot2rue.WF.InitialSetup
{
    partial class TeamSelectionUserControl
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
            comboBox_TeamSelection = new ComboBox();
            comboBox_GenreSelection = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(109, 186);
            button1.Name = "button1";
            button1.Size = new Size(80, 35);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox_TeamSelection
            // 
            comboBox_TeamSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TeamSelection.FormattingEnabled = true;
            comboBox_TeamSelection.Location = new Point(78, 132);
            comboBox_TeamSelection.Name = "comboBox_TeamSelection";
            comboBox_TeamSelection.Size = new Size(151, 28);
            comboBox_TeamSelection.TabIndex = 1;
            comboBox_TeamSelection.SelectedIndexChanged += comboBox_TeamSelection_SelectedIndexChanged;
            // 
            // comboBox_GenreSelection
            // 
            comboBox_GenreSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_GenreSelection.FormattingEnabled = true;
            comboBox_GenreSelection.Location = new Point(78, 82);
            comboBox_GenreSelection.Name = "comboBox_GenreSelection";
            comboBox_GenreSelection.Size = new Size(151, 28);
            comboBox_GenreSelection.TabIndex = 2;
            comboBox_GenreSelection.SelectedIndexChanged += comboBox_GenreSelection_SelectedIndexChanged;
            // 
            // TeamSelectionUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox_GenreSelection);
            Controls.Add(comboBox_TeamSelection);
            Controls.Add(button1);
            Name = "TeamSelectionUserControl";
            Size = new Size(304, 274);
            Load += TeamSelectionUserControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ComboBox comboBox_TeamSelection;
        private ComboBox comboBox_GenreSelection;
    }
}
