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
    public struct Glyph
    {
        /// <summary>
        /// Creates a new glyph
        /// </summary>
        /// <param name="g">the character or symbol</param>
        /// <param name="fg">the foreground color</param>
        /// <param name="bg">the background color</param>
        public Glyph(char g, ConsoleColor fg, ConsoleColor bg)
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
    }
}
