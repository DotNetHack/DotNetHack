using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items
{
    /// <summary>
    /// Currency
    /// </summary>
    public class Currency : Item
    {
        public Currency(int aAmt)
            : base("gold", '$', Colour.Yellow)
        { Amount = aAmt; }

        public int Amount { get; set; }
    }
}
