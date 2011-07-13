using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Affects;
using DotNetHack.Game.Events;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game
{
    /// <summary>
    /// Actor
    /// </summary>
    public abstract class Actor
    {
        public Actor()

        { Health = 100; }
        public int Health { get; set; }

        public void ApplyAffects()
        {
            foreach (Affect affect in AffectStack)
                affect.ApplyTo(this);
        }

        /// <summary>
        /// The resistances this actor has at the moment.
        /// </summary>
        public Stack<AffectResistance> ResistanceStack = new Stack<AffectResistance>();

        /// <summary>
        /// The affects that are currently applied to this actor
        /// </summary>
        public Stack<Affect> AffectStack = new Stack<Affect>();

        /// <summary>
        /// Stats for this Actor
        /// </summary>
        public Stats Stats { get; set; }
    }
}
