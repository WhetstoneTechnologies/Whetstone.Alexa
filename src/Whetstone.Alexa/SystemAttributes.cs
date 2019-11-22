// MIT License
// 
// Copyright (c) 2019 WhetstoneTechnologies
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{
    public class SystemAttributes
    {

        [JsonProperty("application", NullValueHandling = NullValueHandling.Ignore)]
        public ApplicationAttributes Application { get; set; }



        /// <summary>
        /// An object that describes the Amazon account for which the skill is enabled. The user object is different than the person object, because user refers to the Amazon account for which the skill is enabled, whereas person refers
        /// to a user whom Alexa recognizes by voice.
        /// </summary>
        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public UserAttributes User { get; set; }


        /// <summary>
        /// An object that describes the person who is making the request to Alexa.
        /// The person object is different than the user object, because person refers to a user whom Alexa recognizes by voice, whereas user refers to the Amazon account for which the skill is enabled.
        /// </summary>
        [JsonProperty("person", NullValueHandling = NullValueHandling.Ignore)]
        public PersonAttributes Person { get; set; }


        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public DeviceAttributes Device { get; set; }


        [JsonProperty("apiEndpoint")]
        public string ApiEndpoint { get; set; }


        [JsonProperty("apiAccessToken")]
        public string ApiAccessToken { get; set; }


    }
}
