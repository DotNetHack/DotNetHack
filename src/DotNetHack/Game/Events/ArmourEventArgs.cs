using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// ArmourEventArgs
    /// </summary>
    public class ArmourEventArgs : GameEventArgs
    {
        /// <summary>
        /// ArmourEventArgs
        /// </summary>
        /// <param name="aArmour">The armour involved in this armour event</param>
        public ArmourEventArgs(IArmour aArmour)
        { Armour = aArmour; }

        /// <summary>
        /// The armour involved in this armour event
        /// </summary>
        public IArmour Armour { get; set; }
    }
}
