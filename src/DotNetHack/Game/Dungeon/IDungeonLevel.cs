using System;
using DotNetHack.Game.Interfaces;
namespace DotNetHack.Game.Dungeon
{
    interface IDungeonLevel
    {
        string MapFile { get; set; }
        void Render(Location2i aLocation);
    }
}
