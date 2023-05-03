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
            dataGridView = new DataGridView();
            pictureBox_Loading = new PictureBox();
            pictureBox_NoData = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_NoData).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(628, 373);
            dataGridView.TabIndex = 0;
            // 
            // pictureBox_Loading
            // 
            pictureBox_Loading.Location = new Point(249, 156);
            pictureBox_Loading.Name = "pictureBox_Loading";
            pictureBox_Loading.Size = new Size(125, 62);
            pictureBox_Loading.TabIndex = 1;
            pictureBox_Loading.TabStop = false;
            // 
            // pictureBox_NoData
            // 
            pictureBox_NoData.Location = new Point(275, 194);
            pictureBox_NoData.Name = "pictureBox_NoData";
            pictureBox_NoData.Size = new Size(125, 62);
            pictureBox_NoData.TabIndex = 2;
            pictureBox_NoData.TabStop = false;
            // 
            // DataDisplay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox_NoData);
            Controls.Add(pictureBox_Loading);
            Controls.Add(dataGridView);
            Name = "DataDisplay";
            Size = new Size(628, 373);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_NoData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private PictureBox pictureBox_Loading;
        private PictureBox pictureBox_NoData;
    }
}
