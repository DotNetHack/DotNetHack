using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DotNetHack.Game
{
    /// <summary>
    /// StatsBase is a simple stats abstraction.
    /// items, players, npcs, enchantments may use this at will.
    /// </summary>
    [Serializable]
    public class StatsBase
    {
        /// <summary>
        /// create a new instance of stats base.
        /// </summary>
        public StatsBase() { }

        /// <summary>
        /// Creates a new instance of stats base with all stats set to the same value.
        /// </summary>
        /// <param name="v">The value that all stats will be set to.</param>
        public StatsBase(int v) 
        {
            Strength = v;
            Perception = v;
            Endurance = v;
            Charisma = v;
            Intelligence = v;
            Agility = v;
            Level = v;
            Luck = v;
            ArmourClass = v;
            Wisdom = v;
        }

        /// <summary>
        /// the level
        /// </summary>
        [XmlAttribute]
        public int Level { get; set; }

        /// <summary>
        /// speed
        /// </summary>
        [XmlAttribute]
        public int Speed { get; set; }

        /// <summary>
        /// AC or armour class
        /// </summary>
        [XmlAttribute]
        public int ArmourClass { get; set; }

        /// <summary>
        /// strength
        /// </summary>
        [XmlAttribute]
        public int Strength { get; set; }

        /// <summary>
        /// endurance
        /// </summary>
        [XmlAttribute]
        public int Endurance { get; set; }

        /// <summary>
        /// agility
        /// </summary>
        [XmlAttribute]
        public int Agility { get; set; }

        /// <summary>
        /// wisdom.
        /// </summary>
        [XmlAttribute]
        public int Wisdom { get; set; }

        /// <summary>
        /// intelligence.
        /// </summary>
        [XmlAttribute]
        public int Intelligence { get; set; }

        /// <summary>
        /// charisma
        /// </summary>
        [XmlAttribute]
        public int Charisma { get; set; }

        /// <summary>
        /// experience.
        /// </summary>
        [XmlAttribute]
        public int Experience { get; set; }

        /// <summary>
        /// luck
        /// </summary>
        [XmlAttribute]
        public int Luck { get; set; }

        /// <summary>
        /// perception.
        /// </summary>
        [XmlAttribute]
        public int Perception { get; set; }

        /// <summary>
        /// plus operator for <see cref="StatsBase"/>.
        /// </summary>
        /// <param name="a">LHS</param>
        /// <param name="b">RHS</param>
        /// <returns>The result of adding the two <c>StatsBase</c> 
        /// objects.</returns>
        public static StatsBase operator +(StatsBase a, StatsBase b)
        {
            return new StatsBase()
            {
                Strength = a.Strength + b.Strength,
                Perception = a.Perception + b.Perception,
                Endurance = a.Endurance + b.Endurance,
                Charisma = a.Charisma + b.Charisma,
                Intelligence = a.Intelligence + b.Intelligence,
                Agility = a.Agility + b.Agility,
                Luck = a.Luck + b.Luck,
                ArmourClass = a.ArmourClass + b.ArmourClass,
                Experience = a.Experience + b.Experience,
                Level = a.Level + b.Level,
                Speed = a.Speed + b.Speed,
                Wisdom = a.Wisdom + b.Wisdom,
            };
        }

        /// <summary>
        /// minus operator for <see cref="StatsBase"/>.
        /// See: unary -
        /// </summary>
        /// <param name="a">LHS</param>
        /// <param name="b">RHS</param>
        /// <returns>The result of subtracting the two <c>StatsBase</c> 
        /// objects.</returns>
        public static StatsBase operator -(StatsBase a, StatsBase b)
        {
            return a + (-b);
        }

        /// <summary>
        /// unary (negate) for a <see cref="StatsBase"/> object.
        /// <remarks>leveraged to perform subtraction.</remarks>
        /// </summary>
        /// <param name="a">The StatsBase object to negate.</param>
        /// <returns>A statsbase object with each of the stats negated.</returns>
        public static StatsBase operator -(StatsBase a)
        {
            return new StatsBase()
            {
                Agility = -a.Agility,
                ArmourClass = -a.ArmourClass,
                Charisma = -a.Charisma,
                Endurance = -a.Endurance,
                Experience = -a.Experience,
                Intelligence = -a.Intelligence,
                Level = -a.Level,
                Luck = -a.Luck,
                Perception = -a.Perception,
                Speed = -a.Speed,
                Strength = -a.Strength,
                Wisdom = -a.Wisdom,
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Stats : StatsBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Stats()
            : base()
        { }

        /// <summary>
        /// Health is a derrived stat.
        /// </summary>
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

        [XmlIgnore]
        public int Mana 
        {
            get { return _mana; }
            set 
            {
                if (_mana != value)
                    _mana = value;

                // mana ceiling.
                if (_mana >= ManaPoints)
                    _mana = ManaPoints;
            }
        }

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
        [XmlIgnore]
        public int ManaPoints { get { return (int)(2.5 * Intelligence); } }

        /// <summary>
        /// Triggered on any change in health.
        /// Note: Should be elsewhere.
        /// </summary>
        public event EventHandler OnHealthChanged;

        /// <summary>
        /// Health backing store.
        /// </summary>
        private int _health;

        /// <summary>
        /// Mana backing store
        /// </summary>
        private int _mana;
    }
}
