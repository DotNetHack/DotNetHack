using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items.Equipment.Tools;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    /// <summary>
    /// An effect imbued by alchemy equipment upon the creation of potions; 
    /// more specifically the resulting potion.
    /// </summary>
    public class AlchemyEquipmentEffect
    {
        /// <summary>
        /// Create a new AlchemyEquipmentEffect
        /// </summary>
        /// <param name="pos_str">potion stregth for positive effects</param>
        /// <param name="pos_dur">duration of positive effects</param>
        /// <param name="neg_str">stregth of negative effects</param>
        /// <param name="neg_dur">duration of negative effects</param>
        public AlchemyEquipmentEffect(double potion_quality, double effect_strength, 
            double effect_duration, double harmful_effect_magnitude)
        {
            PotionQuality = potion_quality;
            PositiveStrength = effect_strength;
            PositiveEffectDuration = effect_duration;
            HarmfulEffectMagnitude = harmful_effect_magnitude;
        }

        /// <summary>
        /// The potion quality modifier
        /// </summary>
        public double PotionQuality { get; set; }

        /// <summary>
        /// The beneficial stregth modifier
        /// </summary>
        public double PositiveStrength { get; set; }

        /// <summary>
        /// The duration modifier of positive effects
        /// </summary>
        public double PositiveEffectDuration { get; set; }

        /// <summary>
        /// The harmful effect modifier
        /// </summary>
        public double HarmfulEffectMagnitude { get; set; }
    }
}
