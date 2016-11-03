using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using Cake.Core;
using Cake.Core.Annotations;

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
        [CakeMethodAlias]
        [CakeAliasCategory("PostMessage")]
        public static void MicrosoftTeamsPostMessage(this ICakeContext context, string message,
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

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.Add(
                    new ProductInfoHeaderValue("Cake.MicrosoftTeams",
                        typeof(MicrosoftTeamsAliases).GetTypeInfo().Assembly.GetName().Version.ToString()));

                var result = client.PostAsync(
                    settings.IncomingWebhookUrl,
                    new StringContent(LitJson.JsonMapper.ToJson(new {text = message}), Encoding.UTF8, "application/json")
                );
                result.Wait();
            }
        }
    }
}