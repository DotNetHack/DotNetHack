using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Interfaces
{
    public interface IDrawable : IGlyph, IHasLocation
    {
        void Draw();
    }

    /// <summary>
    /// IRender
    /// </summary>
    public interface IRender : IHasLocation
    {

    }
}
