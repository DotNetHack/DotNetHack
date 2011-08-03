using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Equipment.Armor
{
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
        { }
    }

    [Serializable]
    public class GauntletsOfBane : Armour
    {
        public GauntletsOfBane() { }
        public GauntletsOfBane(Location3i l)
            : base("Gauntlets of Bane",
                '{', Colour.Silver, l,
            Equipment.Armour.ArmourLocation.Arms)
        { }
    }

    [Serializable]
    public class GauntletsOfWisdom : Armour
    {
        public GauntletsOfWisdom() { }
        public GauntletsOfWisdom(Location3i l)
            : base("Gauntlets of Wisdom",
                '{', Colour.Silver, l,
            Equipment.Armour.ArmourLocation.Arms)
        { }
    }

    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL
    // WARNING: EXPERIMENTAL

#endif
}
