using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiskSpaceMonitoring
{
    public partial class FormDisks : Form
    {
        private Timer chartTimer;
        List<DiskChart> charts = new List<DiskChart>();
        StringCollection checkedDisks;
        private static readonly int CHART_SIZE = 400;
        private static readonly Color BACKGRD_COLOR = Color.FromArgb(100, 240, 240, 240);

        public FormDisks()
        {
            InitializeComponent();
            InitTimer();
            textBoxServerUrl.Text = Properties.Settings.Default.server_url;

            testConnection();
            Dictionary<String, DiskInfo> disks;
            try
            {
                disks = DisksRestClient.Instance
                    .setServerUrl(Properties.Settings.Default.server_url)
                    .getDiskList();
                foreach (KeyValuePair<string, DiskInfo> diskEntry in disks)
                {
                    if (diskEntry.Key != "Cмонтировано" && diskEntry.Key != "Mounted")
                    {
                        checkedListBoxDisks.Items.Add(diskEntry.Key);
                    }
                }
            }
            catch (Exception e)
            {
                disks = null;
            }
            if (Properties.Settings.Default.disks != null && Properties.Settings.Default.disks.Count > 0)
            {
                foreach (String diskName in Properties.Settings.Default.disks)
                {
                    charts.Add(createChart(diskName));
                }
                foreach (DiskChart diskChart in charts)
                {
                    tabPageDisks.Controls.Add(diskChart.chart);
                }
                drawCharts();
                foreach (String diskName in Properties.Settings.Default.disks) {
                    checkedListBoxDisks.SetItemChecked(checkedListBoxDisks.Items.IndexOf(diskName), true);
                }
            }
            else
            {
                Properties.Settings.Default.disks = new StringCollection();
            }
            adjustFormSize();
        }

        public void adjustFormSize()
        {
            if (charts != null && charts.Count > 0 && charts.ElementAt(0) != null)
            {
                int w = charts.ElementAt(0).chart.Width;
                int ml = charts.ElementAt(0).chart.Margin.Left;
                int mr = charts.ElementAt(0).chart.Margin.Right;
                int mt = charts.ElementAt(0).chart.Margin.Top;
                int mb = charts.ElementAt(0).chart.Margin.Bottom;
                int h = charts.ElementAt(0).chart.Height;
                this.Width = (w + (ml + mr)) * charts.Count + 30;
                this.Height = 485;
                //this.Height = h + (mt + mb) + 50;
                //tabPageDisks.Width = this.Width;
            }
            else { tabPageDisks.Width = 300; }
        }

        public void drawCharts()
        {
            if (DisksRestClient.Instance.connected)
            {
                foreach (DiskChart diskChart in charts)
                {
                    drawDiskChart(diskChart.chart, diskChart.mountPoint, diskChart.name);
                }
            }
        }

        private DiskChart createChart(String diskName)
        {
            String label;
            if (diskName == "_")
            {
                label = "Root";
            }
            else
            {
                label = diskName
                            .Replace("_media_Downloads", "DL")
                            .Replace("_media_Video", "Video")
                            .Replace("_", "/");
            }
            Chart c = new Chart();
            ChartArea ca = new ChartArea();
            c.BackColor = Color.Transparent;
            ca.BackColor = BACKGRD_COLOR;
            c.ChartAreas.Add(ca);
            c.Width = CHART_SIZE;
            c.Height = CHART_SIZE;
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
                if (DisksRestClient.Instance.connected)
                {
                    Dictionary<String, DiskInfo> disks = DisksRestClient.Instance.getDiskList();
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

        void testConnection()
        {
            chartTimer.Stop();
            textBoxServerUrl.BackColor = Color.Yellow;
            DisksRestClient.Instance.setServerUrl(textBoxServerUrl.Text).connect();
            if (DisksRestClient.Instance.connected)
            {
                textBoxServerUrl.BackColor = Color.Green;
                chartTimer.Start();
                notifyIconDisks.ShowBalloonTip(1000, "Info", "Test passed", ToolTipIcon.Info);
            }
            else
            {
                textBoxServerUrl.BackColor = Color.Red;
                notifyIconDisks.ShowBalloonTip(1000, "Info", "Test failed", ToolTipIcon.Error);
            }
        }

        private void buttonTestConnection_Click_1(object sender, EventArgs e)
        {
            testConnection();
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

        private void buttonSaveSettings_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.server_url = textBoxServerUrl.Text;
            if (charts != null)
                charts.Clear();
            if (Properties.Settings.Default.disks != null)
                Properties.Settings.Default.disks.Clear();            
            foreach (String item in checkedListBoxDisks.CheckedItems)
            {                
                charts.Add(createChart(item));
                Properties.Settings.Default.disks.Add(item);
            }
            tabPageDisks.Controls.Clear();
            foreach (DiskChart diskChart in charts)
            {
                tabPageDisks.Controls.Add(diskChart.chart);
            }
            Properties.Settings.Default.Save();
            chartTimer.Stop();
            chartTimer.Start();
            textBoxServerUrl.BackColor = Color.White;
            adjustFormSize();
        }
    }
}
