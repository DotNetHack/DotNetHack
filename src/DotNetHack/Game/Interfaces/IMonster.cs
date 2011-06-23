using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Interfaces
{
    public interface IMonster : IDrawable
    {
        string Name { get; set; }
    }
}
