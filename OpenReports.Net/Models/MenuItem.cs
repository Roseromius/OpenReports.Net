using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class MenuItem: IModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "item")]
        public Item Item { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal? Price { get; set; }

        [JsonProperty(PropertyName = "price_half_gram")]
        public decimal? PriceHalfGram { get; set; }

        [JsonProperty(PropertyName = "price_gram")]
        public decimal? PriceGram { get; set; }

        [JsonProperty(PropertyName = "price_eighth")]
        public decimal? PriceEighth { get; set; }

        [JsonProperty(PropertyName = "price_quarter")]
        public decimal? PriceQuarter { get; set; }

        [JsonProperty(PropertyName = "price_half_ounce")]
        public decimal? PriceHalfOunce { get; set; }

        [JsonProperty(PropertyName = "price_ounce")]
        public decimal? PriceOunce { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public TimeStamp CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public TimeStamp UpdatedAt { get; set; }

        public bool IsValid()
        {
            if (Name == null) { return false; }
            if (Item == null) { return false; }

            return true;
        }
    }
}
