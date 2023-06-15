namespace foot2rue.WF.HomePage.Matches
{
    partial class TeamDisplayUserControl
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
            pictureBox_CountryFlag = new PictureBox();
            label_Attempts = new Label();
            label_RedCardsCount = new Label();
            label_Score = new Label();
            label_YellowCardsCount = new Label();
            label_Possession = new Label();
            label_TeamName = new Label();
            pictureBox_Winner = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_CountryFlag).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Winner).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_CountryFlag
            // 
            pictureBox_CountryFlag.Location = new Point(5, 5);
            pictureBox_CountryFlag.Name = "pictureBox_CountryFlag";
            pictureBox_CountryFlag.Size = new Size(140, 140);
            pictureBox_CountryFlag.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_CountryFlag.TabIndex = 0;
            pictureBox_CountryFlag.TabStop = false;
            // 
            // label_Attempts
            // 
            label_Attempts.AutoSize = true;
            label_Attempts.Location = new Point(409, 14);
            label_Attempts.Name = "label_Attempts";
            label_Attempts.Size = new Size(50, 20);
            label_Attempts.TabIndex = 15;
            label_Attempts.Text = "label2";
            // 
            // label_RedCardsCount
            // 
            label_RedCardsCount.AutoSize = true;
            label_RedCardsCount.Location = new Point(409, 110);
            label_RedCardsCount.Name = "label_RedCardsCount";
            label_RedCardsCount.Size = new Size(50, 20);
            label_RedCardsCount.TabIndex = 14;
            label_RedCardsCount.Text = "label3";
            // 
            // label_Score
            // 
            label_Score.AutoSize = true;
            label_Score.Location = new Point(156, 55);
            label_Score.Name = "label_Score";
            label_Score.Size = new Size(50, 20);
            label_Score.TabIndex = 12;
            label_Score.Text = "label2";
            // 
            // label_YellowCardsCount
            // 
            label_YellowCardsCount.AutoSize = true;
            label_YellowCardsCount.Location = new Point(409, 78);
            label_YellowCardsCount.Name = "label_YellowCardsCount";
            label_YellowCardsCount.Size = new Size(50, 20);
            label_YellowCardsCount.TabIndex = 11;
            label_YellowCardsCount.Text = "label3";
            // 
            // label_Possession
            // 
            label_Possession.AutoSize = true;
            label_Possession.Location = new Point(409, 46);
            label_Possession.Name = "label_Possession";
            label_Possession.Size = new Size(50, 20);
            label_Possession.TabIndex = 10;
            label_Possession.Text = "label2";
            // 
            // label_TeamName
            // 
            label_TeamName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label_TeamName.Location = new Point(156, 14);
            label_TeamName.Name = "label_TeamName";
            label_TeamName.Size = new Size(247, 41);
            label_TeamName.TabIndex = 9;
            label_TeamName.Text = "label1";
            label_TeamName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox_Winner
            // 
            pictureBox_Winner.BackColor = Color.Transparent;
            pictureBox_Winner.Image = Properties.Resources.winner;
            pictureBox_Winner.Location = new Point(105, 5);
            pictureBox_Winner.Name = "pictureBox_Winner";
            pictureBox_Winner.Size = new Size(40, 40);
            pictureBox_Winner.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Winner.TabIndex = 16;
            pictureBox_Winner.TabStop = false;
            // 
            // TeamDisplayUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(pictureBox_Winner);
            Controls.Add(label_Attempts);
            Controls.Add(label_RedCardsCount);
            Controls.Add(label_Score);
            Controls.Add(label_YellowCardsCount);
            Controls.Add(label_Possession);
            Controls.Add(label_TeamName);
            Controls.Add(pictureBox_CountryFlag);
            Name = "TeamDisplayUserControl";
            Size = new Size(625, 150);
            ((System.ComponentModel.ISupportInitialize)pictureBox_CountryFlag).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Winner).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_CountryFlag;
        private Label label_Attempts;
        private Label label_RedCardsCount;
        private Label label_Score;
        private Label label_YellowCardsCount;
        private Label label_Possession;
        private Label label_TeamName;
        private PictureBox pictureBox_Winner;
    }
}
