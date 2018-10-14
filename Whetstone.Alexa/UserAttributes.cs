using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{

    [JsonObject("user")]
    public class UserAttributes
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName ="permissions")]
        public PermissionAttributes Permissions { get; set; }
    }
}
