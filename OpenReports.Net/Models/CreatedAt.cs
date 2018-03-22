using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class CreatedAt: IModel
    {
        [JsonProperty(PropertyName = "dateTime")]
        public string Datetime { get; private set; }

        [JsonProperty(PropertyName = "timeZone")]
        public string Timezone { get; private set; }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Datetime))
            {
                return false;
            }

            if (String.IsNullOrEmpty(Timezone))
            {
                return false;
            }

            return true;
        }
    }
}
