using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Interfaces
{
    public interface IKey
    {
        Guid KeyGuid { get; set; }
    }

    public interface IHasLock
    {
        bool UnLock(IKey aKey);
        Guid KeyRef { get; set; }
    }
}