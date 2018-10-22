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
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{
    public enum RequestType
    {
        [EnumMember(Value = "LaunchRequest")]
        LaunchRequest,
        [EnumMember(Value = "IntentRequest")]
        IntentRequest,
        [EnumMember(Value = "SessionEndedRequest")]
        SessionEndedRequest,
        [EnumMember(Value = "CanFulfillIntentRequest")]
        CanFulfillIntentRequest,
        [EnumMember(Value = "AlexaSkillEvent.SkillPermissionAccepted")]
        SkillPermissionAccepted,
        [EnumMember(Value = "AlexaSkillEvent.SkillAccountLinked")]
        SkillAccountLinked,
        [EnumMember(Value = "AlexaSkillEvent.SkillEnabled")]
        SkillEnabled,
        [EnumMember(Value = "AlexaSkillEvent.SkillDisabled")]
        SkillDisabled,
        [EnumMember(Value = "AlexaSkillEvent.SkillPermissionChanged")]
        SkillPermissionChanged,
        [EnumMember(Value = "Messaging.MessageReceived")]
        MessageReceived

    }

    [JsonObject("request")]
    public class RequestAttributes
    {
        private string _timestampEpoch;
        private double _timestamp;

        [JsonProperty("type")]
        [JsonConverter(typeof(JsonEnumConverter<RequestType>))]
        public RequestType Type { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("timestamp")]
        public string TimestampEpoch
        {
            get
            {
                return _timestampEpoch;
            }
            set
            {
                _timestampEpoch = value;

                if (Double.TryParse(value, out _timestamp) && _timestamp > 0)
                    Timestamp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(_timestamp);
                else
                {
                    var timeStamp = DateTime.MinValue;
                    if (DateTime.TryParse(_timestampEpoch, out timeStamp))
                        Timestamp = timeStamp.ToUniversalTime();
                }
            }
        }

        [JsonIgnore]
        public DateTime Timestamp { get; set; }

        [JsonProperty("intent")]
        public IntentAttributes Intent { get; set; }

        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        public RequestAttributes()
        {
            Intent = new IntentAttributes();
        }
        

        [JsonProperty("shouldLinkResultBeReturned", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShouldLinkResultBeReturned { get; set; }


        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public AlexaErrorAttributes Error { get; set; }



        [JsonProperty("eventCreationTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EventCreationTime { get; set; }

        [JsonProperty("eventPublishingTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EventPublishingTime { get; set; }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public AlexaRequestBodyAttributes Body { get; set; }


        /// <summary>
        /// Free form class supplied in a <see cref="Whetstone.Alexa.RequestType.MessageReceived">Messaging.MessageReceived</see> from a customer application.
        /// </summary>
        /// <value>
        /// Custom application data.
        /// </value>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Data { get; set; }
       
    }



}
