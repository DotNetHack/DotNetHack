using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.UI;

namespace DotNetHack.Game.Items.Herbs
{
    /// <summary>
    /// Herb
    /// </summary>
    [Serializable]
    public class Herb : Item
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Herb() { }

        /// <summary>
        /// Creates a new instance of Herb
        /// <param name="aName">The name of the herb</param>
        /// <param name="aColour">The colour of the herb</param>
        /// </summary>
        public Herb(string aName, Colour aColour)
            : base(aName, Symbols.YEN, aColour) { }

        /// <summary>
        /// Creates a new instance of Herb
        /// <remarks>defaults colour to green.</remarks>
        /// </summary>
        /// <param name="aName">The name of the herb</param>
        public Herb(string aName)
            : this(aName, Colour.Green) { }
    }
}
