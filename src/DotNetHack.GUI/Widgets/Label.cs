using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// Label
    /// </summary>
    public class Label : Widget
    {
        /// <summary>
        /// Label
        /// </summary>
        /// <param name="text"></param>
        public Label(Widget parent, string text)
            : base(text)
        {

        }

        public override void Show()
        {
            base.Show();

            Console.Write(Text);
        }
    }
}
