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
        public HealthPotion(PotionStrength aPotionStrength)
            : base(PotionType.Healing, aPotionStrength, "", Colour.White)
        { }

        /// <summary>
        /// Quaff
        /// </summary>
        public override void Quaff(Actor aActor)
        {
            var healingAffect = new Affect(AffectType.Healing,
                aActor.Stats.Endurance * StregthModifier, 1);

            healingAffect.Modifiers += 
                new Affect.Modifier(delegate(Affect af, Actor ta) 
                    {
                        ta.Health += (int)(10 * af.Magnitude);
                    });

            aActor.AffectStack.Push(healingAffect);
        }
    }
}
