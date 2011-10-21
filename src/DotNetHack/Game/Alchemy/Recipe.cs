using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game
{
    /// <summary>
    /// A recipe, is a collection of ingredients that when <c>mixxed</c> and stored
    /// becomes a potion.
    /// </summary>
    public class Recipe
    {
        public Recipe(string aName, Ingredient[] aIn)
        {
            Ingredients = new List<IIngredient>();
            foreach (var ix in aIn) { }
                // Ingredients.Add(ix);
        }

        /// <summary>
        /// The name of this recipe
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Yields
        /// </summary>
        public IPotion Potion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<IIngredient> Ingredients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iii"></param>
        /// <returns></returns>
        public bool HasRequiredIngredients(List<IIngredient> iii)
        {
            foreach (var ix in iii)
                if (!Ingredients.Contains(ix))
                    return false;
            return true;
        }
    }
}
