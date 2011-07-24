using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Events;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items;

namespace DotNetHack.Game
{
    /// <summary>
    /// Actor
    /// </summary>
    public abstract class Actor : ICanDrink
    {
        /// <summary>
        /// Create a new instance of Actor.
        /// </summary>
        public Actor()
        {
            // Create inventory collection.
            Inventory = new ItemCollection();

            // Health is at 100 (not percent).
            Health = 100;
        }

        public int Health { get; set; }

        public void ApplyAffects()
        {
        }


        /// <summary>
        /// Stats for this Actor
        /// </summary>
        public Stats Stats { get; set; }

        /// <summary>
        /// All actors have inventory.
        /// </summary>
        public ItemCollection Inventory { get; set; }


        #region Potion Related

        /// TODO: 
        /// It appears this pattern will be used quite a lot.
        /// it may be wise to make special templated collection(s)
        /// notice how IPotion is used at least twice that would be T.

        /// <summary>
        /// Quaff the selected potion.
        /// </summary>
        /// <param name="aPotion">The <see cref="Potion"/> to drink</param>
        public void Quaff(IPotion aPotion) { aPotion.Quaff(this); }

        #endregion
    }
}
