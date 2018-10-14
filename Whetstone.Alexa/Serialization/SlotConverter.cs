using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Whetstone.Alexa.Serialization
{
    public class SlotConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var slots = value as List<SlotAttributes>;

            writer.WriteStartObject();
            if (slots != null)
            {
                foreach (var slotEntry in slots)
                {
                    writer.WritePropertyName(slotEntry.Name);

                    writer.WriteStartObject();

                  
                    writer.WritePropertyName("name");
                    writer.WriteValue(slotEntry.Name);

                    if (!string.IsNullOrWhiteSpace(slotEntry.Value))
                    {
                        writer.WritePropertyName("value");
                        writer.WriteValue(slotEntry.Value);
                    }



                    if (!string.IsNullOrWhiteSpace(slotEntry.Id))
                    {
                        writer.WritePropertyName("id");
                        writer.WriteValue(slotEntry.Id);


                    }


                    writer.WriteEndObject();


                }
            }

            writer.WriteEndObject();


            //"slots": {
            //    "location": {
            //        "name": "location",
            //        "value": "barn"
            //    }


        //public List<SlotAttributes> Slots { get; set; }
    }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            List<SlotAttributes> slots =null;

            JObject jsonObject = JObject.Load(reader);
            if (jsonObject.Properties() != null)
            {
                slots = new List<SlotAttributes>();
                var properties = jsonObject.Properties().ToList();
                foreach (var jprop in properties)
                {
                    SlotAttributes slotAttrib = new SlotAttributes();

                    slotAttrib.Name = jprop.Name;
                   
                    if (jprop.Value is JObject propVal)
                    {
                        var props = propVal.Properties();
                        if (propVal.Properties() != null)
                        {
                            var propValue = props.FirstOrDefault(x =>
                                x.Name.Equals("value", StringComparison.OrdinalIgnoreCase));

                            if (propValue != null)
                                slotAttrib.Value = (string) propValue.Value;

                            propValue = props.FirstOrDefault(x =>
                                x.Name.Equals("id", StringComparison.OrdinalIgnoreCase));

                            if (propValue != null)
                                slotAttrib.Id = (string) propValue.Value;
                        }

                    }

                    slots.Add(slotAttrib);
                }

            }

            return slots;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<SlotAttributes>);
        }
    }
}
