using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Engine.Scripting
{
    /// <summary>
    /// ScriptLoader
    /// <remarks>Singleton</remarks>
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ff650316.aspx"/>
    /// </summary>
    internal class ScriptLoader
    {
        /// <summary>
        /// CompilerParameters
        /// </summary>
        public CompilerParameters CompilerParameters { get; set; }

        #region Singleton

        /// <summary>
        /// The backing-store for the singleton-instance
        /// </summary>
        private ScriptLoader _instance = null;

        /// <summary>
        /// Private constructor for the script loader.
        /// </summary>
        private ScriptLoader() { }

        /// <summary>
        /// ScriptLoader Instance
        /// </summary>
        public ScriptLoader Instance 
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new ScriptLoader();
                }

                return _instance;
            }
        }

        #endregion
    }
}
