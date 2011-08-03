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
        public WeaponsWielded()
        {
            WieldedWeapons = new Dictionary<WeaponLocation, IWeapon>();
        }

        /// <summary>
        /// Wield the following weapon.
        /// </summary>
        /// <param name="aWeapon">wield this weapon.</param>
        public void Wield(IWeapon aWeapon)
        {
            if (WieldedWeapons.ContainsKey(aWeapon.WeaponLocation))
            {
                if (SwitchWeaponConfirm != null)
                {
                    var currentWeapon = WieldedWeapons[aWeapon.WeaponLocation];
                    if (SwitchWeaponConfirm(string.Format(
                        "Are you sure you want to wield {0} instead of {1}?",
                            currentWeapon, aWeapon)))
                        WieldedWeapons.Remove(aWeapon.WeaponLocation);
                }
                else WieldedWeapons.Remove(aWeapon.WeaponLocation);
            }

            WieldedWeapons.Add(aWeapon.WeaponLocation, aWeapon);

            OnWieldWeaponEvent(this,
                new EquipmentEventArgs<WieldEventType, IWeapon>(WieldEventType.Wield,
                    aWeapon));
        }

        /// <summary>
        /// occurs when the weapon wield is complete.
        /// </summary>
        public event EventHandler<EquipmentEventArgs<WieldEventType, IWeapon>> OnWieldWeaponEvent;

        /// <summary>
        /// confirmation that a weapon switch will take place.
        /// obviously monsters dont do this.
        /// </summary>
        public Input.Confirm SwitchWeaponConfirm = null;

        /// <summary>
        /// contains all wielded weapons.
        /// </summary>
        public Dictionary<WeaponLocation, IWeapon> WieldedWeapons { get; set; }

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
