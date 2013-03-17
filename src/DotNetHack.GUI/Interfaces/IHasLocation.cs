using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Interfaces
{
    /// <summary>
    /// IHasLocation
    /// </summary>
    public interface IHasLocation
    {
        Point Location { get; set; }
    }
}
