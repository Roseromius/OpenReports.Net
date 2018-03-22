using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class Children: IModel
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; private set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; private set; }

        public bool IsValid()
        {
            /*if (Count < 0)
            {
                return false;
            }

            if (String.IsNullOrEmpty(Link))
            {
                return false;
            }//*/

            return true;
        }
    }
}
