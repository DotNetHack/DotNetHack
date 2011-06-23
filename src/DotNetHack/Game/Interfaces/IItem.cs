using System;

namespace DotNetHack.Game.Interfaces
{
	/// <summary>
	/// IItem
	/// </summary>
    public interface IItem : IDrawable
	{
        string Name { get; set; }
	}
}

