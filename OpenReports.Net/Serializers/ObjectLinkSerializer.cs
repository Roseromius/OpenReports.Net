using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenReports.Net
{
    class ObjectLinkSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectLink = value as ObjectLink;

            writer.WriteStartObject();

            writer.WritePropertyName("name");
            serializer.Serialize(writer, objectLink.Name);

            writer.WritePropertyName("link");
            serializer.Serialize(writer, objectLink.Link);

            writer.WritePropertyName("ucpc");
            serializer.Serialize(writer, objectLink.UCPC);

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var objectLinkArray = new JArray();
            var objectLinkObject = new JObject();

            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    objectLinkArray = JArray.Load(reader);
                    break;
                case JsonToken.StartObject:
                    objectLinkObject = JObject.Load(reader);

                    List<JProperty> properties = objectLinkObject.Properties().ToList();

                    var objectLink = new ObjectLink
                        (
                            properties[0].Value.ToString(),
                            properties[1].Value.ToString(),
                            properties[2].Value.ToString()
                        );

                    return objectLink;
                default:
                    Debug.WriteLine("Unknown Token Type: " + reader.TokenType);
                    break;
            }

            return new ObjectLink();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ObjectLink).IsAssignableFrom(objectType);
        }
    }
}
