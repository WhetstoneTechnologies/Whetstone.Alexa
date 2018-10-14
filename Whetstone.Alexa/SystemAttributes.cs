using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{
    public class SystemAttributes
    {

        [JsonProperty("application", NullValueHandling = NullValueHandling.Ignore)]
        public ApplicationAttributes Application { get; set; }


        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public UserAttributes User { get; set; }


        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public DeviceAttributes Device { get; set; }


        [JsonProperty("apiEndpoint")]
        public string ApiEndpoint { get; set; }


        [JsonProperty("apiAccessToken")]
        public string ApiAccessToken { get; set; }


    }
}
