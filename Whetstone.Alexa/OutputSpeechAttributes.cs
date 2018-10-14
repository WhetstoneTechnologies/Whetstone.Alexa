using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{
    [Serializable]
    public enum OutputSpeechType
    {
        [EnumMember(Value = "PlainText")]
        PlainText,
        [EnumMember(Value = "SSML")]
        Ssml
    }

    [Serializable]
    [JsonObject("outputSpeech")]
    public class OutputSpeechAttributes
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(JsonEnumConverter<OutputSpeechType>))]
        public OutputSpeechType Type { get; set; }

        [JsonProperty("text",  DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("ssml", DefaultValueHandling = DefaultValueHandling.Ignore)]        
        public string Ssml { get; set; }

        public OutputSpeechAttributes()
        {
            Type = OutputSpeechType.PlainText;
        }
    }
}
