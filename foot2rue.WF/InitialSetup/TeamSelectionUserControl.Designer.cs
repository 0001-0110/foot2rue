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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(251, 231);
            button1.Name = "button1";
            button1.Size = new Size(80, 35);
            button1.TabIndex = 0;
            button1.Tag = "{Ok}";
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox_TeamSelection
            // 
            comboBox_TeamSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TeamSelection.FormattingEnabled = true;
            comboBox_TeamSelection.Location = new Point(302, 166);
            comboBox_TeamSelection.Name = "comboBox_TeamSelection";
            comboBox_TeamSelection.Size = new Size(151, 28);
            comboBox_TeamSelection.TabIndex = 1;
            comboBox_TeamSelection.SelectedIndexChanged += comboBox_TeamSelection_SelectedIndexChanged;
            // 
            // comboBox_GenreSelection
            // 
            comboBox_GenreSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_GenreSelection.FormattingEnabled = true;
            comboBox_GenreSelection.Location = new Point(302, 84);
            comboBox_GenreSelection.Name = "comboBox_GenreSelection";
            comboBox_GenreSelection.Size = new Size(151, 28);
            comboBox_GenreSelection.TabIndex = 2;
            comboBox_GenreSelection.SelectedIndexChanged += comboBox_GenreSelection_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.ForeColor = Color.White;
            label1.Location = new Point(35, 87);
            label1.Name = "label1";
            label1.Size = new Size(240, 20);
            label1.TabIndex = 3;
            label1.Tag = "{Label_GenreSelection}:";
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 169);
            label2.Name = "label2";
            label2.Size = new Size(240, 20);
            label2.TabIndex = 4;
            label2.Tag = "{Label_TeamSelection}:";
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TeamSelectionUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox_GenreSelection);
            Controls.Add(comboBox_TeamSelection);
            Controls.Add(button1);
            Name = "TeamSelectionUserControl";
            Size = new Size(622, 313);
            Load += TeamSelectionUserControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ComboBox comboBox_TeamSelection;
        private ComboBox comboBox_GenreSelection;
        private Label label1;
        private Label label2;
    }
}
