using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Actors
{
    /// <summary>
    /// A Game Actor
    /// <remarks>
    /// An actor can be the player, another player, etc.
    /// </remarks>
    /// </summary>
    [Serializable]
    public abstract class Actor : IScriptedObject<Actor>
    {
        /// <summary>
        /// Default .ctor supports serialization.
        /// </summary>
        public Actor()
        {

        }

        /// <summary>
        /// ScriptedCallback
        /// </summary>
        public ScriptedCallback<Actor> ScriptedCallback { get; set; }
    }
}
