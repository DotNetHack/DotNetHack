using System;
namespace DotNetHack.Game.Interfaces
{
	/// <summary>
	/// IFood
	/// </summary>
	public interface IFood : IConsumable
	{
        void Eat();
	}
}

