using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment.Tools
{
    public abstract class AlchemyEquipment : Tool
    {
        public AlchemyEquipment(string name, Glyph glyph, double potion_quality,
           double effect_strength, double effect_duration, double harmful_effect_magnitude)
            : base(name, glyph.G, glyph.C)
        {
            AlchemyEquipmentEffect = new AlchemyEquipmentEffect(potion_quality, effect_strength,
                effect_duration, harmful_effect_magnitude);
        }

        /// <summary>
        /// The effect imbued on potions and elixers
        /// </summary>
        public AlchemyEquipmentEffect AlchemyEquipmentEffect { get; set; }

        /// <summary>
        /// Base modifier
        /// </summary>
        public double BaseModifier { get; set; }
    }
}
