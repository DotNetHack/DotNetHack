using System;
using DotNetHack.Game.Interfaces;
namespace DotNetHack.Game
{
    interface IDungeonLevel
    {
        string MapFile { get; set; }
        void Render(Location aLocation);
    }
}
