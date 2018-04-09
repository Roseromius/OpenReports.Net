using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OpenReports.Net
{
    public class DataRequester
    {
        public static string GetRawData(string url)
        {
            string json;

            using (WebClient client = new WebClient())
            {
                json = client.DownloadString(url);
            }

            return json;
        }

        public static T GetObject<T>(string url)
        {
            string json = GetRawData(url);

            JObject rawData = JObject.Parse(json);
            T tempObject = rawData["data"].ToObject<T>();

            return tempObject;
        }

        public static IEnumerable<T> GetObjects<T>(string url)
        {
            var tempObjects = new List<T>();
            string json = GetRawData(url);
            JObject rawData = JObject.Parse(json);

            foreach (JToken token in rawData["data"].Children())
            {
                T tempObject = token.ToObject<T>();
                tempObjects.Add(tempObject);
            }

            return tempObjects;
        }

    }
}
