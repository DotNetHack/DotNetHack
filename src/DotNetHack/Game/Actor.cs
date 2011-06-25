using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Affects;

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

        public Stack<AffectResistance> ResistanceStack = new Stack<AffectResistance>();
        public Stack<Affect> AffectStack = new Stack<Affect>();
    }
}
