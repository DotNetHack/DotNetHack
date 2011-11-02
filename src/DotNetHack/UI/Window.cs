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
        /// <summary>
        /// Occurs when the user scrolls up.
        /// </summary>
        protected event EventHandler<KeyPressEventArgs> OnScrollUp;

        /// <summary>
        /// Occurs when the user scrolls down.
        /// </summary>
        protected event EventHandler<KeyPressEventArgs> OnScrollDown;

        /// <summary>
        /// Occurs when the user preses escape.
        /// </summary>
        protected event EventHandler<KeyPressEventArgs> OnEsc;

        /// <summary>
        /// Occurs when the user presses enter.
        /// </summary>
        protected event EventHandler<KeyPressEventArgs> OnEnter;

        /// <summary>
        /// Window
        /// </summary>
        /// <param name="aWindowTitle">The title for the window</param>
        public Window(string aWindowTitle)
            : this(aWindowTitle, 0, 0, Graphics.ScreenWidth, Graphics.ScreenHeight - 1) { }

        /// <summary>
        /// Window
        /// </summary>
        /// <param name="aWindowTitle">The title of the window to display</param>
        /// <param name="x">The x-coordinate for the window.</param>
        /// <param name="y">The y-coordinate for the window</param>
        /// <param name="aWindowWidth">The width of the window</param>
        /// <param name="aWindowHeight">The height of the window.</param>
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

        /// <summary>
        /// Executes control-input for the widget. Expect events to pipe back the 
        /// key-press details.
        /// </summary>
        public void Exec()
        {
            ConsoleKeyInfo tmpConsoleKey;
            switch (Input.Filter(
                k => k.Key == ConsoleKey.PageDown ||
                    k.Key == ConsoleKey.PageUp ||
                    k.Key == ConsoleKey.UpArrow ||
                    k.Key == ConsoleKey.DownArrow ||
                    k.Key == ConsoleKey.Enter ||
                    k.Key == ConsoleKey.Escape, out tmpConsoleKey).Key)
            {
                case ConsoleKey.PageUp:
                case ConsoleKey.UpArrow:
                    if (OnScrollDown != null)
                        OnScrollDown(this, new KeyPressEventArgs(tmpConsoleKey));
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.PageDown:
                    if (OnScrollUp != null)
                        OnScrollUp(this, new KeyPressEventArgs(tmpConsoleKey));
                    break;
                case ConsoleKey.Escape:
                    if (OnEsc != null)
                        OnEsc(this, new KeyPressEventArgs(tmpConsoleKey));
                    break;
                case ConsoleKey.Enter:
                    if (OnEnter != null)
                        OnEnter(this, new KeyPressEventArgs(tmpConsoleKey));
                    break;
            }
        }
    }
}
