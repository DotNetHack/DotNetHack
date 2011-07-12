using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Affects
{
    /// <summary>
    /// AffectResistance
    /// </summary>
    public class AffectResistance
    {
        /// <summary>
        /// Create a new AffectResistance
        /// </summary>
        /// <param name="aType"></param>
        /// <param name="aMagnitude"></param>
        public AffectResistance(AffectType aType, double aMagnitude)
        { AffectType = aType; Magnitude = aMagnitude; }

        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="affect"></param>
        public Affect Apply(Affect affect)
        {
            // Affect output = new Affect(affect.AffectType, affect.Magnitude, affect.Duration);

            if (affect.AffectType == this.AffectType)
                affect.Magnitude = (affect.Magnitude - (affect.Magnitude * (this.Magnitude) / 100));

            return affect;
        }

        /// <summary>
        /// Resistance AffectType
        /// </summary>
        public AffectType AffectType { get; set; }

        /// <summary>
        ///       Resistance Magnitude
        /// </summary>
        public double Magnitude { get; set; }
    }
}
