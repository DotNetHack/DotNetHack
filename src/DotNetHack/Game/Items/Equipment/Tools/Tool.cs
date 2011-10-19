using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.UI;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    /// <summary>
    /// Tool
    /// </summary>
    public abstract class Tool : Item, ITool
    {
        /// <summary>
        /// Tool
        /// </summary>
        /// <param name="aName">The name of this tool</param>
        /// <param name="aGlyph">The glyph this tool is displayed as.</param>
        /// <param name="aColour">The colour of the glyph.</param>
        public Tool(string aName, Char aGlyph, Colour aColour)
            : base(aName, aGlyph, aColour) { }

        /// <summary>
        /// Use
        /// </summary>
        public abstract void Use();

        /// <summary>
        /// Appply
        /// </summary>
        /// <param name="items"></param>
        public abstract void Apply(IItem[] items);

        /// <summary>
        /// The number of uses remaining.
        /// </summary>
        public int UsesRemaining { get; set; }
    }
}
