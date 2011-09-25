using System;
namespace DotNetHack.Game.Interfaces
{
	/// <summary>
	/// IFood
	/// </summary>
	public interface IFood : IConsumable
	{
        /// <summary>
        /// The number of calories of this food-stuff.
        /// </summary>
        int Calories { get; set; }

        /// <summary>
        /// If this food tainted
        /// </summary>
        bool Tainted { get; set; }

        /// <summary>
        /// Eat this food
        /// </summary>
        void Eat();
	}
}

