using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items.Equipment.Armour;

namespace DotNetHack.Game.Items.Equipment.Armor
{
    [Serializable]
    public class Armour : IArmour
    {
        public Armour() { }
        public Armour(string aName, char aGlyph, Colour aColour, 
            Location3i l, ArmourLocation aArmourLocation) 
        {
            ArmourLocation = aArmourLocation;
            ItemType = Items.ItemType.Armour;
            Location = l;
            Name = aName;
            C = aColour;
            G = aGlyph;
            Condition = 100;
        }

        public string Name { get; set; }

        public ArmourLocation ArmourLocation { get; set; }

        public ItemType ItemType { get; set; }

        public virtual void Draw() { UI.Graphics.Draw(this); }

        public char G { get; set; }

        public Colour C { get; set; }

        public Location3i Location { get; set; }

        public int Condition { get; set; }
    }
}
