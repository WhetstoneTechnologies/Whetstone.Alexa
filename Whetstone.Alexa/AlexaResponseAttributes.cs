using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Whetstone.Alexa.CanFulfill;

namespace Whetstone.Alexa
{
    [JsonObject("response")]
    public class AlexaResponseAttributes
    {
        [JsonRequired]
        [JsonProperty("shouldEndSession")]
        public bool ShouldEndSession { get; set; }

        [JsonProperty("outputSpeech", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public OutputSpeechAttributes OutputSpeech { get; set; }

        [JsonProperty("card", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CardAttributes Card { get; set; }

        [JsonProperty("reprompt", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public RepromptAttributes Reprompt { get; set; }

        [JsonProperty("canFulfillIntent", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CanFulfillResponseAttributes CanFulfill { get; set; }

        public AlexaResponseAttributes()
        {
            ShouldEndSession = true;
            OutputSpeech = new OutputSpeechAttributes();
            CanFulfill = null;
            Card = null;
            Reprompt = new RepromptAttributes();
        }
    }
}
