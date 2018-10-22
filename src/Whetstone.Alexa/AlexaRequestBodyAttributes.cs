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
using Whetstone.Alexa.Security;
using Whetstone.Alexa.Serialization;

namespace Whetstone.Alexa
{

    /// <summary>
    /// Used to indicate if the user data should be persisted or not when then the user disables the skill through a <see cref="Whetstone.Alexa.RequestType.SkillDisabled">AlexaSkillEvent.SkillDisabledEvent</see>.
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public enum UserInformationPersistedEnum
    {

        /// <summary>
        /// Returned if the user has made in-skill purchases that should be maintained.
        /// </summary>
        [EnumMember(Value = "PERSISTED")]
        Persisted = 0,
        /// <summary>
        /// Returned if a new user id is generated when the user enables the skill again.
        /// </summary>
        [EnumMember(Value = "NOT_PERSISTED")]
        NotPersisted = 1

    }


    /// <summary>
    /// If the Alexa skill can receive events if the AlexaSkillEvent is enabled on the Alexa skill.
    /// </summary>
    /// <remarks>
    /// <para>This is used to process AlexaSkillEvent</para>
    /// </remarks>
    public class AlexaRequestBodyAttributes
    {


        /// <summary>
        /// Passed in the account linking event notification. <see cref="Whetstone.Alexa.RequestType.SkillAccountLinked">AlexaSkillEvent.SkillAccountLinked</see>
        /// </summary>
        /// <value>
        /// The access token provided by the account linking process
        /// </value>
        [JsonProperty("accessToken", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the user information persistence status. If it is <see cref="Whetstone.Alexa.UserInformationPersistedEnum.NotPersisted">NotPersisted</see> then user data
        /// can be safely removed from storage. If it is <see cref="Whetstone.Alexa.UserInformationPersistedEnum.Persisted">Persisted</see>, then user data with purchase history 
        /// must be maintained.
        /// </summary>
        /// <value>
        /// The user information persistence status. 
        /// </value>
        [JsonProperty("userInformationPersistenceStatus", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonEnumConverter<UserInformationPersistedEnum>))]
        public UserInformationPersistedEnum? UserInformationPersistenceStatus { get; set; }



        [JsonProperty("acceptedPermissions", NullValueHandling = NullValueHandling.Ignore)]
        public List<AcceptedPermission> AcceptedPermissions { get; set; }


    }
}
