using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    public class Alembic : AlchemyEquipment
    {
        public Alembic(double m)
            : base("Alembic", new Glyph('σ', Colour.Standard), 0.0, m, 0.0, 0.0)
        { }

        public override void Apply(Interfaces.IItem[] items) { }

        public override void Use() { }
    }
}
