using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.NPC
{
    /// <summary>
    /// Agression
    /// </summary>
    public enum Agression
    {
        /// <summary>
        /// An NPC that is passive will never attack, even in self defense.
        /// </summary>
        Passive,

        /// <summary>
        /// An NPC that is passive agressive will never attack, except in self defense.
        /// </summary>
        PassiveAgressive,

        /// <summary>
        /// An NPC that is agressive will attack on sight.
        /// </summary>
        Agressive,

        /// <summary>
        /// An NPC that is hostile is actively looking for a fight.
        /// </summary>
        Hostile,

        /// <summary>
        /// Will attack anything and everything!  Including objects, humanoids, creatures
        /// 10x it's size.
        /// </summary>
        Frenzied,
    }
}
