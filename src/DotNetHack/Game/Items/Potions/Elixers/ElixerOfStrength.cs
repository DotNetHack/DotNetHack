using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Affects;

namespace DotNetHack.Game.Items.Potions.Elixers
{
    public class ElixerOfStrength : Elixer
    {
        public ElixerOfStrength(PotionStrength aElixerStr)
            : base(aElixerStr) { }

        public override void Quaff(Actor aTarget)
        {
            var elixerAffect = new Affect(AffectType.Elixer, aTarget.Stats.Luck, -1);
            elixerAffect.Modifiers += new Affect.Modifier(
                delegate(Affect af, Actor ta)
                {
                    ta.Stats.Strength += 1;
                });
            aTarget.AffectStack.Push(elixerAffect);
        }
    }
}
