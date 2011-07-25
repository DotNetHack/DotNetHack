using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Potions.Elixers
{
    [Serializable]
    public class ElixerOfStrength : Elixer
    {
        public ElixerOfStrength(PotionStrength aElixerStr)
            : base(aElixerStr) { }

        public override void Quaff(Actor aTarget)
        {
        }
    }
}
