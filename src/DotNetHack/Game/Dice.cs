using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game
{
    /// <summary>
    /// Though this class is titled <c>Dice</c> it merely deals with and handlesthe various requests
    /// for randomness throughout.
    /// </summary>
    public static class Dice
    {
        /// <summary>
        /// returns true for desired percent chance.
        /// <remarks>linear distribution?</remarks>
        /// </summary>
        /// <param name="n">desired percent chance</param>
        /// <returns>true when condition is met.</returns>
        public static bool D(double n) { return (R.Random.NextDouble() * 100 < n); }



        /// <summary>
        /// RandomChoice
        /// <example>
        /// <code>      
        /// var flowerColor = Dice.RandomChoice<Colour>(new List<Colour>() 
        /// {   
        ///     new Colour(ConsoleColor.Magenta, ConsoleColor.Green),
        ///     new Colour(ConsoleColor.Red, ConsoleColor.Green),
        ///     new Colour(ConsoleColor.Yellow, ConsoleColor.Green),
        ///     new Colour(ConsoleColor.DarkMagenta, ConsoleColor.Green),
        /// });
        /// </code>
        /// </example>
        /// <remarks>Not dissimilar to Pythons random choice.</remarks>
        /// </summary>
        /// <typeparam name="T">The type of the object to return for 
        ///     the random choice.</typeparam>
        /// <param name="obj">The object that will be used to get a random element from.</param>
        /// <returns>A "randomly" selected element from the list.</returns>
        public static T RandomChoice<T>(IList<T> obj)
        {
            return obj[R.Random.Next(0, obj.Count)];
        }
    }
}
