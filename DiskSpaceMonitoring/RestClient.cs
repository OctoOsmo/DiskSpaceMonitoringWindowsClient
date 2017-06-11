using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceMonitoring
{
    class DisksRestClient
    {

        public static Dictionary<String, DiskInfo> getDiskList(String server_url)
        {             
            StringDictionary dk = Properties.Settings.Default.disks;
            var client = new RestClient(server_url);
            //client.Timeout = 1000;            
            var oneDiskRrequest = new RestRequest("/diskInfoRESTAPI/disk/_media_Video", Method.GET);
            var allDisksRequest = new RestRequest("/diskInfoRESTAPI/disk_list", Method.GET);
            // execute the request
            IRestResponse response = client.Execute(oneDiskRrequest);
            var content = response.Content; // raw content as string


            RestResponse<DiskInfo> disk = (RestResponse<DiskInfo>)client.Execute<DiskInfo>(oneDiskRrequest);
            RestResponse<Dictionary<String, DiskInfo>> disks = 
                (RestResponse<Dictionary<String, DiskInfo>>)client.Execute<Dictionary<String, DiskInfo>>(allDisksRequest);
            
            return disks.Data;
        }
    }
}
