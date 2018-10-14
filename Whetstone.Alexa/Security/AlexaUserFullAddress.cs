using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.Security
{
    public class AlexaUserFullAddress
    {

        //  {"addressLine1":null,"addressLine2":null,"addressLine3":null,"districtOrCounty":null,"stateOrRegion":null,"city":null,"countryCode":"US","postalCode":"19075"}

        [JsonProperty(PropertyName ="addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty(PropertyName = "addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty(PropertyName = "addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonProperty(PropertyName = "districtOrCounty")]
        public string DistrictOrCounty { get; set; }

        [JsonProperty(PropertyName = "stateOrRegion")]
        public string StateOrRegion { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

    }
}
