using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// GUI
    /// </summary>
    public class GUI
    {
        /// <summary>
        /// done
        /// </summary>
        volatile bool done = false;

        /// <summary>
        /// Initialize
        /// </summary>
        public void Initialize(Action<ConsoleKey> keyboardCallback)
        {
            KeyboardCallback = keyboardCallback;
        }

        /// <summary>
        /// Run
        /// </summary>
        public void Run(Widget root)
        {
            Console.Title = root.Text;

            root.InitializeWidget();
            root.Show();

            while (!done)
            {
                // critical section
                lock (syncRoot)
                {
                    foreach (var w in root.Widgets.Where(v => v.Visible))
                        DrawWidget(w);
                   
                    Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="w"></param>
        public static void DrawWidget(Widget w)
        {
            IPoint screenLocation = w.Location;

            w.Show();

            for (int y = 0; y < w.Console.Height; ++y)
            {
                for (int x = 0; x < w.Console.Width; ++x)
                {
                    Glyph g = w.Console[x, y];
                    Console.SetCursorPosition(screenLocation.X + x, screenLocation.Y + y);
                    Console.ForegroundColor = g.FG;
                    Console.BackgroundColor = g.BG;
                    Console.Write(g.G);
                }
            }
            
            //PushCursorState();
            //w.Show();
            //PopAndSetCursorState();
        }

        /// <summary>
        /// KeyboardCallback
        /// </summary>
        public event Action<ConsoleKey> KeyboardCallback;

        /// <summary>
        /// Screen
        /// </summary>
        public DisplayBuffer Screen { get; private set; }

        /// <summary>
        /// ScreenCenter
        /// <value>The location of the center of the screen.</value>
        /// </summary>
        public static Point ScreenCenter
        {
            get
            {
                return new Point(Console.WindowWidth / 2,
                    Console.WindowHeight / 2);
            }
        }

        #region Cursor State Stack

        /// <summary>
        /// Push the cursor state
        /// </summary>
        public static void PushCursorState()
        {
            CursorStateStack.Push(CurrentCursorState);
        }

        /// <summary>
        /// Pops the cursor state
        /// </summary>
        public static void PopAndSetCursorState()
        {
            if (CursorStateStack.Count <= 0)
                return;
            CursorStateStack.Pop().Set();
        }

        /// <summary>
        /// CursorStateStack
        /// </summary>
        static Stack<Utility.CursorState> CursorStateStack { get; set; }

        /// <summary>
        /// Returns the current cursor state as known by the system Console object.
        /// </summary>
        public static Utility.CursorState CurrentCursorState
        {
            get
            {
                return new Utility.CursorState(Console.CursorLeft, Console.CursorTop,
                    Console.ForegroundColor, Console.BackgroundColor);
            }
        }

        #endregion

        #region Singleton

        /// <summary>
        /// instance
        /// </summary>
        private static volatile GUI instance;

        /// <summary>
        /// syncRoot
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// GUI Constructor
        /// </summary>
        private GUI() { }

        /// <summary>
        /// Instance
        /// </summary>
        public static GUI Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new GUI();
                    }
                }

                return instance;
            }
        }

        #endregion
    }
}
