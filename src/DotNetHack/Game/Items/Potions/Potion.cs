using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Potions
{
    /// <summary>
    /// Potion
    /// </summary>
    public abstract class Potion: Item, IPotion
    {
        /// <summary>
        /// Creates a (base) instance of Potion/
        /// </summary>
        /// <param name="aType">The type of potion</param>
        /// <param name="aName">The name of the potion.</param>
        /// <param name="aColor">The color of the potion.</param>
        public Potion(PotionType aType, string aName, Colour aColor)
            : base(aName, '!', aColor) { PotionType = aType; }

        /// <summary>
        /// The type of potion
        /// </summary>
        public PotionType PotionType { get; set; }

        /// <summary>
        /// Quaff
        /// </summary>
        public abstract void Quaff(Actor aTarget);
    }
}
