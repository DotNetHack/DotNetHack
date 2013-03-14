using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// Utility
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Set
        /// </summary>
        /// <param name="c"></param>
        public static void Set(this IColorScheme g)
        {
            Console.ForegroundColor = g.FG;
            Console.BackgroundColor = g.BG;
        }

        /// <summary>
        /// CursorState,
        ///     Basic cursor information.
        /// </summary>
        public class CursorState : IColorScheme
        {
            /// <summary>
            /// Static constructor; mainly for the CursorStateStack.
            /// </summary>
            static CursorState() { }

            /// <summary>
            /// Create a new CursorState object
            /// </summary>
            /// <param name="x">x-coordinate</param>
            /// <param name="y">y-coordindate</param>
            /// <param name="fg">foreground colour</param>
            /// <param name="bg">background colour</param>
            public CursorState(int x, int y, ConsoleColor fg, ConsoleColor bg)
            {
                X = x; Y = y; FG = fg; BG = bg;
            }

            /// <summary>
            /// the x-coordinate
            /// </summary>
            public int X { get; set; }

            /// <summary>
            /// the y-coordinate
            /// </summary>
            public int Y { get; set; }

            /// <summary>
            /// the background colour
            /// </summary>
            public ConsoleColor BG { get; set; }

            /// <summary>
            /// The foreground colour
            /// </summary>
            public ConsoleColor FG { get; set; }
        }
    }
}
