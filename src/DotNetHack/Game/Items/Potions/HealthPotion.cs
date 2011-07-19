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
        /// HealthPotionType
        /// </summary>
        public enum HealthPotionType { Minor, Light, Strong, Greater, Super }

        /// <summary>
        /// HealthPotion
        /// </summary>
        public HealthPotion(HealthPotionType aHealthPotionType)
            : base(PotionType.Healing,
                aHealthPotionType.ToString() + " Healing Potion", Colour.DarkRed) 
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
