using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Monsters
{
    [Serializable]
    public class Monster : Actor, IMonster, IEquatable<Monster>
    {
        public Monster() { }
        public Monster(string aName, char aChar, Location3i aLocation)
            : base()
        {
            Name = aName;
            Location = aLocation;
            G = aChar;
        }

        public string Name { get; set; }

        public virtual void Draw() { UI.Graphics.Draw(this); }

        public char G { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public Colour C { get; set; }

        public Location3i Location { get; set; }

        public bool Equals(Monster other) { return other.Location == Location; }
    }
}
