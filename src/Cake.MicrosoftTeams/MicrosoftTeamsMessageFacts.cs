// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Cake.MicrosoftTeams
{
    /// <summary>
    /// Facts are simple name value pairs that will appear in a list. These are set as a list in the facts field of the <see cref="MicrosoftTeamsMessageSection"/> object.
    /// </summary>
    public sealed class MicrosoftTeamsMessageFacts
    {
        /// <summary>
        /// Name of the fact.
        /// </summary>
        /// <remarks>Plaintext String with no added Markdown.</remarks>
        public string name { get; set; }

        /// <summary>
        /// Value of the fact.
        /// </summary>
        /// <remarks>Content can be formatted using basic Markdown markup (headings, bold, italic, links, etc.).</remarks>
        public string value { get; set; }
    }
}