using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// WeaponEvent
    /// </summary>
    public class WeaponEventArgs : GameEventArgs
    {
        /// <summary>
        /// WeaponEvent
        /// </summary>
        public WeaponEventArgs(IWeapon aWeapon) { Weapon = aWeapon; }

        /// <summary>
        /// The weapon involved in the weapon event
        /// </summary>
        IWeapon Weapon { get; set; }
    }
}
