using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Interfaces
{
    /// <summary>
    /// IColorScheme
    /// </summary>
    public interface IColorScheme
    {
        /// <summary>
        /// the background colour
        /// </summary>
        ConsoleColor BG { get; set; }

        /// <summary>
        /// The foreground colour
        /// </summary>
        ConsoleColor FG { get; set; }
    }
}
