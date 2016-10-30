using System.Collections.Generic;
using System.Linq;
using DotNetHack.Definitions;

namespace DotNetHack.Core
{
    /// <summary>
    /// Tile
    /// </summary>
    public class Tile : Id
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        /// </summary>
        /// <param name="tileDef">The tile definition.</param>
        public Tile(TileDef tileDef)
        {
            Id = tileDef.Id;
            Glyph = tileDef.Glyph;

            var attrIsPassable = tileDef.Attributes.SingleOrDefault(s => s.Name == "IsPassable");

            if (attrIsPassable != null)
            {
                IsPassable = (bool)attrIsPassable.Value;
            }
            else
            {
                IsPassable = true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is passable.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is passable; otherwise, <c>false</c>.
        /// </value>
        public bool IsPassable { get; }

        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        public Glyph Glyph { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public Stack<Item> Items { get; set; } = new Stack<Item>();
    }
}