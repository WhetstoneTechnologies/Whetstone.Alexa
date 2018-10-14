using Newtonsoft.Json;
using Whetstone.Alexa.CanFulfill;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.Serialization
{
    public class CanFulfillSlotResponseConverter : JsonConverter
    {
        public override bool CanRead { get { return false; } }

        public override bool CanWrite { get { return true; } }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<CanFulfillSlotResponse>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var slots = value as List<CanFulfillSlotResponse>;

            writer.WriteStartObject();
            if (slots != null)
            {
                foreach (var slotEntry in slots)
                {
                    writer.WritePropertyName(slotEntry.Name);

                    writer.WriteStartObject();

                    writer.WritePropertyName("canFulfill");
                   
                    writer.WriteValue(slotEntry.CanFulfill.GetDescriptionFromEnumValue());

                    writer.WritePropertyName("canUnderstand");

                    writer.WriteValue(slotEntry.CanUnderstand.GetDescriptionFromEnumValue());

                    writer.WriteEndObject();


                }
            }

            writer.WriteEndObject();

        }
    }
}
