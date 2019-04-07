// MIT License
// 
// Copyright (c) 2019 WhetstoneTechnologies
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{
    [DebuggerDisplay("Intent Name = {Name}")]
    [JsonObject("intent")]
    public class IntentAttributes
    {

        public IntentAttributes()
        {

        }

        public IntentAttributes(string intentName) : this()
        {
            Name = intentName;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slots")]

        [JsonConverter(typeof(SlotConverter))]
        public List<SlotAttributes> Slots { get; set; }


        /// <summary>
        /// Returns the string value of the slot based on the name. If the slot list is null or empty, the result is null. The slot name comparison is case insensitive.
        /// </summary>
        /// <param name="slotName">Name of the slot.</param>
        /// <returns>User-provided slot value. Null if slot is not found or slot attributes are missing.</returns>
        public string GetSlotValue(string slotName)
        {

            SlotAttributes slotAttribs = Slots?.FirstOrDefault(x => x.Name.Equals(slotName, StringComparison.OrdinalIgnoreCase));

            if (slotAttribs != null)
                return slotAttribs.Value;

            return null;
        }
    }


    [DebuggerDisplay("Slot (Name: {Name}, Value: {Value})")]
    [JsonObject("slot")]
    public class SlotAttributes
    {


        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }


    }
}
