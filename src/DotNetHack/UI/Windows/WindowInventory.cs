using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;

namespace DotNetHack.UI.Windows
{
    /// <summary>
    /// Inventory Window
    /// </summary>
    public class WindowInventory : Window
    {
        /// <summary>
        /// Creates a new inventory window.
        /// </summary>
        /// <param name="aActor">The actor</param>
        public WindowInventory(Actor aActor)
            : base("Inventory") 
        {
            InventoryActor = aActor; 
        }

        /// <summary>
        /// Shows the inventory window.
        /// </summary>
        public override void Show()
        {
            // base show called first.
            base.Show();


        }

        /// <summary>
        /// The actor whos inventory gets shown.
        /// </summary>
        Actor InventoryActor { get; set; }
    }
}
