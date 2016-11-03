#r "./bin/Debug/net45/Cake.MicrosoftTeams.dll"
string message = "Hello from Cake!";
Information("[{1:yyyy-MM-dd HH:mm:ss}] Posting message to Microsoft Teams: {0}", message, DateTime.Now);

Information("[{1:yyyy-MM-dd HH:mm:ss}] {0}",
        MicrosoftTeamsPostMessage(message,
        new MicrosoftTeamsSettings {
            IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
        }),
        DateTime.Now
    );

var messageCard = new MicrosoftTeamsMessageCard {
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

Information("[{1:yyyy-MM-dd HH:mm:ss}] Posting message to Microsoft Teams:\r\n{0}", messageCard, DateTime.Now);

System.Net.HttpStatusCode result = MicrosoftTeamsPostMessage(messageCard,
        new MicrosoftTeamsSettings {
            IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
        });

Information("[{1:yyyy-MM-dd HH:mm:ss}] {0}",
        result,
        DateTime.Now
    );