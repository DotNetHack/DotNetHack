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

        // Store the amount of currency in copper
        public int Amount { get; set; }

        /// <summary>
        /// DisplayAmount
        /// Gets a three element array for currency display to
        /// user.
        /// </summary>
        public int[] DisplayAmount()
        {
            // Take our amount and convert it into Gold/Silver/Copper
            // 1 Gold = 100 Silver, 1 Silver = 100 Copper
            // 1 Gold = 10000 Copper
            int [] amounts = new int [3];
            amounts[0] = Amount / 10000;
            amounts[1] = (Amount % 10000 - Amount % 100) / 100;
            amounts[2] = Amount % 100;

            return amounts;
        }
    }
}
