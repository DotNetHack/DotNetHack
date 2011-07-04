using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    public class MortarAndPestle : Tool
    {
        public MortarAndPestle()
            : base("Mortar and Pestle", 'ù', Colour.White) { }
        public override void Apply(Interfaces.IItem[] items) { }
    }
}
