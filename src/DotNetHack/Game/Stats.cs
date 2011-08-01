using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DotNetHack.Game
{
    [Serializable]
    public class Stats
    {
        public Stats() { }

        [XmlAttribute]
        public int Level { get; set; }

        [XmlAttribute]
        public int Speed { get; set; }

        [XmlAttribute]
        public int ArmorClass { get; set; }

        [XmlAttribute]
        public int Strength { get; set; }

        [XmlAttribute]
        public int Endurance { get; set; }

        [XmlAttribute]
        public int Agility { get; set; }

        [XmlAttribute]
        public int Wisdom { get; set; }

        [XmlAttribute]
        public int Intelligence { get; set; }

        [XmlAttribute]
        public int Charisma { get; set; }

        [XmlAttribute]
        public int Experience { get; set; }

        [XmlAttribute]
        public int Luck { get; set; }

        [XmlAttribute]
        public int Perception { get; set; }

        [XmlIgnore]
        public int Health
        {
            get { return _health; }
            set
            {
                // health is being set, and what the value is now isn't what it used to 
                // be.
                if (_health != value)
                {
                    _health = value;

                    // trigger health changed event.
                    if (OnHealthChanged != null)
                        OnHealthChanged(this, null);
                }

                // health ceiling
                if (_health >= HitPoints)
                    _health = HitPoints;

            }
        }

        private int _health;

        /// <summary>
        /// Derrived attribute
        /// </summary>
        public int HitPoints { get { return (int)(Strength + Endurance * 2); } }

        /// <summary>
        /// Health as a percentage.
        /// </summary>
        public double HealthPercent
        {
            get { return (Health / HitPoints) * 100.0; }
        }

        /// <summary>
        /// Derrived attribute
        /// </summary>
        public int ManaPoints { get { return (int)(2.5 * Intelligence); } }

        /// <summary>
        /// Triggered on any change in health.
        /// </summary>
        public event EventHandler OnHealthChanged;
    }
}
