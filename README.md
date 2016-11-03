# Cake Microsoft Teams

Cake addin that provides Microsoft Teams aliases

## Usage

### Simple message

```cake
#addin nuget:?package=Cake.MicrosoftTeams&version=0.2.0-Alpha

MicrosoftTeamsPostMessage("Hello from Cake!",
    new MicrosoftTeamsSettings {
        IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
    });
```
![image](https://cloud.githubusercontent.com/assets/1647294/19965126/cca0d8f6-a1c5-11e6-89f2-b8a16bbf000c.png)

### Advanced message

```cake
#addin nuget:?package=Cake.MicrosoftTeams&version=0.2.0-Alpha

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
  }
};

MicrosoftTeamsPostMessage(messageCard,
  new MicrosoftTeamsSettings {
      IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
  });
```

![image](https://cloud.githubusercontent.com/assets/1647294/19965144/e402e034-a1c5-11e6-8b3c-70b2dfdda427.png)

## Disclaimer

This is an early pre-release
