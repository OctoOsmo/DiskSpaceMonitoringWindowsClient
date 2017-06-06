using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiskSpaceMonitoring
{
    public partial class FormDisks : Form
    {
        private Timer chartTimer;
        private Boolean connected = true;

        public FormDisks()
        {
            InitializeComponent();
            InitTimer();
            drawCharts();
            textBoxServerUrl.Text = Properties.Settings.Default.server_url;
        }

        public void drawCharts()
        {
            if (connected)
            {
                drawDiskChart(chartVideo, "_media_Video", "Video");
                drawDiskChart(chartDownloads, "_media_Downloads", "DL");
                drawDiskChart(chartRoot, "_", "Root");
            }
        }

        public void InitTimer()
        {
            chartTimer = new Timer();
            chartTimer.Tick += new EventHandler(timer1_Tick);
            chartTimer.Interval = 2000; // in miliseconds
            chartTimer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawCharts();
        }

        private void drawDiskChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, String diskName, String label) {
            try
            {
                if (connected)
                {
                    Dictionary<String, DiskInfo> disks = DisksRestClient.getDiskList();
                    DiskInfo videoDisk = disks[diskName];
                    int percentOfuse = Convert.ToInt32(videoDisk.PercentOfUse.Replace("%", ""));
                    String usedlabel = "Used: " + videoDisk.UsedSpace;
                    String freeLabel = "Free: " + videoDisk.AvailableSpace;
                    chart.Series["SeriesUsed"].Points.Clear();
                    chart.Series["SeriesUsed"].Points.AddXY(usedlabel, percentOfuse);
                    chart.Series["SeriesUsed"].Points.AddXY(freeLabel, 100 - percentOfuse);
                    chart.Titles["Title1"].Text = label + " " + videoDisk.Size;
                }
            }
            catch (Exception e)
            {
                if (connected)
                {
                    //MessageBox.Show("Connection error", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    textBoxServerUrl.BackColor = Color.Red;
                    connected = false;
                }
                chartTimer.Stop();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server_url = textBoxServerUrl.Text;
            Properties.Settings.Default.Save();
            chartTimer.Stop();
            chartTimer.Start();
            connected = true;
            textBoxServerUrl.BackColor = Color.White;
        }
    }
}
