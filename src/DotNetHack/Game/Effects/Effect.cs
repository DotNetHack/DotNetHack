using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Effects
{
    /// <summary>
    /// Effect
    /// </summary>
    [Serializable]
    public class Effect
    {
        /// <summary>
        /// Creates a new Effect.
        /// </summary>
        public Effect() { }

        /// <summary>
        /// Creates a new instance of Effect
        /// </summary>
        /// <param name="aDuration">The duration of the effect</param>
        public Effect(EffectType aEffectType, int aDuration = 1)
        {
            // Set the effect type.
            EffectType = aEffectType;

            // Set the duration of this effect.
            Duration = aDuration;
        }

        /// <summary>
        /// The duration of the affect.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The Effect's type
        /// </summary>
        public EffectType EffectType { get; set; }
    }
}
