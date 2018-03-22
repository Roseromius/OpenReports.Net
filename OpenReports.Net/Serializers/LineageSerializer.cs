using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OpenReports.Net
{
    class LineageSerializer: JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var lineage = value as Lineage;

            writer.WriteStartObject();

            foreach (KeyValuePair<string,string> country in lineage.Countries)
            {
                writer.WritePropertyName(country.Key);
                serializer.Serialize(writer, country.Value);
            }

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var lineageArray = new JArray();
            var lineageObject = new JObject();

            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    lineageArray = JArray.Load(reader);
                    break;
                case JsonToken.StartObject:
                    lineageObject = JObject.Load(reader);
                    var countries = new Dictionary<string, string>();

                    foreach (JProperty property in lineageObject.Properties())
                    {
                        countries.Add(property.Name, property.Value.ToString());
                    }

                    return new Lineage(countries);
                default:
                    Debug.WriteLine("Unknown Token Type: " + reader.TokenType);
                    break;
            }
            /*Debug.WriteLine("Start Token: " + reader.TokenType);
            while (reader.Read())
            {
                Debug.WriteLine("Body Token: " + reader.TokenType);
            }//*/

            return new Lineage();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Lineage).IsAssignableFrom(objectType);
        }
    }
}
