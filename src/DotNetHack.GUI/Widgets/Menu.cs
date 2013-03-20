using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// Menu
    /// </summary>
    public class Menu : Widget
    {
        /// <summary>
        /// Menu
        /// </summary>
        public Menu(Widget parent, params MenuItem[] items)
            : base("Menu Title", 0, 0, 0, 0)
        {
            MenuItems = new List<MenuItem>(items.Length);
            MenuItems.AddRange(items);
            Size = new Size(MenuItems.Max(f => f.Name.Length) + 2, MenuItems.Count + 3);
        }

        /// <summary>
        /// The menu's parent
        /// </summary>
        public Widget Parent { get; protected set; }

        /// <summary>
        /// MenuItems
        /// </summary>
        public List<MenuItem> MenuItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        public void Show(Point p)
        {
            System.Console.SetCursorPosition(1, 1);
            foreach(var m1 in MenuItems)
            {
                System.Console.WriteLine(m1.Name);
            }
            
        }

        /// <summary>
        /// Show
        /// </summary>
        /// <param name="subMenu"></param>
        public void Show(Menu subMenu)
        {
            Clear();

            for (int index = 0; index < MenuItems.Count; ++index)
            {
                Console.SetCursorPosition(1, index);
                Console.Write("> " + MenuItems[index].Name);
            }
        }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            
        }

        /// <summary>
        /// MenuItem
        /// </summary>
        public struct MenuItem
        {
            /// <summary>
            /// MenuItem Delegate
            /// </summary>
            /// <param name="argv"></param>
            public delegate void MActionDelegate(params object[] argv);

            /// <summary>
            /// Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// MAction
            /// </summary>
            public Action MAction { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Func<ConsoleKeyInfo, bool> MenuActionFilter { get; set; }
        }
    }

    /*
    /// <summary>
    /// Menu
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Menu
        /// </summary>
        /// <param name="aTile"></param>
        /// <param name="aActions"></param>
        public Menu(string aTile, MenuItem[] aActions)
        {
            // set menu actions, set title.
            MenuActions = aActions; Title = aTile;

            // init menu colour
          //  MenuColour = aColour ?? Colour.Standard;

            // selected colour is passed colour but negated.
           // SelectedColour = !MenuColour;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// MenuColour
        /// </summary>
        public IColorScheme MenuColour { get; set; }

        /// <summary>
        /// The item selected colour.
        /// </summary>
        public IColorScheme SelectedColour { get; set; }

        /// <summary>
        /// Show this menu at the passed location
        /// </summary>
        /// <param name="x">x-coordinate for menu</param>
        /// <param name="y">y-coordinate for menu</param>
        public void Show(int x, int y)
        {
            // remember location, remember we've shown the menu.
            MenuShown = true;
            MenuLocation = new Point(x, y);

            MenuColour.ForegroundColor = ConsoleColor.White;
            MenuColour.BackgroundColor = ConsoleColor.Blue;

            #region init selector location & selector colour

            // WARNING: Show() is called repeatedly, don't init this value
            // more than one time, otherwise SelectorLocation is over-written.
            if (SelectorLocation == null)
            {
                SelectorLocation = new Point(MenuLocation.X, MenuLocation.Y);
                SelectorLocation.X++;
                SelectorLocation.Y++;
            }

            #endregion

            // display.box knows how to draw a menu.
            //Graphics.Display.Box(this, x, y);
        }

        /// <summary>
        /// Show this menu at the passed location
        /// </summary>
        /// <param name="l">The <see cref="Location2i"/> to shown menu @</param>
        public void Show(Point l) { Show(l.X, l.Y); }

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
                return;

            do
            {
                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.Enter:
                        // wire into the MenuItem array via selector offset and
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
            foreach (MenuItem mAction in MenuActions)
                if (mAction.MenuActionFilter(input))
                    mAction.MAction(argv);
            return;
        }


        /// <summary>
        /// 
        /// </summary>
        public MenuItem[] MenuActions { get; set; }

        /// <summary>
        /// MActionDelegate
        /// </summary>
        /// <param name="argv"></param>
        public delegate void MActionDelegate(object argv);

        /// <summary>
        /// MenuLocation
        /// </summary>
        public Point MenuLocation { get; private set; }

        /// <summary>
        /// SelectorLocation
        /// </summary>
        public Point SelectorLocation { get; private set; }

        /// <summary>
        /// Set to true when the menu is shown. Can be used to determine if
        /// it's already been drawn.
        /// </summary>
        private bool MenuShown = false;

        /// <summary>
        /// MenuItem
        /// </summary>
        public struct MenuItem
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
     * 
     * }*/
}
