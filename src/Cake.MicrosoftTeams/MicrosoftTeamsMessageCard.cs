// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Cake.MicrosoftTeams
{
    /// <summary>
    /// Message structure used by <see cref="MicrosoftTeamsAliases"/>.
    /// </summary>
    public sealed class MicrosoftTeamsMessageCard
    {
        /// <summary>
        /// A string used for summarizing card content. This will be shown as the message subject. This is required if the text parameter isn't populated.
        /// </summary>
        /// <remarks>Plaintext String with no added Markdown.</remarks>
        public string summary { get; set; }

        /// <summary>
        /// The main text of the card. This will be rendered below the sender information and optional title, and above any sections or actions present.
        /// </summary>
        /// <remarks>Content can be formatted using basic Markdown markup (headings, bold, italic, links, etc.).</remarks>
        public string text { get; set; }

        /// <summary>
        /// A title for the Connector message. Shown at the top of the message.
        /// </summary>
        /// <remarks>Plaintext String with no added Markdown.</remarks>
        public string title { get; set; }

        /// <summary>
        /// Contains a list of sections to display in the card.
        /// </summary>
        public ICollection<MicrosoftTeamsMessageSection> sections { get; set; }

        /// <summary>
        /// Converts <see cref="MicrosoftTeamsMessageCard"/> to an string representation.
        /// </summary>
        /// <returns>Returns string representation of current <see cref="MicrosoftTeamsMessageCard"/>.</returns>
        public override string ToString()
        {
            return LitJson.JsonMapper.ToJson(this);
        }
    }
}