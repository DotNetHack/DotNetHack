namespace DotNetHack.GUI
{
    /// <summary>
    /// A display buffer
    /// </summary>
    public struct DisplayBuffer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayBuffer"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public DisplayBuffer(int width, int height)
        {
            Width = width;
            Height = height;
            Glyphs = new Glyph[width, height];
        }

        /// <summary>
        /// Gets the glyphs.
        /// </summary>
        /// <value>
        /// The glyphs.
        /// </value>
        public Glyph[,] Glyphs { get; }

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
        /// Sets the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="glyph">The glyph.</param>
        public void Set(int x, int y, Glyph glyph)
        {
            Glyphs[x, y] = glyph;
        }

        /// <summary>
        /// Gets or sets the <see cref="Glyph"/> with the specified x.
        /// </summary>
        /// <value>
        /// The <see cref="Glyph"/>.
        /// </value>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public Glyph this[int x, int y]
        {
            get { return Glyphs[x, y]; }
            set { Glyphs[x, y] = value; }
        }
    }
}