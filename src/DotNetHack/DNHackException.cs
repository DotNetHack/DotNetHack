using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack
{
    /// <summary>
    /// DNHackException
    /// </summary>
    public class DNHackException : Exception
    {
        /// <summary>
        /// DNHackException
        /// </summary>
        /// <param name="aMessage">Exception message</param>
        /// <param name="aInner">Inner exception</param>
        public DNHackException(string aMessage, Exception aInner)
            : base(aMessage, aInner) { }

        /// <summary>
        /// DNHackException
        /// </summary>
        /// <param name="aMessage">Exception message</param>
        public DNHackException(string aMessage)
            : this(aMessage, null) { }
    }
}
