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
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Whetstone.Alexa.Display;
using Whetstone.Alexa.Security;
using System.Net;
using Whetstone.Alexa.CanFulfill;

namespace Whetstone.Alexa.EmailChecker
{


    public static class EmailProcessor
    {
        private static readonly DisplayDirectiveImage BACKGROUND_IMAGE = new DisplayDirectiveImage("email background",
                    "https://dev-custom.s3.amazonaws.com/emailchecker/image/emailbackground_1200x600.png", 1024, 600);



        internal const string EMAIL_REQUEST_INTENT = "EmailCheckIntent";

        public static bool PermissionGranted { get; private set; }
        public static string Email { get; private set; }
        

        public static async Task<AlexaResponse> ProcessEmailRequestAsync(AlexaRequest request)
        {
            AlexaResponse response = new AlexaResponse();


            string intentName = request.Request.Intent.Name;


            switch (request.Request.Type)
            {
                case RequestType.LaunchRequest:
                    response = await GetLaunchResponseAsync(request);
                    break;
                case RequestType.IntentRequest:

                    break;
                case RequestType.CanFulfillIntentRequest:
                    response = await GetCanFulfillResponse(request.Request.Intent);
                    break;
            }


            return response;
        }

        private static async  Task<AlexaResponse> GetCanFulfillResponse(IntentAttributes intent)
        {
            AlexaResponse resp = new AlexaResponse();
            resp.Version = "1.0";
            resp.Response = new AlexaResponseAttributes();

            if(intent.Name.Equals(EMAIL_REQUEST_INTENT, StringComparison.OrdinalIgnoreCase))
            {
                resp.Response.CanFulfill = new CanFulfillResponseAttributes(CanFulfillEnum.Yes);
            }
            else
            {
                resp.Response.CanFulfill = new CanFulfillResponseAttributes(CanFulfillEnum.No);
            }
            //resp.Response.ShouldEndSession = true;

            return resp;
        }

        private static async Task<AlexaResponse> GetLaunchResponseAsync(AlexaRequest req)
        {
            // Attempt to get the user's email address.

           

            string emailAddress = null;




            AlexaResponse resp = new AlexaResponse
            {
                Version = "1.0",

                Response = new AlexaResponseAttributes
                {
                    OutputSpeech = new OutputSpeechAttributes()
                }
            };


            var ret = await GetEmailAddressAsync(req);

            if (ret.PermissionGranted)
            {
                resp.Response.OutputSpeech.Type = OutputSpeechType.Ssml;

                string[] emailParts = ret.Email.Split('@');

                string emailName = emailParts[0];
                string emailHost = emailParts[1];

                string title = "Your Email";

                resp.Response.OutputSpeech.Ssml = $"<speak>Your email is <prosody rate=\"x-slow\"><say-as interpret-as=\"characters\">{emailName}</say-as></prosody>@{emailHost}</speak>";

                string textResp = ret.Email;

                resp.Response.Card = CardBuilder.GetSimpleCardResponse(title, string.Concat("Your email is ", ret.Email));

               

                if (req.Context.System.Device.SupportedInterfaces.Display != null)
                {
                    resp.Response.Directives = new List<DirectiveResponse>();
                    DisplayDirectiveResponse displayResp = new DisplayDirectiveResponse();
                    displayResp.Template = new DisplayTemplate();
                    displayResp.Template.Type = DisplayTemplateTypeEnum.BodyTemplate3;
                    displayResp.Template.Token = "user_email";
                    displayResp.Template.Title = title;
                    displayResp.Template.TextContent = new DisplayTextContent();
                    displayResp.Template.TextContent.PrimaryText = new DisplayTextField();
                    displayResp.Template.TextContent.PrimaryText.Type = DisplayTextTypeEnum.RichText;
                    displayResp.Template.TextContent.PrimaryText.Text = "<b><font size=\"6\">" + WebUtility.HtmlEncode(ret.Email) + "</font></b>";

                    displayResp.Template.Image = GetSideIconImage();


                    displayResp.Template.BackgroundImage = BACKGROUND_IMAGE;

                    resp.Response.Directives.Add(displayResp);
                }



            }
            else
            {
                resp.Response.OutputSpeech.Type = OutputSpeechType.PlainText;

                StringBuilder sb = new StringBuilder();
                sb.Append("The skill needs permission to access your email in order to repeat it to you.  ");                
                sb.Append("Your email address is not retained or used by the skill other than to repeat the email to you.");

                string textResp = sb.ToString();
                resp.Response.OutputSpeech.Text = sb.ToString();

                resp.Response.Card = CardBuilder.GetPermissionRequestCard(PersonalDataType.Email);


                if (req.Context.System.Device.SupportedInterfaces.Display != null)
                {
                    DisplayDirectiveResponse displayResponse = new DisplayDirectiveResponse(DisplayTemplateTypeEnum.BodyTemplate3, "Permission Needed");

                    displayResponse.Template.BackgroundImage = BACKGROUND_IMAGE;
                    displayResponse.Template.Token = "no_permission";


                    DisplayTextContent displayText = new DisplayTextContent();
                    displayText.PrimaryText = new DisplayTextField("The skill needs permission to access your email.");
                    displayText.PrimaryText.Type = DisplayTextTypeEnum.RichText;
                    displayText.SecondaryText = new DisplayTextField("A permission request has been sent to your Alexa mobile app. You can check it on your mobile phone or open a browser and log into alexa.amazon.com");

                    displayResponse.Template.TextContent = displayText;
                    displayResponse.Template.Image = GetSideIconImage();


                    DisplayDirectiveHintResponse hintResponse = new DisplayDirectiveHintResponse("Check alexa.amazon.com or your Alexa mobile app.");


                    resp.Response.Directives = new List<DirectiveResponse>();
                    resp.Response.Directives.Add(displayResponse);
                    resp.Response.Directives.Add(hintResponse);
                }
              //  resp.Response.Directives.Add(hintRepsonse);
            }
            


            resp.Response.ShouldEndSession = true;



            

            return resp;
        }

        private static DisplayDirectiveImage GetSideIconImage()
        {
            DisplayDirectiveImage sideImage = new DisplayDirectiveImage("email icon");


            DisplayDirectiveImageSource emailIcon576 = new DisplayDirectiveImageSource(
                "https://dev-custom.s3.amazonaws.com/emailchecker/image/emailicon_576x576.png", 576, 576);

            DisplayDirectiveImageSource emailIcon340 = new DisplayDirectiveImageSource(
                "https://dev-custom.s3.amazonaws.com/emailchecker/image/emailicon_340x340.png", 340, 340);

            sideImage.Sources = new List<DisplayDirectiveImageSource> { emailIcon340, emailIcon576 };


            return sideImage;

        }

        private async static Task<(bool PermissionGranted, string Email)> GetEmailAddressAsync(AlexaRequest req)
        {
            AlexaUserDataManager userDataManager = new AlexaUserDataManager();
            string emailAddress = null;
            bool isPermissionGranted = false;

            try
            {
                emailAddress = await userDataManager.GetAlexaUserEmailAsync(req.Context.System.ApiEndpoint, req.Context.System.ApiAccessToken);
                isPermissionGranted = true;
            }
            catch (AlexaSecurityException secEx)
            {
                if(secEx.StatusCode == HttpStatusCode.Forbidden)
                {
                    isPermissionGranted = false;

                }

            }



            return (PermissionGranted : isPermissionGranted, Email : emailAddress);
        }

    }

}
