namespace foot2rue.WF
{
    partial class InitialSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialSetupForm));
            label_AppName = new Label();
            button_Quit = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label_AppName
            // 
            resources.ApplyResources(label_AppName, "label_AppName");
            label_AppName.Name = "label_AppName";
            // 
            // button_Quit
            // 
            resources.ApplyResources(button_Quit, "button_Quit");
            button_Quit.Name = "button_Quit";
            button_Quit.Tag = "{button_Quit}";
            button_Quit.UseVisualStyleBackColor = true;
            button_Quit.Click += button_Quit_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // InitialSetupForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(button_Quit);
            Controls.Add(panel1);
            Controls.Add(label_AppName);
            Name = "InitialSetupForm";
            Load += InitialSetupForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_AppName;
        private Button button_Quit;
        private Panel panel1;
    }
}