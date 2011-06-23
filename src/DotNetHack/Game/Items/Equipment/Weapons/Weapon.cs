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
        /// Condition
        /// </summary>
        public int Condition
        {
            get { return WeaponProperties.Condition; }
            set { WeaponProperties.Condition = value; }
        }

        /// <summary>
        /// WeaponProperties
        /// </summary>
        public WeaponProperties WeaponProperties;// { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return string.Format("{0}", Name); }

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