﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class Product : IModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ucpc")]
        public string UCPC { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "qr")]
        public string Qr { get; set; }

        [JsonProperty(PropertyName = "barcode")]
        public string Barcode { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "producer")]
        public ObjectLink Producer { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "strain")]
        public ObjectLink Strain { get; set; }

        [JsonProperty(PropertyName = "labTest")]
        public string LabTest { get; set; }

        [JsonProperty(PropertyName = "thc")]
        public string THC { get; set; }

        [JsonProperty(PropertyName = "cbd")]
        public string CBD { get; set; }

        [JsonProperty(PropertyName = "cannabis")]
        public string Cannabis { get; set; }

        [JsonProperty(PropertyName = "hashOil")]
        public string HashOil { get; set; }

        [JsonProperty(PropertyName = "reviews")]
        public ObjectsLink Reviews { get; set; }

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
