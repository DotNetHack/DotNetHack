using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Effects;

namespace DotNetHack.Game.Items.Potions.Elixers
{
    [Serializable]
    public class ElixerOfOgreStrength : Elixer
    {
        public ElixerOfOgreStrength(PotionStrength aElixerStr)
            : base(aElixerStr) { }

        public override void Quaff(Actor aTarget)
        {
            base.Quaff(aTarget);

            aTarget.EffectStack.Add(new Effects.Effect()
            {
                EffectedStats = new StatsBase() { Strength = 2 },
                EffectType = Effects.EffectType.Enchantment,
                Duration = 30,
                Magnitude = 3,
            });
        }
    }
}
