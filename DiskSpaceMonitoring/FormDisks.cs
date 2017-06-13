using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiskSpaceMonitoring
{
    public partial class FormDisks : Form
    {
        private Timer chartTimer;
        private Boolean connected = false;
        List<DiskChart> charts = new List<DiskChart>();


        public FormDisks()
        {
            InitializeComponent();
            InitTimer();
            textBoxServerUrl.Text = Properties.Settings.Default.server_url;
            testConnection();
            Dictionary<String, DiskInfo> disks;
            try
            {
                disks = DisksRestClient.getDiskList(Properties.Settings.Default.server_url);
                foreach (KeyValuePair<string, DiskInfo> diskEntry in disks)
                {
                    checkedListBoxDisks.Items.Add(diskEntry.Key);
                }
            }
            catch(Exception e)
            {
                disks = null;
            }
            charts.Add(createChart("_", "Root"));
            charts.Add(createChart("_media_Downloads", "DL"));
            charts.Add(createChart("_media_Video", "Video"));
            foreach (DiskChart diskChart in charts)
            {
                tabPageDisks.Controls.Add(diskChart.chart);
            }
            drawCharts();
            tabPageDisks.Width = 1200;
            if (charts.ElementAt(0) != null)
            {
                int w = charts.ElementAt(0).chart.Width;
                int ml = charts.ElementAt(0).chart.Margin.Left;
                int mr = charts.ElementAt(0).chart.Margin.Right;
                int mt = charts.ElementAt(0).chart.Margin.Top;
                int mb = charts.ElementAt(0).chart.Margin.Bottom;
                int h = charts.ElementAt(0).chart.Height;
                this.Width = (w + ml + mr) * charts.Count + 20;
                this.Height = h + 20;

            }
        }

        public void drawCharts()
        {
            if (connected)
            {
                foreach (DiskChart diskChart in charts)
                {
                    drawDiskChart(diskChart.chart, diskChart.mountPoint, diskChart.name);
                }
            }
        }

        private DiskChart createChart(String diskName, String label)
        {
            Chart c = new Chart();
            ChartArea ca = new ChartArea();
            c.BackColor = Color.Transparent;
            ca.BackColor = Color.FromArgb(100, 240, 240, 240);
            c.ChartAreas.Add(ca);
            c.Width = 400;
            c.Height = 400;
            Font f = new Font(FontFamily.GenericSansSerif, 12);
            Title t = new Title("Title1");
            t.Font = f;
            t.Docking = Docking.Top;
            //t.IsDockedInsideChartArea = false;
            t.DockingOffset = 42;
            t.DockedToChartArea = ca.Name;
            c.Titles.Add(t);
            c.Series.Add("SeriesUsed");
            c.Series["SeriesUsed"].ChartType = SeriesChartType.Doughnut;
            c.Series["SeriesUsed"].Font = f;
            c.Dock = DockStyle.Left;
            DiskChart diskChart = new DiskChart(c, label, diskName);
            //drawDiskChart(c, diskName, label);
            return diskChart;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void testConnection()
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

        private void buttonTestConnection_Click_1(object sender, EventArgs e)
        {
            testConnection();
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

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void tabControlDisks_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void buttonSaveSettings_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.server_url = textBoxServerUrl.Text;
            charts.Clear();
            foreach (String item in checkedListBoxDisks.CheckedItems)
            {
                if (item == "_")
                {
                    charts.Add(createChart("_", "Root"));
                }
                else
                {
                    charts.Add(createChart(item,
                        item
                        .Replace("_media_Downloads", "DL")
                        .Replace("_media_Video", "Video")
                        .Replace("_", "/")
                        ));
                }
            }
            tabPageDisks.Controls.Clear();
            foreach (DiskChart diskChart in charts)
            {
                tabPageDisks.Controls.Add(diskChart.chart);
            }
            //charts.Add(createChart("_", "Root"));
            //charts.Add(createChart("_media_Downloads", "DL"));
            //charts.Add(createChart("_media_Video", "Video"));
            Properties.Settings.Default.Save();
            chartTimer.Stop();
            chartTimer.Start();
            textBoxServerUrl.BackColor = Color.White;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
