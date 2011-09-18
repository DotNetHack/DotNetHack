using System;

namespace DotNetHack.Game
{
    /// <summary>
    /// A glyph is the combination of a symbol and a colour.
    /// <remarks>
    /// The <c>Glyph</c> object is intended to replace multiple occurances
    /// of the Char and Colour combination present throughout multiple DNH
    /// object classes.
    /// </remarks>
    /// </summary>
    public class Glyph
    {
        /// <summary>
        /// Parameterless constructor supports serialization.
        /// </summary>
        public Glyph() 
        {
            G = '\0';                   // nil 
            C = Colour.Standard;        // nil
        }

        /// <summary>
        /// Creates a new glyph with the symbol <c>g</c>
        /// <remarks>Colour.Standard</remarks>
        /// </summary>
        public Glyph(char g)
            : this(g, Colour.Standard)
        { }

        /// <summary>
        /// Creates a new Glyph with the passed symbol and colour.
        /// </summary>
        public Glyph(char g, Colour c) 
        {
            G = g;  // set the symbol
            C = c;  // set the colour./
        }

        /// <summary>
        /// The symbol for the glyph.
        /// </summary>
        public char G { get; set; }

        /// <summary>
        /// The colour of the glyph.
        /// </summary>
        public Colour C { get; set; }
    }
}
