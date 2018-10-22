# Whetstone Alexa

## Introduction

This goal of the Nuget package is:

* Provide POCO classes and serialization helpers to send and receive messages to and from Alexa
* Integrate with the Amazon's Alexa related services to:
  * Get users security information like the user name, device address, etc.

## Processing Requests and Responses

The Whetstone.Alexa Nuget package includes classes for serialization and deserializing common requests and responses passed to and from 
Alexa Skills. The same structures apply irrespective of whether the client service is deployed as a web API or a Lambda Function. 


### Web Api Sample

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Whetstone.Alexa;
. . .

namespace Whetstone.Alexa.EmailChecker.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/alexa")]
    public class AlexaController : Controller
    {       
        [HttpPost]
        public async Task<ActionResult> ProcessAlexaRequest([FromBody] AlexaRequest request)
        {
           AlexaResponse resp = await _emailProcessor.ProcessEmailRequestAsync(request);
           return Ok(resp);
        }

```


### Lambda Function Sample
 ```csharp
using Amazon.Lambda.Core;
using Whetstone.Alexa
. . .

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Whetstone.Alexa.EmailChecker.Lambda
{
    public class Function
    {

        public async Task<AlexaResponse> FunctionHandlerAsync(AlexaRequest request, ILambdaContext context)
        {
            var emailProcessor = _serviceProvider.Value.GetRequiredService<IEmailProcessor>();
            return await emailProcessor.ProcessEmailRequestAsync(request);     
        }
```
<br/>
<br/>


## Processing the AlexaRequest

The most useful values on the AlexaRequest is the [request type](https://developer.amazon.com/docs/custom-skills/request-types-reference.html), \
[intent, and slot](https://developer.amazon.com/docs/custom-skills/create-the-interaction-model-for-your-skill.html#intents-and-slots) values. 

Get the request type:
 ```csharp
RequestType reqType = request.Request.Type;
```

Get the name of the intent:
 ```csharp
string intent = request.Request.Intent.Name;
```

Get a slot value from the intent:
```csharp
string selectedCity = request.Request.Intent.GetSlotValue("city"); 
```

## Create a Response
Alexa can speak a plain text response to the user or process [Speech Synthesis Markup Language (SSML)](https://developer.amazon.com/docs/custom-skills/speech-synthesis-markup-language-ssml-reference.html).
SSML include speech directives to tell change the volume of Alexa's voice, speed up or slow the response, and play MP3 files. The total time to provide the response the user cannot exceed 90 seconds. If the user
does not respond, Alexa uses a [reprompt](https://developer.amazon.com/docs/custom-skills/request-and-response-json-reference.html#reprompt-object) to elicit a response from the user. Optionally, a
card response can send plain text along with small images. Card responses appear in the user's Alexa mobile application and on alexa.amazon.com.
<br/>
<br/>
The following sample sends a plain text response, a reprompt, and a standard card response.

```csharp
string textResp = "You are following a path in forest and have come to a fork. Would you like to go left or right?";
AlexaResponse resp = new AlexaResponse
{
    Version = "1.0",
    Response = new AlexaResponseAttributes
    {
        OutputSpeech = OutputSpeechBuilder.GetPlainTextSpeech(textResp),
        Card = CardBuilder.GetSimpleCardResponse("Fork in the Road", textResp),
        Reprompt = new RepromptAttributes
        {
            OutputSpeech = OutputSpeechBuilder.GetPlainTextSpeech("Left or right?"),
        }
    },
};
```

To include an image in the card response, provide a publicly accessible URL for both a small image (720wx480h) and large image (1200w x 800h).
For more information, please see [Create a Home Card to Display Text and an Image](https://developer.amazon.com/docs/custom-skills/include-a-card-in-your-skills-response.html#create-a-home-card-to-display-text-and-an-image).

```csharp
   . . .
        Card = CardBuilder.GetStandardCardResponse("Fork in the Road",
                textResponse,
                "https://dev-custom.s3.amazonaws.com/adventuregame/images/forkintheroad_720x800.png",
                "https://dev-custom.s3.amazonaws.com/adventuregame/images/forkintheroad_1200x800.png"
                ),
   . . .
```




### Embedding MP3 files

string textResp = "You are following a path in forest and have come to a fork. Would you like to go left or right?";
AlexaResponse resp = new AlexaResponse
{
    Version = "1.0",
    Response = new AlexaResponseAttributes
    {
        OutputSpeech = OutputSpeechBuilder.GetPlainTextSpeech(textResp),
        Card = CardBuilder.GetSimpleCardResponse("Fork in the Road", textResp),
        Reprompt = new RepromptAttributes
        {
            OutputSpeech = OutputSpeechBuilder.GetPlainTextSpeech("Left or right?"),
        }
    },
};

## TODO
The following enhancements are planned:

- Dialog state processing
- Streaming audio management using the [AudioPlayer](https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html) Interface
