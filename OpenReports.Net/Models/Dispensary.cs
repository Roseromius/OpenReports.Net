using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class Dispensary: IModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "qr")]
        public string Qr { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "reviews")]
        public ObjectsLink Reviews { get; set; }

        [JsonProperty(PropertyName = "strains")]
        public ObjectsLink Strains { get; set; }

        [JsonProperty(PropertyName = "flowers")]
        public ObjectsLink Flowers { get; set; }

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

            if (String.IsNullOrEmpty(Link))
            {
                return false;
            }

            return true;
        }

    }
}
