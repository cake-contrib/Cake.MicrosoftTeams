#r "./bin/Debug/net45/Cake.MicrosoftTeams.dll"

MicrosoftTeamsPostMessage("Hello from Cake!",
    new MicrosoftTeamsSettings {
        IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
    });