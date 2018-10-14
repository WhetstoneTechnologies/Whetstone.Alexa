using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Whetstone.Alexa.Security
{
    [DataContract]
    [JsonObject("AlexaSecurityInfo")]
    public class AlexaSecurityInfo 
    {

        public AlexaSecurityInfo()
        {

        }


        [DataMember]
        [JsonProperty(PropertyName = "deviceId", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "accessToken", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }


        [DataMember]
        [JsonProperty(PropertyName = "apiEndpoint", NullValueHandling = NullValueHandling.Ignore)]
        public string ApiEndpoint { get; set; }

    }
}
