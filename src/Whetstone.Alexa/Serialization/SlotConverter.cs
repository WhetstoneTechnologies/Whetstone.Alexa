// MIT License
// 
// Copyright (c) 2019 WhetstoneTechnologies
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            List<SlotAttributes> slots =null;


            JObject jsonObject = null;
            try
            {
               jsonObject =  JObject.Load(reader);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deserializing slots: {ex}");
            }
 
            if (jsonObject?.Properties() != null)
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
