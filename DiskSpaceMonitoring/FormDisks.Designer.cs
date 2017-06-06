namespace DiskSpaceMonitoring
{
    partial class FormDisks
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDisks));
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tabPageDisks = new System.Windows.Forms.TabPage();
            this.chartRoot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDownloads = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVideo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControlDisks = new System.Windows.Forms.TabControl();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBoxServerUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.tabPageSettings.SuspendLayout();
            this.tabPageDisks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDownloads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVideo)).BeginInit();
            this.tabControlDisks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.buttonSaveSettings);
            this.tabPageSettings.Controls.Add(this.labelUrl);
            this.tabPageSettings.Controls.Add(this.textBoxServerUrl);
            this.tabPageSettings.Controls.Add(this.checkedListBox1);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 25);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(1107, 367);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // tabPageDisks
            // 
            this.tabPageDisks.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPageDisks.Controls.Add(this.chartRoot);
            this.tabPageDisks.Controls.Add(this.chartDownloads);
            this.tabPageDisks.Controls.Add(this.chartVideo);
            this.tabPageDisks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageDisks.Location = new System.Drawing.Point(4, 25);
            this.tabPageDisks.Name = "tabPageDisks";
            this.tabPageDisks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisks.Size = new System.Drawing.Size(1107, 367);
            this.tabPageDisks.TabIndex = 0;
            this.tabPageDisks.Text = "Disks";
            // 
            // chartRoot
            // 
            this.chartRoot.BackColor = System.Drawing.Color.Transparent;
            this.chartRoot.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Inclination = 40;
            chartArea1.BackColor = System.Drawing.SystemColors.Menu;
            chartArea1.Name = "ChartAreaVideo";
            this.chartRoot.ChartAreas.Add(chartArea1);
            this.chartRoot.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartRoot.Location = new System.Drawing.Point(729, 3);
            this.chartRoot.Name = "chartRoot";
            this.chartRoot.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series1.ChartArea = "ChartAreaVideo";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series1.Name = "SeriesUsed";
            this.chartRoot.Series.Add(series1);
            this.chartRoot.Size = new System.Drawing.Size(363, 361);
            this.chartRoot.TabIndex = 5;
            this.chartRoot.Text = "chart2";
            title1.DockedToChartArea = "ChartAreaVideo";
            title1.DockingOffset = 42;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "Root";
            this.chartRoot.Titles.Add(title1);
            // 
            // chartDownloads
            // 
            this.chartDownloads.BackColor = System.Drawing.Color.Transparent;
            this.chartDownloads.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.Area3DStyle.Inclination = 40;
            chartArea2.BackColor = System.Drawing.SystemColors.Menu;
            chartArea2.Name = "ChartAreaVideo";
            this.chartDownloads.ChartAreas.Add(chartArea2);
            this.chartDownloads.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartDownloads.Location = new System.Drawing.Point(366, 3);
            this.chartDownloads.Name = "chartDownloads";
            this.chartDownloads.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series2.ChartArea = "ChartAreaVideo";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series2.Name = "SeriesUsed";
            this.chartDownloads.Series.Add(series2);
            this.chartDownloads.Size = new System.Drawing.Size(363, 361);
            this.chartDownloads.TabIndex = 4;
            this.chartDownloads.Text = "chart1";
            title2.DockedToChartArea = "ChartAreaVideo";
            title2.DockingOffset = 42;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Title1";
            title2.Text = "Downloads";
            this.chartDownloads.Titles.Add(title2);
            // 
            // chartVideo
            // 
            this.chartVideo.BackColor = System.Drawing.Color.Transparent;
            this.chartVideo.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea3.Area3DStyle.Inclination = 40;
            chartArea3.BackColor = System.Drawing.SystemColors.Menu;
            chartArea3.Name = "ChartAreaVideo";
            this.chartVideo.ChartAreas.Add(chartArea3);
            this.chartVideo.Dock = System.Windows.Forms.DockStyle.Left;
            this.chartVideo.Location = new System.Drawing.Point(3, 3);
            this.chartVideo.Name = "chartVideo";
            this.chartVideo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            series3.ChartArea = "ChartAreaVideo";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series3.Name = "SeriesUsed";
            this.chartVideo.Series.Add(series3);
            this.chartVideo.Size = new System.Drawing.Size(363, 361);
            this.chartVideo.TabIndex = 3;
            this.chartVideo.Text = "chartVideo";
            title3.DockedToChartArea = "ChartAreaVideo";
            title3.DockingOffset = 42;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title3.Name = "Title1";
            title3.Text = "Video";
            this.chartVideo.Titles.Add(title3);
            // 
            // tabControlDisks
            // 
            this.tabControlDisks.Controls.Add(this.tabPageDisks);
            this.tabControlDisks.Controls.Add(this.tabPageSettings);
            this.tabControlDisks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDisks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlDisks.Location = new System.Drawing.Point(0, 0);
            this.tabControlDisks.Name = "tabControlDisks";
            this.tabControlDisks.SelectedIndex = 0;
            this.tabControlDisks.Size = new System.Drawing.Size(1115, 396);
            this.tabControlDisks.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(11, 36);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(514, 310);
            this.checkedListBox1.TabIndex = 0;
            // 
            // textBoxServerUrl
            // 
            this.textBoxServerUrl.Location = new System.Drawing.Point(92, 8);
            this.textBoxServerUrl.Name = "textBoxServerUrl";
            this.textBoxServerUrl.Size = new System.Drawing.Size(1007, 22);
            this.textBoxServerUrl.TabIndex = 1;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(8, 11);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(78, 16);
            this.labelUrl.TabIndex = 2;
            this.labelUrl.Text = "Server URL";
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveSettings.Location = new System.Drawing.Point(1026, 338);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 3;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // FormDisks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 396);
            this.Controls.Add(this.tabControlDisks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDisks";
            this.Text = "Disk Space Viewer";
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.tabPageDisks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDownloads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVideo)).EndInit();
            this.tabControlDisks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageDisks;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRoot;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDownloads;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVideo;
        private System.Windows.Forms.TabControl tabControlDisks;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxServerUrl;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonSaveSettings;
    }
}

