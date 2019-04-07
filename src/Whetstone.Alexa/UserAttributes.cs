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
using System.Text;

namespace Whetstone.Alexa
{


    /// <summary>
    /// Represents the Alexa user. Encapsulates the UserId and the ConsentToken.
    /// </summary>
    /// <remarks>
    /// <para></para>
    /// </remarks>
    [JsonObject("user")]
    public class UserAttributes
    {


        /// <summary>
        /// Unique and immutable Alexa skill user id. Returning users can be identified using this value.
        /// </summary>
        /// <remarks>
        /// <para>The UserId can be used to identify returning users. It cannot be used to identify users across multiple skills. This value is
        /// unique per user per Alexa Skill. If a developer has published multiple Skills and the same Amazon user launches each Skill, the single user
        /// will have a different UserId for each Skill.</para> 
        /// <para>Also, a new user id is generated if the user disables the Skill and enables the Skill again.</para>
        /// </remarks>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }


        /// <summary>
        /// Permissions are populated if the user has granted the skill access to user information like email, address, etc.
        /// </summary>
        /// <remarks>If permissions have not been granted, this value will be missing from the response.</remarks>
        [JsonProperty(PropertyName ="permissions")]
        public PermissionAttributes Permissions { get; set; }
    }
}
