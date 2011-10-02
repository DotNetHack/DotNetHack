using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aTile"></param>
        /// <param name="aActions"></param>
        public Menu(string aTile, MenuAction[] aActions, Colour aColour = null)
        {
            // set menu actions, set title.
            MenuActions = aActions; Title = aTile;

            // init menu colour
            MenuColour = aColour ?? Colour.Standard;

            // selected colour is passed colour but negated.
            SelectedColour = !MenuColour;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// MenuColour
        /// </summary>
        public Colour MenuColour { get; set; }

        /// <summary>
        /// The item selected colour.
        /// </summary>
        public Colour SelectedColour { get; set; }

        /// <summary>
        /// Show this menu at the passed location
        /// </summary>
        /// <param name="x">x-coordinate for menu</param>
        /// <param name="y">y-coordinate for menu</param>
        public void Show(int x, int y)
        {
            // remember location, remember we've shown the menu.
            MenuShown = true;
            MenuLocation = new Location2i(x, y);

            MenuColour.FG = ConsoleColor.White;
            MenuColour.BG = ConsoleColor.Blue;

            MenuColour.Set();

            #region init selector location & selector colour

            // WARNING: Show() is called repeatedly, don't init this value
            // more than one time, otherwise SelectorLocation is over-written.
            if (SelectorLocation == null)
            {
                SelectorLocation = new Location2i(MenuLocation);
                SelectorLocation.X++;
                SelectorLocation.Y++;
            }

            #endregion

            // display.box knows how to draw a menu.
            Graphics.Display.Box(this, x, y);
        }

        /// <summary>
        /// Show this menu at the passed location
        /// </summary>
        /// <param name="l">The <see cref="Location2i"/> to shown menu @</param>
        public void Show(Location2i l) { Show(l.X, l.Y); }

        /// <summary>
        /// Exec
        /// </summary>
        /// <param name="argv"></param>
        public virtual void Exec(object argv)
        {
            int selector = 0x00;
            bool done = false;

            // if the menu has not already been shown, calling exec makes no sense.
            if (!MenuShown)
                throw new DNHackException("Cannot call Menu.Exec() before Menu.Show().");

            do
            {
                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.Enter:
                        // wire into the MenuAction array via selector offset and
                        // execute the associated action.
                        MenuActions[selector].MAction(argv);    
                            return;

                    // other keys don't do anything.
                    default: break;

                    // "escape" will exit the menu.
                    case ConsoleKey.Escape:
                        done = true;
                        break;

                    // All keys associated with moving "up".
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.PageUp:
                        selector++;
                        break;

                    // All keys associated with moving "down".
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.PageDown:
                        selector--;
                        break;
                }

                // keep selector within array bounds & non-negative.
                selector %= MenuActions.Length;
                if (selector < 0)
                    selector = MenuActions.Length - 1;  // loop around.

                // set menu selector location.
                SelectorLocation.Y = selector + MenuLocation.Y + 1;

                // re-draw the menu; this will update MenuSelection display too.
                Show(MenuLocation);

            } while (!done);
        }

        /*
        public virtual void Exec(object argv)
        {
            var input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
                return;
            foreach (MenuAction mAction in MenuActions)
                if (mAction.MenuActionFilter(input))
                    mAction.MAction(argv);
            return;
        }*/


        /// <summary>
        /// 
        /// </summary>
        public MenuAction[] MenuActions { get; set; }

        /// <summary>
        /// MActionDelegate
        /// </summary>
        /// <param name="argv"></param>
        public delegate void MActionDelegate(object argv);

        /// <summary>
        /// MenuLocation
        /// </summary>
        public Location2i MenuLocation { get; private set; }

        /// <summary>
        /// SelectorLocation
        /// </summary>
        public Location2i SelectorLocation { get; private set; }

        /// <summary>
        /// Set to true when the menu is shown. Can be used to determine if
        /// it's already been drawn.
        /// </summary>
        private bool MenuShown = false;

        /// <summary>
        /// MenuAction
        /// </summary>
        public struct MenuAction
        {
            /// <summary>
            /// Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// ConsoleKey
            /// </summary>
            public string ConsoleKey { get; set; }

            /// <summary>
            /// MAction
            /// </summary>
            public MActionDelegate MAction { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Func<ConsoleKeyInfo, bool> MenuActionFilter { get; set; }
        }
    }
}
