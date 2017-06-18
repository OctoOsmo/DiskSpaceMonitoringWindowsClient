using RestSharp;
using System;
using System.Collections.Generic;

namespace DiskSpaceMonitoring
{
    class DisksRestClient
    {

        private DisksRestClient() { }

        public bool connected = false;
        private String serverUrl { get; set; } = "";
        private String restEndpoint { get; set; } = Properties.Settings.Default.AllDisksRestEndpoint;
        private RestClient clientInstance;
         
        public DisksRestClient setRestEndpoint(String endpoint)
        {
            this.restEndpoint = endpoint;
            return this;
        }

        public DisksRestClient setServerUrl(String url)
        {
            this.serverUrl = url;
            return this;
        }

        public DisksRestClient connect()
        {
            if (serverUrl != null)
            {
                clientInstance = new RestClient(serverUrl);
                if (clientInstance != null) { connected = true; }
            }
            return this;
        }

        public DisksRestClient setClientTimeout(int timeout)
        {
            if (connected)
                clientInstance.Timeout = timeout;
            return this;
        }

        private static readonly DisksRestClient instance = new DisksRestClient();

        public static DisksRestClient Instance
        {
            get
            {
                return instance;
            }
        }

        public Dictionary<String, DiskInfo> getDiskList()
        {
            RestResponse<Dictionary<String, DiskInfo>> disks = null;
            try
            {
                if (connected) {
                    //StringDictionary dk = Properties.Settings.Default.disks;
                    //client.Timeout = 1000;            
                    var oneDiskRrequest = new RestRequest("/diskInfoRESTAPI/disk/_media_Video", Method.GET);
                    var allDisksRequest = new RestRequest(restEndpoint, Method.GET);
                    // execute the request
                    IRestResponse response = clientInstance.Execute(oneDiskRrequest);
                    var content = response.Content; // raw content as string


                    RestResponse<DiskInfo> disk = (RestResponse<DiskInfo>)clientInstance.Execute<DiskInfo>(oneDiskRrequest);
                    disks = (RestResponse<Dictionary<String, DiskInfo>>)clientInstance.Execute<Dictionary<String, DiskInfo>>(allDisksRequest);
                }
            }catch(Exception e)
            {
                //TODO: add error
            }
            return disks!=null?disks.Data:null;
        }
    }
}
