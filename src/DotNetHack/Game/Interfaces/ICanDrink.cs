using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Interfaces
{
    /// <summary>
    /// For anything that can drink
    /// </summary>
    public interface ICanDrink
    {
        /// <summary>
        /// Drinks a potion.
        /// </summary>
        /// <param name="aPotion">The potion being drank.</param>
        void Quaff(IPotion aPotion);
    }
}
