using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.Security
{
    public class AlexaUserPhoneNumber
    {

        [JsonProperty(PropertyName ="countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "phoneNumber")]
        public string PhoneNumber { get; set; }

    }
}
