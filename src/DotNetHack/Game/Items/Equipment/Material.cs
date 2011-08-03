using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Items.Equipment
{
    /// <summary>
    /// Material
    /// </summary>
    [Flags]
    public enum Material
    {
        Stone, 
        Wooden, 
        Steel, 
        Iron,
        Gold, 
        Silver,
        Leather,
        Cloth,
        Glass,
    }
}
