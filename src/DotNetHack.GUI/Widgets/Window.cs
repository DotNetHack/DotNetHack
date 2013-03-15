using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// Window
    /// </summary>
    public class Window : Widget
    {
        /// <summary>
        /// Window
        /// </summary>
        /// <param name="text"></param>
        public Window(string text)
            : base(text, 1, 1, 30 , 10)
        {
        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            Box(0, 0, Width, Height);
        }
    }
}
