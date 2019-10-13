using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.Test.Models
{
    public enum SessionStartType
    {
        Standard =0,
        Direct=1


    }


    public class EngineContext
    {
        [JsonProperty("userId")]
        public Guid EngineUserId { get; set; }

        [JsonProperty("sessionId")]
        public Guid EngineSessionId { get; set; }


        [JsonProperty("titleVersion")]
        public TitleVersion TitleVersion { get; set; }

        [JsonProperty("badIntentCounter")]
        public int BadIntentCounter { get; set; }

        [JsonProperty("sessionStartType", NullValueHandling = NullValueHandling.Ignore)]
        public SessionStartType? SessionStartType { get; set; }

    }
}
