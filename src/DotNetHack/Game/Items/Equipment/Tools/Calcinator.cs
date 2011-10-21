using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    public class Calcinator : AlchemyEquipment
    {
        public Calcinator(double m)
            : base("Calcinator", new Glyph('π', Colour.Standard), 0.0, 0.0, 0.0, -m)
        { }

        public override void Apply(Interfaces.IItem[] items) { }

        public override void Use() { }
    }
}
