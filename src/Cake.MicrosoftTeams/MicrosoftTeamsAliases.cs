using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.Annotations;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Cake.MicrosoftTeams
{
    /// <summary>
    /// Contains functionality related to Microsoft Teams.
    /// </summary>
    [CakeAliasCategory("Microsoft Teams")]
    public static class MicrosoftTeamsAliases
    {
        /// <summary>
        /// Posts a message to a Microsoft Teams channel
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        /// <list type="table">
        /// <listheaders>
        /// <term>Response Code</term>
        /// <term>Description</term>
        /// <term>Details</term>
        /// </listheaders>
        /// <item><term>200</term><term>Ok</term><term>A well-formed request is sent to an existing webhook. The request contains a valid payload, and has a valid corresponding webhook configuration.</term></item>
        /// <item><term>400</term><term>Bad Request</term><term>An incorrectly-formed request is sent to a webhook that exists. The payload could contain non-parseable JSON, incorrect JSON values (e.g.expected a String, got an array), incorrect content-type, etc..</term></item>
        /// <item><term>404</term><term>Not Found</term><term>A request is sent to a webhook that does not exist.</term></item>
        /// <item><term>413</term><term>Payload Too Large</term><term>A request is sent to a webhook that is too large in size for processing.</term></item>
        /// <item><term>429</term><term>Too Many Requests</term><term>Client is sending too many requests and Office 365 is throttling the requests to a webhook.</term></item>
        /// </list>
        /// </returns>
        /// <example>
        /// <code>
        /// MicrosoftTeamsPostMessage("Hello from Cake!",
        ///    new MicrosoftTeamsSettings {
        ///        IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
        ///    });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("PostMessage")]
        public static HttpStatusCode MicrosoftTeamsPostMessage(this ICakeContext context,
            string message,
            MicrosoftTeamsSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(settings.IncomingWebhookUrl))
            {
                throw new ArgumentNullException(nameof(settings.IncomingWebhookUrl));
            }

            return context.MicrosoftTeamsPostMessage(new MicrosoftTeamsMessageCard {text = message}, settings);
        }

        /// <summary>
        /// Posts a message to a Microsoft Teams channel
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message as <see cref="MicrosoftTeamsMessageCard"/>.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>
        /// <list type="table">
        /// <listheaders>
        /// <term>Response Code</term>
        /// <term>Description</term>
        /// <term>Details</term>
        /// </listheaders>
        /// <item><term>200</term><term>Ok</term><term>A well-formed request is sent to an existing webhook. The request contains a valid payload, and has a valid corresponding webhook configuration.</term></item>
        /// <item><term>400</term><term>Bad Request</term><term>An incorrectly-formed request is sent to a webhook that exists. The payload could contain non-parseable JSON, incorrect JSON values (e.g.expected a String, got an array), incorrect content-type, etc..</term></item>
        /// <item><term>404</term><term>Not Found</term><term>A request is sent to a webhook that does not exist.</term></item>
        /// <item><term>413</term><term>Payload Too Large</term><term>A request is sent to a webhook that is too large in size for processing.</term></item>
        /// <item><term>429</term><term>Too Many Requests</term><term>Client is sending too many requests and Office 365 is throttling the requests to a webhook.</term></item>
        /// </list>
        /// </returns>
        /// <example>
        /// <code>
        /// var messageCard = new MicrosoftTeamsMessageCard {
        ///    summary = "Cake posted message using Cake.MicrosoftTeams",
        ///    title ="Cake Microsoft Teams",
        ///    sections = new []{
        ///        new MicrosoftTeamsMessageSection{
        ///            activityTitle = "Cake posted message",
        ///            activitySubtitle = "using Cake.MicrosoftTeams",
        ///            activityText = "Here is the runtime Information",
        ///            activityImage = "https://raw.githubusercontent.com/cake-build/graphics/master/png/cake-small.png",
        ///            facts = new [] {
        ///                new MicrosoftTeamsMessageFacts { name ="CakeVersion", value = Context.Environment.Runtime.CakeVersion.ToString() },
        ///                new MicrosoftTeamsMessageFacts { name ="TargetFramework", value = Context.Environment.Runtime.TargetFramework.ToString() },
        ///                new MicrosoftTeamsMessageFacts { name ="IsCoreClr", value = Context.Environment.Runtime.IsCoreClr.ToString() }
        ///            },
        ///        }
        ///    },
        ///    potentialAction = new [] { 
        ///        new MicrosoftTeamsMessagePotentialAction {
        ///            name = "View in Trello",
        ///            target = new []{"https://trello.com/c/1101/"}
        ///        }
        ///    }
        /// };
        ///
        /// MicrosoftTeamsPostMessage(messageCard,
        ///    new MicrosoftTeamsSettings {
        ///        IncomingWebhookUrl = EnvironmentVariable("MicrosoftTeamsWebHook")
        ///    });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("PostMessage")]
        // ReSharper disable once UnusedParameter.Global
        public static HttpStatusCode MicrosoftTeamsPostMessage(this ICakeContext context,
            MicrosoftTeamsMessageCard message,
            MicrosoftTeamsSettings settings)
        {
            return UseHttpClient(
                client => client.PostAsync(
                    settings.IncomingWebhookUrl,
                    new StringContent(message.ToString(), Encoding.UTF8, "application/json")
                )
            );
        }

        private static HttpStatusCode UseHttpClient(Func<HttpClient, Task<HttpResponseMessage>> action)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.Add(
                    new ProductInfoHeaderValue("Cake.MicrosoftTeams",
                        typeof(MicrosoftTeamsAliases).GetTypeInfo().Assembly.GetName().Version.ToString()));

                return action?.Invoke(client)?.Result.StatusCode ?? HttpStatusCode.PreconditionFailed;
            }
        }
    }
}