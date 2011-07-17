using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items
{
    /// <summary>
    /// Currency
    /// </summary>
    public class Currency : Item, IEquatable<Currency>
    {
        /// <summary>
        /// Currency
        /// </summary>
        /// <param name="aAmount">Amount</param>
        public Currency(int aAmount)
            : base("Gold", '$', Colour.Yellow) { }

        /// <summary>
        /// The amont of currency this represents.
        /// </summary>
        public int Amount { get; set; }

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

        public override void Draw()
        {
            base.Draw();
        }
    }
}
