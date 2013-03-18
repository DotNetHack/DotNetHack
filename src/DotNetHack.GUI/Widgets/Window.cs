using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// Window
    /// </summary>
    [DebuggerDisplay("{Title}")]
    public class Window : Widget
    {
        /// <summary>
        /// Window
        /// </summary>
        /// <param name="text"></param>
        public Window(string text, Size size)
            : base(text, 1, 1, size.Width, size.Height)
        {
            KeyboardEvent += Window_KeyboardEvent;
        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Window_KeyboardEvent(object sender, Events.GUIKeyboardEventArgs e)
        {
            switch (e.ConsoleKeyInfo.Key)
            {
                case ConsoleKey.Escape:
                    Dispose();            
                    break;
            }
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            Box(Title, 0, 0, Width, Height);
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get { return Text; } set { Text = value; } }
    }
}
