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
            : base("", parent.Location.X + 1, parent.Location.Y + 1, parent.Width - 2, 1)
        {
            Parent = parent;

            int x = 1;

            foreach (var s in items)
            {
                Widgets.Add(new Button(s.Name, x, 0) 
                {
                    // wire up okay callback to menu action
                    OkayCallback = s.MAction
                });

                // offset placement of future buttons if any
                x += s.Name.Length + 3;
            }
        }

        /// <summary>
        /// Parent
        /// </summary>
        Window Parent { get; set; }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();
        }
    }
}
