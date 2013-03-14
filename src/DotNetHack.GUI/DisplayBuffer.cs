using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// DisplayBuffer
    /// </summary>
    public class DisplayBuffer : IDimensional
    {
        /// <summary>
        /// DisplayBuffer
        /// </summary>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public DisplayBuffer(int width, int height)
            : this(new Size(width, height))
        {
            Cursor = new DisplayBufferCursor(this);
        }

        /// <summary>
        /// Creates a new <see cref="DisplayBuffer"/>
        /// </summary>
        /// <param name="dimension">The dimension of this display buffer</param>
        public DisplayBuffer(Size dimension)
        {
            Size = dimension;
            buffer = new Glyph[dimension.Width-1, dimension.Height];
            Cursor = new DisplayBufferCursor(this);
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="x">1st dimension</param>
        /// <param name="y">2nd dimension</param>
        /// <returns>A glyph</returns>
        public Glyph this[int x, int y]
        {
            get { return buffer[x, y]; }
            set { buffer[x, y] = value; }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="p">1st and second dimension</param>
        /// <returns>A glyph</returns>
        public Glyph this[IPoint p]
        {
            get { return buffer[p.X, p.Y]; }
            set { buffer[p.X, p.Y] = value; }
        }

        #region Buffer Cursor

        /// <summary>
        /// DisplayBufferCursor
        /// </summary>
        public DisplayBufferCursor Cursor { get; set; }

        #endregion

        /// <summary>
        /// buffer
        /// </summary>
        Glyph[,] buffer;

        /// <summary>
        /// Size
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        public int Width { get { return Size.Width; } }

        /// <summary>
        /// Height
        /// </summary>
        public int Height { get { return Size.Height; } }
    }
}
