using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class Review: IModel
    {
        [JsonProperty(PropertyName = "link")]
        public string Link { get; private set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; private set; }

        [JsonProperty(PropertyName = "euphoria")]
        public int? Euphoria { get; private set; }

        [JsonProperty(PropertyName = "creativity")]
        public int? Creativity { get; private set; }

        [JsonProperty(PropertyName = "pain_relief")]
        public int? PainRelief { get; private set; }

        [JsonProperty(PropertyName = "appetite_gain")]
        public int? AppetiteGain { get; private set; }

        [JsonProperty(PropertyName = "calming")]
        public int? Calming { get; private set; }

        [JsonProperty(PropertyName = "anxiety")]
        public int? Anxiety { get; private set; }

        [JsonProperty(PropertyName = "spicy")]
        public int? Spicy { get; private set; }

        [JsonProperty(PropertyName = "earthy")]
        public int? Earthy { get; private set; }

        [JsonProperty(PropertyName = "fruity")]
        public int? Fruity { get; private set; }

        [JsonProperty(PropertyName = "sour")]
        public int? Sour { get; private set; }

        [JsonProperty(PropertyName = "dry_mouth")]
        public int? DryMouth { get; private set; }

        [JsonProperty(PropertyName = "createdAt")]
        public CreatedAt CreatedAt { get; private set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public UpdatedAt UpdatedAt { get; private set; }

        public bool IsValid()
        {
            if (Link == null) { return false; }
            if (Url == null) { return false; }
            if (CreatedAt == null) { return false; }
            if (UpdatedAt == null) { return false; }

            return true;
        }
    }
}
