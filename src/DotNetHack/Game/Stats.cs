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


        /// <summary>
        /// Derrived attribute
        /// </summary>
        public int HitPoints { get { return (int)((Strength + Endurance) / 10) * 2; } }

        /// <summary>
        /// Derrived attribute
        /// </summary>
        public int ManaPoints { get { return (int)(2.5 * Intelligence); } }
    }
}
