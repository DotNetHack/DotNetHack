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


        /// <summary>
        ///  operator +
        /// </summary>
        /// <param name="a">LHS</param>
        /// <param name="b">RHS</param>
        /// <returns>The new amount</returns>
        public static Currency operator +(Currency a, Currency b)
        {
            return new Currency(a.Amount + b.Amount);
        }

        /// <summary>
        /// operator <
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Currency a, Currency b)
        {
            return (a.Amount < b.Amount);
        }

        /// <summary>
        /// operator >
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Currency a, Currency b)
        {
            return (a.Amount > b.Amount);
        }

        /// <summary>
        /// operator >=
        /// </summary>
        /// <param name="a">LHS</param>
        /// <param name="b">RHS</param>
        /// <returns>true when condition met</returns>
        public static bool operator >=(Currency a, Currency b)
        {
            return (a.Amount >= b.Amount);
        }

        /// <summary>
        /// operator <=
        /// </summary>
        /// <param name="a">LHS</param>
        /// <param name="b">RHS</param>
        /// <returns>true when condition met</returns>
        public static bool operator <=(Currency a, Currency b)
        {
            return (a.Amount <= b.Amount);
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other">The Currency to compare to</param>
        /// <returns><value>true</value> when equal</returns>
        public bool Equals(Currency other)
        {
            return this.Amount.Equals(other.Amount);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns>The amount is good enough for the hash</returns>
        public override int GetHashCode() { return this.Amount; }
    }
}
