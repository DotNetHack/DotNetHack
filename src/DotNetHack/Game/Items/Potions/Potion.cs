using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;
using DotNetHack.UI;

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
        /// Quaff, this base triggers event.
        /// </summary>
        public virtual void Quaff(Actor aTarget) 
        {
            Sound.DoSound(Sound.SoundEventType.QuaffPotion);
            if (OnQuaff != null)
                OnQuaff(this, new PotionEventArgs(aTarget, this));
        }

        /// <summary>
        /// Quaff event handler
        /// </summary>
        public event EventHandler<PotionEventArgs> OnQuaff;

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
        /// <list type="bullet">
        /// <listheader>StregthModifier and Effect on Magnitude</listheader>
        /// <item>Elixer
        /// <list type="bullet">
        /// <item>Light</item>
        /// <item>Minor</item>
        /// <item>Greater</item>
        /// <item>Strong</item>
        /// <item>Super</item>
        /// </list>
        /// </item>
        /// <item>Poision
        /// <list type="bullet">
        /// <item>Light</item>
        /// <item>Minor</item>
        /// <item>Greater</item>
        /// <item>Strong</item>
        /// <item>Super</item>
        /// </list>
        /// </item>
        /// <item>Healing
        /// <list type="bullet">
        /// <item>Light</item>
        /// <item>Minor</item>
        /// <item>Greater</item>
        /// <item>Strong</item>
        /// <item>Super</item>
        /// </list>
        /// </item>
        /// </list>
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
                                return 1;
                            case Potions.PotionStrength.Minor:
                                return 2;
                            case Potions.PotionStrength.Greater:
                                return 3;
                            case Potions.PotionStrength.Strong:
                                return 4;
                            case Potions.PotionStrength.Super:
                                return 5;
                        }
                    case Potions.PotionType.Poision:
                        switch (PotionStrength)
                        {
                            default:
                            case Potions.PotionStrength.Light:
                                return 2.6;
                            case Potions.PotionStrength.Minor:
                                return 3.4;
                            case Potions.PotionStrength.Greater:
                                return 4.04;
                            case Potions.PotionStrength.Strong:
                                return 4.54;
                            case Potions.PotionStrength.Super:
                                return 4.96;
                        }
                    case Potions.PotionType.Healing:
                        switch (PotionStrength)
                        {
                            default:
                            case Potions.PotionStrength.Light:
                                return 5;
                            case Potions.PotionStrength.Minor:
                                return 5.2;
                            case Potions.PotionStrength.Greater:
                                return 5.7;
                            case Potions.PotionStrength.Strong:
                                return 6.5;
                            case Potions.PotionStrength.Super:
                                return 7.7;
                        }
                }
            }
        }
    }
}
