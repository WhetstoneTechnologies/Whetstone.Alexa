using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{
    [JsonObject("application")]
    public class ApplicationAttributes
    {
        [JsonProperty("applicationId")]
        public string ApplicationId { get; set; }
    }
}
