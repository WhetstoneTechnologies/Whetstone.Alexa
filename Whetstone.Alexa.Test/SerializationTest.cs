using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Whetstone.Alexa.Test
{
    public class SerializationTest
    {

        [Fact]
        public void SerializeEmptyResponse()
        {

            AlexaResponse resp = new AlexaResponse();

            string textResp = JsonConvert.SerializeObject(resp);

            // The text should serialize to empty brackets.

            Assert.Equal("{}", textResp);

        }


    }
}
