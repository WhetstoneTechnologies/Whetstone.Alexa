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
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Whetstone.Alexa.Security;
using Xunit;

namespace Whetstone.Alexa.Test
{
    public class SecurityTests
    {

        private const string ApiBadToken = "BLAH";
        private const string ApiTimedOutToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgxZjM3NjMzLTZlMzktNDAwYi1iZTFjLTBmNWQ1NGNhYzVjMiIsImV4cCI6MTUzOTM5OTM0MCwiaWF0IjoxNTM5Mzk1NzQwLCJuYmYiOjE1MzkzOTU3NDAsInByaXZhdGVDbGFpbXMiOnsiY29uc2VudFRva2VuIjoiQXR6YXxJd0VCSUt0Q1JkY1UtTXFYX1VQVVppb1JKR2dnWWRSMXpNZDRZT0pSZThHZVZXQ2VKdDR6OGdXUTY2OHhpUXZ0QzdCLVF1cEI4Q3FqVERGallvTlBRXzdWTnZuOXQweWY0Nms2QUNjZXR5Sm1WMzBxZm5oOWdkWXhKdEQxLWc5U3Fxem5vbUd2aXRib2xmV1lxcktvUktNWHozcXdyVUh1a0E2U2ZWZndwMXVUN1Rma1BOYjdVNEhkYmVOMVJKRjQzWWx0NzFoX3Z4QXRLeDR3RGNWNjZsU0tyTGRFR2IyZ0NkZktQSmdaQnA3V2JHNDA4emJ6Zjk4M3JHajQwZ2ozZVpGZnpPMlg3NFVVYWVfQ3B5ZkxjbzhNdHJNZlJneWNvTmk5b3hYTW1jS0NMSjFtNHJmREw0QnRRWUxSWGRBNGZlRkVmeENCdTVubk5pdi1tZHlnWlp3RUZDOWFucHBFTkZPUjg2N2lOcjQ2UVhrNWw1SklpNUxlbVFBXzlIS1cwSUl2a2tTSVFiRTJ0M1YtQmZrbDRyT1hqS3JsTmtyem9PdW52ZkVMRDRYbTg3ZGRpNVgyNDdUWUlPeE9RR0prQlFyYU0zY1pTM1VMSGdaMWNMcld4R2lPUkVXWFZyUUhobjZGZWhFZi1IemtKZS16dlZwYjM1aDRpNUlKN1k0aUc3dTltSEsyb3BYdWNIc19sQlNEZVdiZTF0RmdsTWpsbVVraTd5Vks3Z05MT0RVLWtDa1JYVW9IS1hNTldjMTRaYUttT0ZuTE5mR1VPSWxSSUdmU2pva1RSMkxIIiwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSUg1WTdLTU02Q0ZTUjdLT0JITVZNUVJVU01JQ1dKTlZMQ1o2NVYyWkFWSTRGNkpORE1aSEY2STQ0R1NaRTRUTElHTFU2REIyUExGUlAzNEFFREs1RUxNVEkySTMyWU1QS0lYWUhUS0lDVUVQNktLUTNVVjdYQ1hNU0dEUVg3NUdCVDJXWVZKQktKVEpSTjNERkNPNklES1BYUSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0RLRkxPWU9VSkdJSU1XNlZTV0NFSU1YTFJRVUJYSkc2NERWSVY3U1hKTjdIR1JERlZEQk40WkY1WkVaSVBETlRUN0RNNVhEUU0zUEI1QlVPU0lHTEI3QlVVTlEyRUVTM1oyS1RZTEVLTFI3VjNWUVVWUzM1SkFOVURJN0ZWWlBZSzZFRjVUUk1PRTRLUDRKSkpOVUM2UzdOVlcyUUtEWTU2UE5KTEJTSEFKMklVUE1OV05BTzVRNUs0TUdBVVdHTzYyVDRXTTVSNVBJSSJ9fQ.G8XWkl2f9EWgOUXdq8u_1gvN0aKe59F1jr0ysU7vjUiVKEK8OO4Kxdo_EmgKNKTryRBB-ft_xqGBCTGyxOSoDjvWQPujIJX1fPKLlYg0jiKmTKw0JWV4HVeEbA6CZHo_gO-E88pZuLRJ5ZBBJ6LuXZS0S20WJv5YxTzDLt2UZjijcW0Ju3W2lYuaBOi92yPsfP9Emw27SQXtJfxDz0VzxawEqMQGjQJIsSf0dfR3qGZjPRSU-LO4W-H0KCNDivT2k_M6XpNlThAj9hFp8IB0wEQXd9EetnX9mIEDh72Ds7Qn2lzzbcs_Qm0dHz-nmlJOqQExJa9XkYoHYWwrb7AdYw";


