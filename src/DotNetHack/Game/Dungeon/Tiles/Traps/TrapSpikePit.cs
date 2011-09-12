using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Effects;

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
            GameEngine.DoSound(new Sound(e.TrapTarget, 40, "shhhhing!!"));

            string strMessage = string.Format("You stepped into a {0} trap!", this);
            if (Dice.D(e.TrapTarget.Stats.Agility) || Dice.D(e.TrapTarget.Stats.Luck))
                strMessage += " You were agile enough to avoid it!";
            else
            {
                e.TrapTarget.Stats.Health -= 10;
            }

            UI.Graphics.Display.ShowMessage(strMessage);

            Disable();
        }

        /// <summary>
        /// ToString for TrapSpikePit.
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return "spike pit"; }
    }
}
