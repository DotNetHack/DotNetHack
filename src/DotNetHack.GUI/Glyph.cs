using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// Glyph
    /// </summary>
    [DebuggerDisplay("{G} {FG} {BG}")]
    public struct Glyph : IEquatable<Glyph>
    {
        /// <summary>
        /// Creates a new glyph
        /// </summary>
        /// <param name="g">the character or symbol</param>
        /// <param name="fg">the foreground color</param>
        /// <param name="bg">the background color</param>
        public Glyph(char g, ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            this.fg = fg;
            this.bg = bg;
            this.g = g;
        }

        /// <summary>
        /// the foreground color
        /// </summary>
        readonly ConsoleColor fg;

        /// <summary>
        /// the background color
        /// </summary>
        readonly ConsoleColor bg;

        /// <summary>
        /// the character or symbol
        /// </summary>
        readonly char g;

        /// <summary>
        /// The foreground color of this glyph
        /// </summary>
        public ConsoleColor FG { get { return fg; } }

        /// <summary>
        /// The foreground color of this glyph
        /// </summary>
        public ConsoleColor BG { get { return bg; } }

        /// <summary>
        /// The character symbol for this glyph
        /// </summary>
        public char G { get { return g; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Glyph other)
        {
            if (other == null)
                return false;
            return this == other;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            return obj is Glyph && Equals((Glyph)obj);
        }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int retVal = G.GetHashCode();
                retVal = (retVal ^ 397) + FG.GetHashCode();
                retVal = (retVal ^ 397) + BG.GetHashCode();
                return retVal;
            }
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Glyph a, Glyph b)
        {
            return a.G.Equals(b.G) && a.FG.Equals(b.FG) && a.BG.Equals(b.BG);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Glyph a, Glyph b)
        {
            return !(a == b);
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return G.ToString();
        }
    }
}
