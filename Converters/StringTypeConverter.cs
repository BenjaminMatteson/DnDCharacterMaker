using System;
using Newtonsoft.Json;

//TODO: Is this needed?
namespace DnDCharacterMaker.Converters
{
    public class StringTypeConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string json = (string)reader.Value;
            var result = JsonConvert.DeserializeObject(json, objectType);
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var json = JsonConvert.SerializeObject(value);
            serializer.Serialize(writer, json);
        }
    }
}

