using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core.Game.Interfaces
{
    /// <summary>
    /// IKey
    /// </summary>
    public interface IKey
    {
        Guid KeyGuid { get; set; }
    }
}
