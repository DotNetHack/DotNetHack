using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetHack.Core.Game.Actors
{
    /// <summary>
    /// A Game Actor
    /// <remarks>
    /// An actor can be the player, another player, etc.
    /// </remarks>
    /// </summary>
    [Serializable]
    public class Actor : IScriptedObject<Actor>
    {
        /// <summary>
        /// Default .ctor supports serialization.
        /// </summary>
        public Actor()
        {

        }

        /// <summary>
        /// The name of this actor
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ScriptedCallback
        /// </summary>
        [XmlIgnore]
        public ScriptedCallback<Actor> ScriptedCallback { get; set; }
    }
}
