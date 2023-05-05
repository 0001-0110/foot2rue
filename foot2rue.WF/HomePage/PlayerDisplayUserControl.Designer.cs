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
            ((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Favorite).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_PlayerPicture
            // 
            pictureBox_PlayerPicture.Location = new Point(32, 52);
            pictureBox_PlayerPicture.Name = "pictureBox_PlayerPicture";
            pictureBox_PlayerPicture.Size = new Size(125, 62);
            pictureBox_PlayerPicture.TabIndex = 0;
            pictureBox_PlayerPicture.TabStop = false;
            // 
            // label_FullName
            // 
            label_FullName.AutoSize = true;
            label_FullName.Location = new Point(237, 94);
            label_FullName.Name = "label_FullName";
            label_FullName.Size = new Size(50, 20);
            label_FullName.TabIndex = 1;
            label_FullName.Text = "label1";
            // 
            // label_GoalCount
            // 
            label_GoalCount.AutoSize = true;
            label_GoalCount.Location = new Point(404, 104);
            label_GoalCount.Name = "label_GoalCount";
            label_GoalCount.Size = new Size(50, 20);
            label_GoalCount.TabIndex = 2;
            label_GoalCount.Text = "label2";
            // 
            // label_YellowCardsCount
            // 
            label_YellowCardsCount.AutoSize = true;
            label_YellowCardsCount.Location = new Point(544, 108);
            label_YellowCardsCount.Name = "label_YellowCardsCount";
            label_YellowCardsCount.Size = new Size(50, 20);
            label_YellowCardsCount.TabIndex = 3;
            label_YellowCardsCount.Text = "label3";
            // 
            // pictureBox_Favorite
            // 
            pictureBox_Favorite.Location = new Point(180, 40);
            pictureBox_Favorite.Name = "pictureBox_Favorite";
            pictureBox_Favorite.Size = new Size(18, 14);
            pictureBox_Favorite.TabIndex = 4;
            pictureBox_Favorite.TabStop = false;
            // 
            // PlayerDisplayUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox_Favorite);
            Controls.Add(label_YellowCardsCount);
            Controls.Add(label_GoalCount);
            Controls.Add(label_FullName);
            Controls.Add(pictureBox_PlayerPicture);
            Name = "PlayerDisplayUserControl";
            Size = new Size(897, 235);
            ((System.ComponentModel.ISupportInitialize)pictureBox_PlayerPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Favorite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_PlayerPicture;
        private Label label_FullName;
        private Label label_GoalCount;
        private Label label_YellowCardsCount;
        private PictureBox pictureBox_Favorite;
    }
}
