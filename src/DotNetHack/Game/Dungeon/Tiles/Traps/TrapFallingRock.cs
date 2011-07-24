using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Tiles.Traps
{
    /// <summary>
    /// TrapFallingRock
    /// </summary>
    [Serializable]
    public class TrapFallingRock : Trap
    {
        /// <summary>
        /// Creates a new instance of TrapFallingRock
        /// </summary>
        public TrapFallingRock()
        {
            TriggerEvent += new EventHandler<TrapEventArgs>(TrapFallingRock_TriggerEvent);
        }

        /// <summary>
        /// Occurs when the falling rock trap is triggered.
        /// </summary>
        /// <param name="sender">The event sender</param>
        /// <param name="e">The event argument(s)</param>
        void TrapFallingRock_TriggerEvent(object sender, Trap.TrapEventArgs e)
        {

        }
    }
}
