using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Interfaces
{
    /// <summary>
    /// ITool
    /// </summary>
    public interface ITool : IItem, IHasUses
    {
        void Use();
        void Apply(IItem item);
    }
}
