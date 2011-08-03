using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items.Equipment.Armour;

namespace DotNetHack.Game.Interfaces
{
    public interface IArmour : IEquipment, IHasCondition
    {
        ArmourLocation ArmourLocation { get; }
    }
}
