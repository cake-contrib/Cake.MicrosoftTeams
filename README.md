# Cake Microsoft Teams

Cake addin that provides Microsoft Teams aliases

## Usage

### Simple message

```cake
#addin nuget:?package=Cake.MicrosoftTeams&version=0.2.0-alpha

System.Net.HttpStatusCode result = MicrosoftTeamsPostMessage("Hello from Cake!",
    new MicrosoftTeamsSettings {
        IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
    });
```
![image](https://cloud.githubusercontent.com/assets/1647294/19965126/cca0d8f6-a1c5-11e6-89f2-b8a16bbf000c.png)

### Advanced message

```cake
#addin nuget:?package=Cake.MicrosoftTeams&version=0.2.0-alpha

var messageCard = new MicrosoftTeamsMessageCard {
  summary = "Cake posted message using Cake.MicrosoftTeams",
  title ="Cake Microsoft Teams",
  sections = new []{
      new MicrosoftTeamsMessageSection{
          activityTitle = "Cake posted message",
          activitySubtitle = "using Cake.MicrosoftTeams",
          activityText = "Here is the runtime Information",
          activityImage = "https://raw.githubusercontent.com/cake-build/graphics/master/png/cake-small.png",
          facts = new [] {
              new MicrosoftTeamsMessageFacts { name ="CakeVersion", value = Context.Environment.Runtime.CakeVersion.ToString() },
              new MicrosoftTeamsMessageFacts { name ="TargetFramework", value = Context.Environment.Runtime.TargetFramework.ToString() },
              new MicrosoftTeamsMessageFacts { name ="IsCoreClr", value = Context.Environment.Runtime.IsCoreClr.ToString() }
          },
      }
  },
  potentialAction = new [] { 
        new MicrosoftTeamsMessagePotentialAction {
            name = "View in Trello",
            target = new []{"https://trello.com/c/1101/"}
        }
   }
};

System.Net.HttpStatusCode result = MicrosoftTeamsPostMessage(messageCard,
  new MicrosoftTeamsSettings {
      IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
  });

```
![image](https://cloud.githubusercontent.com/assets/1647294/19965144/e402e034-a1c5-11e6-8b3c-70b2dfdda427.png)

### Return values

|Response Code                | Details    |
|-----------------------------|------------|
|OK (200)                     | A well-formed request is sent to an existing webhook. The request contains a valid payload, and has a valid corresponding webhook configuration.|
|BadRequest (400)             | An incorrectly-formed request is sent to a webhook that exists. The payload could contain non-parseable JSON, incorrect JSON values (e.g. expected a String, got an array), incorrect content-type, etc..|
|NotFound (404)               | A request is sent to a webhook that does not exist.|
|RequestEntityTooLarge (413)  | A request is sent to a webhook that is too large in size for processing.|
|429 (429)                    |Client is sending too many requests and Office 365 is throttling the requests to a webhook.|

## Disclaimer

This is an early pre-release
