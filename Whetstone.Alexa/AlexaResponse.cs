using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Whetstone.Alexa
{
   

    [JsonObject(Description = "Alexa root response")]
    public class AlexaResponse
    {
        [JsonRequired]
        [JsonProperty("version", Order = 1)]
        public string Version { get; set; }

        [JsonProperty("sessionAttributes", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public AlexaSessionAttributes Session { get; set; }

        [JsonRequired]
        [JsonProperty("response", Order = 3)]
        public AlexaResponseAttributes Response { get; set; }

        public AlexaResponse()
        {
            Version = "1.0";
            Session = null;
            Response = new AlexaResponseAttributes();
        }

        public AlexaResponse(string outputSpeechText)
            : this()
        {
            Response.OutputSpeech.Text = outputSpeechText;
            Response.Card.Content = outputSpeechText;
        }

        public AlexaResponse(string outputSpeechText, bool shouldEndSession)
            : this()
        {
            Response.OutputSpeech.Text = outputSpeechText;
            Response.ShouldEndSession = shouldEndSession;

            if (shouldEndSession)
            {
                Response.Card.Content = outputSpeechText;
            }
            else
            {
                Response.Card = null;
            }
        }

        public AlexaResponse(string outputSpeechText, string cardContent)
            : this()
        {
            Response.OutputSpeech.Text = outputSpeechText;
            Response.Card.Content = cardContent;
        }
        
    }
}
