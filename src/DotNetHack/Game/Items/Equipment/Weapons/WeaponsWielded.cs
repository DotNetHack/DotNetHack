using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    /// <summary>
    /// WeaponsWielded
    /// </summary>
    [Serializable]
    public class WeaponsWielded
    {
        /// <summary>
        /// supports serialization
        /// </summary>
        public WeaponsWielded() { }

        /// <summary>
        /// Wield the following weapon.
        /// </summary>
        /// <param name="aWeapon">wield this weapon.</param>
        /// <param name="confirm">show a conf message if a weapon is already wielded.</param>
        public void Wield(IWeapon aWeapon, bool confirm = true)
        {
            if (CurrentWeapon != null)
                UnWield(CurrentWeapon, confirm);

            CurrentWeapon = aWeapon;
            
            if (OnWieldWeaponEvent != null)
                OnWieldWeaponEvent(this,
                    new EquipmentEventArgs<WieldEventType, IWeapon>
                    (WieldEventType.Wield, aWeapon));
        }

        public void UnWield(IWeapon aWeapon, bool confirm = true)
        {
            if (UnWieldConfirm != null && confirm)
                confirm = UnWieldConfirm(string.Format(
                    "Are you sure you want to unwield {0}", CurrentWeapon.Name));

            if (confirm)
            {
                CurrentWeapon = null;
                SheathedWeapon = aWeapon;
            }

            if (OnWieldWeaponEvent != null)
                OnWieldWeaponEvent(this,
                    new EquipmentEventArgs<WieldEventType, IWeapon>(WieldEventType.Sheath,
                        aWeapon));
        }

        /// <summary>
        /// occurs when the weapon wield is complete.
        /// </summary>
        public event EventHandler<EquipmentEventArgs<
            WieldEventType, IWeapon>> OnWieldWeaponEvent;

        /// <summary>
        /// confirmation that a weapon switch will take place.
        /// obviously monsters dont do this.
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public Input.Confirm UnWieldConfirm = null;

        /*
        /// <summary>
        /// contains all wielded weapons.
        /// </summary>
        public Dictionary<WeaponLocation, IWeapon> 
            WieldedWeapons { get; set; }
         */

        /// <summary>
        /// 
        /// </summary>
        public IWeapon CurrentWeapon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IWeapon SheathedWeapon { get; set; }

        /// <summary>
        /// the various types of wielding (or not)
        /// </summary>
        public enum WieldEventType
        {
            /// <summary>
            /// wield event
            /// </summary>
            Wield,

            /// <summary>
            /// sheath event.
            /// </summary>
            Sheath,
        }
    }
}
