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
            : base("", parent.Location.X + 2, parent.Location.Y, 0, 0)
        {
            Parent = parent;

            int x = 1;

            foreach (var m in items)
            {
                Widgets.Add(new Button(m.Name, parent.Location.X + x, parent.Location.Y) 
                {
                    Visible = true,
                    OkayCallback = m.MAction,
                });

                x += m.Name.Length + 3;
            }
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            Console.ResetCursorPosition();
        }

        /// <summary>
        /// Parent
        /// </summary>
        Window Parent { get; private set; }
    }
}
