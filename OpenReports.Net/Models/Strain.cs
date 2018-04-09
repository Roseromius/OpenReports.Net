using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace OpenReports.Net
{
    public class Strain: IModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "ucpc")]
        public string UCPC { get; private set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; private set; }

        [JsonProperty(PropertyName = "qr")]
        public string Qr { get; private set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; private set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; private set; }

        [JsonProperty(PropertyName = "seedCompany")]
        public ObjectLink SeedCompany { get; private set; }

        [JsonProperty(PropertyName = "genetics")]
        public ObjectLink Genetics { get; private set; }

        [JsonProperty(PropertyName = "lineage")]
        public Lineage Lineage { get; private set; }

        [JsonProperty(PropertyName = "children")]
        public Children Children { get; private set; }

        [JsonProperty(PropertyName = "reviews")]
        public ObjectsLink Reviews { get; private set; }

        [JsonProperty(PropertyName = "createdAt")]
        public TimeStamp CreatedAt { get; private set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public TimeStamp UpdatedAt { get; private set; }

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

            /*if (String.IsNullOrEmpty(Qr))
            {
                return false;
            }

            if (String.IsNullOrEmpty(Url))
            {
                return false;
            }

            if (String.IsNullOrEmpty(Image))
            {
                return false;
            }

            if (String.IsNullOrEmpty(Name))
            {
                return false;
            }

            if (String.IsNullOrEmpty(Name))
            {
                return false;
            }

            if (SeedCompany.IsValid())
            {
                return false;
            }

            if (Genetics.IsValid())
            {
                return false;
            }*/

            return true;
        }
    }
}
