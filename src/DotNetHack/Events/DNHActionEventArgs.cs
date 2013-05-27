using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Events
{
    /// <summary>
    /// DNHActionEventArgs
    /// </summary>
    public class DNHActionEventArgs : DNHEventArgs
    {
        /// <summary>
        /// Canceled
        /// </summary>
        public bool Canceled { get; set; }
    }
}
