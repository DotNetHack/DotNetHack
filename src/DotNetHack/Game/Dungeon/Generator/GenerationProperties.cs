using System;
namespace DotNetHack
{
	/// <summary>
	/// Generation properties.
	/// </summary>
	public struct GenerationProperties
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DotNetHack.GenerationProperties"/> struct.
		/// </summary>
		/// <param name='d'>
		/// Dungeon depth.
		/// </param>
		public GenerationProperties(int d)
		: this()
		{
			// parameter assignment
			TargetDepth = d;
			
			if (TargetDepth <= 0)
				throw new ArgumentOutOfRangeException("Dungeon target depth must be greater than zero.");
		}
				
		/// <summary>
		/// Gets or sets the target depth.
		/// </summary>
		/// <value>
		/// The target depth.
		/// </value>
		public int TargetDepth { get; set; }
	}
}