        private const string ApiToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjgxZjM3NjMzLTZlMzktNDAwYi1iZTFjLTBmNWQ1NGNhYzVjMiIsImV4cCI6MTUzOTQ3ODM0MiwiaWF0IjoxNTM5NDc0NzQyLCJuYmYiOjE1Mzk0NzQ3NDIsInByaXZhdGVDbGFpbXMiOnsiY29uc2VudFRva2VuIjoiQXR6YXxJd0VCSURScFJNemJuLWEwaFJyT21mWXNTRmhHdVJINnpmWDFZaXYybFFrcGxlRGs4WlNOTk1SdExGRFQ5MVJ4R3R6VlRzQWsyX1RpVjFkbjc5czA4RnUyd2ZNY1VTd2JjaDExOWtBay1fZ3RJdmN5dlZQLUxNWnZrR0VZSkU5NVliWk1ETlg3WThwLU1kSi12eHBpa09EZG1yRU85dHlpQjdZSGRaRjJVZU9VdlFISTdNTG9JNEkwaWJienRibFhmTU1FY19tdVQ3eHdCM0V3b2h5YjIxWHl2VDJndVRHTDg2bDFkVEcxMjdZTW5zYXNoUVBxRE9QS3BwOFdtTFFEd1lmcG9IaXhjT0x0aWsyMmdZMXp5R1IyeWxrMV95MnptREExMVBZcXhZbDJkcDVVNkpLaXdubnE3M1lrUW1EandkRlRMLXlyRWJXLVZOaWlTRXF0MzFEajJCdTVMeTA2cDNZUDRrOHJZc1gwbHgzMm9ENHR6alpvU19IMGJzQzVxeWI4R1ZLYWV5cnFRVmxrb2l0b05WWXg1UnkzeUZEcTZOMElFYzNlWGVJVEhJazZWa21GOFE3UTV6cmZGU0Y2TWx1Q1dTZmFaLWtoQVI0REhkUTY1XzZYTXB6N1M0Tm1BNXkwNFFnMXZNSFFsa2lBZm5HNGNQZ21rQTNhUkpSQk55VXlrVlRwalFjdFlmS295Sm96Rmp0NEhIUlMxUGktZzk5dWNBSlpmaTZHNVNNclBBIiwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFSUg1WTdLTU02Q0ZTUjdLT0JITVZNUVJVU01JQ1dKTlZMQ1o2NVYyWkFWSTRGNkpORE1aSEY2STQ0R1NaRTRUTElHTFU2REIyUExGUlAzNEFFREs1RUxNVEkySTMyWU1QS0lYWUhUS0lDVUVQNktLUTNVVjdYQ1hNU0dEUVg3NUdCVDJXWVZKQktKVEpSTjNERkNPNklES1BYUSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFGR0RLRkxPWU9VSkdJSU1XNlZTV0NFSU1YTFJRVUJYSkc2NERWSVY3U1hKTjdIR1JERlZEQk40WkY1WkVaSVBETlRUN0RNNVhEUU0zUEI1QlVPU0lHTEI3QlVVTlEyRUVTM1oyS1RZTEVLTFI3VjNWUVVWUzM1SkFOVURJN0ZWWlBZSzZFRjVUUk1PRTRLUDRKSkpOVUM2UzdOVlcyUUtEWTU2UE5KTEJTSEFKMklVUE1OV05BTzVRNUs0TUdBVVdHTzYyVDRXTTVSNVBJSSJ9fQ.iRgPV9NX1mB5QC28UFmGiztZf0gN63zuRcoU6W8W9tuA-Hito4NrWNBHqGvsmgxVU_wVCIvXmfRQYgFuCBAFlpOVi7NpHy2ym7f4mzKLeM4GDUUUiTHwrGuNdRK4rKgIyCYUImCMUvjglkLEpy7s63cupaFedIR1Sb8U3dGNfIGFCgjibBoDscrzPm1dF8ruEK7JOfYpqAzgrsp66rnlPX6vSEM8DEM-O4skEBL1RUi-A8wo1orT4CLVh6B7apCntHL3rhnkc1aIl2PtzQ_FXgBXmv5Cub5StOIOqffBpdyxQ-WwlCXR1eIE_hvr9jNPQRdmwTrtUFGDX4Ak-vP7xg";
        private const string DeviceId = "amzn1.ask.device.AEIH5Y7KMM6CFSR7KOBHMVMQRUSMICWJNVLCZ65V2ZAVI4F6JNDMZHF6I44GSZE4TLIGLU6DB2PLFRP34AEDK5ELMTI2I32YMPKIXYHTKICUEP6KKQ3UV7XCXMSGDQX75GBT2WYVJBKJTJRN3DFCO6IDKPXQ";


        private const string ApiEndpoint = "https://api.amazonalexa.com";

        [Trait("Type", "IntegrationTest")]
        [Theory()]
        [InlineData(ApiTimedOutToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiBadToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiToken, HttpStatusCode.OK)]
        public async Task GetFullNameAsync(string token, HttpStatusCode expectedCode)
        {
            AlexaUserDataManager dataManager = new AlexaUserDataManager();
            string fullName = null;


            try
            {

                fullName = await dataManager.GetAlexaUserFullNameAsync(ApiEndpoint, token);
            }
            catch (AlexaSecurityException secResp)
            {
                Debug.WriteLine(secResp.Message);

                Assert.Equal(expectedCode, secResp.StatusCode);

            }

            if (expectedCode == HttpStatusCode.OK)
            {
                // if a good response is expected, then we should have a populated given name.
                Assert.True(!string.IsNullOrWhiteSpace(fullName));
            }
        }


