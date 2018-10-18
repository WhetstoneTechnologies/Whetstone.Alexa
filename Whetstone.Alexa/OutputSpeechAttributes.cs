﻿// Copyright (c) 2018 Whetstone Technologies
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
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
        PlainText = 0,
        [EnumMember(Value = "SSML")]
        Ssml = 1
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
