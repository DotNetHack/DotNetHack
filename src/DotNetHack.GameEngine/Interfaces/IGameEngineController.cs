using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Engine.Interfaces
{
    /// <summary>
    /// GameEngine
    /// </summary>
    public interface IGameEngineController
    {
        /// <summary>
        /// The game engine to control
        /// </summary>
        GameEngine Engine { get; set; }
    }
}
