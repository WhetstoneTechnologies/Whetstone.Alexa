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
using System;
using System.Collections.Generic;
using System.Text;
using Whetstone.Alexa.CanFulfill;
using Whetstone.Alexa.Display;
using Whetstone.Alexa.Serialization;
using Xunit;
using Whetstone.Alexa.Audio.AmazonSoundLibrary;

namespace Whetstone.Alexa.Test
{
    public class SerializationTest
    {
        [Trait("Type", "UnitTest")]
        [Fact]
        public void SerializeEmptyResponse()
        {

            AlexaResponse resp = new AlexaResponse();

            string textResp = JsonConvert.SerializeObject(resp);

            // The text should serialize to empty brackets.

            Assert.Equal("{}", textResp);

        }


        [Trait("Type", "UnitTest")]
        [Fact]
        public void SimpleResponse()
        {

            string textResp = "You are following a path in forest and have come to a fork. Would you like to go left or right?";

            StringBuilder ssmlSample = new StringBuilder();

            ssmlSample.Append("<speak><audio src='https://dev-sbsstoryengine.s3.amazonaws.com/stories/animalfarmpi/audio/Act1-OpeningMusic-alexa.mp3'/> ");
            ssmlSample.Append("It was a dark and stormy night. <break time='500ms'/>");
            ssmlSample.Append("<say-as interpret-as='interjection'>no way!</say-as> ");
            ssmlSample.Append("I'm not doing this. That doesn’t make any sense!  That music didn’t sound dark and stormy at ");
            ssmlSample.Append("<prosody volume='x-loud' pitch='+10%'>all!</prosody>");
            ssmlSample.Append(" It sounds to me more like a bright and chipper morning! Should we go with dark and stormy, or bright and chipper?");
            ssmlSample.Append("</speak>");


            StringBuilder librarySample = new StringBuilder();
            librarySample.Append("<speak>");
            librarySample.Append(Office.ELEVATOR_BELL_1X_01);
            librarySample.Append("Your hotel is booked!");
            librarySample.Append("</speak>");


            AlexaResponse resp = new AlexaResponse
            {
                Version = "1.0",
                Response = new AlexaResponseAttributes
                {
                    // OutputSpeech = OutputSpeechBuilder.GetPlainTextSpeech(textResp),
                    OutputSpeech = OutputSpeechBuilder.GetSsmlSpeech(ssmlSample.ToString()),
                    Card = CardBuilder.GetStandardCardResponse("Fork in the Road",
                            textResp,
                            "https://dev-custom.s3.amazonaws.com/adventuregame/images/forkintheroad_1200x600.png",
                            "https://dev-custom.s3.amazonaws.com/adventuregame/images/forkintheroad_1200x600.png"

                            ),
                    Reprompt = new RepromptAttributes
                    {
                        OutputSpeech = OutputSpeechBuilder.GetPlainTextSpeech("Left or right?"),
                    },
                    ShouldEndSession = false
                },
                
            };

       
            string textSer = JsonConvert.SerializeObject(resp, Formatting.Indented);

            // The text should serialize to empty brackets.
            

        }



        [Trait("Type", "UnitTest")]
        [Fact]
        public void DirectiveResponse()
        {

            AlexaResponse resp = new AlexaResponse
            {
                Version = "1.0",
                Response = new AlexaResponseAttributes
                {
                    OutputSpeech = OutputSpeechBuilder.GetPlainTextSpeech("You are hearing me talk."),
                    Card = CardBuilder.GetSimpleCardResponse("Card Title", "This is some card text."),
                },
            };

            DisplayDirectiveResponse displayResp = new DisplayDirectiveResponse();
            displayResp.Template = new DisplayTemplate();
            displayResp.Template.Type = DisplayTemplateTypeEnum.BodyTemplate3;
            displayResp.Template.Token = "user_email";
            displayResp.Template.Title = "Display Title";
            displayResp.Template.TextContent = new DisplayTextContent();
            displayResp.Template.TextContent.PrimaryText = new DisplayTextField();
            displayResp.Template.TextContent.PrimaryText.Type = DisplayTextTypeEnum.RichText;
            displayResp.Template.TextContent.PrimaryText.Text = "<b><font size=\"6\">Some bold text</font></b>";

            displayResp.Template.Image = new DisplayDirectiveImage("small image", "http://pathtosomeimage");

            displayResp.Template.BackgroundImage = new DisplayDirectiveImage("background image", "http://pathtosomebackgroundimage");

            resp.Response.Directives = new List<DirectiveResponse>();

            resp.Response.Directives.Add(displayResp);

            string textResp = JsonConvert.SerializeObject(resp, Formatting.Indented);

            // The text should serialize to empty brackets.


        }

        [Trait("Type", "UnitTest")]
        [Fact]
        public void CanFulfillEnumSerializationTest()
        {

            CanFulfillEnum fulfillEnum = CanFulfillEnum.Yes;

            string textVal = fulfillEnum.GetDescriptionFromEnumValue();


            Assert.Equal("YES", textVal);

            CanFulfillEnum yesVal = textVal.GetEnumValue<CanFulfillEnum>();


            Assert.Equal(CanFulfillEnum.Yes, yesVal);

        }

    }
}
