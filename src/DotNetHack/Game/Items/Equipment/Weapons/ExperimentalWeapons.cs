using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    [Serializable]
    public class ShortswordOfRending : Weapon
    {
        public ShortswordOfRending(Location3i l)
            : base("Shortsword of rending", '(', Colour.Standard, l,
            new WeaponProperties()
            {
                BaseWeaponDamage = 5,
                WeaponMaterial = Material.Steel,
                RustAccumulator = 0,
                Condition = 100,
                MaxCondition = 100,
            }, WeaponLocation.MainHand,
            WeaponSubType.MainHand | WeaponSubType.Thrown | WeaponSubType.DualWield)
        { }
    }

    [Serializable]
    public class ShortswordOfTheBear : Weapon
    {
        public ShortswordOfTheBear(Location3i l)
            : base("Shortsword of the Bear", '(', Colour.Standard, l,
            new WeaponProperties()
            {
                BaseWeaponDamage = 5,
                WeaponMaterial = Material.Steel,
                RustAccumulator = 0,
                Condition = 100,
                MaxCondition = 100,
            }, WeaponLocation.MainHand,
            WeaponSubType.MainHand | WeaponSubType.Thrown | WeaponSubType.DualWield)
        { }
    }
}
