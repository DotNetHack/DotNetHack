using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    public abstract class Tool : Item, ITool
    {
        public Tool(string aName, Char aGlyph, Colour aColour)
            : base(aName, aGlyph, aColour) { }

        public abstract void Use();

        public abstract void Apply(IItem[] items);

        public int UsesRemaining { get; set; }
    }
}
