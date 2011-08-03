using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    /// <summary>
    /// Weapon
    /// </summary>
    [Serializable]
    public abstract class Weapon : Item, IWeapon
    {
        /// <summary>
        /// Weapon
        /// </summary>
        /// <param name="aName"></param>
        public Weapon(string aName, char aGlyph, Colour aColor)
            : base(aName, aGlyph, aColor)
        { WeaponProperties = new WeaponProperties(); }

        /// <summary>
        /// WeaponProperties
        /// </summary>
        public WeaponProperties WeaponProperties { get; set; }

        /// <summary>
        /// the worn weapon location
        /// </summary>
        public WeaponLocation WeaponLocation { get; set; }

        /// <summary>
        /// the type of weapon this is
        /// </summary>
        public WeaponType WeaponType { get; set; }

        /// <summary>
        /// the various weapon subtypes allow for further classification.
        /// </summary>
        public WeaponSubType WeaponSubType { get; set; }

        /// <summary>
        /// The overall health of this weapon.
        /// </summary>
        public int Condition
        {
            get { return WeaponProperties.Condition; }
            set
            {
                // the maximum condition can not be exceeded.
                if (value > WeaponProperties.MaxCondition)
                    WeaponProperties.Condition = WeaponProperties.MaxCondition;
                else WeaponProperties.Condition = value;
            }
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        /// <summary>
        /// Loads all available weapons and returns them as an array.
        /// </summary>
        /// <returns></returns>
        public static Weapon[] Load()
        {
            return null;
        }
    }
}