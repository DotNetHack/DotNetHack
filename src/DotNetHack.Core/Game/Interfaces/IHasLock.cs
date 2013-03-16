using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Interfaces
{
    /// <summary>
    /// IHasLock
    /// </summary>
    public interface IHasLock
    {
        /// <summary>
        /// UnLock
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        bool UnLock(IKey aKey);

        /// <summary>
        /// KeyRef
        /// </summary>
        Guid KeyRef { get; set; }
    }
}
