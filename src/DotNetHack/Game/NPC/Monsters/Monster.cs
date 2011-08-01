using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

using System.Xml.Serialization.Persisted;

namespace DotNetHack.Game.NPC.Monsters
{
    /*
B	Breath
E	Engulf
G	Gaze
M	Magic (spell)
S	Spit
W	Uses weapon
X	Explodes
()	Defensive response when the monster is attacked
[]	Defensive response when the monster is killed
     */

    /// <summary>
    /// Monsters generally are NPCs that may hurt the player.
    /// </summary>
    [Serializable]
    public class Monster : NonPlayerControlled, IMonster, IEquatable<Monster>
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Monster() { }

        /// <summary>
        /// Creates a new Monster
        /// </summary>
        /// <param name="aName">The name of the monster</param>
        /// <param name="aGlyph">The species or glyph</param>
        /// <param name="aColour">The colour</param>
        /// <param name="aLocation">The location.</param>
        public Monster(string aName, char aGlyph, Colour aColour, Location3i aLocation = null)
            : base(aName, aGlyph, aColour, aLocation)
        { }

        public bool Equals(Monster other) { return other.Location == Location; }

        /// <summary>
        /// Agression level of this monster
        /// </summary>
        public Agression Agression { get; set; }

    }
}
