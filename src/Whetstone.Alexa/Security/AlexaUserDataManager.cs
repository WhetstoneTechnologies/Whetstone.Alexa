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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Whetstone.Alexa.Security
{
    public enum PersonalDataType
    {
        FullAddress = 1,
        PostalCode = 2,
        PhoneNumber = 3,
        Email = 4,
        FullName = 5,
        GivenName = 6

    }

    public class AlexaUserDataManager : IAlexaUserDataManager
    {

        // For more information about getting user profile data:
        //  https://developer.amazon.com/docs/custom-skills/request-customer-contact-information-for-use-in-your-skill.html

        // For more information about getting device profile data:
        //  https://developer.amazon.com/docs/custom-skills/device-address-api.html

        private const string PROFILE_FRAG_FULLNAME = "{0}/v2/accounts/~current/settings/Profile.name";
        private const string PROFILE_FRAG_GIVENNAME = "{0}/v2/accounts/~current/settings/Profile.givenName";
        private const string PROFILE_FRAG_EMAIL = "{0}/v2/accounts/~current/settings/Profile.email";
        private const string PROFILE_FRAG_PHONENUMBER = "{0}/v2/accounts/~current/settings/Profile.mobileNumber";

        private const string PROFILE_POSTALCODE = "{0}/v1/devices/{1}/settings/address/countryAndPostalCode";
        private const string PROFILE_FULLADDRESS = "{0}/v1/devices/{1}/settings/address";


        private ILogger _logger = null;


        public AlexaUserDataManager(ILogger logger) : this()
        {
            _logger = logger;
        }

        public AlexaUserDataManager()
        {


        }


        private Uri GetAlexaUrl(PersonalDataType personalDataType, string apiEndpoint)
        {

            return GetAlexaUrl(personalDataType, apiEndpoint, null);

        }

        internal static string GetPermissionToken(PersonalDataType personalDataType)
        {
            string retToken = null;

            switch(personalDataType)
            {
                case PersonalDataType.Email:
                    retToken = PermissionScopes.SCOPE_EMAIL_READ;
                    break;
                case PersonalDataType.FullAddress:
                    retToken = PermissionScopes.SCOPE_FULLADDRESS;

                      //  PERM_TOKEN_FULLADDRESS;
                    break;
                case PersonalDataType.FullName:
                    retToken = PermissionScopes.SCOPE_FULLNAME_READ;
                        
                        //PERM_TOKEN_FULLNAME;
                    break;
                case PersonalDataType.GivenName:
                    retToken = PermissionScopes.SCOPE_GIVENNAME_READ;
                        
                        //PERM_TOKEN_GIVENNAME;
                    break;
                case PersonalDataType.PhoneNumber:
                    retToken = PermissionScopes.SCOPE_MOBILENUMBER_READ;
                        //PERM_TOKEN_PHONENUMBER;
                    break;
                case PersonalDataType.PostalCode:
                    retToken = PermissionScopes.SCOPE_POSTALCODE;
                        //PERM_TOKEN_POSTALCODE;
                    break;
            }

            return retToken;
        }

        private Uri GetAlexaUrl(PersonalDataType personalDataType, string apiEndpoint, string deviceId)
        {
            string textUrl = null;
            Uri retUri = null;

            switch (personalDataType)
            {
                case PersonalDataType.PostalCode:
                    textUrl = string.Format(PROFILE_POSTALCODE, apiEndpoint, deviceId);
                    _logger?.LogDebug("Building Url for Zip Code request");
                    break;
                case PersonalDataType.FullAddress:
                    textUrl = string.Format(PROFILE_FULLADDRESS, apiEndpoint, deviceId);
                    _logger?.LogDebug("Building Url for Full Address request");
                    break;
                case PersonalDataType.Email:
                    textUrl = string.Format(PROFILE_FRAG_EMAIL, apiEndpoint);
                    _logger?.LogDebug("Building Url for email request");
                    break;
                case PersonalDataType.FullName:
                    textUrl = string.Format(PROFILE_FRAG_FULLNAME, apiEndpoint);
                    _logger?.LogDebug("Building Url for full name request");
                    break;
                case PersonalDataType.GivenName:
                    textUrl = string.Format(PROFILE_FRAG_GIVENNAME, apiEndpoint);
                    _logger?.LogDebug("Building Url for given name request");
                    break;
                case PersonalDataType.PhoneNumber:
                    textUrl = string.Format(PROFILE_FRAG_PHONENUMBER, apiEndpoint);
                    _logger?.LogDebug("Building Url for phone number request");
                    break;
            }

            if (!string.IsNullOrWhiteSpace(textUrl))
            {
                retUri = new Uri(textUrl);
                _logger?.LogDebug("Built url {0}", textUrl);
            }
            else
                _logger?.LogWarning("No url built");

            return retUri;
        }



        /// <summary>
        /// Retrieves the user's full name if it is available.
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="apiToken"></param>
        /// <returns></returns>
        public async Task<string> GetAlexaUserFullNameAsync(string apiEndpoint, string apiToken)
        {
            string alexaTextResponse = await GetAlexaSecureStringAsync(PersonalDataType.FullName, apiEndpoint, apiToken);

            _logger?.LogInformation($"User full name returned: {alexaTextResponse}");

            return alexaTextResponse;
        }


        /// <summary>
        /// Retrieves the user's full name if it is available.
        /// </summary>
        /// <param name="apiEndpoint"></param>
        /// <param name="apiToken"></param>
        /// <returns></returns>
        public async Task<string> GetAlexaUserGivenNameAsync(string apiEndpoint, string apiToken)
        {

            string alexaTextResponse = await GetAlexaSecureStringAsync(PersonalDataType.GivenName, apiEndpoint, apiToken);

            _logger?.LogInformation($"User given returned: {alexaTextResponse}");

            return alexaTextResponse;
        }

        public async Task<string> GetAlexaUserEmailAsync(string apiEndpoint, string apiToken)
        {
            string alexaTextResponse = await GetAlexaSecureStringAsync(PersonalDataType.Email, apiEndpoint, apiToken);

            _logger?.LogInformation($"User email returned: {alexaTextResponse}");

            return alexaTextResponse;
        }



        private async Task<string> GetAlexaSecureStringAsync(PersonalDataType personalType, string apiEndpoint, string apiToken)
        {
            if (string.IsNullOrWhiteSpace(apiEndpoint))
                throw new ArgumentException("apiEndpoint cannot be null or empty");

            if (string.IsNullOrWhiteSpace(apiToken))
                throw new ArgumentException("apiToken cannot be null or empty");

            Uri alexaUrl = GetAlexaUrl(personalType, apiEndpoint);


            string alexaTextResponse = await GetAlexaSecurityInfoAsync(alexaUrl, apiToken);

            if (!string.IsNullOrWhiteSpace(alexaTextResponse))
            {
                if (alexaTextResponse.Length > 1 && alexaTextResponse[0].Equals('"'))
                    alexaTextResponse = alexaTextResponse.Substring(1, alexaTextResponse.Length - 2);
            }

            return alexaTextResponse;
        }


        private async Task<string> GetAlexaSecurityInfoAsync(Uri alexaUrl, string accessToken)
        {
            string bodyText = null;

            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _logger?.LogDebug("Setting bearer token '{0}'", accessToken);


                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                _logger?.LogDebug("Setting host header value '{0}'", alexaUrl.Host);

                httpClient.DefaultRequestHeaders.Host = alexaUrl.Host;


                _logger?.LogDebug("Executing GET against '{0}'", alexaUrl);

                HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Get, alexaUrl);

                HttpResponseMessage respMessage = null;

                try
                {
                    respMessage = await httpClient.SendAsync(reqMessage);
                }
                catch (Exception ex)
                {
                    string errMsg = string.Format("Error calling {0}", alexaUrl);
                    _logger?.LogError(ErrorEventCatalog.USER_SECURITYINVOCATION, ex, errMsg);
                    throw new AlexaSecurityException(errMsg);
                }


                if (respMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    bodyText = await respMessage.Content.ReadAsStringAsync();

                    _logger?.LogInformation($"Good response: {bodyText}");

                }
                else
                {
                    string alexaLogMessage = null;

                    int httpStatus = (int)respMessage.StatusCode;

                    //200 OK Successfully got the address associated with this deviceId.
                    //204 No Content  The query did not return any results.
                    //401 Unauthorized authentication token timed out 
                    //403 Forbidden The authentication token is invalid or doesn't have access to the resource.
                    //405 Method Not Allowed The method is not supported.
                    //429 Too Many Requests The skill has been throttled due to an excessive number of requests.
                    //500 Internal Error  An unexpected error occurred.


                    if (respMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        // TODO throw an informative error here
                        throw new AlexaSecurityException("No content returned", System.Net.HttpStatusCode.NoContent);
                    }
                    else
                    {

                        string respText = null;

                        try
                        {
                            respText = await respMessage.Content.ReadAsStringAsync();
                        }
                        catch(Exception ex)
                        {
                            alexaLogMessage = string.Format("Error deserializing response from {0}", alexaUrl);
                            _logger?.LogError(alexaLogMessage, ex);
                            throw new AlexaSecurityException(alexaLogMessage, respMessage.StatusCode, ex);
                        }

                        AlexaSecurityErrorResponse errResp = null;

                        try
                        {
                            errResp = JsonConvert.DeserializeObject<AlexaSecurityErrorResponse>(respText);
                        }
                        catch (Exception ex)
                        {
                            string errMsg = "Could not deserialized Alexa Error Response";
                            _logger?.LogWarning(ErrorEventCatalog.ALEXA_ERROR_DESERIALIZATION, ex, errMsg);

                            throw new AlexaSecurityException(errMsg, respMessage.StatusCode, ex);
                        }

                        if (errResp == null)
                        {
                            alexaLogMessage = string.Format("Error {0}: {1}", httpStatus, respText);
                            _logger?.LogError(alexaLogMessage);
                            throw new AlexaSecurityException(respText, respMessage.StatusCode);
                        }
                        else
                        {
                            alexaLogMessage = string.Format("Error {0}: Type: {1}, Message: {2}", httpStatus, errResp.Type, errResp.Message);
                            _logger?.LogError(alexaLogMessage);
                            throw new AlexaSecurityException(errResp, respMessage.StatusCode);
                        }
                    }
                }
            }


            return bodyText;
        }

        public async Task<AlexaUserPostalCode> GetAlexaUserPostalCodeAsync(string apiEndpoint, string apiToken, string deviceId)
        {
            AlexaUserPostalCode retPostalCode = null;

            string addressText = await GetAlexaDeviceAddressAsync(PersonalDataType.PostalCode, apiEndpoint, apiToken, deviceId);

            try
            {
                retPostalCode = JsonConvert.DeserializeObject<AlexaUserPostalCode>(addressText);
            }
            catch (Exception ex)
            {
                string alexaLogMessage = $"Error deserializing address response {addressText}";
                _logger?.LogError(alexaLogMessage, ex);
                throw new AlexaSecurityException(alexaLogMessage, ex);
            }

            return retPostalCode;
        }

        public async Task<AlexaUserFullAddress> GetAlexaUserFullAddressAsync(string apiEndpoint, string apiToken, string deviceId)
        {

            AlexaUserFullAddress retAddress = null;

            string addressText = await GetAlexaDeviceAddressAsync(PersonalDataType.FullAddress, apiEndpoint, apiToken, deviceId);

            try
            {
                retAddress = JsonConvert.DeserializeObject<AlexaUserFullAddress>(addressText);
            }
            catch (Exception ex)
            {
                string alexaLogMessage = $"Error deserializing address response {addressText}";
                _logger?.LogError(alexaLogMessage, ex);
                throw new AlexaSecurityException(alexaLogMessage, ex);
            }

            return retAddress;
        }


        private async Task<string> GetAlexaDeviceAddressAsync(PersonalDataType dataType, string apiEndpoint, string apiToken, string deviceId)
        {
            if (string.IsNullOrWhiteSpace(apiEndpoint))
                throw new ArgumentException("apiEndpoint cannot be null or empty");

            if (string.IsNullOrWhiteSpace(apiToken))
                throw new ArgumentException("apiToken cannot be null or empty");

            if (string.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentException("deviceId cannot be null or empty");

            Uri alexaUrl = GetAlexaUrl(dataType, apiEndpoint, deviceId);
      

            string addressText = await GetAlexaSecurityInfoAsync(alexaUrl, apiToken);

            

            return addressText;
        }

        public async Task<AlexaUserPhoneNumber> GetAlexaUserPhoneNumberAsync(string apiEndpoint, string apiToken)
        {
            AlexaUserPhoneNumber retPhoneNumber = null;
            string alexaTextResponse = await GetAlexaSecureStringAsync(PersonalDataType.PhoneNumber, apiEndpoint, apiToken);
        

            try
            {
                retPhoneNumber = JsonConvert.DeserializeObject<AlexaUserPhoneNumber>(alexaTextResponse);
            }
            catch(Exception ex)
            {
                string alexaLogMessage = $"Error deserializing phone number response {alexaTextResponse}";
                _logger?.LogError(alexaLogMessage, ex);
                throw new AlexaSecurityException(alexaLogMessage, ex);
            }

            if (retPhoneNumber != null)
            {
                _logger?.LogInformation($"User phone number returned +{retPhoneNumber.CountryCode} {retPhoneNumber.PhoneNumber}");
            }

            return retPhoneNumber;
        }
    }



}


