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
            button_Confirm = new Button();
            button_Cancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button_Confirm
            // 
            button_Confirm.Location = new Point(690, 264);
            button_Confirm.Name = "button_Confirm";
            button_Confirm.Size = new Size(94, 29);
            button_Confirm.TabIndex = 0;
            button_Confirm.Text = "button1";
            button_Confirm.UseVisualStyleBackColor = true;
            button_Confirm.Click += button1_Click;
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new Point(563, 261);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(94, 29);
            button_Cancel.TabIndex = 1;
            button_Cancel.Text = "button2";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(655, 159);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // ExitConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button_Cancel);
            Controls.Add(button_Confirm);
            Name = "ExitConfirmationForm";
            Text = "ExitConfirmationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Confirm;
        private Button button_Cancel;
        private Label label1;
    }
}