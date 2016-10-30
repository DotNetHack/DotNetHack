using DotNetHack.Core;
using DotNetHack.Tools;

namespace DotNetHack.Definitions
{
    /// <summary>
    /// IDef
    /// </summary>
    public interface IDef : Id
    {
        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        Glyph Glyph { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        EventCollection Events { get; set; }

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        AttributeCollection Attributes { get; set; }

        /// <summary>
        /// Gets or sets the editor command for this definition
        /// </summary>
        /// <value>
        /// The editor command.
        /// </value>
        EditorCommand EditorCommand { get; set; }

        /// <summary>
        /// Gets or sets the script block.
        /// </summary>
        /// <value>
        /// The script block.
        /// </value>
        string ScriptBlock { get; set; }
    }
}