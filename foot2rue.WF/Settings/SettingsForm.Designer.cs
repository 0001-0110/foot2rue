namespace foot2rue.WF.Settings
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_Save = new Button();
            button_Cancel = new Button();
            comboBox_LanguageSelection = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            checkBox_OfflineModeSelection = new CheckBox();
            SuspendLayout();
            // 
            // button_Save
            // 
            button_Save.Location = new Point(380, 247);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(94, 29);
            button_Save.TabIndex = 0;
            button_Save.Tag = "{SaveSettings}";
            button_Save.Text = "button1";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += button_Save_Click;
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new Point(149, 247);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(94, 29);
            button_Cancel.TabIndex = 1;
            button_Cancel.Tag = "{Cancel}";
            button_Cancel.Text = "button2";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += button_Cancel_Click;
            // 
            // comboBox_LanguageSelection
            // 
            comboBox_LanguageSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_LanguageSelection.FormattingEnabled = true;
            comboBox_LanguageSelection.Location = new Point(323, 94);
            comboBox_LanguageSelection.Name = "comboBox_LanguageSelection";
            comboBox_LanguageSelection.Size = new Size(151, 28);
            comboBox_LanguageSelection.TabIndex = 2;
            comboBox_LanguageSelection.Tag = "{LanguageSelection}:";
            comboBox_LanguageSelection.SelectedIndexChanged += comboBox_LanguageSelection_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(286, 27);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Tag = "{Settings}";
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.ForeColor = Color.White;
            label2.Location = new Point(149, 98);
            label2.Name = "label2";
            label2.Size = new Size(151, 28);
            label2.TabIndex = 5;
            label2.Tag = "{LanguageSelection}:";
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.Click += label2_Click;
            // 
            // checkBox_OfflineModeSelection
            // 
            checkBox_OfflineModeSelection.AutoSize = true;
            checkBox_OfflineModeSelection.ForeColor = Color.White;
            checkBox_OfflineModeSelection.Location = new Point(261, 163);
            checkBox_OfflineModeSelection.Name = "checkBox_OfflineModeSelection";
            checkBox_OfflineModeSelection.Size = new Size(101, 24);
            checkBox_OfflineModeSelection.TabIndex = 6;
            checkBox_OfflineModeSelection.Tag = "{OfflineModeSelection}";
            checkBox_OfflineModeSelection.Text = "checkBox1";
            checkBox_OfflineModeSelection.UseVisualStyleBackColor = true;
            checkBox_OfflineModeSelection.CheckedChanged += checkBox_OfflineModeSelection_CheckedChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(622, 313);
            Controls.Add(checkBox_OfflineModeSelection);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox_LanguageSelection);
            Controls.Add(button_Cancel);
            Controls.Add(button_Save);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "SettingsForm";
            Tag = "{Settings}";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Save;
        private Button button_Cancel;
        private ComboBox comboBox_LanguageSelection;
        private Label label1;
        private Label label2;
        private CheckBox checkBox_OfflineModeSelection;
    }
}