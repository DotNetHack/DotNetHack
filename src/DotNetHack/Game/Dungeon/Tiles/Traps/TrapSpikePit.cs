using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Tiles.Traps
{
    /// <summary>
    /// TrapSpikePit
    /// </summary>
    [Serializable]
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
            UI.Graphics.Display.ShowMessage(
                string.Format("You stepped into a {0} trap!", this));
            e.TrapTarget.Stats.Health -= 1;
        }

        /// <summary>
        /// ToString for TrapSpikePit.
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return "spike pit"; }
    }
}
