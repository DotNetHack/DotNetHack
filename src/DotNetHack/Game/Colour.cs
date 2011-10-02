using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DotNetHack.Game
{
    public static class ColourExtensions
    {
        public static void Set(this Colour c)
        {
            Console.ForegroundColor = c.FG;
            Console.BackgroundColor = c.BG;
        }

        public static ConsoleColor Negate(this ConsoleColor c)
        {
            switch (c)
            {
                default:
                    return ConsoleColor.White;

                case ConsoleColor.Gray:
                    return ConsoleColor.DarkGray;

                case ConsoleColor.DarkGray:
                    return ConsoleColor.Gray;

                case ConsoleColor.Black:
                    return ConsoleColor.White;

                case ConsoleColor.White:
                    return ConsoleColor.Black;

                case ConsoleColor.Yellow:
                    return ConsoleColor.Cyan;

                case ConsoleColor.Cyan:
                    return ConsoleColor.Yellow;

                case ConsoleColor.DarkCyan:
                    return ConsoleColor.DarkYellow;

                case ConsoleColor.DarkYellow:
                    return ConsoleColor.DarkCyan;

                case ConsoleColor.Green:
                    return ConsoleColor.Red;

                case ConsoleColor.Red:
                    return ConsoleColor.Green;

                case ConsoleColor.DarkMagenta:
                    return ConsoleColor.DarkYellow;

                case ConsoleColor.DarkBlue:
                    return ConsoleColor.DarkRed;

                case ConsoleColor.DarkRed:
                    return ConsoleColor.DarkBlue;

                case ConsoleColor.DarkGreen:
                    return ConsoleColor.DarkMagenta;

                case ConsoleColor.Magenta:
                    return ConsoleColor.DarkGreen;
            }
        }
    }

    /// <summary>
    /// Colour
    /// </summary>
    [Serializable, DebuggerDisplay("{ToString()}")]
    public class Colour : IEquatable<Colour>
    {
        public Colour() { }
        public Colour(ConsoleColor aFG)
            : this(aFG, ConsoleColor.Black)
        { }

        public Colour(ConsoleColor aFG, ConsoleColor aBG)
        {
            FG = aFG;
            BG = aBG;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="colour">The colour to copy</param>
        public Colour(Colour colour)
        {
            BG = colour.BG;
            FG = colour.FG;
        }

        public void SetBG(ConsoleColor aBG)
        {
            BG = aBG;
        }

        public void SetFG(ConsoleColor aFG)
        {
            FG = aFG;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0},{1})", FG, BG);
        }

        /// <summary>
        /// Return a colour that is <c>NOT</c> this colour.
        /// <remarks>The inverse of the passed colour.</remarks>
        /// </summary>
        /// <param name="colour"></param>
        /// <returns>The inverse of the passed colour.</returns>
        public static Colour operator !(Colour colour)
        {
            Colour retVal = new Colour(colour);
            retVal.BG = retVal.BG.Negate();
            retVal.FG = retVal.FG.Negate();
            return retVal;
        }

        public ConsoleColor FG;

        public ConsoleColor BG;

        public static Colour CurrentColour
        {
            get { return new Colour(Console.ForegroundColor, Console.BackgroundColor); }
        }

        public static Colour Standard
        {
            get { return new Colour(ConsoleColor.Gray); }
        }

        public static Colour DarkRed
        {
            get { return new Colour(ConsoleColor.DarkRed); }
        }

        public static Colour Yellow
        {
            get { return new Colour(ConsoleColor.Yellow); }
        }

        public static Colour Magenta
        {
            get { return new Colour(ConsoleColor.Magenta); }
        }

        public static Colour DarkMagenta
        {
            get { return new Colour(ConsoleColor.DarkMagenta); }
        }

        public static Colour Blue
        {
            get { return new Colour(ConsoleColor.Blue); }
        }

        public static Colour Cyan
        {
            get { return new Colour(ConsoleColor.Cyan); }
        }

        public static Colour DarkBlue
        {
            get { return new Colour(ConsoleColor.DarkBlue); }
        }

        public static Colour DarkCyan
        {
            get { return new Colour(ConsoleColor.DarkCyan); }
        }

        public static Colour DarkYellow
        {
            get { return new Colour(ConsoleColor.DarkYellow); }
        }

        public static Colour Green
        {
            get { return new Colour(ConsoleColor.Green); }
        }

        public static Colour DarkGreen
        {
            get { return new Colour(ConsoleColor.DarkGreen); }
        }

        // TODO: Find the best color combination for copper and silver
        public static Colour Silver
        {
            get { return new Colour(ConsoleColor.DarkGray); }
        }

        public static Colour Copper
        {
            get { return new Colour(ConsoleColor.DarkRed); }
        }

        public static Colour Void
        {
            get { return new Colour(ConsoleColor.Black); }
        }

        public static Colour White
        {
            get { return new Colour(ConsoleColor.White); }
        }

        public static Colour Ocean
        {
            get { return new Colour(ConsoleColor.White, ConsoleColor.Blue); }
        }

        public static Colour Bridge
        {
            get { return new Colour(ConsoleColor.DarkRed, ConsoleColor.Blue); }
        }

        public static Colour DeepOcean
        {
            get { return new Colour(ConsoleColor.White, ConsoleColor.DarkBlue); }
        }

        public static Colour Mountain
        {
            get { return new Colour(ConsoleColor.Red, ConsoleColor.DarkRed); }
        }

        public static Colour Grass
        {
            get { return new Colour(ConsoleColor.Green); }
        }

        public static Colour Grave
        {
            get { return new Colour(ConsoleColor.Black, ConsoleColor.DarkGreen); }
        }

        public static Colour Door
        {
            get { return new Colour(ConsoleColor.DarkYellow); }
        }

        public static Colour Field
        {
            get { return new Colour(ConsoleColor.DarkYellow, ConsoleColor.Yellow); }
        }

        public static Colour Road
        {
            get { return new Colour(ConsoleColor.DarkGreen, ConsoleColor.Black); }
        }

        public static Colour Fountain
        {
            get { return new Colour(ConsoleColor.DarkBlue); }
        }

        public bool Equals(Colour other)
        {
            return this.BG == other.BG &&
                this.FG == other.FG;
        }
    }
}
