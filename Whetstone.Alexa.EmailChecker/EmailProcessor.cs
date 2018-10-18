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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Whetstone.Alexa.Security;

namespace Whetstone.Alexa.EmailChecker
{


    public static class EmailProcessor
    {
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


                    break;
            }


            return response;
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


                resp.Response.OutputSpeech.Ssml = $"<speak>Your email is <prosody rate=\"x-slow\"><say-as interpret-as=\"characters\">{emailName}</say-as></prosody>@{emailHost}</speak>";

                string textResp = ret.Email;

                resp.Response.Card = CardBuilder.GetSimpleCardResponse("Your Email", "Something here");

            }
            else
            {
                resp.Response.OutputSpeech.Type = OutputSpeechType.PlainText;

                StringBuilder sb = new StringBuilder();
                sb.Append("The skill needs permission to access your email in order to repeat it to you.");                
                sb.Append("Your email address is not retained or used by the skill other than to repeat the email to you.");

                string textResp = sb.ToString();
                resp.Response.OutputSpeech.Text = sb.ToString();

                resp.Response.Card = CardBuilder.GetPermissionRequestCard(PersonalDataType.Email, textResp);
            }
            


            resp.Response.ShouldEndSession = true;



            

            return resp;
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
