using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items.Equipment.Armour;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.Items.Equipment.Armor
{
    [Serializable]
    public class Armour : Item, IArmour
    {
        public Armour() : base() { }
        public Armour(string aName, char aGlyph, Colour aColour, Location3i l,
            ArmourLocation aArmourLocation) 
            : base(ItemType.Armour, aName, aGlyph, aColour, l)
        {
            ArmourStats = new Armor.ArmourStats() 
            {
                Condition = 100,
                Weight = 1.0, // WARNING: Add weight.
            };
            ArmourLocation = aArmourLocation;
            ArmourStats.Condition = 100;
        }

        public ArmourLocation ArmourLocation { get; set; }

        public StatsBase StatsBase { get; set; }

        public ArmourStats ArmourStats { get; set; }

        public int Condition
        {
            get { return ArmourStats.Condition; }
            set { ArmourStats.Condition = value; }
        }
    }
}
