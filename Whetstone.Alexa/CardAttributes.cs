using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{
    public enum CardType
    {
        Simple,
        Standard,
        LinkAccount,
        AskForPermissionsConsent
    }


    [JsonObject("card")]
    public class CardAttributes
    {
        [JsonProperty("type", Required =  Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType Type { get; set; }

        [JsonProperty("title",DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Content { get; set; }

        // Populate text when sending back a standard card.
        [JsonProperty("text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("image", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AlexaImageAttributes ImageAttributes { get; set; }

        [JsonProperty("permissions", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<string> Permissions { get; set; }

        public CardAttributes()
        {
            Type = CardType.Simple;
        }
    }

    [JsonObject("image")]
    public class AlexaImageAttributes
    {

        [JsonProperty("smallImageUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SmallImageUrl { get; set; }

        [JsonProperty("largeImageUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LargeImageUrl { get; set; }


    }


}
