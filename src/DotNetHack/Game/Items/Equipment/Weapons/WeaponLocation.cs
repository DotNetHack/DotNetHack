using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    /// <summary>
    /// locations a given weapon can be in.
    /// </summary>
    public enum WeaponLocation
    {
        /// <summary>
        /// the weapon is taking up both hands.
        /// </summary>
        BothHands,

        /// <summary>
        /// the weapon is harmless
        /// </summary>
        Sheathed,

        /// <summary>
        /// posessed in the main hand.
        /// </summary>
        MainHand,

        /// <summary>
        /// posessed in the offhand.
        /// </summary>
        OffHand,

        /// <summary>
        /// on the back 
        /// </summary>
        Back,
    }
}
