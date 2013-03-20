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
                var tmpMenuButton = new Button(parent, m.Name, parent.Location.X + x, parent.Location.Y)
                {
                    Visible = true,
                };

                tmpMenuButton.OkayEvent += (object sender, Events.GUIEventArgs e) => 
                {
                    m.MAction();
                };

                Widgets.Add(tmpMenuButton);

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
        Window Parent { get; set; }
    }
}
