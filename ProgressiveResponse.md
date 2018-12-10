# Sending Progressive Response

If the skill invokes a third-party API or performs a database search, the response could be delayed by a few seconds. A blue light will flash on the Alexa device while waiting for a response and the user may get the impression the skill is no longer responding. 
A progressive response informs the user that the skill is processing the request. This is the voice equivalent of a spinner icon on a web page while it's refreshing.

The **Whetstone.Alexa** Nuget package wraps this in an easy-to-use class.

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
