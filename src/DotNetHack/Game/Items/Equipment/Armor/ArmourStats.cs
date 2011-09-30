using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Armor
{
    [Serializable]
    public class ArmourStats 
    {
        public ArmourStats() { }

        public double Weight { get; set; }
        public int Condition { get; set; }
    }
}
