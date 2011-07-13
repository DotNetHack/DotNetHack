using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game
{
    public static class ColourExtensions 
    {
        public static void Set(this Colour c)
        {
            Console.ForegroundColor = c.FG;
            Console.BackgroundColor = c.BG;
        }
    }

    /// <summary>
    /// Colour
    /// </summary>
    [Serializable]
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

        public void SetBG(ConsoleColor aBG)
        {
            BG = aBG;
        }

        public void SetFG(ConsoleColor aFG)
        {
            FG = aFG;
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
            get { return new Colour(ConsoleColor.Green, ConsoleColor.DarkGreen); }
        }

        public static Colour Grave
        {
            get { return new Colour(ConsoleColor.Black, ConsoleColor.DarkGreen); }
        }

        public static Colour Field
        {
            get { return new Colour(ConsoleColor.DarkYellow, ConsoleColor.Yellow); }
        }

        public static Colour Road
        {
            get { return new Colour(ConsoleColor.DarkRed, ConsoleColor.DarkYellow); }
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
