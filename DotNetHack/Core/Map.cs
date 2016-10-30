using DotNetHack.Definitions;

namespace DotNetHack.Core
{
    /// <summary>
    /// Map
    /// </summary>
    public class Map
    {
        /// <summary>
        /// The _tiles
        /// </summary>
        private readonly Tile[,,] _tiles;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="mapDef">The map definition.</param>
        public Map(MapDef mapDef)
        {
            Id = mapDef.Id;

            _tiles = new Tile[Width = mapDef.Width, Height = mapDef.Height, Depth = mapDef.Depth];
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; }

        /// <summary>
        /// Gets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth { get; }

        /// <summary>
        /// Gets or sets the <see cref="Tile"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="Tile"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns></returns>
        public Tile this[int x, int y, int z]
        {
            get { return _tiles[x, y, z]; }
            set { _tiles[x, y, z] = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="Tile"/> with the specified location.
        /// </summary>
        /// <value>
        /// The <see cref="Tile"/>.
        /// </value>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public Tile this[ILocation location]
        {
            get { return this[location.X, location.Y, location.Z]; }
            set { this[location.X, location.Y, location.Z] = value; }
        }
    }
}