using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.NPC.Monsters
{
    [Serializable]
    public class Monster : Actor, IMonster, IEquatable<Monster>
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Monster() { }

        /// <summary>
        /// Creates a new monster.
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aChar"></param>
        /// <param name="aLocation"></param>
        public Monster(string aName, char aChar, Location3i aLocation)
            : base()
        {
            Name = aName;
            Location = aLocation;
            G = aChar;
        }

        /// <summary>
        /// The name of this monster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Draw this monster
        /// </summary>
        public virtual void Draw() { UI.Graphics.Draw(this); }

        /// <summary>
        /// The glyph representing this monster
        /// </summary>
        public char G { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public Colour C { get; set; }

        public bool Equals(Monster other) { return other.Location == Location; }
    }
}
