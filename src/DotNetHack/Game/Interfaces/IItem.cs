using System;
using DotNetHack.Game.Items;

namespace DotNetHack.Game.Interfaces
{
	/// <summary>
	/// IItem
	/// </summary>
    
    public interface IItem : IDrawable
	{
        string Name { get; set; }
        ItemType ItemType { get; set; }
	}
}

