using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// GameEvent
    /// EventArgs should have as much context as required for 
    /// event subscribers to act appropriately.
    /// </summary>
    public class GameEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance of <see cref="GameEventArgs"/>
        /// </summary>
        public GameEventArgs() : base() { }
    }
}
