using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;

namespace DotNetHack
{
    /// <summary>
    /// Input
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Performs input filtering
        /// <remarks>Pass anonymous filter called "filter" be sure it returns a boolean, filtering will continue until the boolean condition is met.</remarks>
        /// </summary>
        /// <param name="aFilter">The filtering lambda to use, expression should eval to true</param>
        /// <returns>Whatever the final keypress was</returns>
        public static ConsoleKeyInfo Filter(Func<ConsoleKeyInfo, bool> aFilter, out ConsoleKeyInfo k)
        {
        filter_input:
            k = Console.ReadKey();
            if (!aFilter(k))
                goto filter_input;
            return k;
        }

        /// <summary>
        /// Get a string from stdin
        /// </summary>
        /// <param name="aMessage">The message to display</param>
        /// <returns></returns>
        public static string GetString(string aMessage = "")
        {
            UI.Graphics.CursorToLocation(1, 1);
            Console.Write(aMessage + ": ");
            return Console.ReadLine();
        }

        /// <summary>
        /// GetInt (inplace)
        /// <remarks>Gets an integer from standard input
        /// requires that input is definately valid.</remarks>
        /// </summary>
        /// <param name="aValue">The <c>out</c> value where the input is stashed.</param>
        /// <param name="aMessage">The message to show prior to reading the input.</param>
        public static void GetInt(out int aValue, string aMessage = "#: ")
        {
        redo_get_int:
            UI.Graphics.CursorToLocation(1, 1);
            Console.Write(aMessage);
            if (!int.TryParse(Console.ReadLine(), out aValue))
                goto redo_get_int;
        }

        /// <summary>
        /// GetInt
        /// </summary>
        /// <param name="aMessage">Gets an integer from standard input.</param>
        /// <returns>The value read.</returns>
        public static int GetInt(string aMessage = "#:")
        {
        redo_get_int:
            int tmpVal = 0;
            UI.Graphics.CursorToLocation(1, 1);
            Console.Write(aMessage);
            if (!int.TryParse(Console.ReadLine(), out tmpVal))
                goto redo_get_int;
            return tmpVal;
        }

        /// <summary>
        /// ReadStats, read a full out stats object from standard-in.
        /// This is only for properties that *can* be read.
        /// </summary>
        /// <returns></returns>
        public static Stats ReadStats()
        {
            // Get all properties for a stats object and set them via user input.
            Stats retVal = new Stats();
            foreach (var p in typeof(Stats).GetProperties())
            {
                if (p.CanWrite)
                {
                    var pSet = p.GetSetMethod();
                    pSet.Invoke(retVal, new object[] { Input.GetInt(p.Name + ": ") });
                }

                UI.Graphics.CursorToLocation(1, 1);
                Console.Write("                   ");
            }

            return retVal;
        }
    }
}
