// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using System.Collections.Generic;

namespace Cake.MicrosoftTeams
{
    /// <summary>
    /// A section is a canvas to show richer content than what can be represented in the just the title and text of the card. 
    /// A section can contain text and images, or the activity and facts fields can be used to highlight key events and details.
    /// These sections are passed via the sections array in the payload, and will be rendered in the order of array position.
    /// The content in a section is displayed in the following order(top to bottom): 
    ///     * title
    ///     * text
    ///     * activityTitle, activitySubtitle, activityText
    ///     * facts
    ///     * images
    ///     * actions
    /// </summary>
    public sealed class MicrosoftTeamsMessageSection
    {
        /// <summary>
        /// Title of the section.
        /// </summary>
        /// <remarks>Content can be formatted using basic Markdown markup (headings, bold, italic, links, etc.).</remarks>
        public string title { get; set; }

        /// <summary>
        /// Title of the event or action. Often this will be the name of the "actor".
        /// </summary>
        /// <remarks>Content can be formatted using basic Markdown markup (headings, bold, italic, links, etc.).</remarks>
        public string activityTitle { get; set; }

        /// <summary>
        /// A subtitle describing the event or action. Often this will be a summary of the action.
        /// </summary>
        /// <remarks>Content can be formatted using basic Markdown markup (headings, bold, italic, links, etc.).</remarks>
        public string activitySubtitle { get; set; }

        /// <summary>
        /// An image representing the action. Often this is an avatar of the "actor" of the activity.
        /// </summary>
        /// <remarks>URL to image.</remarks>
        public string activityImage { get; set; }

        /// <summary>
        /// A full description of the action.
        /// </summary>
        /// <remarks>Content can be formatted using basic Markdown markup (headings, bold, italic, links, etc.).</remarks>
        public string activityText { get; set; }

        /// <summary>
        /// A collection of facts, displayed as key-value pairs.
        /// </summary>
        public ICollection<MicrosoftTeamsMessageFacts> facts { get; set; }

        /// <summary>
        /// Optional text that will appear before the activity.
        /// </summary>
        /// <remarks>Content can be formatted using basic Markdown markup (headings, bold, italic, links, etc.).</remarks>
        public string text { get; set; }

        /// <summary>
        /// Set this to false to disable markdown parsing on this section's content. Markdown parsing is enabled by default.
        /// </summary>
        public bool? markdown { get; set; }
    }
}