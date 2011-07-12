using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DotNetHack.Game.Affects
{
    [DebuggerDisplay("{ToString()}")]
    public class Affect
    {
        [Flags]
        enum AffectFlag { None, Permanent }

        public Affect(AffectType aType, double aMagnitude, int aDuration = -1)
        {
            if (aDuration == -1)
                AffectFlags = AffectFlag.Permanent;
            AffectType = aType;
            Magnitude = aMagnitude;
            Duration = aDuration;
        }

        public AffectType AffectType { get; set; }

        public int Duration { get; set; }

        public double Magnitude { get; set; }

        public void ApplyTo(Actor aTarget)
        {
            foreach (Affect aff in aTarget.AffectStack)
            {
                aff.Tick(aTarget);
            }
        }

        void Tick(Actor target)
        {
            if (AffectFlag.Permanent !=
                (AffectFlag.Permanent | AffectFlags) && Duration > 0)
                Duration--;

            if (Modifiers != null)
                Modifiers(this, target);
        }

        AffectFlag AffectFlags { get; set; }

        public Modifier Modifiers { get; set; }

        public delegate void Modifier(Affect affect, Actor target);

        public override string ToString()
        {
            return string.Format("Aff: {0}, Mag: {1}, Dur: {2}",
                AffectType, Magnitude, Duration);
        }
    }
}
