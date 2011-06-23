using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.UI
{
    public class Menu
    {
        public Menu(string aTile, MenuAction[] aActions) { MenuActions = aActions; Title = aTile; }
        public string Title { get; set; }
        public MenuAction[] MenuActions { get; private set; }
        public void Show(int x, int y) 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Graphics.Display.Box(this, x, y); 
        }
        public void Exec(object state)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo input = (ConsoleKeyInfo)state;
            if (input.Key == ConsoleKey.Escape)
                return;
            foreach (MenuAction m in MenuActions)
                if (input.Key == m.ActionKey)
                    m.Action(state);
        }
        public struct MenuAction
        {
            public string Name;
            public MAction Action;
            public ConsoleKey ActionKey;
        }

        public delegate void MAction(object state);
    }
}
