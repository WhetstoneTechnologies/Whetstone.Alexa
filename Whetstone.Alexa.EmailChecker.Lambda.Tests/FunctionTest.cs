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
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Newtonsoft.Json;

namespace Whetstone.Alexa.EmailChecker.Lambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            AlexaRequest req = new AlexaRequest();

            var upperCase = function.FunctionHandlerAsync(req, context);



            //Assert.Equal("HELLO WORLD", upperCase);
        }

        [Fact]
        public async Task FireCanFulfillRequestTest()
        {

            AlexaRequest req = new AlexaRequest();

            req.Version = "1.0";

            req.Request = new RequestAttributes();
            req.Request.RequestId = Guid.NewGuid().ToString();
            req.Request.Timestamp = DateTime.Now;
            req.Request.Locale = "en-US";
            req.Request.Type = RequestType.CanFulfillIntentRequest;
            req.Session = new AlexaSessionAttributes();
            req.Session.New = true;
            req.Session.SessionId = Guid.NewGuid().ToString();
            req.Request.Intent = new IntentAttributes("EmailCheckIntent");


            var function = new Function();
            var context = new TestLambdaContext();

           AlexaResponse resp = await function.FunctionHandlerAsync(req, context);

            string jsonText = JsonConvert.SerializeObject(resp);

        }
    }
}
