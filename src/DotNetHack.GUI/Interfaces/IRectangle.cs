using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Interfaces
{
    /// <summary>
    /// IRectangle
    /// </summary>
    public interface IRectangle
    {
        IPoint P1 { get; set; }
        IPoint P2 { get; set; }
    }
}
