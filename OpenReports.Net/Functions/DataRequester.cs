using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OpenReports.Net
{
    public class DataRequester
    {
        public static string GetData(string url)
        {
            string json;

            using (WebClient client = new WebClient())
            {
                json = client.DownloadString(url);
            }

            return json;
        }
    }
}
