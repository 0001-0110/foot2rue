namespace foot2rue.WF.HomePage
{
    partial class DataDisplay
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
            pictureBox_Error = new PictureBox();
            pictureBox_Loading = new PictureBox();
            pictureBox_NoData = new PictureBox();
            flowLayoutPanel_DataPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Error).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_NoData).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Error
            // 
            pictureBox_Error.Dock = DockStyle.Fill;
            pictureBox_Error.Location = new Point(0, 0);
            pictureBox_Error.Name = "pictureBox_Error";
            pictureBox_Error.Size = new Size(628, 373);
            pictureBox_Error.TabIndex = 3;
            pictureBox_Error.TabStop = false;
            // 
            // pictureBox_Loading
            // 
            pictureBox_Loading.BackgroundImageLayout = ImageLayout.None;
            pictureBox_Loading.Dock = DockStyle.Fill;
            pictureBox_Loading.Image = Properties.Resources.Soccer_Ball_Hexagon_Pattern_Loader;
            pictureBox_Loading.Location = new Point(0, 0);
            pictureBox_Loading.Name = "pictureBox_Loading";
            pictureBox_Loading.Size = new Size(628, 373);
            pictureBox_Loading.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Loading.TabIndex = 1;
            pictureBox_Loading.TabStop = false;
            // 
            // pictureBox_NoData
            // 
            pictureBox_NoData.Dock = DockStyle.Fill;
            pictureBox_NoData.Location = new Point(0, 0);
            pictureBox_NoData.Name = "pictureBox_NoData";
            pictureBox_NoData.Size = new Size(628, 373);
            pictureBox_NoData.TabIndex = 2;
            pictureBox_NoData.TabStop = false;
            // 
            // flowLayoutPanel_DataPanel
            // 
            flowLayoutPanel_DataPanel.AutoScroll = true;
            flowLayoutPanel_DataPanel.Dock = DockStyle.Fill;
            flowLayoutPanel_DataPanel.Location = new Point(0, 0);
            flowLayoutPanel_DataPanel.Name = "flowLayoutPanel_DataPanel";
            flowLayoutPanel_DataPanel.Size = new Size(628, 373);
            flowLayoutPanel_DataPanel.TabIndex = 4;
            // 
            // DataDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox_Error);
            Controls.Add(pictureBox_NoData);
            Controls.Add(pictureBox_Loading);
            Controls.Add(flowLayoutPanel_DataPanel);
            Name = "DataDisplay";
            Size = new Size(628, 373);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Error).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_NoData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel_DataPanel;
        private PictureBox pictureBox_Error;
        private PictureBox pictureBox_NoData;
        private PictureBox pictureBox_Loading;
    }
}
