using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            while (!done)
            {
                // critical section
                lock (syncRoot)
                {
                    Screen = parent.ActiveWidget.Buffer;

                    for (int x = 0; x < Screen.Width; ++x)
                    {
                        for (int y = 0; y < Screen.Height; ++y)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = Screen[x, y].FG;
                            Console.ForegroundColor = Screen[x, y].BG;
                            Console.Write(Screen[x, y].G);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// KeyboardCallback
        /// </summary>
        public event Action<ConsoleKey> KeyboardCallback;

        /// <summary>
        /// Screen
        /// </summary>
        public DisplayBuffer Screen { get; private set; }

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
