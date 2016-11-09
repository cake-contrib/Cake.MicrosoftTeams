// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using Cake.MicrosoftTeams.LitJson;

namespace Cake.MicrosoftTeams
{
    /// <summary>
    /// Actions can be presented to the user by including a Schema.org JSON-LD object in the potentialAction array. 
    /// We currently support schema.org/ViewAction, which creates a hyperlinked action button at the bottom of the connector card. 
    /// The text shown on the action button is set by the Action's name parameter, and the destination of the hyperlink is the first link in the target array.
    /// </summary>
    public sealed class MicrosoftTeamsMessagePotentialAction
    {
        /// <summary>
        /// Actions can be presented to the user by including a Schema.org JSON-LD object.
        /// </summary>
        [JsonName("@context")]
        public string context { get; }  = "http://schema.org";

        /// <summary>
        /// Currently only supports ViewAction, which creates a hyperlinked action button at the bottom of the connector card. 
        /// </summary>
        [JsonName("@type")]
        public string type { get; } = "ViewAction";

        /// <summary>
        /// Name of the action. (Shown as the Button text)
        /// </summary>
        /// <remarks>Plaintext String with no added Markdown.</remarks>
        public string name { get; set; }

        /// <summary>
        /// Target of the action. (The destination hyperlink)
        /// </summary>
        /// <remarks>Plaintext string containing a URL</remarks>
        public string[] target { get; set; }
    }
}