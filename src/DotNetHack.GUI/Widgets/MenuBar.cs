using DotNetHack.GUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// MenuBar
    /// </summary>
    public class MenuBar : Widget
    {
        /// <summary>
        /// MenuBar
        /// </summary>
        public MenuBar(Window parent, params Menu.MenuItem[] items)
            : base("", 0, 0, 0, 0)
        {
            Parent = parent;

            MenuItems = items;
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            foreach (var s in MenuItems)
            {
                Console.ResetCursorPosition();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(s.Name);
            }
        }


        readonly Menu.MenuItem[] MenuItems;

        /// <summary>
        /// Parent
        /// </summary>
        Window Parent { get; set; }
    }
}
