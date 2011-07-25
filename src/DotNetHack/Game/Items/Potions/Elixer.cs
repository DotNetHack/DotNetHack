using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Potions
{
    /// <summary>
    /// Elixer
    /// </summary>
    [Serializable]
    public abstract class Elixer : Potion
    {
        /// <summary>
        /// Elixer
        /// </summary>
        public Elixer(PotionStrength aPotionStrength)
            : base(PotionType.Elixer, aPotionStrength, "", new Colour(ConsoleColor.Magenta))
        { }
    }
}
