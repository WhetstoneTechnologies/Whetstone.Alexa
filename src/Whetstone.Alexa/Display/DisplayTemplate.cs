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
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Whetstone.Alexa.Display
{
    public enum DisplayTemplateTypeEnum
    {
        BodyTemplate1 = 0,
        /// <summary>
        /// Image is displayed on the right. Text is centered.
        /// </summary>
        BodyTemplate2 = 1,
        /// <summary>
        /// Image is displayed on the left. Text is centered.
        /// </summary>
        BodyTemplate3 = 2,
        BodyTemplate4 = 3,
        BodyTemplate5 = 4,
        BodyTemplate6 = 5,
        BodyTemplate7 = 6,
        ListTemplate1 = 7,
        ListTemplate2 = 8

    }

    public enum BackButtonDisplayEnum
    {
        [EnumMember(Value = "VISIBLE")]
        Visible = 0,
        [EnumMember(Value = "HIDDEN")]
        Hidden =1

    }

    public class DisplayTemplate
    {

        /// <summary>
        /// Name of the template.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public DisplayTemplateTypeEnum Type { get; set; }


        /// <summary>
        /// Used to track selectable elements in the skill service code. The value can be any user-defined string.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        [JsonProperty("token")]
        public string Token { get; set;}

        /// <summary>
        /// Used for title for a display template. The value can be any user-defined string.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// References and describes the image. Multiple sources for the image can be provided. The same format is used for both `backgroundImage` and `image`.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public DisplayDirectiveImage Image { get; set; }

        /// <summary>
        /// Contains primaryText, secondaryText, and tertiaryText.
        /// </summary>
        /// <value>
        /// The content of the text.
        /// </value>
        [JsonProperty("textContent", NullValueHandling = NullValueHandling.Ignore)]
        public DisplayTextContent TextContent { get; set; }

        /// <summary>
        /// Used to place the back button on a display template. Defaults to VISIBLE.
        /// </summary>
        /// <value>
        /// The back button display.
        /// </value>
        [JsonProperty("backButton", NullValueHandling = NullValueHandling.Ignore)]
        public BackButtonDisplayEnum? BackButtonDisplay { get; set; }


        /// <summary>
        /// Used to include a background image on a display template.
        /// </summary>
        /// <value>
        /// The background image.
        /// </value>
        [JsonProperty("backgroundImage", NullValueHandling = NullValueHandling.Ignore)]
        public DisplayDirectiveImage BackgroundImage { get; set; }


        /// <summary>
        /// Contains the text and images of the list items.
        /// </summary>
        /// <value>
        /// The list items.
        /// </value>
        [JsonProperty("listItems", NullValueHandling = NullValueHandling.Ignore)]
        public List<DisplayListItem> ListItems { get; set; }

    }
}
