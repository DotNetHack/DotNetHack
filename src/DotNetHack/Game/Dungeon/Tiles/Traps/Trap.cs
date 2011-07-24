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
    [Serializable]
    public abstract class Trap : Tile, IGlyph
    {
        /// <summary>
        /// Creates a new instance of Trap
        /// <remarks>This is the most basic form of trap.</remarks>
        /// </summary>
        public Trap()
            : base('^', Colour.Standard, TileFlags.Trap)
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
        public virtual void OnTrapTriggeredEvent(TrapEventArgs e) 
        {
            if (TriggerEvent != null && !Disabled)
                TriggerEvent(this, e);
        }

        /// <summary>
        /// The trap trigger event handler.
        /// </summary>
        public event EventHandler<TrapEventArgs> TriggerEvent;

        /// <summary>
        /// Has this trap been disabled?
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Calling this method will Disable this trap.
        /// </summary>
        public void Enable() { Disabled = true; }

        /// <summary>
        /// Calling this trap will <c>Enable</c> this trap.
        /// </summary>
        public void Disable() { Disabled = false; }
    }
}
