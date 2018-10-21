using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.Security
{
    public class AcceptedPermission
    {

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
