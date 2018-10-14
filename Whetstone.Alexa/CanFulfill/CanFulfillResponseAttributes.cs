using Newtonsoft.Json;
using Whetstone.Alexa.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.CanFulfill
{
    public class CanFulfillResponseAttributes
    {

        /// <summary>
        /// Must be set to string "YES" or "NO"
        /// </summary>
        [JsonProperty("canFulfill")]
        [JsonConverter(typeof(JsonEnumConverter<CanFulfillEnum>))]
        public CanFulfillEnum CanFulfill { get; set; }


        [JsonConverter(typeof(CanFulfillSlotResponseConverter))]
        [JsonProperty("slots")]
        public List<CanFulfillSlotResponse> Slots { get; set; }

    }




    
}
