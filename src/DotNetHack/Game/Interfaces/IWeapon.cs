using System;
using DotNetHack.Game.Items.Equipment;
using DotNetHack.Game.Items.Equipment.Weapons;
namespace DotNetHack.Game.Interfaces
{
	/// <summary>
	/// IWeapon
	/// </summary>
    public interface IWeapon : IEquipment, IHasCondition 
    {
        /// <summary>
        /// the worn (or not) location of this weapon.
        /// </summary>
        WeaponLocation WeaponLocation { get; set; }

        /// <summary>
        /// the intrinsic properties of this weapon.
        /// </summary>
        WeaponProperties WeaponProperties { get; set; }

        /// <summary>
        /// more information about the type of weapon.
        /// this pretains to usage.
        /// </summary>
        WeaponSubType WeaponSubType { get; set; }

        /// <summary>
        /// the type of weapon this is
        /// </summary>
        WeaponType WeaponType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aWeaponSubType"></param>
        /// <returns></returns>
        bool HasSubTypeFlag(WeaponSubType aWeaponSubType);
    }
}

