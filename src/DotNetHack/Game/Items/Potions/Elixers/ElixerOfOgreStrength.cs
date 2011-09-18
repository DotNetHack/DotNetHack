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
            aTarget.EffectStack.Add(new Effects.Effect()
            {
                Duration = 30,
                EffectType = Effects.EffectType.Enchantment,
                Magnitude = 3,
            });
        }
    }
}
