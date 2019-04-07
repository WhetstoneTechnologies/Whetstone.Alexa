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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Whetstone.Alexa.Display
{
    public class DisplayTextContent
    {
        /// <summary>
        /// Contains type (which is PlainText or RichText) and text (which is a string). Limit of 8000 characters.
        /// </summary>
        /// <value>
        /// The primary text.
        /// </value>
        [StringLength(8000)]
        [JsonProperty("primaryText", NullValueHandling =NullValueHandling.Ignore)]
        public DisplayTextField PrimaryText { get; set; }

        /// <summary>
        /// Contains type (which is PlainText or RichText) and text (which is a string). Limit of 8000 characters.
        /// </summary>
        /// <value>
        /// The secondary text.
        /// </value>
        [StringLength(8000)]
        [JsonProperty("secondaryText", NullValueHandling = NullValueHandling.Ignore)]
        public DisplayTextField SecondaryText { get; set; }

        /// <summary>
        /// Contains type (which is PlainText or RichText) and text (which is a string). Limit of 8000 characters.
        /// </summary>
        /// <value>
        /// The tertiary text.
        /// </value>
        [StringLength(8000)]
        [JsonProperty("tertiaryText", NullValueHandling = NullValueHandling.Ignore)]
        public DisplayTextField TertiaryText { get; set; }
    }
}
