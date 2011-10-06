﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.UI;

namespace DotNetHack.Game.Items.Herbs
{
    public static class HerbExtensions
    {
        public static Colour GetHerbColourByType(this Herb.HerbType aHerbType)
        {
            switch (aHerbType)
            {
                default:
                    return Colour.Grass;
                    break;
                case Herb.HerbType.TigerLilly:
                    return new Colour(ConsoleColor.Yellow, ConsoleColor.Green);
                    break;
                case Herb.HerbType.WhiteSage:
                    return new Colour(ConsoleColor.White, ConsoleColor.Green);
                    break;
                case Herb.HerbType.MandrakeRoot:
                case Herb.HerbType.Amanita:
                case Herb.HerbType.WolfsBane:
                    return new Colour(ConsoleColor.Red, ConsoleColor.Green);
                    break;
            }
        }
    }

    /// <summary>
    /// Herb
    /// </summary>
    [Serializable]
    public class Herb : Item
    {
        /// <summary>
        /// Supports serialization.
        /// </summary>
        public Herb() { }

        /// <summary>
        /// Creates a new instance of Herb
        /// <param name="aName">The name of the herb</param>
        /// <param name="aColour">The colour of the herb</param>
        /// </summary>
        private Herb(HerbType aType, Colour aColour)
            : base(aType.ToString(), Symbols.YEN, aColour) { }

        /// <summary>
        /// Creates a new instance of Herb
        /// <remarks>defaults colour to green.</remarks>
        /// </summary>
        /// <param name="aName">The name of the herb</param>
        public Herb(HerbType aType)
            : this(aType, aType.GetHerbColourByType()) { }

        public enum HerbType
        {
            // Various
            MotherWort,
            WolfsBane,
            ShadeLeaf,
            WhiteSage,
            MandrakeRoot,

            // floral
            Hibiscus,
            TigerLilly,

            // Mushrooms & Fungi
            DeathCap,
            Amanita,
        }
    }
}
