using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

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
        /// <param name="aEffectType">The type of effect.</param>
        /// <param name="aMagnitude">The magnitude.</param>
        /// <param name="aDuration">The duration.</param>
        public Effect(EffectType aEffectType, int aMagnitude, int aDuration = 1)
            : this(new StatsBase(0), aEffectType, aMagnitude, aDuration) { }

        /// <summary>
        /// Creates a new instance of Effect
        /// </summary>
        /// <param name="aStats">The (initial) effect on stats.</param>
        /// <param name="aEffectType">The type of effect.</param>
        /// <param name="aMagnitude">The magnitude.</param>
        /// <param name="aDuration">The duration.</param>
        public Effect(StatsBase aStats, EffectType aEffectType, int aMagnitude, int aDuration = -1)
        {
            // set effected stats
            EffectedStats = aStats;

            // Set the effect type.
            EffectType = aEffectType;

            // Set the magnitude of this effect.
            Magnitude = aMagnitude;

            // Set the duration of this effect.
            Duration = aDuration;
        }

        /// <summary>
        /// The duration of the affect.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Magnitude
        /// <remarks>Magnitude is used as a variable during effects 
        /// computation for <c>this</c> effect.</remarks>
        /// <example>a spell that gets stronger (or weaker) over time.</example>
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
        /// The effect that this effect has on stats; this is assumed to be cumulative
        /// for <c>this</c> effect. A "stack" of effects can expect to have each of these 
        /// commuted for the final combat calculation. <see cref="StatsBase"/>
        /// <remarks></remarks>
        /// </summary>
        public StatsBase EffectedStats { get; set; }

        /// <summary>
        /// The effect tick, exactly who this ticks on is important.
        /// </summary>
        /// <param name="targets">The effected target(s)</param>
        public void Tick(Actor[] targets)
        {
#if DEBUG
            UI.Graphics.Display.ShowMessage("Type: {0}, Duration: {1}",
                this.EffectType, this.Duration);
#endif
            if (Duration > 0)
                Duration--;
            if (EffectModifiers != null && targets.Length > 0)
                for (int index = 0; index < targets.Length; ++index)
                    if (targets[index] != null)
                        EffectModifiers(this, targets[index]);
        }

        /// <summary>
        /// The effect tick, exactly who this ticks on is important.
        /// </summary>
        /// <param name="target">the (single) target this ticks on</param>
        public void Tick(Actor target)
        {
            Tick(new Actor[] { target });
        }

        /// <summary>
        /// PermanentDuration
        /// </summary>
        public const int PermanentDuration = -1;
    }
}
