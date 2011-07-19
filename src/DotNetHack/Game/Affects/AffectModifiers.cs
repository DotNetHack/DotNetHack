using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Affects
{
    /// <summary>
    /// AffectModifiers
    /// </summary>
    public static class AffectModifiers
    {
        /// <summary>
        /// Damages target by base + 7% of remaining health
        /// Disease restistance applied.
        /// </summary>
        /// <param name="affect"></param>
        /// <param name="target"></param>
        public static void Pestilence(Affect affect, Actor target)
        {
            Affect tmpAffect = new Affect(affect.AffectType, affect.Magnitude, affect.Duration);
            foreach (var resistance in target.ResistanceStack)
                tmpAffect = resistance.Apply(tmpAffect);
            tmpAffect.Magnitude +=
                ((double)(target.Health * 0.07));
            target.Health -= (int)tmpAffect.Magnitude;
        }

        /// <summary>
        /// HealingPotion
        /// </summary>
        /// <param name="aAffect">Affect</param>
        /// <param name="aTarget">Target</param>
        public static void HealingPotion(Affect aAffect, Actor aTarget)
        {
            aTarget.Health += (int)(aAffect.Magnitude * 0.3);
        }
    }
}
