using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Effects;
using DotNetHack.Game.Items.Equipment.Armour;

namespace DotNetHack.Game.Items.Equipment.Armor
{
    #region Cloth Set

    [Serializable]
    public class ClothSetPiece : Armour
    {
        public ClothSetPiece(Location3i l, ArmourLocation aArmourLocation)
            : base(string.Empty, '{', Colour.Standard, l, aArmourLocation)
        {
            switch (aArmourLocation)
            {
                default: Name = "Cloth " + aArmourLocation;
                    break;
                case Equipment.Armour.ArmourLocation.Legs:
                    Name = "Cloth Pants";
                    break;
            }
            ArmourStats = new Armor.ArmourStats()
            {
                Condition = 100,
                Weight = 0.5,
            };
            switch (aArmourLocation)
            {
                default:
                    StatsBase = new StatsBase() { ArmourClass = 1, };
                    break;
                case Equipment.Armour.ArmourLocation.Chest:
                    StatsBase = new StatsBase() { ArmourClass = 2, };
                    break;
            }
        }
    }

    [Serializable]
    public class ClothShoes : ClothSetPiece
    {
        public ClothShoes(Location3i l)
            : base(l, ArmourLocation.Feet) { }
    }

    [Serializable]
    public class ClothShirt : ClothSetPiece
    {
        public ClothShirt(Location3i l)
            : base(l, ArmourLocation.Chest) { }
    }

    [Serializable]
    public class ClothPants : ClothSetPiece
    {
        public ClothPants(Location3i l)
            : base(l, ArmourLocation.Legs) { }
    }

    #endregion

    [Serializable]
    public class ChestpieceOfDebugging : Armour
    {
        public ChestpieceOfDebugging() : base() { }

        public ChestpieceOfDebugging(Location3i l)
            : base("Chestpiece of Debugging", '{',
            Colour.Silver, l, Equipment.Armour.ArmourLocation.Chest)
        {
            ArmourStats = new Armor.ArmourStats()
            {
                Condition = 100,
                Weight = 1,
            };
            StatsBase = new StatsBase()
            {
                Strength = 1,
                Perception = 1,
                Endurance = 1,
                Charisma = 1,
                Intelligence = 12,
                Agility = 1,
                Luck = 1,
            };
        }
    }

#if DEBUG

    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL

    [Serializable]
    public class HauberkOfDefense : Armour
    {
        public HauberkOfDefense() { }
        public HauberkOfDefense(Location3i l)
            : base("Hauberk of Defense",
                '{', Colour.Silver, l,
            Equipment.Armour.ArmourLocation.Chest)
        {
            StatsBase = new StatsBase()
            {
                Strength = 0,
                Perception = 0,
                Endurance = 6,
                Charisma = 0,
                Intelligence = 0,
                Agility = 0,
                Luck = 0,
            };
        }
    }

    [Serializable]
    public class BandOfSalvation : Armour
    {
        /// <summary>
        /// BandOfSalvation
        /// </summary>
        /// <param name="l"></param>
        public BandOfSalvation(Location3i l)
            : base("Band of Salvation", '/', Colour.Silver,
            l, Equipment.Armour.ArmourLocation.LeftFinger)
        {
            StatsBase = new StatsBase() { Intelligence = 8 };
            ArmourStats = new Armor.ArmourStats()
            {
                Condition = 100,
                Weight = 0.1,
            };

            // occurs on melee strike.
            OnMeleeStrike +=
                new EventHandler<Events.ArmourStrikeEventArgs>(
                    BandOfSalvation_OnMeleeStrike);
        }

        void BandOfSalvation_OnMeleeStrike(object sender, Events.ArmourStrikeEventArgs e)
        {
            if (Dice.D(50))
            {
                if (e.WornByActor.EffectStack.FirstOrDefault(
                    x => x.Guid.Equals(BandOfSalvation_OnMeleeStrike_Guid)) == null)
                    e.WornByActor.EffectStack.Add(
                        new Effects.Effect()
                        {
                            Magnitude = 1,
                            Duration = 30,
                            EffectModifiers = delegate(Effect effect, Actor t) { t.Stats.Health += 1; },
                            Guid = BandOfSalvation_OnMeleeStrike_Guid,
                        });
            }
        }

        readonly Guid BandOfSalvation_OnMeleeStrike_Guid =
            new Guid("52ade84e-33c2-43c1-b295-bdd525e758d6");
    }

    [Serializable]
    public class GauntletsOfBane : Armour
    {
        public GauntletsOfBane() { }
        public GauntletsOfBane(Location3i l)
            : base("Gauntlets of Bane",
                '{', Colour.Silver, l,
            Equipment.Armour.ArmourLocation.Arms)
        {
            StatsBase = new StatsBase()
            {
                Strength = 5,
                Perception = 0,
                Endurance = 50,
                Charisma = 0,
                Intelligence = 0,
                Agility = 0,
                Luck = 0,
            };
        }
    }

    [Serializable]
    public class GauntletsOfWisdom : Armour
    {
        public GauntletsOfWisdom() { }
        public GauntletsOfWisdom(Location3i l)
            : base("Gauntlets of Wisdom",
                '{', Colour.Silver, l,
            Equipment.Armour.ArmourLocation.Arms)
        {
            StatsBase = new StatsBase()
            {
                Strength = 0,
                Perception = 0,
                Endurance = 0,
                Charisma = 0,
                Intelligence = 5,
                Agility = 0,
                Luck = 0,
            };
        }
    }

    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL

#endif
}
