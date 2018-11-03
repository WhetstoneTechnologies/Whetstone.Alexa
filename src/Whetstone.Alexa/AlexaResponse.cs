// MIT License
// 
// Copyright (c) 2018 WhetstoneTechnologies
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Whetstone.Alexa
{
   

    [JsonObject(Description = "Alexa root response")]
    public class AlexaResponse
    {
        [JsonProperty("version", Order = 0, NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("sessionAttributes", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, dynamic> SessionAttributes { get; set; }

        [JsonProperty("response", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public AlexaResponseAttributes Response { get; set; }




        public AlexaResponse()
        {
         
           
        }

        public AlexaResponse(string outputSpeechText) : this()
        {
            Version = "1.0";
            Response = new AlexaResponseAttributes();
            Response.OutputSpeech = new OutputSpeechAttributes();
            Response.OutputSpeech.Text = outputSpeechText;
        }

        public AlexaResponse(string outputSpeechText, bool shouldEndSession) : this(outputSpeechText)
        {
            Response.ShouldEndSession = shouldEndSession;
        }

        
    }
}
