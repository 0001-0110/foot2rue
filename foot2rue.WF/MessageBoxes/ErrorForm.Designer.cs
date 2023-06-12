namespace foot2rue.WF.MessageBoxes
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            label1 = new Label();
            button_Confirm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Tag = "{InitialSetupFailure}";
            // 
            // button_Confirm
            // 
            resources.ApplyResources(button_Confirm, "button_Confirm");
            button_Confirm.Name = "button_Confirm";
            button_Confirm.Tag = "{Quit}";
            button_Confirm.UseVisualStyleBackColor = true;
            button_Confirm.Click += button_Confirm_Click;
            // 
            // InitialSetupFailureForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            Controls.Add(label1);
            Controls.Add(button_Confirm);
            Name = "InitialSetupFailureForm";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button_Confirm;
    }
}