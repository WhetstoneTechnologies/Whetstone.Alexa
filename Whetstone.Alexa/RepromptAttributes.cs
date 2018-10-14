using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Whetstone.Alexa
{
    [JsonObject("reprompt")]
    public class RepromptAttributes
    {
        [JsonProperty("outputSpeech")]
        public OutputSpeechAttributes OutputSpeech { get; set; }

        public RepromptAttributes()
        {
            OutputSpeech = new OutputSpeechAttributes();
        }
    }
}
