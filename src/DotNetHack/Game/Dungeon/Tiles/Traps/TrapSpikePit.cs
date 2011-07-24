using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Tiles.Traps
{
    /// <summary>
    /// TrapSpikePit
    /// </summary>
    public class TrapSpikePit : Trap
    {
        /// <summary>
        /// Creates a new instance of a spike pit trap.
        /// </summary>
        public TrapSpikePit()
            : base() 
        {
            TriggerEvent += new EventHandler<TrapEventArgs>(TrapSpikePit_TriggerEvent);
        }

        /// <summary>
        /// Occurs when the spike pit trap is triggered.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Trap event arguments.</param>
        void TrapSpikePit_TriggerEvent(object sender, Trap.TrapEventArgs e)
        {

        }
    }
}
