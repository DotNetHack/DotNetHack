using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Armor
{
    public class ArmourStats 
    {
        public ArmourStats() { }

        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Charisma { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
    }
}
