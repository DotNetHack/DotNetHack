using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items.Equipment.Armour;

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
            ArmourLocation = aArmourLocation;
            Condition = 100;
        }

        public ArmourLocation ArmourLocation { get; set; }

        public int Condition { get; set; }
    }
}
