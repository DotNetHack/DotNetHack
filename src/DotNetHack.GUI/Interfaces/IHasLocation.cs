using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Interfaces
{
    public interface IHasLocation
    {
        IPoint Location { get; set; }
    }
}
