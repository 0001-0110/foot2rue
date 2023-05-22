namespace foot2rue.WF.MessageBoxes
{
    partial class ExitConfirmationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitConfirmationForm));
            button_Confirm = new Button();
            button_Cancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button_Confirm
            // 
            resources.ApplyResources(button_Confirm, "button_Confirm");
            button_Confirm.Name = "button_Confirm";
            button_Confirm.Tag = "{Button_Quit}";
            button_Confirm.UseVisualStyleBackColor = true;
            button_Confirm.Click += button_Confirm_Click;
            // 
            // button_Cancel
            // 
            resources.ApplyResources(button_Cancel, "button_Cancel");
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Tag = "{Button_Cancel}";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += button_Cancel_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Tag = "{Label_QuitConfirmation}";
            // 
            // ExitConfirmationForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(button_Cancel);
            Controls.Add(button_Confirm);
            Name = "ExitConfirmationForm";
            ResumeLayout(false);
        }

        #endregion

        private Button button_Confirm;
        private Button button_Cancel;
        private Label label1;
    }
}