// Copyright (c) 2018 Whetstone Technologies. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Whetstone.Alexa.Audio;
using Whetstone.Alexa.Security;
using Whetstone.Alexa.Serialization;
using Xunit;

namespace Whetstone.Alexa.Test
{
    public class DeserializationTests
    {
        [Trait("Type", "UnitTest")]
        [Fact]
        public void EchoShowDeserializationTest()
        {
            string filePath = @"requestsamples\echoshowlaunchrequest.json";


            string fileContents = File.ReadAllText(filePath);


            AlexaRequest req = JsonConvert.DeserializeObject<AlexaRequest>(fileContents);
        }

        [Trait("Type", "UnitTest")]
        [Fact]
        public void AllInterfaceLaunchTest()
        {
            string filePath = @"requestsamples\allsupportedinterfaceslaunchrequest.json";


            string fileContents = File.ReadAllText(filePath);

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            AlexaRequest req = JsonConvert.DeserializeObject<AlexaRequest>(fileContents, serializerSettings);

            Assert.Equal("1.0", req.Context.System.Device.SupportedInterfaces.AdvancedPresentationLanguage.Runtime.MaxVersion);

            Assert.Equal(AudioPlayerActivityEnum.Stopped, req.Context.AudioPlayer.PlayerActivity);

#if NET45 || NET47
            //     Assert.NotNull(req.Context.Display);
            object displayObj = req.Context.Display;

            Assert.NotNull(displayObj);
#else 


            Assert.NotNull(req.Context.Display);
#endif
        }

        [Trait("Type", "UnitTest")]
        [Fact]
        public void CanInvokeDeserializationTest()
        {
            string filePath = @"requestsamples\caninvokesamplerequest.json";


            string fileContents = File.ReadAllText(filePath);


            AlexaRequest req = JsonConvert.DeserializeObject<AlexaRequest>(fileContents);

            RequestType reqType = req.Request.Type;

            string intent = req.Request.Intent.Name;

            Assert.Equal(RequestType.CanFulfillIntentRequest, req.Request.Type);

            Assert.Equal("FindTrialByCityAndConditionIntent", req.Request.Intent.Name);



            string selectedCity = req.Request.Intent.GetSlotValue("city");           

            Assert.Contains("epilepsy", req.Request.Intent.GetSlotValue("condition"));


            Assert.Equal("New York", req.Request.Intent.GetSlotValue("city"));

        }

        [Trait("Type", "UnitTest")]
        [Fact]
        public void GetRequestType()
        {
            RequestType reqType = RequestType.SkillEnabled;

            string enabledMember = reqType.GetDescriptionFromEnumValue();


            RequestType fromMemberString = enabledMember.GetEnumValue<RequestType>();



        }

        [Trait("Type", "UnitTest")]
        [Fact]
        public void AcceptPermissionDeserializationTest()
        {
            string filePath = @"requestsamples\acceptpermissionrequest.json";


            string fileContents = File.ReadAllText(filePath);


            AlexaRequest req = JsonConvert.DeserializeObject<AlexaRequest>(fileContents);

            Assert.Equal<RequestType>(RequestType.SkillPermissionAccepted, req.Request.Type);

            Assert.Contains<AcceptedPermission>(req.Request.Body.AcceptedPermissions, x => x.Scope.Equals(PermissionScopes.SCOPE_EMAIL_READ));

            Assert.Null(req.Request.Body.UserInformationPersistenceStatus);
        }

        [Trait("Type", "UnitTest")]
        [Fact]
        public void SkillDisabledTest()
        {
            string filePath = @"requestsamples\skilldisabledrequest.json";


            string fileContents = File.ReadAllText(filePath);


            AlexaRequest req = JsonConvert.DeserializeObject<AlexaRequest>(fileContents);

            Assert.Equal<RequestType>(RequestType.SkillDisabled, req.Request.Type);

            Assert.Equal(UserInformationPersistedEnum.NotPersisted, req.Request.Body.UserInformationPersistenceStatus);

            Assert.NotNull(req.Request.EventCreationTime);

            Assert.NotNull(req.Request.EventPublishingTime);


        }

    }


}
