using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.Game.Dungeon.Generator
{
    /// <summary>
    /// DungeonGenerator
    /// </summary>
    public abstract class DungeonGenerator
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="DotNetHack.Game.Dungeon.Generator.DungeonGenerator"/> class.
		/// </summary>
		/// <param name='aDungeon'>
		/// A dungeon.
		/// </param>
        public DungeonGenerator(Dungeon3 aDungeon) { Dungeon = aDungeon; }
		
		/// <summary>
		/// Generate the specified d.
		/// </summary>
		/// <param name='d'>
		/// D.
		/// </param>
        public abstract void Generate(int d);
		
		/// <summary>
		/// Gets or sets the dungeon.
		/// </summary>
		/// <value>
		/// The dungeon.
		/// </value>
        protected Dungeon3 Dungeon { get; set; }
		
		/// <summary>
		/// Gets or sets the generation properties.
		/// </summary>
		/// <value>
		/// The generation properties.
		/// </value>
		protected GenerationProperties GenerationProperties { get; set; }
    }
}
