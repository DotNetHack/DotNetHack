using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;
using DotNetHack.Game.Dungeon;

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
            public static void Show(string aTitle, Exception ex) { Show(aTitle, ex.Message); }

            /// <summary>
            /// YesNo Box
            /// </summary>
            public static bool YesNo(string aMessage = "")
            {
                const string YES_NO = "[Y/N]: ";

                // Draw MessageBox
                const int WIDTH_OFFSET = 2;
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Blue;

                Location2i ynBoxLocation = Graphics.ScreenCenter;
                aMessage = string.Format(" {0} ", aMessage);
                int messagePadding = 2;
                int borderWidth = 1;
                int mWidth = messagePadding + YES_NO.Length + aMessage.Length + messagePadding + borderWidth;
                int mHeight = messagePadding + messagePadding + borderWidth;

                ynBoxLocation.X -= mWidth / 2;
                ynBoxLocation.Y -= mHeight / 2;

                Display.Box(ynBoxLocation.X, ynBoxLocation.Y, mWidth, mHeight);

                ynBoxLocation.X++;

                Location2i tmpLoc = ynBoxLocation;

                string spacer = "";
                for (int ix = 0; ix < mWidth - WIDTH_OFFSET; ++ix)
                    spacer += " ";

                Console.SetCursorPosition(ynBoxLocation.X, ynBoxLocation.Y + 2);
                Console.Write(spacer);

                Console.SetCursorPosition(ynBoxLocation.X, ynBoxLocation.Y + 4);
                Console.Write(spacer);

                Console.SetCursorPosition(tmpLoc.X, tmpLoc.Y + 3);
                Console.Write(spacer);

                Console.SetCursorPosition(tmpLoc.X, tmpLoc.Y + 3);
                Console.Write(aMessage);

                Console.SetCursorPosition(tmpLoc.X + ((mWidth / 2) - 3), tmpLoc.Y + 4);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(YES_NO);

                Console.SetCursorPosition(tmpLoc.X + ((mWidth / 2) - 3) + YES_NO.Length - 1, tmpLoc.Y + 4);

                // Handle Y/N logic
                int x_loc = Console.CursorLeft;
                int y_loc = Console.CursorTop;
            redo_yes_no:
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.Y:
                        Console.ResetColor();
                        return true;
                    case ConsoleKey.N:
                        Console.ResetColor();
                        return false;
                    default:
                        Console.SetCursorPosition(x_loc, y_loc);
                        goto redo_yes_no;
                }
            }

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

                Location2i mBoxLocation = Graphics.ScreenCenter;

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

                Location2i tmpLoc = mBoxLocation;

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
            /// <summary>
            /// ShowMessage
            /// </summary>
            /// <param name="aFormatString">A composite format string.</param>
            /// <param name="aArgs">Parameters</param>
            public static void ShowMessage(string aFormatString,
                params object[] aArgs)
            {
                // determine what the display string ends up being.
                string tmpDisplayString = string.Format(aFormatString, aArgs);

                // If the size of the last string is greater than this one,
                // overwrite what was there with nothing.
                if (_lastStringSize > tmpDisplayString.Length)
                {
                    CursorToLocation(1, 0);
                    for (int c = 0; c < _lastStringSize; ++c)
                        Console.Write(' ');
                }

                // Jump back over to starting location.
                CursorToLocation(1, 0);

                // Write the display string.
                Console.Write(tmpDisplayString);

                // Capture the last string size.
                _lastStringSize = tmpDisplayString.Length;
            }

            static int _lastStringSize = 0;


            public static void ShowStatsBar(Player aPlayer)
            {
                Stats aStats = aPlayer.Stats;

                string strPlayerInfo = string.Format(
                        "{0}, {1}, (hp){2}/{3}, (Ma){4}/{5}, {6}",
                        aPlayer.Name,
                        aPlayer.Wallet,
                        aPlayer.Stats.Health,
                        aPlayer.Stats.HitPoints,
                        0,
                        aPlayer.Stats.ManaPoints,
                        GameEngine.Time
                    );
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write(strPlayerInfo);

                string strStats =
                    string.Format("Str:{0} Per:{1} End:{2} Chr:{3} Int:{4} Agi:{5} Luck:{6}",
                    aStats.Strength, aStats.Perception, aStats.Endurance, aStats.Charisma,
                    aStats.Intelligence, aStats.Agility, aStats.Luck, aStats.Level);
                
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
                int w = aMenu.Title.Length; int h = 0;
                int max_name_length = 0;
                foreach (var action in aMenu.MenuActions)
                    if (action.Name.Length > max_name_length)
                        max_name_length = action.Name.Length;
                w = max_name_length + 7;
                h = aMenu.MenuActions.Count() + 2;
                Box(aMenu.Title, x, y, w, h);
                ++y; ++x; int c = 0;  // top right
                Console.SetCursorPosition(x, y);
                foreach (var action in aMenu.MenuActions)
                {
                    string tmpPad = string.Empty;
                    for (int padIndex = 0; padIndex < Math.Abs(action.Name.Length - w) - 7; ++padIndex)
                        tmpPad += " ";
                    Console.Write("({0}). {1}", c, action.Name + tmpPad);
                    Console.SetCursorPosition(x, y++);
                    ++c;
                }
                string tmpPad1 = string.Empty;
                for (int padIndex = 2; padIndex < w; ++padIndex)
                    tmpPad1 += " ";
                Console.Write(tmpPad1);
                Console.SetCursorPosition(x, y++);
                Console.Write(tmpPad1);


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
            /// DisplayRefresh
            /// </summary>
            /// <param name="aDungeon">The dungeon used for determining data to clear</param>
            /// <param name="aLocation">The location for determing the dungeon level to use in refreshing.</param>
            public static void Refresh(Dungeon3 aDungeon, Location3i aLocation)
            {
                if (PostRedisplay != null)
                    PostRedisplay(aDungeon, aLocation);
            }

            /// <summary>
            /// PostRedisplay, should only be wired up to clear one area at a time. A multicast del
            /// is not used.
            /// </summary>
            static Func<Dungeon3, Location3i, DisplayRegion> PostRedisplay = null;

            /// <summary>
            /// Box
            /// </summary>
            /// <param name="x">The X-Coordinate</param>
            /// <param name="y">The Y-Coordinate</param>
            /// <param name="w">The Width.</param>
            /// <param name="h">The Height.</param>
            public static void Box(int x, int y, int w, int h)
            {
                // wire up the post redisplay callback.
                PostRedisplay = delegate(Dungeon3 dungeon, Location3i l)
                {
                    if (dungeon == null || l == null)
                        throw new ApplicationException("PostRedisplay Failed!");
                    var displayRegion = new DisplayRegion(x, y, x + w, y + h);
                    dungeon.DungeonRenderer.RefreshBufferedRegion(l, displayRegion);
                    return displayRegion;
                };

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
