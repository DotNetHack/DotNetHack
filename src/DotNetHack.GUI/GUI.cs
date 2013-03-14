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
        public void Run(Widget parent)
        {
            Console.Title = parent.Text;

            parent.InitializeWidget();
            parent.Show();

            while (!done)
            {

                // critical section
                lock (syncRoot)
                {
                    foreach (var w in parent.Widgets)
                    {
                        w.Show();

                        for (int x = w.Location.X; x <= w.Width; ++x)
                        {
                            for (int y = w.Location.Y; y <= w.Height; ++y)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.ForegroundColor = w.Buffer[x, y].FG;
                                Console.ForegroundColor = w.Buffer[x, y].BG;
                                Console.Write(w.Buffer[x, y].G);
                            }
                        }
                    }

                    Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="w"></param>
        public void DrawWidget(Widget w)
        {
            PushCursorState();

            w.Show();

            PopAndSetCursorState();
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
