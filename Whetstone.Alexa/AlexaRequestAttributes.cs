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
