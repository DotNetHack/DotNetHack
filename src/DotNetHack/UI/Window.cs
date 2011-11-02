using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;

namespace DotNetHack.UI
{
    /// <summary>
    /// Window
    /// </summary>
    public class Window : Widget
    {
        protected event EventHandler<KeyPressEventArgs> OnPageUp;
        protected event EventHandler<KeyPressEventArgs> OnPageDown;
        protected event EventHandler<KeyPressEventArgs> OnEsc;

        /// <summary>
        /// Window
        /// </summary>
        /// <param name="aWindowTitle">The title for the window</param>
        public Window(string aWindowTitle)
            : this(aWindowTitle, 0, 0, Graphics.ScreenWidth, Graphics.ScreenHeight) { }

        /// <summary>
        /// Window
        /// </summary>
        /// <param name="aWindowTitle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="aWindowWidth"></param>
        /// <param name="aWindowHeight"></param>
        public Window(string aWindowTitle, int x, int y,
            int aWindowWidth, int aWindowHeight)
            : base(x, y, aWindowWidth, aWindowHeight)
        {
            if (aWindowHeight <= 0 || aWindowWidth <= 0)
                throw new ArgumentException(
                    "Window size and coorinates must be greater than zero.");

            WindowTitle = aWindowTitle;
            // WindowRegion = new DisplayRegion(x, y,
            // x + aWindowWidth, y + (aWindowHeight - 1));
        }

        /// <summary>
        /// WindowRegion
        /// </summary>
        DisplayRegion WindowRegion { get { return base.DisplayRegion; } }

        /// <summary>
        /// WindowTitle
        /// </summary>
        public string WindowTitle { get; set; }

        /// <summary>
        /// WindowWidth
        /// </summary>
        public int WindowWidth
        {
            get { return Width; }
        }

        /// <summary>
        /// WindowHeight
        /// </summary>
        public int WindowHeight
        {
            get { return Height; }
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();
            UI.Graphics.Clear(WindowRegion);
            UI.Graphics.Display.Box(WindowRegion);
            Console.SetCursorPosition(WindowRegion.P1.X + 3, WindowRegion.P1.Y);
            Console.Write(string.Format("{0} {1} {2}",
                Symbols.W_DBL_V_RIGHT_JUNC, WindowTitle, Symbols.W_DBL_V_LEFT_JUNC));
        }
    }
}
