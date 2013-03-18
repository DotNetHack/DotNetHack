using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// ColorScheme
    /// </summary>
    public class ColorScheme : IColorScheme
    {
        /// <summary>
        /// ColorScheme
        /// </summary>
        /// <param name="fg">the foreground color</param>
        /// <param name="bg">the background color</param>
        public ColorScheme(ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            BackgroundColor = bg;
            ForegroundColor = fg;
        }

        /// <summary>
        /// BackgroundColor
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// ForegroundColor
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Returns a new color scheme
        /// </summary>
        /// <param name="fg"></param>
        /// <param name="bg"></param>
        /// <returns></returns>
        internal static ColorScheme New(ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            return new ColorScheme(fg, bg);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns>the hash code for this color scheme</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = BackgroundColor.GetHashCode();
                result = (result ^ 397) + ForegroundColor.GetHashCode();
                return result;
            }
        }
    }
}
