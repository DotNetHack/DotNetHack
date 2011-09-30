using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items.Equipment.Armour;
using DotNetHack.Game.Items.Equipment.Armor;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.Interfaces
{
    public interface IArmour : IEquipment, IHasCondition
    {
        ArmourLocation ArmourLocation { get; }
        StatsBase StatsBase { get; set; }
        ArmourStats ArmourStats { get; set; }
        event EventHandler<ArmourStrikeEventArgs> OnMeleeStrike;
        event EventHandler<ArmourStrikeEventArgs> OnSpellStrike;
        void ArmourStrike(ArmourStrikeEventArgs args);
    }
}
