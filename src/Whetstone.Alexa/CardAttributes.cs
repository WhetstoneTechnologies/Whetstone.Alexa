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
using Newtonsoft.Json.Converters;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{
    public enum CardType
    {
        Simple,
        Standard,
        LinkAccount,
        AskForPermissionsConsent
    }


    [JsonObject("card")]
    public class CardAttributes
    {
        [JsonProperty("type", Required =  Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType Type { get; set; }

        [JsonProperty("title",DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Content { get; set; }

        // Populate text when sending back a standard card.
        [JsonProperty("text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("image", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AlexaImageAttributes ImageAttributes { get; set; }

        [JsonProperty("permissions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<string> Permissions { get; set; }

        public CardAttributes()
        {
            Type = CardType.Simple;
        }
    }


    /// <summary>
    /// Image urls must be publicly accessible, JPG or PNG, and less than 500KB.
    /// </summary>
    [JsonObject("image")]
    public class AlexaImageAttributes
    {

        /// <summary>
        /// Displayed on smaller screens, like smart phones (720w x 480w)
        /// </summary>
        /// <value>
        /// The small image URL.
        /// </value>
        [JsonProperty("smallImageUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SmallImageUrl { get; set; }


        /// <summary>
        ///  Displayed on larger screens like the Echo Show. (1200w x 800h)
        /// </summary>
        /// <value>
        /// The large image URL.
        /// </value>
        [JsonProperty("largeImageUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LargeImageUrl { get; set; }


    }


}
