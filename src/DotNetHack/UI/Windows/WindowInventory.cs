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

            bool done = false;
            int n = 0x00;           // index,offset to the first n+1 inventory items
            while (!done)
            {
                // WARNING: Something like this only applies to fullscreen windows
                Console.SetCursorPosition(1, 1);

                int index = 0x00;
                foreach (var iItem in InventoryActor.Inventory)
                {
                    Console.SetCursorPosition(1, 1 + index + n);
                    Console.Write("\t{0})\t{1}", index + 1 + n, iItem.Name);
                    index++;
                }

                ConsoleKeyInfo input;
                Input.Filter(i =>
                    i.Key == ConsoleKey.PageDown ||
                    i.Key == ConsoleKey.PageUp ||
                    i.Key == ConsoleKey.Escape, out input);

                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                    case ConsoleKey.PageDown:
                        break;
                    case ConsoleKey.PageUp:
                        break;
                }
            }
        }

        /// <summary>
        /// The actor whos inventory gets shown.
        /// </summary>
        Actor InventoryActor { get; set; }
    }
}
