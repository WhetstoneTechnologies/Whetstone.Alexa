// MIT License
// 
// Copyright (c) 2018 WhetstoneTechnologies
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

namespace Whetstone.Alexa.Display
{

    public enum DisplayImageSizeEnum
    {
        /// <summary>
        /// Displayed within extra small containers	(480x320)
        /// </summary>
        [EnumMember(Value = "X_SMALL")]
        ExtraSmall = 0,
        /// <summary>
        ///  Displayed within small containers (720x480)
        /// </summary>
        [EnumMember(Value = "SMALL")]
        Small = 1,
        /// <summary>
        ///  Displayed within medium containers	(960x640)
        /// </summary>
        [EnumMember(Value = "MEDIUM")]
        Medium = 2,
        /// <summary>
        /// Displayed within large containers (1200x800)
        /// </summary>
        [EnumMember(Value = "LARGE")]
        Large = 3,
        /// <summary>
        /// Displayed within extra large containers	(1920x1280)
        /// </summary>
        [EnumMember(Value = "X_LARGE")]
        ExtraLarge = 4
    }

    public class DisplayDirectiveImageSource
    {
        public DisplayDirectiveImageSource()
        {

        }

        public DisplayDirectiveImageSource(string url) : this()
        {
            this.Url = url;
        }

        public DisplayDirectiveImageSource(string url,  int width, int height) : this(url)
        {
            this.WidthPixels = width;
            this.HeightPixels = height;
          

        }

        public DisplayDirectiveImageSource(string url, DisplayImageSizeEnum size) : this(url)
        {
            this.Size = size;

        }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonEnumConverter<DisplayImageSizeEnum>))]
        public DisplayImageSizeEnum? Size { get; set; }
        

        [JsonProperty("widthPixels", NullValueHandling = NullValueHandling.Ignore)]
        public int? WidthPixels { get; set; }

        [JsonProperty("heightPixels", NullValueHandling = NullValueHandling.Ignore)]
        public int? HeightPixels { get; set; }
    }
}
