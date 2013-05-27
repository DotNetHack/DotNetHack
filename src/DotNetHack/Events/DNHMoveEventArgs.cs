using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Events
{
    /// <summary>
    /// DNHMoveEventArgs
    /// </summary>
    public class DNHMoveEventArgs : DNHActionEventArgs
    {
        /// <summary>
        /// DNHMoveEventArgs
        /// </summary>
        /// <param name="from">from location</param>
        /// <param name="to">to location</param>
        public DNHMoveEventArgs(DNHLocation from, DNHLocation to)
        {
            FromLocation = from;
            ToLocation = to;
        }

        /// <summary>
        /// FromLocation
        /// </summary>
        public DNHLocation FromLocation { get; set; }

        /// <summary>
        /// ToLocation
        /// </summary>
        public DNHLocation ToLocation { get; set; }
    }
}
