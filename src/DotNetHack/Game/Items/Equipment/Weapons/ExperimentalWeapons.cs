using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Weapons
{
    [Serializable]
    public class RustedLongsword : Weapon
    {
        public RustedLongsword(Location3i l)
            : base("Rusted Longsword", '(', Colour.Standard, l,
            new WeaponProperties()
            {
                BaseWeaponDamage = 3,
                Condition = 100,
                MaxCondition = 100,
                RustAccumulator = 50,
                WeaponMaterial = Material.Steel | Material.Wooden,
            }, WeaponLocation.MainHand,
            WeaponSubType.LongBlade | WeaponSubType.TwoHanded)
        { }
    }

    [Serializable]
    public class RustedShortsword : Weapon
    {
        public RustedShortsword(Location3i l)
            : base("Rusted Shortsword", '(', Colour.Standard, l,
            new WeaponProperties() 
            {
                BaseWeaponDamage = 2,
                Condition = 100,
                MaxCondition = 100,
                RustAccumulator = 50,
                WeaponMaterial = Material.Steel | Material.Wooden,
            }, WeaponLocation.MainHand,
            WeaponSubType.ShortBlade | WeaponSubType.MainHand)
        { }
    }

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
            WeaponSubType.MainHand | WeaponSubType.ShortBlade)
        { }

        protected override void WeaponStrike()
        {
            base.WeaponStrike();
        }
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
            WeaponSubType.MainHand | WeaponSubType.ShortBlade) { }

        protected override void WeaponStrike()
        {
            base.WeaponStrike();
        }
    }
}
