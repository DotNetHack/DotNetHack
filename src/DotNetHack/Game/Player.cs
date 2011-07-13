using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;

namespace DotNetHack.Game
{
    /// <summary>
    /// Player
    /// </summary>
    public class Player : Actor, IDrawable
    {
        /// <summary>
        /// Player
        /// </summary>
        /// <param name="aPlayerName"></param>
        public Player(string aPlayerName)
            : this(aPlayerName, new Location3i(0, 0, 0)) { }

        /// <summary>
        /// Player
        /// </summary>
        /// <param name="aPlayerName"></param>
        /// <param name="aLocation"></param>
        public Player(string aPlayerName, Location3i aLocation)
            : base()
        {
            G = '@';
            Name = aPlayerName;
            Location = aLocation;
            C = new Colour() { FG = ConsoleColor.Gray };
            Stats = new Stats()
            {
                Agility = 2,
                Charisma = 4,
                Endurance = 6,
                Intelligence = 7,
                Luck = 4,
                Perception = 2,
                Strength = 4,
            };
        }

        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// G
        /// </summary>
        public char G { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        public Location3i Location { get; set; }

        /// <summary>
        /// DLV
        /// </summary>
        public int DungeonLevel { get { return Location.D; } }

        /// <summary>
        /// Draw
        /// </summary>
        public void Draw() { UI.Graphics.Draw(this); }

        /// <summary>
        /// Color
        /// </summary>
        public Colour C { get; set; }
    }
}
