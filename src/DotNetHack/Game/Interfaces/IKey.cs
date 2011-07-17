using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Interfaces
{
    public interface IKey
    {
        public Guid KeyGuid { get; set; }
    }

    public interface IHasLock
    {
        public void UnLock(IKey aKey);
        public IKey KeyGuid { get; set; }
    }
}