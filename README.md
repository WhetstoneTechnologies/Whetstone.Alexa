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
        },
        ShouldEndSession = false
    },
};
```

To include an image in the card response, provide a publicly accessible URL for both a small image (720w x 480h) and large image (1200w x 800h).
For more information, please see [Create a Home Card to Display Text and an Image](https://developer.amazon.com/docs/custom-skills/include-a-card-in-your-skills-response.html#create-a-home-card-to-display-text-and-an-image).

```csharp
   . . .
        Card = CardBuilder.GetStandardCardResponse("Fork in the Road",
                textResponse,
                "https://dev-customapp.s3.amazonaws.com/adventuregame/images/forkintheroad_720x800.png",
                "https://dev-customapp.s3.amazonaws.com/adventuregame/images/forkintheroad_1200x800.png"
                ),
   . . .
```


### Embedding MP3 files and SSML Tags

The following sample shows how to include MP3 files in the response using the audio tag along with supported SSML tags. For a comprehensive list of Alexa-supported SSML tags, please see [Speech Synthesis Markup Language (SSML) Reference](https://developer.amazon.com/docs/custom-skills/speech-synthesis-markup-language-ssml-reference.html).

```csharp
    StringBuilder ssmlSample = new StringBuilder();

    ssmlSample.Append("<speak><audio src='https://dev-sbsstoryengine.s3.amazonaws.com/stories/animalfarmpi/audio/Act1-OpeningMusic-alexa.mp3'/> ");
    ssmlSample.Append("It was a dark and stormy night. <break time='500ms'/>");
    ssmlSample.Append("<say-as interpret-as='interjection'>no way!</say-as> ");
    ssmlSample.Append("I'm not doing this. That doesn’t make any sense!  That music didn’t sound dark and stormy at ");
    ssmlSample.Append("<prosody volume='x-loud' pitch='+10%'>all!</prosody>");
    ssmlSample.Append(" It sounds to me more like a bright and chipper morning! Should we go with dark and stormy, or bright and chipper?");
    ssmlSample.Append("</speak>")

    AlexaResponse resp = new AlexaResponse
    {
        Version = "1.0",
        Response = new AlexaResponseAttributes
        {
            OutputSpeech = OutputSpeechBuilder.GetSsmlSpeech(ssmlSample.ToString()),
```

#### Using the Alexa Skills Kit Sound Library

Amazon has provided a sound library that includes animal, game show, and other sounds. This may be a viable alternative if the needs for sounds is limited. The **Whetstone.Alexa** Nuget package includes 
constants that link to all of the sounds provided in the [Alexa Skills Kit Sound Library](https://developer.amazon.com/docs/custom-skills/ask-soundlibrary.html).

```csharp
using Whetstone.Alexa.Audio.AmazonSoundLibrary;

  . . .

    StringBuilder librarySample = new StringBuilder();
    librarySample.Append("<speak>");
    librarySample.Append(Office.ELEVATOR_BELL_1X_01);
    librarySample.Append("Your hotel is booked!");
    librarySample.Append("</speak>");
```

# Media Hosting Tips

If you'd like to include and reference MP3 files and images, they must be publicly available. If hosting on S3 storage, then use a [bucket policy](https://docs.aws.amazon.com/AmazonS3/latest/dev/example-bucket-policies.html) 
to limit the public files only to directories need to be exposed.
<br/>

The following bucket policy exposes only the files in the audio and image subfolders to the public. 
```json
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Sid": "AddPerm",
            "Effect": "Allow",
            "Principal": "*",
            "Action": "s3:GetObject",
            "Resource": [
                "arn:aws:s3:::bucketname/projects/*/audio/*",
                "arn:aws:s3:::bucketname/projects/*/image/*"
            ]
        }
    ]
}
```

In order to allow the Alexa mobile app to download the image, CORS restrictions must allow for GET requests from ask-ifr-download.s3.amazonaws.com.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<CORSConfiguration xmlns="http://s3.amazonaws.com/doc/2006-03-01/">
<CORSRule>
    <AllowedOrigin>http://ask-ifr-download.s3.amazonaws.com</AllowedOrigin>
    <AllowedMethod>GET</AllowedMethod>
</CORSRule>
<CORSRule>
    <AllowedOrigin>https://ask-ifr-download.s3.amazonaws.com</AllowedOrigin>
    <AllowedMethod>GET</AllowedMethod>
</CORSRule>
</CORSConfiguration>
```
## Sending Progressive Response

If the skill invokes a third-party API or performs a database search, the response could be delayed by a few seconds. A blue light will flash on the Alexa device while waiting for a response and
 the user may get the impression the skill is no longer responding.
<br/>
A progressive response informs the user that the skill is processing the request. The **Whetstone.Alexa** Nuget package wraps this in an easy-to-use class.

```csharp
using Whetstone.Alexa.ProgressiveResponse;

      . . .

    private IProgressiveResponseManager _progMan;
    private ILogger _logger;

    public EmailProcessor(ILogger<EmailProcessor> logger, IProgressiveResponseManager progMan)
    {
        _logger = logger;
        _progMan = progMan;
    }

    public async Task<AlexaResponse> GetAlexaAsync(AlexaRequest req)
    {
        try
        {
            await _progMan.SendProgressiveResponseAsync(req, "I'm working on it");
        }
        catch(Exception ex)
        {
            // Log the error, don't fail the call
            _logger.LogError(ex, "Error sending progressive response");

        }

        AlexaResponse ret = await CallLongRunningProcess(req);

```

## TODO
The following enhancements are planned:

- Dialog state processing
- Streaming audio management using the [AudioPlayer](https://developer.amazon.com/docs/custom-skills/audioplayer-interface-reference.html) Interface
