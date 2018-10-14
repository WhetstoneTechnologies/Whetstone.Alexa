using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{


   
    public class DeviceAttributes
    {

        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }


        // TODO - Deteremine how to handle Supported Interfaces
    }
}
