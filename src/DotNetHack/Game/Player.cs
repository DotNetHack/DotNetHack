using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack.Game.Interfaces;

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
            : this(aPlayerName, UI.Graphics.ScreenCenter)
        { }

        /// <summary>
        /// Player
        /// </summary>
        /// <param name="aPlayerName"></param>
        /// <param name="aLocation"></param>
        public Player(string aPlayerName, Location aLocation)
            : base()
        {
            G = '@';
            Name = aPlayerName;
            Location = aLocation;
            C = new Colour() { FG = ConsoleColor.Gray };
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
        public Location Location { get; set; }

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
