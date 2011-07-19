using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Affects;

namespace DotNetHack.Game.Items.Potions
{
    /// <summary>
    /// HealthPotion
    /// </summary>
    public class HealthPotion : Potion
    {
        /// <summary>
        /// HealthPotion
        /// </summary>
        public HealthPotion(PotionStrength aHealthPotionType)
            : base(PotionType.Healing,
                "Health Potion", Colour.White) 
        { }

        /// <summary>
        /// Quaff
        /// </summary>
        public override void Quaff(Actor aActor)
        {
            // Push the healing affect onto the affect stack.
            aActor.AffectStack.Push(
                new Affect(AffectType.Healing, aActor.Stats.Endurance));
        }
    }
}
