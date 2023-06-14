namespace foot2rue.WF.HomePage
{
    partial class MatchDisplayUserControl
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
            panel_HomeTeam = new Panel();
            panel_AwayTeam = new Panel();
            pictureBox_Versus = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label_Venue = new Label();
            label_Location = new Label();
            label_Date = new Label();
            label_VisitorCount = new Label();
            pictureBox_VisitorIcon = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Versus).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_VisitorIcon).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel_HomeTeam
            // 
            panel_HomeTeam.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel_HomeTeam.Location = new Point(3, 42);
            panel_HomeTeam.Margin = new Padding(0);
            panel_HomeTeam.Name = "panel_HomeTeam";
            panel_HomeTeam.Size = new Size(625, 150);
            panel_HomeTeam.TabIndex = 0;
            // 
            // panel_AwayTeam
            // 
            panel_AwayTeam.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel_AwayTeam.Location = new Point(869, 42);
            panel_AwayTeam.Margin = new Padding(0);
            panel_AwayTeam.Name = "panel_AwayTeam";
            panel_AwayTeam.Size = new Size(625, 150);
            panel_AwayTeam.TabIndex = 1;
            // 
            // pictureBox_Versus
            // 
            pictureBox_Versus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox_Versus.Image = Properties.Resources.versus;
            pictureBox_Versus.Location = new Point(631, 42);
            pictureBox_Versus.Name = "pictureBox_Versus";
            pictureBox_Versus.Size = new Size(235, 150);
            pictureBox_Versus.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Versus.TabIndex = 2;
            pictureBox_Versus.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label_Venue);
            flowLayoutPanel1.Controls.Add(label_Location);
            flowLayoutPanel1.Controls.Add(label_Date);
            flowLayoutPanel1.Location = new Point(0, 6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(866, 33);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label_Venue
            // 
            label_Venue.AutoSize = true;
            label_Venue.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label_Venue.Location = new Point(3, 0);
            label_Venue.Name = "label_Venue";
            label_Venue.Size = new Size(79, 31);
            label_Venue.TabIndex = 0;
            label_Venue.Text = "label1";
            // 
            // label_Location
            // 
            label_Location.AutoSize = true;
            label_Location.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_Location.Location = new Point(88, 0);
            label_Location.Name = "label_Location";
            label_Location.Size = new Size(65, 28);
            label_Location.TabIndex = 1;
            label_Location.Text = "label1";
            // 
            // label_Date
            // 
            label_Date.AutoSize = true;
            label_Date.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_Date.Location = new Point(159, 0);
            label_Date.Name = "label_Date";
            label_Date.Size = new Size(65, 28);
            label_Date.TabIndex = 2;
            label_Date.Text = "label1";
            // 
            // label_VisitorCount
            // 
            label_VisitorCount.AutoSize = true;
            label_VisitorCount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_VisitorCount.Location = new Point(521, 0);
            label_VisitorCount.Name = "label_VisitorCount";
            label_VisitorCount.Size = new Size(65, 28);
            label_VisitorCount.TabIndex = 2;
            label_VisitorCount.Text = "label1";
            // 
            // pictureBox_VisitorIcon
            // 
            pictureBox_VisitorIcon.Image = Properties.Resources.guests;
            pictureBox_VisitorIcon.Location = new Point(592, 3);
            pictureBox_VisitorIcon.Name = "pictureBox_VisitorIcon";
            pictureBox_VisitorIcon.Size = new Size(30, 30);
            pictureBox_VisitorIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_VisitorIcon.TabIndex = 3;
            pictureBox_VisitorIcon.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(pictureBox_VisitorIcon);
            flowLayoutPanel2.Controls.Add(label_VisitorCount);
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(869, 6);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(625, 33);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // MatchDisplayUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pictureBox_Versus);
            Controls.Add(panel_AwayTeam);
            Controls.Add(panel_HomeTeam);
            Name = "MatchDisplayUserControl";
            Size = new Size(1500, 200);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Versus).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_VisitorIcon).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_HomeTeam;
        private Panel panel_AwayTeam;
        private PictureBox pictureBox_Versus;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label_Venue;
        private Label label_Location;
        private Label label_VisitorCount;
        private PictureBox pictureBox_VisitorIcon;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label_Date;
    }
}
