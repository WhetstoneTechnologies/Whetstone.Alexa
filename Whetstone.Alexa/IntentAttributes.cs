using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{
    [JsonObject("intent")]
    public class IntentAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slots")]

        [JsonConverter(typeof(SlotConverter))]
        public List<SlotAttributes> Slots { get; set; }

        //public List<KeyValuePair<string, string>> GetSlots()
        //{
        //    var output = new List<KeyValuePair<string, string>>();
        //    if (Slots == null) return output;

        //    foreach (var slot in Slots.Children())
        //    {
        //        if (slot.First.value != null)
        //            output.Add(new KeyValuePair<string, string>(slot.First.name.ToString(), slot.First.value.ToString()));
        //    }

        //    return output;
        //}
    }

  
    [JsonObject("slot")]
    public class SlotAttributes
    {


        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }


    }
}
