using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Equipment.Armor
{

    [Serializable]
    public class ChestpieceOfDebugging : Armour
    {
        public ChestpieceOfDebugging() : base() { }

        public ChestpieceOfDebugging(Location3i l)
            : base("Chestpiece of Debugging", '{',
            Colour.Silver, l, Equipment.Armour.ArmourLocation.Chest)
        {
            StatsBase = new StatsBase()
            {
                Strength = 1,
                Perception = 1,
                Endurance = 1,
                Charisma = 1,
                Intelligence = 1,
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
                Strength = 1,
                Perception = 1,
                Endurance = 1,
                Charisma = 1,
                Intelligence = 1,
                Agility = 1,
                Luck = 1,
            };
        }
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
                Strength = 1,
                Perception = 1,
                Endurance = 1,
                Charisma = 1,
                Intelligence = 1,
                Agility = 1,
                Luck = 1,
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
                Strength = 1,
                Perception = 1,
                Endurance = 1,
                Charisma = 1,
                Intelligence = 1,
                Agility = 1,
                Luck = 1,
            };
        }
    }

    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL

#endif
}
