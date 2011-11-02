using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.UI
{
    /// <summary>
    /// CursorState,
    ///     Basic cursor information.
    /// </summary>
    public class CursorState
    {
        /// <summary>
        /// Static constructor; mainly for the CursorStateStack.
        /// </summary>
        static CursorState() { CursorStateStack = new Stack<CursorState>(); }

        /// <summary>
        /// Create a new CursorState object
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordindate</param>
        /// <param name="fg">foreground colour</param>
        /// <param name="bg">background colour</param>
        public CursorState(int x, int y, ConsoleColor fg, ConsoleColor bg)
        {
            X = x; Y = y; FG = fg; BG = bg;
        }

        /// <summary>
        /// the x-coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// the y-coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// the background colour
        /// </summary>
        public ConsoleColor BG { get; set; }

        /// <summary>
        /// The foreground colour
        /// </summary>
        public ConsoleColor FG { get; set; }

        /// <summary>
        /// Returns the current cursor state as known by the system Console object.
        /// </summary>
        public static CursorState CurrentCursorState
        {
            get
            {
                return new CursorState(Console.CursorLeft, Console.CursorTop,
                    Console.ForegroundColor, Console.BackgroundColor);
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
        static Stack<CursorState> CursorStateStack { get; set; }

        #endregion
    }
}
