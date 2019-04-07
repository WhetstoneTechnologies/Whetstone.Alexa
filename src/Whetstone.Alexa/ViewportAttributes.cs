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
using System.Runtime.Serialization;
using System.Text;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{
 //{
 //     "experiences": [
 //       {
 //         "arcMinuteWidth": 246,
 //         "arcMinuteHeight": 144,
 //         "canRotate": false,
 //         "canResize": false
 //       }
 //     ],
 //     "shape": "RECTANGLE",
 //     "pixelWidth": 1024,
 //     "pixelHeight": 600,
 //     "dpi": 160,
 //     "currentPixelWidth": 1024,
 //     "currentPixelHeight": 600,
 //     "touch": [
 //       "SINGLE"
 //     ],
 //     "keyboard": []
 //   }

    [Serializable]
    public enum ViewportShape
    {
        [EnumMember(Value = "RECTANGLE")]
        Rectangle = 0,
        [EnumMember(Value = "ROUND")]
        Round =1

    }

    public class ViewportAttributes
    {
        [JsonProperty("pixelWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int PixelWidth { get; set; }

        [JsonProperty("pixelHeight", NullValueHandling = NullValueHandling.Ignore)]
        public int PixelHeight { get; set; }

        [JsonProperty("dpi", NullValueHandling = NullValueHandling.Ignore)]
        public int DotsPerInch { get; set; }


        [JsonProperty("currentPixelWidth", NullValueHandling = NullValueHandling.Ignore)]
        public int CurrentPixelWidth { get; set; }

        [JsonProperty("currentPixelHeight", NullValueHandling = NullValueHandling.Ignore)]
        public int CurrentPixelHeight { get; set; }

        [JsonConverter(typeof(JsonEnumConverter<ViewportShape>))]
        [JsonProperty("shape", NullValueHandling = NullValueHandling.Ignore)]
        public ViewportShape Shape { get; set; }

        /// <summary>
        /// The internal values of the keyboard object are unknown.
        /// </summary>
        [JsonProperty("keyboard", NullValueHandling = NullValueHandling.Ignore)]
        public List<dynamic> Keyboard { get; set; }


        [JsonProperty("touch", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Touch { get; set; }
    }


}
