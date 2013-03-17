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
        /// Run
        /// </summary>
        public void Run(Widget root)
        {
            Console.Title = root.Text;

            StartKeyboardInputThread();

            root.InitializeWidget();
            root.Show();

            DrawWidget(root);

            while (!done)
            {
                PushCursorState();

                // critical section
                lock (syncRoot)
                {
                    Widget.Traverse(DrawWidget, root, w => w.Console.Invalidated && w.Visible);
                }

                PopAndSetCursorState();
            }
        }

        /// <summary>
        /// consoleSize
        /// </summary>
        readonly static Size consoleSize = new Size(Console.WindowWidth, Console.WindowHeight);

        /// <summary>
        /// StartKeyboardInputThread
        /// </summary>
        private void StartKeyboardInputThread()
        {
            ThreadPool.QueueUserWorkItem((object state) =>
            {
                while (!done)
                {
                    if (Console.KeyAvailable)
                    {                      
                        KeyboardCallback(Console.ReadKey(true));
                    }

                    Thread.Sleep(10);
                }
            });
        }

        /// <summary>
        /// DrawWidget
        /// </summary>
        /// <param name="w">the widget to draw</param>
        public static void DrawWidget(Widget w)
        {
            IPoint screenLocation = w.Location;

            w.Show();

            for (int y = 0; y <= w.Console.Height; ++y)
            {
                for (int x = 0; x <= w.Console.Width; ++x)
                {
                    Glyph g = w.Console[x, y];

                    if (Buffer[screenLocation.X + x, screenLocation.Y + y] != g)
                    {
                        Console.SetCursorPosition(screenLocation.X + x, screenLocation.Y + y);
                        Console.ForegroundColor = g.FG;
                        Console.BackgroundColor = g.BG;
                        Console.Write(g.G);

                        Buffer[x, y] = g;
                    }
                }
            }

            w.Console.Validate();
        }

        /// <summary>
        /// DisplayBuffer
        /// </summary>
        static GUI()
        {
            CursorStateStack = new Stack<Utility.CursorState>();
            Buffer = new DisplayBuffer(consoleSize);
        }

        /// <summary>
        /// Buffer
        /// </summary>
        internal static DisplayBuffer Buffer { get; set; }

        /// <summary>
        /// KeyboardCallback
        /// </summary>
        public event Action<ConsoleKeyInfo> KeyboardCallback;

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

        /// <summary>
        /// ScreenWidth
        /// </summary>
        public static int ScreenWidth { get { return Console.WindowWidth; } }

        /// <summary>
        /// ScreenHeight
        /// </summary>
        public static int ScreenHeight { get { return Console.WindowHeight; } }

        /// <summary>
        /// ScreenSize
        /// </summary>
        public static Size ScreenSize { get { return consoleSize; } }

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
