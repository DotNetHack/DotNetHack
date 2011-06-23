using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Potions
{
    /// <summary>
    /// Potion
    /// </summary>
    public class Potion : Item, IPotion
    {
        public Potion(string aName, Colour aColor)
            : base(aName, '!', aColor)
        { }

        public void Quaff() { return; }
    }
}
