using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;

namespace DotNetHack.UI
{
    /// <summary>
    /// Graphics
    /// </summary>
    public partial class Graphics
    {
        /// <summary>
        /// MessageBox
        /// </summary>
        public static class MessageBox
        {
            /// <summary>
            /// Show
            /// </summary>
            /// <param name="aTitle">The title of the message box</param>
            /// <param name="aMessage">The message</param>
            public static void Show(string aTitle, string aMessage)
            {
                const int WIDTH_OFFSET = 2;
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Blue;

                // Intentionally pad message
                aMessage = string.Format(" {0} ", aMessage);

                int mBoxWidth = WIDTH_OFFSET; int mBoxHeight = 5;
                int mTitleLength = aTitle.Length;
                int mMessageLength = aMessage.Length;

                Location mBoxLocation = Graphics.ScreenCenter;

                if (aTitle.Length > mMessageLength)
                    mBoxWidth += mTitleLength;
                else mBoxWidth += mMessageLength;

                mBoxLocation.X -= (mBoxWidth / 2);
                mBoxLocation.Y -= (mBoxHeight / 2);

                string spacer = "";
                for (int ix = 0; ix < mBoxWidth - WIDTH_OFFSET; ++ix)
                    spacer += " ";

                Display.Box(aTitle, mBoxLocation.X, mBoxLocation.Y, mBoxWidth, mBoxHeight);

                mBoxLocation.X++;

                Location tmpLoc = mBoxLocation;

                Console.SetCursorPosition(mBoxLocation.X, mBoxLocation.Y + 2);
                Console.Write(spacer);

                Console.SetCursorPosition(mBoxLocation.X, mBoxLocation.Y + 4);
                Console.Write(spacer);

                Console.SetCursorPosition(tmpLoc.X, tmpLoc.Y + 3);
                Console.Write(aMessage);

                Console.SetCursorPosition(tmpLoc.X + ((mBoxWidth / 2) - 3), tmpLoc.Y + 4);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("["); Console.Write("Ok"); Console.Write("]");

                Console.ReadKey();

                Console.ResetColor();
            }
        }

        /// <summary>
        /// Display
        /// </summary>
        public static class Display
        {
            public static void ShowStatsBar(Stats aStats)
            {
                string strStats =
                    string.Format("Str:{0} Per:{1} End:{2} Chr:{3} Int:{4} Agi:{5} Luck:{6}",
                    aStats.Strength, aStats.Perception, aStats.Endurance, aStats.Charisma,
                    aStats.Intelligence, aStats.Agility, aStats.Luck);
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write(strStats);
            }

            /// <summary>
            /// Box
            /// </summary>
            /// <param name="aMenu">The menu</param>
            /// <param name="x">X-Coord</param>
            /// <param name="y">Y-Coord</param>
            public static void Box(Menu aMenu, int x, int y)
            {
                int w = 0; int h = 0;
                int max_name_length = 0;
                foreach (var action in aMenu.MenuActions)
                    if (action.Name.Length > max_name_length)
                        max_name_length = action.Name.Length;
                w = max_name_length + 3;
                h = aMenu.MenuActions.Count() + 2;
                Box(aMenu.Title, x, y, w, h);
                ++y; ++x; int c = 0;  // top right
                Console.SetCursorPosition(x, y);
                foreach (var action in aMenu.MenuActions)
                {
                    Console.Write("({0}). {1}", c, action.Name);
                    Console.SetCursorPosition(x, y++);
                    ++c;
                }
            }

            /// <summary>
            /// Box
            /// </summary>
            /// <param name="aTile">The Title</param>
            /// <param name="x">The X-Coordinate</param>
            /// <param name="y">The Y-Coordinate</param>
            /// <param name="w">The Width.</param>
            /// <param name="h">The Height.</param>
            /// <param name="ralign">Right Align?</param>
            public static void Box(string aTile, int x, int y, int w, int h, bool ralign)
            {
                if (!ralign)
                    Box(aTile, x, y, w, h);
                else Box(aTile, Console.WindowWidth - (((aTile.Length > w ? aTile.Length + 2 : w)) + x), y, w, h);
            }

            /// <summary>
            /// Box
            /// </summary>
            /// <param name="aTitle">The Title</param>
            /// <param name="x">The X-Coordinate</param>
            /// <param name="y">The Y-Coordinate</param>
            /// <param name="w">The Width.</param>
            /// <param name="h">The Height.</param>
            public static void Box(string aTitle, int x, int y, int w, int h)
            {
                int l = aTitle.Length;
                if (l < w)
                {
                    Box(x, y, w, h);
                    Console.SetCursorPosition(x + ((w / 2) - (l / 2)), y);
                    Console.Write(aTitle);
                }
                else Box(aTitle, x, y, l + 2, h);
            }

            /// <summary>
            /// Box
            /// </summary>
            /// <param name="x">The X-Coordinate</param>
            /// <param name="y">The Y-Coordinate</param>
            /// <param name="w">The Width.</param>
            /// <param name="h">The Height.</param>
            public static void Box(int x, int y, int w, int h)
            {
                if (w <= 2)
                    throw new ArgumentException(
                        string.Format("Display box width must be greater than 2. Was {0}.", w));

                for (int c = 0; c < w; ++c)
                {
                    Console.SetCursorPosition(x + c, y);
                    if (c == 0)
                        Console.Write('╔');
                    else if (c == w - 1)
                        Console.Write('╗');
                    else
                        Console.Write('═');
                }
                for (int c = 1; c < h; ++c)
                {
                    Console.SetCursorPosition(x, y + c);
                    Console.Write('║');
                    Console.SetCursorPosition(x + w - 1, y + c);
                    Console.Write('║');
                }
                for (int c = 0; c < w; ++c)
                {
                    Console.SetCursorPosition(x + c, y + h);
                    if (c == 0)
                        Console.Write('╚');
                    else if (c == w - 1)
                        Console.Write('╝');
                    else
                        Console.Write('═');
                }

                string spacer = string.Empty;
                for (int c = 0; c < w - 2; ++c)
                    spacer += " ";

                for (int c = 1; c < h; ++c)
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    Console.Write(spacer);
                }
            }
        }
    }
}
