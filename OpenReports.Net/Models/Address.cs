using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class Address : IModel
    {
        [JsonProperty(PropertyName = "address1")]
        public string Address1 { get; set; }

        [JsonProperty(PropertyName = "address2")]
        public string Address2 { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string ZipCode { get; set; }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Address1))
            {
                return false;
            }

            if (String.IsNullOrEmpty(ZipCode))
            {
                return false;
            }

            return true;
        }
    }
}
