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

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        public DisplayBuffer(Size dimension)
        {
            Size = dimension;
            buffer = new Glyph[dimension.Width, dimension.Height];
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="x">1st dimension</param>
        /// <param name="y">2nd dimension</param>
        /// <returns></returns>
        public Glyph this[int x, int y]
        {
            get { return buffer[x, y]; }
            set { buffer[x, y] = value; }
        }

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
        public int Height { get { return Size.Height ; } }
    }
}
