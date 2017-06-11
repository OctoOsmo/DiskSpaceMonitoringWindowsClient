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

        private void drawDiskChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, String diskName, String label)
        {
            try
            {
                if (connected)
                {
                    Dictionary<String, DiskInfo> disks = DisksRestClient.getDiskList(Properties.Settings.Default.server_url);
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
                textBoxServerUrl.BackColor = Color.Red;
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
            textBoxServerUrl.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTestConnection_Click_1(object sender, EventArgs e)
        {
            try
            {
                chartTimer.Stop();
                textBoxServerUrl.BackColor = Color.Yellow;                
                Dictionary<String, DiskInfo> disks = DisksRestClient.getDiskList(textBoxServerUrl.Text);
                if (null != disks)
                {
                    textBoxServerUrl.BackColor = Color.Green;
                    connected = true;
                    chartTimer.Start();
                    notifyIconDisks.ShowBalloonTip(1000, "Info", "Test passed", ToolTipIcon.Info);
                }
                else
                {
                    throw new Exception("Connection failed");
                }
            }
            catch
            {
                textBoxServerUrl.BackColor = Color.Red;
                connected = false;
                notifyIconDisks.ShowBalloonTip(1000, "Info", "Test failed", ToolTipIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                this.Hide();
            else
                this.Show();
        }

        private void tabPageSettings_Move(object sender, EventArgs e)
        {

        }

        private void FormDisks_Move(object sender, EventArgs e)
        {   
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            tabControlDisks.SelectedTab = tabControlDisks.TabPages["tabPageSettings"];
        }
    }
}
