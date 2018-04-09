using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class Producer: IModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ucpc")]
        public string UCPC { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "qr")]
        public string Qr { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "reviews")]
        public ObjectsLink Reviews { get; set; }

        [JsonProperty(PropertyName = "extracts")]
        public ObjectsLink Extracts { get; set; }

        [JsonProperty(PropertyName = "edibles")]
        public ObjectsLink Edibles { get; set; }

        [JsonProperty(PropertyName = "products")]
        public ObjectsLink Products { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public TimeStamp CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public TimeStamp UpdatedAt { get; set; }

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
