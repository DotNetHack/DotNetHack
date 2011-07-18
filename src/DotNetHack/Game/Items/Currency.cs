using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items
{
    public static class CurrencyModifier
    {
        public const int GOLD = 10000;
        public const int SILVER = 100;
        public const int COPPER = 1;
    }
    /// <summary>
    /// Currency
    /// </summary>
    [Serializable]
    public class Currency : Item, IEquatable<Currency>
    {
        /// <summary>
        /// Currency
        /// </summary>
        /// <param name="aAmount">Amount</param>
        public Currency(int aAmount, int modifier = CurrencyModifier.GOLD)
            : base(ItemType.Currency, "Gold", '$', Colour.Yellow)
        {
            // Given that we seem to be currently setting things in amounts of gold,
            // We'll have the default value set to gold.  Amount get set accordingly:
            Amount = aAmount * modifier;
        }

        /// <summary>
        /// The amont of currency this represents.
        /// This should be in the lowest available amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gold returns how much gold the user has
        /// or sets how much gold the user has.
        /// </summary>
        public int Gold 
        { 
            get 
            {
                return Amount / 10000;
            }

            set 
            {
                Amount -= Amount / 10000;   // Removes the old amount of gold
                Amount += value * 10000;
            }
        }

        /// <summary>
        /// Silver returns how much silver the user has
        /// or sets how much silver the user has.
        /// </summary>
        public int Silver
        {
            get
            {
                return ((Amount % 10000) - (Amount % 100)) / 100;
            }

            set
            {
                Amount -= ((Amount % 10000) - (Amount % 100));
                Amount += value * 100;
            }
        }

        /// <summary>
        /// Copper sets or returns the amount of copper a
        /// user has.
        /// </summary>
        public int Copper
        {
            get
            {
                return Amount % 100;
            }

            set
            {
                Amount -= Amount % 100;
                Amount += value;
            }
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

        public override void Draw()
        {
            base.Draw();
        }
    }
}
