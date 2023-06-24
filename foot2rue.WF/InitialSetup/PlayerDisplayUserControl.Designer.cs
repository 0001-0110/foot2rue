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
			label_PlayerName = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).BeginInit();
			SuspendLayout();
			// 
			// pictureBox_PlayerPicture
			// 
			pictureBox_PlayerPicture.Location = new Point(1, 1);
			pictureBox_PlayerPicture.Name = "pictureBox_PlayerPicture";
			pictureBox_PlayerPicture.Size = new Size(198, 198);
			pictureBox_PlayerPicture.TabIndex = 0;
			pictureBox_PlayerPicture.TabStop = false;
			// 
			// label_PlayerName
			// 
			label_PlayerName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
			label_PlayerName.Location = new Point(1, 201);
			label_PlayerName.Name = "label_PlayerName";
			label_PlayerName.Size = new Size(198, 48);
			label_PlayerName.TabIndex = 1;
			label_PlayerName.Text = "label1";
			label_PlayerName.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// PlayerDisplayUserControl
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ActiveBorder;
			Controls.Add(label_PlayerName);
			Controls.Add(pictureBox_PlayerPicture);
			Name = "PlayerDisplayUserControl";
			Size = new Size(200, 250);
			((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox pictureBox_PlayerPicture;
		private Label label_PlayerName;
	}
}
