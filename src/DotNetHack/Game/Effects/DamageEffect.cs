using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Effects
{
    /// <summary>
    /// DamageEffect
    /// </summary>
    public class DamageEffect : Effect
    {
        /// <summary>
        /// DamageType
        /// </summary>
        public enum DamageType
        {
            Frost,
            Fire,
            Poision,
            Nature,
            Shadow,
            Physical,
        }

        /// <summary>
        /// DamageEffect
        /// </summary>
        /// <param name="aDamageType">The damage type being dealt</param>
        /// <param name="aDuration">The duration of the effect.</param>
        public DamageEffect(DamageType aDamageType, int aDuration = 1)
        { }

        /// <summary>
        /// The DamageAffectType
        /// </summary>
        DamageType DamageEffectType { get; set; }
    }
}
