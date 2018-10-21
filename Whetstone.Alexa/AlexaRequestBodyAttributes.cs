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
