﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Affects;
using DotNetHack.Game.Events;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game
{
    /// <summary>
    /// Actor
    /// </summary>
    public abstract class Actor : ICanDrink
    {
        public Actor()
        {
            // Create a fresh list of potions.
            Potions = new List<IPotion>();

            // Health is at 100 (not percent).
            Health = 100; 
        }

        public int Health { get; set; }

        public void ApplyAffects()
        {
            foreach (Affect affect in AffectStack)
                affect.ApplyTo(this);
        }

        /// <summary>
        /// The resistances this actor has at the moment.
        /// </summary>
        public Stack<AffectResistance> ResistanceStack = new Stack<AffectResistance>();

        /// <summary>
        /// The affects that are currently applied to this actor
        /// </summary>
        public Stack<Affect> AffectStack = new Stack<Affect>();

        /// <summary>
        /// Stats for this Actor
        /// </summary>
        public Stats Stats { get; set; }

        #region Potion Related

        /// TODO: 
        /// It appears this pattern will be used quite a lot.
        /// it may be wise to make special templated collection(s)
        /// notice how IPotion is used at least twice that would be T.

        /// <summary>
        /// Any actor can carry a potion.
        /// </summary>
        public List<IPotion> Potions { get; set; }

        /// <summary>
        /// Returns <c>true</c> if this actor has one or more potions.
        /// </summary>
        public bool HasPotions { get { return Potions.Count > 0; } }

        /// <summary>
        /// Quaff the selected potion.
        /// </summary>
        /// <param name="aPotion">The <see cref="Potion"/> to drink</param>
        public void Quaff(IPotion aPotion)
        {
            aPotion.Quaff(this);
        }

        #endregion
    }
}
