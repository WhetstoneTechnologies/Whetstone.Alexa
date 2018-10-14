using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Whetstone.Alexa
{
    [JsonObject("session")]
    public class AlexaSession
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("application")]
        public ApplicationAttributes Application { get; set; }

        [JsonProperty("attributes")]
        public AlexaSessionAttributes Attributes { get; set; }

        [JsonProperty("user")]
        public UserAttributes User { get; set; }

        [JsonProperty("new")]
        public bool New { get; set; }



    }
}
