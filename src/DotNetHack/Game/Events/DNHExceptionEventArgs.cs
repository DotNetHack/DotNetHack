using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// DNH Exception event arguments
    /// </summary>
    public class DNHackExceptionEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instace of DNH exception event args
        /// </summary>
        /// <param name="ex"></param>
        public DNHackExceptionEventArgs(DNHackException ex)
            : base()
        { DNHackException = ex; }

        /// <summary>
        /// The exception that was involved
        /// </summary>
        public DNHackException DNHackException { get; set; }
    }
}
