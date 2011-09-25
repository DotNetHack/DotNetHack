using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// </summary>
        public Herb(string aName)
            : base(aName, '"', Colour.Grass)
        { }
    }
}
