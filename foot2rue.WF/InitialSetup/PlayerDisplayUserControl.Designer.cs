namespace foot2rue.WF.InitialSetup
{
	partial class PlayerDisplayUserControl
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
            pictureBox_PlayerPicture = new PictureBox();
            label_Name = new Label();
            label_ShirtNumber = new Label();
            label_Position = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_PlayerPicture
            // 
            pictureBox_PlayerPicture.Image = Properties.Resources._default;
            pictureBox_PlayerPicture.Location = new Point(5, 5);
            pictureBox_PlayerPicture.Name = "pictureBox_PlayerPicture";
            pictureBox_PlayerPicture.Size = new Size(200, 200);
            pictureBox_PlayerPicture.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_PlayerPicture.TabIndex = 0;
            pictureBox_PlayerPicture.TabStop = false;
            // 
            // label_Name
            // 
            label_Name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_Name.Location = new Point(5, 210);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(200, 40);
            label_Name.TabIndex = 1;
            label_Name.Text = "label1";
            label_Name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_ShirtNumber
            // 
            label_ShirtNumber.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label_ShirtNumber.Location = new Point(5, 250);
            label_ShirtNumber.Name = "label_ShirtNumber";
            label_ShirtNumber.Size = new Size(200, 30);
            label_ShirtNumber.TabIndex = 2;
            label_ShirtNumber.Text = "label2";
            label_ShirtNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Position
            // 
            label_Position.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label_Position.Location = new Point(5, 280);
            label_Position.Name = "label_Position";
            label_Position.Size = new Size(200, 30);
            label_Position.TabIndex = 3;
            label_Position.Text = "label3";
            label_Position.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlayerDisplayUserControl
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(label_Position);
            Controls.Add(label_ShirtNumber);
            Controls.Add(label_Name);
            Controls.Add(pictureBox_PlayerPicture);
            Name = "PlayerDisplayUserControl";
            Size = new Size(210, 330);
            ((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_PlayerPicture;
        private Label label_Name;
        private Label label_ShirtNumber;
        private Label label_Position;
    }
}
