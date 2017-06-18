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
        private static readonly int CHART_SIZE = 400;
        private static readonly Color BACKGRD_COLOR = Color.FromArgb(100, 240, 240, 240);

        public FormDisks()
        {
            MaximizeBox = false;
            InitializeComponent();
            InitTimer();
            textBoxServerUrl.Text = Properties.Settings.Default.server_url;
            textBoxRestEndpoint.Text = Properties.Settings.Default.AllDisksRestEndpoint;

            testConnection();
            Dictionary<String, DiskInfo> disks;
            try
            {
                disks = DisksRestClient.Instance
                    .setServerUrl(Properties.Settings.Default.server_url)
                    .getDiskList();
                fillDisksListBox(disks);
            }
            catch (Exception e)
            {
                disks = null;
            }
            if (Properties.Settings.Default.disks != null && Properties.Settings.Default.disks.Count > 0)
            {
                textBoxSetup.Visible = false;
                foreach (String diskName in Properties.Settings.Default.disks)
                {
                    charts.Add(createChart(diskName.Replace("/","_")));
                }
                foreach (DiskChart diskChart in charts)
                {
                    tabPageDisks.Controls.Add(diskChart.chart);
                }
                drawCharts();
                foreach (String diskName in Properties.Settings.Default.disks)
                {
                    int diskNameIndex = checkedListBoxDisks.Items.IndexOf(diskName);
                    if (diskNameIndex != -1)
                        checkedListBoxDisks.SetItemChecked(diskNameIndex, true);
                }
            }
            else
            {
                textBoxSetup.Visible = true;
                Properties.Settings.Default.disks = new StringCollection();
            }
            adjustFormSize();
        }

        private void fillDisksListBox(Dictionary<String, DiskInfo> disks)
        {
            checkedListBoxDisks.Items.Clear();
            if (disks != null)
            {
                foreach (KeyValuePair<string, DiskInfo> diskEntry in disks)
                {
                    if (diskEntry.Key != "Cмонтировано" && diskEntry.Key != "Mounted")
                    {
                        checkedListBoxDisks.Items.Add(diskEntry.Key.Replace("_", "/"));
                    }
                }
            }
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
            Title t = new Title("Disk Title");
            t.Name = "Disk Title";
            t.Font = f;
            t.Docking = Docking.Top;
            t.DockingOffset = 42;
            t.DockedToChartArea = ca.Name;
            c.Titles.Add(t);
            c.Series.Add("SeriesUsed");
            c.Series["SeriesUsed"].ChartType = SeriesChartType.Doughnut;
            c.Series["SeriesUsed"].Font = f;
            c.Dock = DockStyle.Left;
            DiskChart diskChart = new DiskChart(c, label, diskName);
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
                    chart.Titles["Disk Title"].Text = label + " " + videoDisk.Size;
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
            try
            {
                DisksRestClient.Instance
                    .setServerUrl(textBoxServerUrl.Text)
                    .setRestEndpoint(textBoxRestEndpoint.Text)
                    .connect();                
                textBoxServerUrl.BackColor = Color.Green;
                chartTimer.Start();
                notifyIconDisks.ShowBalloonTip(1000, "Info", "Test passed", ToolTipIcon.Info);
                if(DisksRestClient.Instance.getDiskList() != null)
                {
                    textBoxRestEndpoint.BackColor = Color.Green;
                }
                else
                {
                    textBoxRestEndpoint.BackColor = Color.Red;
                }
            }
            catch (System.UriFormatException e)
            {
                textBoxServerUrl.BackColor = Color.Red;
                notifyIconDisks.ShowBalloonTip(1000, "Error", "Connection failure", ToolTipIcon.Error);
            }
        }

        private void buttonTestConnection_Click_1(object sender, EventArgs e)
        {
            testConnection();
            if (DisksRestClient.Instance.connected)
            {
                fillDisksListBox(DisksRestClient.Instance.setServerUrl(Properties.Settings.Default.server_url).getDiskList());                
            }
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
            Properties.Settings.Default.AllDisksRestEndpoint = textBoxRestEndpoint.Text;
            if (charts != null)
                charts.Clear();
            if (Properties.Settings.Default.disks != null)
                Properties.Settings.Default.disks.Clear();
            foreach (String item in checkedListBoxDisks.CheckedItems)
            {
                charts.Add(createChart(item.Replace("/","_")));
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
            textBoxRestEndpoint.BackColor = Color.White;
            adjustFormSize();
        }

    }
}
