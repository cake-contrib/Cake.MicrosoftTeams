# Cake Microsoft Teams

Cake addin that provides Microsoft Teams aliases

## Usage

```cake
#addin nuget:?package=Cake.MicrosoftTeams&version=0.1.0-Alpha

MicrosoftTeamsPostMessage("Hello from Cake!",
    new MicrosoftTeamsSettings {
        IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
    });
```

## Disclaimer

This is an early pre-release
