using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class ObjectLink
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "names")]//INSTEAD OF A CONVERTER
        private string Names { set { Name = value; } }

        [JsonProperty(PropertyName = "ucpc")]
        public string UCPC { get; private set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; private set; }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Name))
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
