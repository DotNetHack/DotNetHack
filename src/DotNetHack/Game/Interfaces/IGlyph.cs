using System;
using DotNetHack.UI;
namespace DotNetHack.Game.Interfaces
{
	/// <summary>
	/// IGlyph
	/// </summary>
	public interface IGlyph
	{
		char G { get; set; }

        Colour C { get; set; }
	}
}
