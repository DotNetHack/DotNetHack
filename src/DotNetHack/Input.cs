using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
