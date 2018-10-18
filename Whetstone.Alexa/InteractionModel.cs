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
