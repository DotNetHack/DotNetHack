using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game;

namespace DotNetHack.Editor
{
    /// <summary>
    /// Help
    /// </summary>
    public class Help
    {
        /// <summary>
        /// Show help
        /// </summary>
        public static void Show()
        {
            // Clear the screen, show a bounding box
            UI.Graphics.Clear(Colour.Ocean);
            UI.Graphics.Display.Box(5, 5, 10, 10);
            Colour.DeepOcean.Set();
            ShowHelpLine("PageUp", "Move up a dungeon");
            ShowHelpLine("PageDown", "Move up a dungeon");
        }

        /// <summary>
        /// ShowHelpLine
        /// </summary>
        /// <param name="key"></param>
        /// <param name="desc"></param>
        private static void ShowHelpLine(string key, string desc)
        {
            Console.Write("\t{0}", key);
            Console.Write(" - ");
            Console.WriteLine("{0}", desc);
        }
    }
}