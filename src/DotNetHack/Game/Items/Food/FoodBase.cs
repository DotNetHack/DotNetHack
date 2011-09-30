using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Food
{
    /// <summary>
    /// FoodBase
    /// </summary>
    public abstract class FoodBase : Item, IFood
    {
        /// <summary>
        /// FoodBase
        /// </summary>
        public FoodBase(string aName, int aCalories, bool aTainted = false) 
            : base(aName, '%', Colour.DarkRed)
        {
            Calories = aCalories;
            Tainted = aTainted;
        }

        /// <summary>
        /// The number of calories in this food.
        /// </summary>
        public int Calories { get; set; }

        /// <summary>
        /// Is this food tainted?
        /// </summary>
        public bool Tainted { get; set; }

        /// <summary>
        /// Eat this food.
        /// </summary>
        public void Eat() { }
    }
}
