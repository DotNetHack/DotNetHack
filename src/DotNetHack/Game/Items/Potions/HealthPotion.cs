using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Potions
{
    /// <summary>
    /// HealthPotion
    /// </summary>
    [Serializable]
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
            // experimental
            // TODO: Level impacts amount of healing done.
            aActor.EffectStack.Add(
                new Effects.Effect(Effects.EffectType.Healing, 5, 40)
                {
                    EffectModifiers = delegate(Effects.Effect e, ICanBeEffected t)
                    {
                        aActor.Stats.Health += e.Magnitude;
                    },
                });
        }
    }
}
