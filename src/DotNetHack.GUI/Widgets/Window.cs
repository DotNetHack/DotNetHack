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
        /// 
        /// </summary>
        /// <param name="text"></param>
        public Window(string text)
            : base(text, 1, 1, 10, 10)
        {
        }
    }
}
