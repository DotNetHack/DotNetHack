using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Effects
{
    /// <summary>
    /// Effect
    /// </summary>
    public class Effect
    {
        /// <summary>
        /// Creates a new instance of Effect
        /// </summary>
        /// <param name="aDuration"></param>
        public Effect(int aDuration)
        {
            // Set the duration of this effect.
            Duration = aDuration;
        }

        /// <summary>
        /// The duration of the affect.
        /// </summary>
        public int Duration { get; set; }
    }
}
