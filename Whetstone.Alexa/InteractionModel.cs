using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;


namespace Whetstone.Alexa
{

    [JsonObject("Root interation model")]
    public partial class InteractionModel
    {
        [JsonProperty("languageModel")]
        public LanguageModel LanguageModel { get; set; }
    }



    [JsonObject("Slot Name")]
    public partial class SlotTypeModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<SlotEntry> Values { get; set; }
    }

    [JsonObject("Slot Entry")]
    public partial class SlotEntry
    {

        [JsonProperty("name")]
        public SlotValueItem SlotValue { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }


    }

    [JsonObject("Slot Value")]
    public partial class SlotValueItem
    {

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("synonyms")]
        public List<string> Synonyms { get; set; }
    }

    [JsonObject("Language model")]
    public partial class LanguageModel
    {
        [JsonProperty("types", Order = 0)]
        public List<SlotTypeModel> SlotTypes { get; set; }


        [JsonProperty("intents", Order = 1)]
        public List<IntentModel> Intents { get; set; }

        [JsonProperty("invocationName", Order = 2)]
        public string InvocationName { get; set; }
    }

    [JsonObject("Intent model")]
    public partial class IntentModel
    {


        public IntentModel()
        {

        }

        public IntentModel(string name)
        {

            this.Name = name;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("samples")]
        public List<string> Samples { get; set; }

        [JsonProperty("slots")]
        public List<SlotModel> Slots { get; set; }
    }

    [JsonObject("Slot model")]
    public partial class SlotModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    
}
