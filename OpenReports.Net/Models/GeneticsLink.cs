using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class GeneticsLink: IModel
    {
        [JsonProperty(PropertyName = "names")]
        public string Names { get; private set; }

        [JsonProperty(PropertyName = "ucpc")]
        public string UCPC { get; private set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; private set; }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Names))
            {
                return false;
            }

            if (String.IsNullOrEmpty(UCPC))
            {
                return false;
            }

            if (String.IsNullOrEmpty(Link))
            {
                return false;
            }

            return true;
        }
    }
}
