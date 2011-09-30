using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Effects;

namespace DotNetHack.Game.Items.Gems
{
    /// <summary>
    /// Gem
    /// </summary>
    [Serializable]
    public abstract class Gem
    {
        /// <summary>
        /// Create a new instance of the base gem class.
        /// </summary>
        /// <param name="aName">The name of the gem</param>
        /// <param name="aEffect">The effect imbued by the gem.</param>
        public Gem(string aName, Effect aEffect) { GemEffect = aEffect; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// GemEffect
        /// </summary>
        public Effect GemEffect { get; set; }
    }
}
