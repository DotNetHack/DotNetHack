using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game
{
    /// <summary>
    /// ScriptedObject
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="state"></param>
    /// <param name="arg"></param>
    public delegate void ScriptedCallback<T>(GameState state, T arg);

    /// <summary>
    /// IScriptedObject
    /// </summary>
    public interface IScriptedObject<T>
    {
        /// <summary>
        /// ScriptedCallback
        /// </summary>
        ScriptedCallback<T> ScriptedCallback { get; set; }
    }
}
