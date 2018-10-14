using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa.CanFulfill
{




    public class CanFulfillSlotResponse
    {

        public string Name { get; set; }


        /// <summary>
        /// Serializes to "YES", "NO" or "MAYBE"
        /// </summary>
        [JsonProperty("canUnderstand")]
       [JsonConverter(typeof(JsonEnumConverter<CanFulfillEnum>))]
        public CanFulfillEnum CanUnderstand { get; set; }


        /// <summary>
        /// Serializes to "YES", "NO" or "MAYBE"
        /// </summary>
        [JsonProperty("canFulfill")]
        [JsonConverter(typeof(JsonEnumConverter<CanFulfillEnum>))]
        public CanFulfillEnum CanFulfill { get; set; }

    }
}
