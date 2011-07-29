using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

using System.Xml.Serialization.Persisted;

namespace DotNetHack.Game.NPC.Monsters
{

    [Serializable]
    public class Monster : NonPlayerControlled, IMonster, IEquatable<Monster>
    {
        public Monster() { }

        /// <summary>
        /// Agression level of this monster
        /// </summary>
        public Agression Agression { get; set; }

        public Monster(string aName, char aGlyph, Colour aColour,
            Location3i aLocation)
            : base(aName, aGlyph, aColour, aLocation)
        { }

        public bool Equals(Monster other) { return other.Location == Location; }

    }

    [Serializable]
    public class Monster1 : NonPlayerControlled, IMonster, IEquatable<Monster>
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Monster1() { }

        /// <summary>
        /// Creates a new monster.
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aChar"></param>
        /// <param name="aLocation"></param>
        public Monster1(string aName, char aGlyph, Colour aColour, Location3i l)
            : base(aName, aGlyph, aColour, l) { }

        /// <summary>
        /// TODO: Equals, right now supports collision detection;
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Monster other) { return other.Location == Location; }

        /// <summary>
        /// Agression level of this monster
        /// </summary>
        public Agression Agression { get; set; }
    }
}
