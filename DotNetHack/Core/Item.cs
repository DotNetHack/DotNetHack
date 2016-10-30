using DotNetHack.Definitions;

namespace DotNetHack.Core
{
    /// <summary>
    /// Item
    /// </summary>
    public class Item : Id
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="itemDef">The item definition.</param>
        public Item(ItemDef itemDef)
        {
            Id = itemDef.Id;
            Glyph = itemDef.Glyph;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        public Glyph Glyph { get; set; }
    }
}