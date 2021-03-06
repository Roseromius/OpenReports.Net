﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class SeedCompany: IModel
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
        public string Image { get; private set;}

        [JsonProperty(PropertyName = "lineage")]
        public Lineage Lineage { get; private set;}

        [JsonProperty(PropertyName = "strains")]
        public ObjectsLink Strains { get; private set; }

        [JsonProperty(PropertyName = "reviews")]
        public ObjectsLink Reviews { get; private set; }

        [JsonProperty(PropertyName = "createdAt")]
        public TimeStamp CreatedAt { get; private set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public TimeStamp UpdatedAt { get; private set; }

        public bool IsValid()
        {
            if (Name == null) { return false; }
            if (UCPC == null) { return false; }
            if (Link == null) { return false; }
            if (Qr == null) { return false; }
            if (Url == null) { return false; }
            if (Image == null) { return false; }
            if (Lineage == null) { return false; }
            if (Strains == null) { return false; }
            if (Reviews == null) { return false; }
            if (CreatedAt == null) { return false; }
            if (UpdatedAt == null) { return false; }

            return true;
        }
    }
}
