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
            double tmpModifier = 0.0;

            // Push the healing affect onto the affect stack.
            switch (PotionStrength)
            {
                case Potions.PotionStrength.Light:
                    tmpModifier = 0.1;
                    break;
                case Potions.PotionStrength.Minor:
                    tmpModifier = 0.22;
                    break;
                case Potions.PotionStrength.Greater:
                    tmpModifier = 0.34;
                    break;
                case Potions.PotionStrength.Strong:
                    tmpModifier = 0.46;
                    break;
                case Potions.PotionStrength.Super:
                    tmpModifier = 0.56;
                    break;
            }

            var healingAffect = new Affect(AffectType.Healing,
                aActor.Stats.Endurance * tmpModifier);

            healingAffect.Modifiers = AffectModifiers.HealingPotion;

            aActor.AffectStack.Push(healingAffect);
        }
    }
}
