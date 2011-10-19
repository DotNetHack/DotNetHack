using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    /// <summary>
    /// weapon subtype allows for furtther classification of the weapon.
    /// </summary>
    [Flags]
    public enum WeaponSubType 
    {
        /// <summary>
        /// If this a main handed weapon?
        /// </summary>
        MainHand, 

        /// <summary>
        /// can this weapon be thrown
        /// </summary>
        Thrown,

        /// <summary>
        /// is this a two handed weapon? (like bows)
        /// </summary>
        TwoHanded, 

        /// <summary>
        /// <c>can</c> this weapon be dual wielded?
        /// </summary>
        DualWield, 

        /// <summary>
        /// will this work as an offhand weapon?
        /// </summary>
        OffHand,

        #region additional classification

        /// <summary>
        /// A blunt weapon
        /// </summary>
        Blunt,

        /// <summary>
        /// is this a ranged weapon (requires ammo)
        /// </summary>
        Ranged,
 
        /// <summary>
        /// A longer blade
        /// </summary>
        LongBlade,

        /// <summary>
        /// A short blade
        /// </summary>
        ShortBlade,

        #endregion
    }
}
