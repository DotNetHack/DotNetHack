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
    [Serializable]
    public abstract class Potion : Item, IPotion
    {
        /// <summary>
        /// Creates a (base) instance of Potion/
        /// </summary>
        /// <param name="aType">The type of potion</param>
        /// <param name="aName">The name of the potion.</param>
        /// <param name="aColor">The color of the potion.</param>
        public Potion(PotionType aPotionType, PotionStrength aPotionStrength,
            string aName, Colour aColor)
            : base(ItemType.Potion, aName, '!', aColor)
        {
            PotionType = aPotionType;
            PotionStrength = aPotionStrength;
        }

        /// <summary>
        /// The type of potion
        /// </summary>
        public PotionType PotionType { get; set; }

        /// <summary>
        /// PotionStrength
        /// </summary>
        public PotionStrength PotionStrength { get; set; }

        /// <summary>
        /// Quaff
        /// </summary>
        public abstract void Quaff(Actor aTarget);

        /// <summary>
        /// ToString
        /// {Superior} {Healing} Potion
        /// </summary>
        /// <returns>A string representation of this potion.</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} Potion",
                PotionStrength, PotionType);
        }

        /// <summary>
        /// StregthModifier
        /// </summary>
        public double StregthModifier
        {
            get
            {
                switch (PotionType)
                {
                    default:
                        return 1.0;
                    case Potions.PotionType.Elixer:
                        switch (PotionStrength)
                        {
                            default:
                            case Potions.PotionStrength.Light:
                            case Potions.PotionStrength.Minor:
                            case Potions.PotionStrength.Greater:
                            case Potions.PotionStrength.Strong:
                            case Potions.PotionStrength.Super:
                                return 1.0;
                        }
                    case Potions.PotionType.Poision:
                        switch (PotionStrength)
                        {
                            default:
                            case Potions.PotionStrength.Light:
                            case Potions.PotionStrength.Minor:
                            case Potions.PotionStrength.Greater:
                            case Potions.PotionStrength.Strong:
                            case Potions.PotionStrength.Super:
                                return 1.0;
                        }
                    case Potions.PotionType.Healing:
                        switch (PotionStrength)
                        {
                            default:
                            case Potions.PotionStrength.Light:
                            case Potions.PotionStrength.Minor:
                            case Potions.PotionStrength.Greater:
                            case Potions.PotionStrength.Strong:
                            case Potions.PotionStrength.Super:
                                return 1.0;
                        }
                }
            }
        }
    }
}
