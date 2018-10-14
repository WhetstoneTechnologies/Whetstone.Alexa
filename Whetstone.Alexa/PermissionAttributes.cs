using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa
{

    [JsonObject("permissions")]
    public  class PermissionAttributes
    {

        [JsonProperty( PropertyName ="consentToken", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsentToken { get; set; }

    }
}