        [Trait("Type", "IntegrationTest")]
        [Theory()]
        [InlineData(ApiTimedOutToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiBadToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiToken, HttpStatusCode.OK)]
        public async Task GetEmailAsync(string token, HttpStatusCode expectedCode)
        {
            AlexaUserDataManager dataManager = new AlexaUserDataManager();
            string email = null;


            try
            {

                email = await dataManager.GetAlexaUserEmailAsync(ApiEndpoint, token);
            }
            catch (AlexaSecurityException secResp)
            {
                Debug.WriteLine(secResp.Message);

                Assert.Equal(expectedCode, secResp.StatusCode);

            }

            if (expectedCode == HttpStatusCode.OK)
            {
                // if a good response is expected, then we should have a populated given name.
                Assert.True(!string.IsNullOrWhiteSpace(email));
            }
        }

        [Trait("Type", "IntegrationTest")]
        [Theory()]
        [InlineData(ApiTimedOutToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiBadToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiToken, HttpStatusCode.OK)]
        public async Task GetGivenNameAsync(string token, HttpStatusCode expectedCode)
        {

            AlexaUserDataManager dataManager = new AlexaUserDataManager();
            string givenName = null;
            try
            {
                givenName = await dataManager.GetAlexaUserGivenNameAsync(ApiEndpoint, token);
            }
            catch(AlexaSecurityException secResp)
            {
                Debug.WriteLine(secResp.Message);

                Assert.Equal(expectedCode, secResp.StatusCode);
               
            }

            if(expectedCode==HttpStatusCode.OK)
            {
                // if a good response is expected, then we should have a populated given name.
                Assert.True(!string.IsNullOrWhiteSpace(givenName));
            }

        }


        [Trait("Type", "IntegrationTest")]
        [Theory()]
        [InlineData(ApiTimedOutToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiBadToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiToken, HttpStatusCode.OK)]
        public async Task GetPhoneNumberAsync(string token, HttpStatusCode expectedCode)
        {

            AlexaUserDataManager dataManager = new AlexaUserDataManager();
            AlexaUserPhoneNumber phoneNumber = null;

            try
            {
                phoneNumber = await dataManager.GetAlexaUserPhoneNumberAsync(ApiEndpoint, token);
            }
            catch (AlexaSecurityException secResp)
            {
                Debug.WriteLine(secResp.Message);

                Assert.Equal(expectedCode, secResp.StatusCode);

            }

            if (expectedCode == HttpStatusCode.OK)
            {
                // if a good response is expected, then we should have a populated given name.
                Assert.NotNull(phoneNumber);
                Debug.WriteLine(phoneNumber.PhoneNumber);
            }

        }

        [Trait("Type", "IntegrationTest")]
        [Theory()]
       // [InlineData(ApiTimedOutToken, HttpStatusCode.Unauthorized)]
       // [InlineData(ApiBadToken, HttpStatusCode.Unauthorized)]
        [InlineData(ApiToken, DeviceId, HttpStatusCode.OK)]
        public async Task GetFullAddressAsync(string token, string deviceId, HttpStatusCode expectedCode)
        {

            AlexaUserDataManager dataManager = new AlexaUserDataManager();
            AlexaUserFullAddress userAddress = null;

            try
            {
                userAddress = await dataManager.GetAlexaUserFullAddressAsync(ApiEndpoint, token, deviceId);
            }
            catch (AlexaSecurityException secResp)
            {
                Debug.WriteLine(secResp.Message);

                Assert.Equal(expectedCode, secResp.StatusCode);

            }

            if (expectedCode == HttpStatusCode.OK)
            {
                // if a good response is expected, then we should have a populated given name.
                Assert.NotNull(userAddress);
                Debug.WriteLine(userAddress);
            }

        }

        [Trait("Type", "IntegrationTest")]
        [Theory]
        [InlineData(ApiToken, DeviceId, HttpStatusCode.OK)]
        public async Task GetPostalCodeAsync(string token, string deviceId, HttpStatusCode expectedCode)
        {

            AlexaUserDataManager dataManager = new AlexaUserDataManager();
            AlexaUserPostalCode userPostalCode = null;

            try
            {
                userPostalCode = await dataManager.GetAlexaUserPostalCodeAsync(ApiEndpoint, token, deviceId);
            }
            catch (AlexaSecurityException secResp)
            {
                Debug.WriteLine(secResp.Message);

                Assert.Equal(expectedCode, secResp.StatusCode);

            }

            if (expectedCode == HttpStatusCode.OK)
            {
                // if a good response is expected, then we should have a populated given name.
                Assert.NotNull(userPostalCode);
                Debug.WriteLine(userPostalCode.PostalCode);
            }

        }
    }
}
