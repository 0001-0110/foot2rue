namespace foot2rue.WF.HomePage
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
            label_FullName = new Label();
            label_GoalCount = new Label();
            label_YellowCardsCount = new Label();
            pictureBox_Favorite = new PictureBox();
            label_Position = new Label();
            pictureBox_IsCaptain = new PictureBox();
            label_RedCardsCount = new Label();
            label_MatchPlayed = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Favorite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_IsCaptain).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_PlayerPicture
            // 
            pictureBox_PlayerPicture.Image = Properties.Resources._default;
            pictureBox_PlayerPicture.Location = new Point(0, 0);
            pictureBox_PlayerPicture.Name = "pictureBox_PlayerPicture";
            pictureBox_PlayerPicture.Size = new Size(198, 150);
            pictureBox_PlayerPicture.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_PlayerPicture.TabIndex = 0;
            pictureBox_PlayerPicture.TabStop = false;
            // 
            // label_FullName
            // 
            label_FullName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label_FullName.Location = new Point(204, 13);
            label_FullName.Name = "label_FullName";
            label_FullName.Size = new Size(247, 41);
            label_FullName.TabIndex = 1;
            label_FullName.Text = "label1";
            label_FullName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_GoalCount
            // 
            label_GoalCount.AutoSize = true;
            label_GoalCount.Location = new Point(457, 45);
            label_GoalCount.Name = "label_GoalCount";
            label_GoalCount.Size = new Size(50, 20);
            label_GoalCount.TabIndex = 2;
            label_GoalCount.Text = "label2";
            // 
            // label_YellowCardsCount
            // 
            label_YellowCardsCount.AutoSize = true;
            label_YellowCardsCount.Location = new Point(457, 77);
            label_YellowCardsCount.Name = "label_YellowCardsCount";
            label_YellowCardsCount.Size = new Size(50, 20);
            label_YellowCardsCount.TabIndex = 3;
            label_YellowCardsCount.Text = "label3";
            // 
            // pictureBox_Favorite
            // 
            pictureBox_Favorite.Image = Properties.Resources.star;
            pictureBox_Favorite.Location = new Point(690, 3);
            pictureBox_Favorite.Name = "pictureBox_Favorite";
            pictureBox_Favorite.Size = new Size(57, 42);
            pictureBox_Favorite.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Favorite.TabIndex = 4;
            pictureBox_Favorite.TabStop = false;
            pictureBox_Favorite.Click += pictureBox_Favorite_Click;
            // 
            // label_Position
            // 
            label_Position.AutoSize = true;
            label_Position.Location = new Point(204, 54);
            label_Position.Name = "label_Position";
            label_Position.Size = new Size(50, 20);
            label_Position.TabIndex = 5;
            label_Position.Text = "label2";
            // 
            // pictureBox_IsCaptain
            // 
            pictureBox_IsCaptain.Image = Properties.Resources.captain_band;
            pictureBox_IsCaptain.Location = new Point(151, 3);
            pictureBox_IsCaptain.Name = "pictureBox_IsCaptain";
            pictureBox_IsCaptain.Size = new Size(47, 30);
            pictureBox_IsCaptain.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_IsCaptain.TabIndex = 6;
            pictureBox_IsCaptain.TabStop = false;
            // 
            // label_RedCardsCount
            // 
            label_RedCardsCount.AutoSize = true;
            label_RedCardsCount.Location = new Point(457, 109);
            label_RedCardsCount.Name = "label_RedCardsCount";
            label_RedCardsCount.Size = new Size(50, 20);
            label_RedCardsCount.TabIndex = 7;
            label_RedCardsCount.Text = "label3";
            // 
            // label_MatchPlayed
            // 
            label_MatchPlayed.AutoSize = true;
            label_MatchPlayed.Location = new Point(457, 13);
            label_MatchPlayed.Name = "label_MatchPlayed";
            label_MatchPlayed.Size = new Size(50, 20);
            label_MatchPlayed.TabIndex = 8;
            label_MatchPlayed.Text = "label2";
            // 
            // PlayerDisplayUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(label_MatchPlayed);
            Controls.Add(label_RedCardsCount);
            Controls.Add(pictureBox_IsCaptain);
            Controls.Add(label_Position);
            Controls.Add(pictureBox_Favorite);
            Controls.Add(label_YellowCardsCount);
            Controls.Add(label_GoalCount);
            Controls.Add(label_FullName);
            Controls.Add(pictureBox_PlayerPicture);
            Name = "PlayerDisplayUserControl";
            Size = new Size(750, 150);
            ((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Favorite).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_IsCaptain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_PlayerPicture;
        private Label label_FullName;
        private Label label_GoalCount;
        private Label label_YellowCardsCount;
        private PictureBox pictureBox_Favorite;
        private Label label_Position;
        private PictureBox pictureBox_IsCaptain;
        private Label label_RedCardsCount;
        private Label label_MatchPlayed;
    }
}
