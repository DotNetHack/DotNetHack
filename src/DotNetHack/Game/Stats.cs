using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game
{
    /// <summary>
    /// Stats
    /// </summary>
    [Serializable]
    public class Stats
    {
        public int TotalHealth
        {
            get { return (int)((Strength + Endurance) / 10) * 2; }
        }

        public int TotalMagica { get { return (int)(2.5 * Intelligence); } }

        /// <summary>
        /// Level
        /// </summary>
        public int Level { get; set; }

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
