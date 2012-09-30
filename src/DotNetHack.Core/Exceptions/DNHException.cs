using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Exceptions
{
    /// <summary>
    /// DNHException
    /// </summary>
    public class DNHException : Exception
    {
        /// <summary>
        /// DNHException
        /// </summary>
        public DNHException() { }

        /// <summary>
        /// DNHException
        /// </summary>
        /// <param name="message">exception message</param>
        public DNHException(string message)
        {
        }

        /// <summary>
        /// DNHException
        /// </summary>
        /// <param name="message">exception messahe</param>
        /// <param name="inner">inner exception</param>
        public DNHException(string message, Exception inner)
        {
 
        }
    }
}
