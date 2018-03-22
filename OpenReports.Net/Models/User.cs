using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class User: IModel
    {
        [JsonProperty(PropertyName = "nickname")]
        public string Nickname { get; private set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; private set; }

        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; private set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; private set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; private set; }

        [JsonProperty(PropertyName = "createdAt")]
        public CreatedAt CreatedAt { get; private set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public UpdatedAt UpdatedAt { get; private set; }

        public bool IsValid()
        {
            if (Nickname == null)
            {
                return false;
            }

            if (Link == null)
            {
                return false;
            }

            if (Tagline == null)
            {
                return false;
            }

            if (Url == null)
            {
                return false;
            }

            if (Slug == null)
            {
                return false;
            }

            if (CreatedAt == null)
            {
                return false;
            }

            if (UpdatedAt == null)
            {
                return false;
            }

            return true;
        }
    }
}
