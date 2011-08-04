using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Effects
{
    /// <summary>
    /// The effect modifier delegate.
    /// </summary>
    /// <param name="effect">The effect itself</param>
    /// <param name="target">the effect target</param>
    public delegate void EffectModifier(Effect effect, Actor target);

    /*
    /// <summary>
    /// AOEffectModifier
    /// </summary>
    /// <param name="effect">The effect</param>
    /// <param name="target">The target location</param>
    public delegate void AOEffectModifier(Effect effect, Location3i target);

    /// <summary>
    /// Area Effect
    /// </summary>
    public class AreaEffect : Effect
    {
        /// <summary>
        /// Area of Effect
        /// </summary>
        /// <param name="aEffectType"></param>
        /// <param name="aMagnitude"></param>
        /// <param name="aDuration"></param>
        public AreaEffect(EffectType aEffectType, int aMagnitude, int aDuration = 1)
            : base(aEffectType, aMagnitude, aDuration)
        { }
    }
    */

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
        public Effect(EffectType aEffectType, int aMagnitude, int aDuration = 1)
        {
            // Set the effect type.
            EffectType = aEffectType;

            // Set the duration of this effect.
            Duration = aDuration;

            // Set the magnitude of this effect.
            Magnitude = aMagnitude;
        }

        /// <summary>
        /// The duration of the affect.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Magnitude
        /// </summary>
        public int Magnitude { get; set; }

        /// <summary>
        /// The Effect's type
        /// </summary>
        public EffectType EffectType { get; set; }

        /// <summary>
        /// The effect modifier
        /// </summary>
        public EffectModifier EffectModifiers { get; set; }

        /// <summary>
        /// The effect tick, exactly who this ticks on is important.
        /// </summary>
        /// <param name="target"></param>
        public void Tick(Actor target)
        {
#if DEBUG
            UI.Graphics.Display.ShowMessage("Type: {0}, Duration: {1}",
                this.EffectType, this.Duration);
#endif
            if (Duration > 0)
                Duration--;
            if (EffectModifiers != null)
                EffectModifiers(this, target);
        }
    }
}
