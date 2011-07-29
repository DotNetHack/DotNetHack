using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DotNetHack.Game
{
    /// <summary>
    /// Stats
    /// </summary>
    [Serializable]
    public class Stats
    {
        public Stats()
        {

            Health = MaxHealth;
            Magika = MaxMagika;
        }

        #region Magika Regen
        public void RegenerateMagika()
        {
            if (MagikaRegenTicks > 100 - Intelligence)
            {
                Magika++;
                MagikaRegenTicks = 0;
            }

            MagikaRegenTicks++;
        }

        int MagikaRegenTicks = 0;
        #endregion

        #region Health Regen
        public void RegenerateHealth()
        {
            if (HealthRegenTicks > 100 - Endurance)
            {
                Health++;
                HealthRegenTicks = 0;
            }
            HealthRegenTicks++;
        }
        int HealthRegenTicks = 0;
        #endregion

        /// <summary>
        /// Health
        /// </summary>
        [XmlIgnore]
        public int Health
        {
            get { return _health; }
            set
            {
                if (value <= MaxHealth)
                    _health = value;
            }
        }

        private int _health;

        /// <summary>
        /// Magika
        /// </summary>
        [XmlIgnore]
        public int Magika
        {
            get { return _magika; }
            set 
            {
                if (value <= MaxMagika)
                    _magika = value;
            }
        }

        private int _magika;

        /// <summary>
        /// The maximum amount of health
        /// </summary>
        public int MaxHealth { get { return (int)((Strength + Endurance) / 10) * 2; } }

        /// <summary>
        /// The maximum amount of magika
        /// </summary>
        public int MaxMagika { get { return (int)(2.5 * Intelligence); } }

        /// <summary>
        /// Level
        /// </summary>
        [XmlAttribute]
        public int Level { get; set; }

        /// <summary>
        /// Effectiveness w/ Melee weapons
        /// </summary>
        [XmlAttribute]
        public int Strength { get; set; }

        /// <summary>
        /// Trap, Enemy detection
        /// </summary>
        [XmlAttribute]
        public int Perception { get; set; }

        /// <summary>
        /// Amount that can be carried.
        /// Affects total health.
        /// </summary>
        [XmlAttribute]
        public int Endurance { get; set; }

        /// <summary>
        /// Affects interactions with all NPCs.
        /// </summary>
        [XmlAttribute]
        public int Charisma { get; set; }

        /// <summary>
        /// Affects alchemy.
        /// </summary>
        [XmlAttribute]
        public int Intelligence { get; set; }

        /// <summary>
        /// Agility affects speed.
        /// Use of ranged weapons.
        /// </summary>
        [XmlAttribute]
        public int Agility { get; set; }

        /// <summary>
        /// Luck affects all actions
        /// </summary>
        [XmlAttribute]
        public int Luck { get; set; }
    }
}
