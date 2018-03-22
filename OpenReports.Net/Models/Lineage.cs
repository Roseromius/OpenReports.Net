using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    [JsonConverter(typeof(LineageSerializer))]
    public class Lineage: IModel
    {
        [JsonProperty(PropertyName = "lineage")]
        public Dictionary<string,string> Countries { get; private set; }

        public Lineage()
        {
            Countries = new Dictionary<string, string>();
        }

        public Lineage(Dictionary<string, string> countries)
        {
            Countries = countries;
        }

        public bool IsValid()
        {
            if (Countries == null)
            {
                return false;
            }

            return true;
        }
    }
}

