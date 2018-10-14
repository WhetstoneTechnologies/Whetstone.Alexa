using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{


    /// <summary>
    /// Class logged to DynamoDb for alexa requests and response.
    /// </summary>
    public class AlexaRecord
    {

       
        public string RequestId { get; set; }


        public AlexaRequest Request { get; set; }


        public AlexaResponse Response { get; set; }

        public Exception Error { get; set; }

        public DateTime CreateTime { get; set; }


        /// <summary>
        /// This is when the time will expire in dynamo db
        /// </summary>
        [JsonProperty( PropertyName = "ttl")]
        public long ExpireTime { get; set; }
    }
}
