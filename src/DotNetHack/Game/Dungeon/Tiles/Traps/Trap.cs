using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Dungeon.Tiles.Traps
{
    /// <summary>
    /// Trap
    /// </summary>
    public abstract class Trap : Tile, IGlyph
    {
        /// <summary>
        /// Creates a new instance of Trap
        /// <remarks>This is the most basic form of trap.</remarks>
        /// </summary>
        public Trap()
            : base('^', Colour.Standard)
        { }

        /// <summary>
        /// TrapEventArgs
        /// </summary>
        public class TrapEventArgs : EventArgs
        {
            /// <summary>
            /// Creates a new instance of trap event args
            /// <param name="aActor">The actor that triggered the trap</param>
            /// </summary>
            public TrapEventArgs(Actor aActor) { TrapTarget = aActor; }

            /// <summary>
            /// TrapTarget, the actor responsibile for triggering the trap.
            /// </summary>
            public Actor TrapTarget { get; set; }
        }

        /// <summary>
        /// Occurs when the trap is triggered.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTrapTriggeredEvent(TrapEventArgs e) 
        {
            if (TriggerEvent != null)
                TriggerEvent(this, e);
        }

        /// <summary>
        /// The trap trigger event handler.
        /// </summary>
        public event EventHandler<TrapEventArgs> TriggerEvent;
    }
}
