using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.NPC.Monsters
{
    [Serializable]
    public abstract class Monster : NonPlayerControlled, IMonster, IEquatable<Monster>
    {
        /// <summary>
        /// Creates a new monster.
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aChar"></param>
        /// <param name="aLocation"></param>
        public Monster(string aName, char aGlyph, Colour aColour, Location3i l)
            : base(aName, aGlyph, aColour, l) { }

        public bool Equals(Monster other) { return other.Location == Location; }

        /// <summary>
        /// Agression level of this monster
        /// </summary>
        public Agression Agression { get; set; }
    }
}
