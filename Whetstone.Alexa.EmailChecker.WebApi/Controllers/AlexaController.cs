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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Whetstone.Alexa.EmailChecker;

namespace Whetstone.Alexa.EmailChecker.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/alexa")]
    public class AlexaController : Controller
    {
        
        // private IConfiguration _config;

        private const int MAXREQUESTSENDTIME = 150;

        public AlexaController()
        {

        }




        [HttpPost]
        public async Task<ActionResult> ProcessAlexaRequest([FromBody] AlexaRequest request)
        {
            // One of Alexa's policy requirements is that the request cannot take more then 150 seconds to get from the Echo to the skill processing logic.
            // This check enforces that policy
            var diff = DateTime.UtcNow - request.Request.Timestamp;
#if DEBUG
            // For the diff to be one second to satisfy conditions
            diff = new TimeSpan(0, 0, 0, 1);
#endif


            if (Math.Abs((decimal)diff.TotalSeconds) <= MAXREQUESTSENDTIME)
            {
                Trace.TraceInformation("Alexa request was timestamped {0:0.00} seconds ago below the {1} second maximum.", diff.TotalSeconds, MAXREQUESTSENDTIME);
                AlexaResponse resp = await EmailProcessor.ProcessEmailRequestAsync(request);



                return Ok(resp);
            }
            else
            {
                Trace.TraceWarning("Alexa request was timestamped {0:0.00} seconds ago. It exceeds the {1} second maximum", diff.TotalSeconds, MAXREQUESTSENDTIME);

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
