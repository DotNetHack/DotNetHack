using System;
namespace DotNetHack.Game.Interfaces
{
	/// <summary>
	/// IPotion 
	/// </summary>
	public interface IPotion : IConsumable
	{
        void Quaff();
	}
}

