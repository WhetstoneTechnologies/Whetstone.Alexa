using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace Whetstone.Alexa.Serialization
{

    public class JsonEnumConverter<T> : JsonConverter where T : IComparable, IConvertible, IFormattable
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Enum sourceEnum = value as Enum;

            if (sourceEnum != null)

            {
                string enumText = sourceEnum.GetDescriptionFromEnumValue();
                writer.WriteValue(enumText);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            return Enum.Parse(typeof(T), enumString, true);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
