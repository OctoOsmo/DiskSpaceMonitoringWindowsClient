using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceMonitoring
{
    class DiskInfo
    {
        public String Name { get; set; }
        public String Size { get; set; }
        public String UsedSpace { get; set; }
        public String AvailableSpace { get; set; }
        public String PercentOfUse { get; set; }
        public String MountPoint { get; set; }

        public DiskInfo(){}        
    }
}
