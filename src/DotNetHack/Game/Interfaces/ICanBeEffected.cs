using System;
using System.Collections.Generic;
using DotNetHack.Game.Effects;

namespace DotNetHack.Game.Interfaces
{
    /// <summary>
    /// Interface that 
    /// </summary>
    public interface ICanBeEffected
    {
        /// <summary>
        /// ApplyEffects
        /// </summary>
        void ApplyEffects();

        /// <summary>
        /// the effect stack.
        /// </summary>
        List<Effect> EffectStack { get; set; }
    }

    /// <summary>
    /// ICanBeEffectedExplicit
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICanBeEffectedExplicit<T> : ICanBeEffected
    {
        /// <summary>
        /// Target
        /// </summary>
        T Target { get; set; }
    }
}
