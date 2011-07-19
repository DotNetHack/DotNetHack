using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game
{
    /// <summary>
    /// Stats
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Health
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Effectiveness w/ Melee weapons
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Trap, Enemy detection
        /// </summary>
        public int Perception { get; set; }

        /// <summary>
        /// Amount that can be carried.
        /// Affects total health.
        /// </summary>
        public int Endurance { get; set; }

        /// <summary>
        /// Affects interactions with all NPCs.
        /// </summary>
        public int Charisma { get; set; }

        /// <summary>
        /// Affects alchemy.
        /// </summary>
        public int Intelligence { get; set; }

        /// <summary>
        /// Agility affects speed.
        /// Use of ranged weapons.
        /// </summary>
        public int Agility { get; set; }

        /// <summary>
        /// Luck affects all actions
        /// </summary>
        public int Luck { get; set; }
    }
}
