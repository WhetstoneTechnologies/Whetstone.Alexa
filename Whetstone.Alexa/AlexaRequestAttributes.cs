// Copyright (c) 2018 Whetstone Technologies
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
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Whetstone.Alexa
{
    public enum RequestType
    {

        LaunchRequest,
        IntentRequest,
        SessionEndedRequest,
        CanFulfillIntentRequest

    }

    [JsonObject("request")]
    public class RequestAttributes
    {
        private string _timestampEpoch;
        private double _timestamp;

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
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

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        public RequestAttributes()
        {
            Intent = new IntentAttributes();
        }
        

        [JsonProperty("shouldLinkResultBeReturned", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShouldLinkResultBeReturned { get; set; }


        [JsonProperty("error")]
        public AlexaErrorAttributes Error { get; set; }

    }



}
