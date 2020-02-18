# Processing Nameless Invocation

Today, in order to invoke an Alexa skill, the user must know the name of the skill. Whetstone Technologies released the [Clinical Trial Finder](https://www.amazon.com/Whetstone-Technologies-Inc-Clinical-Finder/dp/B07GR4MGLK)
skill which uses the [ClinicalTrials.gov API](https://www.clinicaltrials.gov/ct2/resources/download) to look up active clinical trials based on the health condition and the city. The skill can be invoked using:

> "Alexa, ask clinical trial finder for lung cancer trials in Boston"

Using [nameless invocation](https://developer.amazon.com/docs/custom-skills/understand-name-free-interaction-for-custom-skills.html), users don't need to know the skill name ahead of time and can use a more natural statement:

> "Alexa, are there any lung cancer trials in Boston"

This functionality is currently in beta and may change before it goes into production. As it stands now, Alexa attempt to match a user's request to an intent supported by a skill in production using a CanFulfillIntent request that looks like similar to:

```json
 "request": {
    "type": "CanFulfillIntentRequest",
    "requestId": "amzn1.echo-api.request.f3931bf4-4ba6-439c-917e-6965006bbe0e",
    "intent": {
      "name": "FindTrialByCityAndConditionIntent",
      "slots": {
        "condition": {
          "name": "condition",
          "value": "lung cancer"
        },
        "city": {
          "name": "city",
          "value": "Boston"
        }
      }
    }
```
The **Whetstone.Alexa** package can process the intent using:

```csharp
AlexaResponse resp = new AlexaResponse();
resp.Version = "1.0";
resp.Response = new AlexaResponseAttributes();

if(intent.Name.Equals("FindTrialByCityAndConditionIntent", StringComparison.OrdinalIgnoreCase))
{
    resp.Response.CanFulfillIntent = new CanFulfillResponseAttributes(CanFulfillEnum.Yes);

    if (intent.Slots.Any())
    {

        resp.Response.CanFulfillIntent.Slots = new List<CanFulfillSlotResponse>();

        foreach (SlotAttributes slotAttribs in intent.Slots)
        {
            if (slotAttribs.Name.Equals("city") || slotAttribs.Name.Equals("condition"))
            {
                resp.Response.CanFulfillIntent.Slots.Add(new CanFulfillSlotResponse()
                {
                    Name = slotAttribs.Name,
                    CanFulfill = CanFulfillEnum.Maybe,
                    CanUnderstand = CanFulfillEnum.Yes
                });

            }
            else
            {
                resp.Response.CanFulfillIntent.Slots.Add(new CanFulfillSlotResponse()
                {
                    Name = slotAttribs.Name,
                    CanFulfill = CanFulfillEnum.No,
                    CanUnderstand = CanFulfillEnum.No
                });

            }
        }

    }
}
else
{
    resp.Response.CanFulfillIntent = new CanFulfillResponseAttributes(CanFulfillEnum.No);
}
```

If Alexa requests an intent that is not supported, then the skill should return a "NO" value in the CanFulfillIntent property. If the skill can support the intent, then return "YES." Slots are a bit more complicated. Each slot response indicates if the skill can understand the slot and, if it can understand the slot, then whether the slot value can be fulfilled. In the example above, the "city" and "condition" slots are understood since the skill searches for clinical trials based on the requested city and health condition. 

Returning "MAYBE" in the CanFulfill value for the slot values is a judgement call. There may or may not be active clinical trials in the requested city for the condition. Returning a definitive YES or NO requires an API call and processing the count of returned active trials. 


