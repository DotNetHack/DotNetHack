using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.UI
{
    public class Menu
    {
        public Menu(string aTile, MenuAction[] aActions) 
        {
            MenuActions = aActions; Title = aTile; 
        }

        public string Title { get; set; }
        public void Show(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Graphics.Display.Box(this, x, y);
        }

        public virtual void Exec(object argv)
        {
            var input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape)
                return;
            foreach (MenuAction mAction in MenuActions)
                if (mAction.MenuActionFilter(input))
                    mAction.MAction(argv);
            return;
        }

        public MenuAction[] MenuActions { get; set; }

        public delegate void MActionDelegate(object argv);

        /// <summary>
        /// MenuAction
        /// </summary>
        public struct MenuAction
        {
            public string Name { get; set; }
            public MActionDelegate MAction { get; set; }
            public Func<ConsoleKeyInfo, bool> MenuActionFilter { get; set; }
        }
    }
}
