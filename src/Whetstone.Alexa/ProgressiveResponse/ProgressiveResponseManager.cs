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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Whetstone.Alexa.ProgressiveResponse
{
    public class ProgressiveResponseManager : IProgressiveResponseManager
    {
        //        POST https://api.amazonalexa.com/v1/directives HTTP/1.1
        //Authorization: Bearer AxThk...
        //Content-Type: application/json

        //{
        //            "header":{
        //                "requestId":"amzn1.echo-api.request.xxxxxxx"
        //            },
        //  "directive":{
        //                "type":"VoicePlayer.Speak",
        //    "speech":"This text is spoken while your skill processes the full response."
        //  }
        //        }
        private const string PROGRESSIVE_RESP_FRAG = "{0}/v1/directives";


        private ILogger _logger = null;


        public ProgressiveResponseManager(ILogger logger) : this()
        {
            _logger = logger;
        }

        public ProgressiveResponseManager()
        {


        }

        public async Task SendProgressiveResponseAsync(AlexaRequest req, string text)
        {
                await SendProgressiveResponseAsync(req?.Context?.System?.ApiEndpoint,
                    req?.Context?.System?.ApiAccessToken,
                    req?.Request?.RequestId,
                    text);
        }



        /// <summary>
        /// Sends a response to let the Alexa user know that the skill is working on the request.
        /// </summary>
        /// <param name="apiEndpoint">The API endpoint.</param>
        /// <param name="apiAccessToken"></param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="text">This can be plain text or ssml. If it contains any audio MP3 files, they cannot take more than 30 secs. to play.</param>
        public async Task SendProgressiveResponseAsync(string apiEndpoint, string apiAccessToken, string requestId, string text)
        {
            if (string.IsNullOrWhiteSpace(apiEndpoint))
                throw new ArgumentException("apiEndpoint cannot be null or empty");

            if (string.IsNullOrWhiteSpace(apiAccessToken))
                throw new ArgumentException("apiAccessToken cannot be null or empty");

            if (string.IsNullOrWhiteSpace(requestId))
                throw new ArgumentException("requestId cannot be null or empty");

            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("text cannot be null or empty");

            string progRespUrl = GetProgressiveUrl(apiEndpoint);
            
            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header


                _logger?.LogDebug("Setting bearer token '{0}'", apiAccessToken);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiAccessToken);


                _logger?.LogDebug("Executing POST against '{0}'", progRespUrl);

                HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, progRespUrl);

                ProgressiveRequest progReq = new ProgressiveRequest(requestId, text);

                string progJsonText = null;

                try
                {
                    progJsonText = JsonConvert.SerializeObject(progReq);
                }
                catch(JsonSerializationException serEx)
                {
                   
                    string errMsg = string.Format("Error serializing progressive request");
                    _logger?.LogError(ErrorEventCatalog.PROGRESSIVE_RESPSERIALIZATION, serEx, errMsg);
                    throw new ProgressiveRequestException(errMsg, serEx);

                }

                reqMessage.Content = new StringContent(progJsonText, Encoding.UTF8,
                                    "application/json");

                HttpResponseMessage respMessage = null;

                try
                {
                    respMessage = await httpClient.SendAsync(reqMessage);
                }
                catch (Exception ex)
                {
                    string errMsg = string.Format("Error calling {0}", progRespUrl);
                    _logger?.LogError(ErrorEventCatalog.PROGRESSIVE_INVOCATION, ex, errMsg);
                    throw new ProgressiveRequestException(errMsg);
                }


                if (respMessage.StatusCode == HttpStatusCode.NoContent ||
                     respMessage.StatusCode == HttpStatusCode.OK)
                {
                    _logger?.LogInformation("ProgressiveRequest succeeded");
                }
                else
                {

                    int httpStatus = (int)respMessage.StatusCode;

                    // 400 Bad Request The requestId is either missing from the request, or is structurally incorrect.
                    // 403 Forbidden The authentication token is invalid or doesn't have access to the resource. This is also returned if the requestId represents a request that is no longer applicable, such as when the progressive response is received after skill's full response.
                    // 405 Method Not Allowed The method is not supported.
                    // 429 Too Many Requests The skill has been throttled due to an excessive number of requests.
                    // 500 Internal Error  

                    int statusCode = (int) respMessage.StatusCode;
                    string errMsg = null;
                    switch(statusCode)
                    {
                        case (int) HttpStatusCode.BadRequest:
                            errMsg = "The requestId is either missing from the request, or is structurally incorrect.";
                            break;
                        case  (int) HttpStatusCode.Forbidden:
                            errMsg = "The authentication token is invalid or doesn't have access to the resource. This is also returned if the requestId represents a request that is no longer applicable, such as when the progressive response is received after skill's full response.";                           
                            break;
                        case (int) HttpStatusCode.MethodNotAllowed:
                            errMsg = "The method is not supported.";
                            break;
                        case 429: // Too many requests
                            errMsg = "The skill has been throttled due to an excessive number of requests.";
                            break;
                        case (int)HttpStatusCode.InternalServerError:
                            errMsg = "Internal error";
                            break;
                        default:
                            errMsg = "Unexpected response";
                            break;
                    }

                    _logger.LogError(string.Concat(statusCode, ": ", errMsg));
                    throw new ProgressiveRequestException(errMsg, statusCode);
                }
            }
        }

        private string GetProgressiveUrl(string apiEndpoint)
        {

            string fullUrl = string.Format(PROGRESSIVE_RESP_FRAG, apiEndpoint);

            return fullUrl;

        }


    }
}
