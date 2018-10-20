// Copyright (c) 2018 Whetstone Technologies
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so.
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
using Whetstone.Alexa.Audio;

namespace Whetstone.Alexa
{
    public class ContextAttributes
    {



        //	"apiEndpoint": "https://api.amazonalexa.com",
        //	"apiAccessToken": "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjk0YzNmZDljLWE5MTUtNDhkOC05OThiLWI5NmY4NTYwNDQwOSIsImV4cCI6MTUzODU4ODExNiwiaWF0IjoxNTM4NTg0NTE2LCJuYmYiOjE1Mzg1ODQ1MTYsInByaXZhdGVDbGFpbXMiOnsiY29uc2VudFRva2VuIjpudWxsLCJkZXZpY2VJZCI6ImFtem4xLmFzay5kZXZpY2UuQUVRR1g1VEpPUlJWSExBS0VaT0tQN1ZGVldGRFlWNFdaSkJVR0tPS1Y3UklUWFpFUTZYTzRUQVJUM1g2WEg2MkZYNUNRR1BEM1FWQlhKWURXTFhLSVBXN0k2N1VKQVZFREdSNEFKUlhWVVZHQkZWRkdRSFFaUEhRVEQzRDJCTkFLTDczMk9XQU9GWktaWFRIUk9NNFZERVJJUUFBIiwidXNlcklkIjoiYW16bjEuYXNrLmFjY291bnQuQUUzRFozTkpMRVMzWjVFTTdJTjNXTzNaSDdMWEZVR05aTlZISEVEVEQzWUtSWk1WUFRLSVE2UDNIUjRXVUhZSTczWEI0U0c3RTdBWVFDWFpVWE9USVpSR1pCTEdMNFIyM0hLSU5aVFRXUkg2VlJPVU9GUjRQTFRMSVQ0SEhKWDM0U05SUEYzRk5JTUpTTUZNUkRDNE4yR0ZSWk5HUkZHQ1dDMkpISk1LRFlIVzVXT1JFQ0pPSElJN1c0RERRT0hOQ0ozVVhQVEpLWlFBT1pRIn19.Y8zyASV79eYnc_XiDQ35bWU1E2PoMrtJAKLSCXeY7_5Cp703gfGSN6GO6uOz5C72mJScUpnKgBEvXQHV19sqX56DzJl3YheIWZBIZUC04sAFo4I5zJ2V9ZcD-oXoqIBVvgxqy6yud4TC-XLyqBRXOTzr01HTYWwqVlrLkSsOcoc9TwnWKmuc1LmNDoqgSuUjvuT59z7AC7CUOhUBO1aBBKJOP53pBEUtVwdENTPi0JbYR5G0QND1pI-RRoSavg03CBNx4cHHCuSvmbZTGT5j2c_CTQk-PBy_3HiF_IwGtzQaOdiZaDmbfoKwspu2St_teXaTx6YBJvgoh0hjzQK1sw"

        [JsonProperty("System", NullValueHandling = NullValueHandling.Ignore)]
        public SystemAttributes System { get; set; }

        [JsonProperty("Viewport", NullValueHandling = NullValueHandling.Ignore)]
        public ViewportAttributes Viewport { get; set; }

        [JsonProperty("Display", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Display { get; set; }

        [JsonProperty("AudioPlayer", NullValueHandling = NullValueHandling.Ignore)]
        public AudioPlayerRequestAttributes AudioPlayer { get; set; }

    }
}
