using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiskSpaceMonitoring
{    

    class DiskChart
    {
        public Chart chart { get; set; }
        public String name { get; set; }
        public String mountPoint { get; set; }

        public DiskChart(Chart chart, String name, String mountPoint) {
            this.chart = chart;
            this.name = name;
            this.mountPoint = mountPoint;
        }
    }
}
