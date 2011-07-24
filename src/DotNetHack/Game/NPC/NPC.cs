using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// non player controlled character.
    /// </summary>
    [Serializable]
    public abstract class NonPlayerControlled : Actor
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public NonPlayerControlled() { }

        /// <summary>
        /// Creates a new NPC with the provided parameters.
        /// </summary>
        /// <param name="aName">The name of this NPC</param>
        /// <param name="aGlyph"></param>
        /// <param name="aColour"></param>
        public NonPlayerControlled(string aName, char aGlyph, Colour aColour, Location3i l)
            : base(aGlyph, aColour, l) { Name = aName; }

        /// <summary>
        /// The name of this non-player controlled character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The level of this NPC.
        /// </summary>
        public int Level { get; set; }
    }
}
