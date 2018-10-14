using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Whetstone.Alexa
{
    [JsonObject("attributes")]
    public class AlexaSessionAttributes
    {
        [JsonProperty("memberId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string MemberId { get; set; }

        [JsonProperty("nodeId", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string NodeId { get; set; }

    }
}
