using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items.Equipment.Armor;

namespace DotNetHack.Game.Interfaces
{
    public interface IArmor : IEquipment, IHasCondition
    {
        ArmorLocation ArmorLocation { get; }
    }
}
