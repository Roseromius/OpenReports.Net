using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class MenuItemSummary : IModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ucpc")]
        public string UCPC { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }

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
        public CreatedAt CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public UpdatedAt UpdatedAt { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
