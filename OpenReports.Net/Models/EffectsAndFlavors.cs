using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class EffectsAndFlavors:  IModel//MIGHT NOT NEED THE NULLABLE TYPES 
    {
        [JsonProperty(PropertyName = "euphoria")]
        public decimal? Euphoria { get; private set; }

        [JsonProperty(PropertyName = "creativity")]
        public decimal? Creativity { get; private set; }

        [JsonProperty(PropertyName = "calming")]
        public decimal? Calming { get; private set; }

        [JsonProperty(PropertyName = "numbness")]
        public decimal? Numbness { get; private set; }

        [JsonProperty(PropertyName = "appetite_gain")]
        public decimal? AppetiteGain { get; private set; }

        [JsonProperty(PropertyName = "dry_mouth")]
        public decimal? DryMouth { get; private set; }

        [JsonProperty(PropertyName = "fruity")]
        public decimal? Fruity { get; private set; }

        [JsonProperty(PropertyName = "spicy")]
        public decimal? Spicy { get; private set; }

        [JsonProperty(PropertyName = "earthy")]
        public decimal? Earthy { get; private set; }

        [JsonProperty(PropertyName = "sour")]
        public decimal? Sour { get; private set; }

        [JsonProperty(PropertyName = "sweet")]
        public decimal? Sweet { get; private set; }

        [JsonProperty(PropertyName = "pine")]
        public decimal? Pine { get; private set; }

        [JsonProperty(PropertyName = "anxiety")]
        public decimal? Anxiety { get; private set; }

        [JsonProperty(PropertyName = "reviews")]
        public int Reviews { get; private set; }

        public bool IsValid()
        {
            if (Euphoria < 0) { return false; }
            if (Creativity < 0) { return false; }
            if (Calming < 0) { return false; }
            if (Numbness < 0) { return false; }
            if (AppetiteGain < 0) { return false; }
            if (DryMouth < 0) { return false; }
            if (Fruity < 0) { return false; }
            if (Spicy < 0) { return false; }
            if (Earthy < 0) { return false; }
            if (Sour < 0) { return false; }
            if (Sweet < 0) { return false; }
            if (Pine < 0) { return false; }
            if (Anxiety < 0) { return false; }
            if (Reviews < 0) { return false; }

            return true;
        }
    }
}
