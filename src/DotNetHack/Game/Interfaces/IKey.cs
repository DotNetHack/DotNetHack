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
        void UnLock(IKey aKey);
        IKey KeyGuid { get; set; }
    }
}