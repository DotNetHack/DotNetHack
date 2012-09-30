using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    class DNHException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public DNHException() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public DNHException(string message)
        {
        }

        /// <summary>
        /// DNHException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public DNHException(string message, Exception inner)
        {
 
        }
    }
}
