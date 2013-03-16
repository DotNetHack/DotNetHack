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
    public class DisplayBuffer : IDimensional, IColorScheme
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
        /// Creates a new <see cref="DisplayBuffer"/>
        /// </summary>
        /// <param name="dimension">The dimension of this display Buffer</param>
        public DisplayBuffer(Size dimension)
        {
            Size = dimension;
            Buffer = new Glyph[dimension.Width + 1, dimension.Height + 1];
            CursorLocation = new Point(0, 0);
            ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="x">1st dimension</param>
        /// <param name="y">2nd dimension</param>
        /// <returns>A glyph</returns>
        public Glyph this[int x, int y]
        {
            get { Invalidated = true;  return Buffer[x, y]; }
            set { Buffer[x, y] = value; }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="p">1st and second dimension</param>
        /// <returns>A glyph</returns>
        public Glyph this[IPoint p]
        {
            get { Invalidated = true; return Buffer[p.X, p.Y]; }
            set { Buffer[p.X, p.Y] = value; }
        }

        #region Console Cursor

        /// <summary>
        /// currentPoint
        /// </summary>
        public IPoint CursorLocation { get; set; }
   
        /// <summary>
        /// The background color
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// The foreground color
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="c">the character to write</param>
        public void Write(char c)
        {
            this[CursorLocation.X++, CursorLocation.Y] = new Glyph(c, ForegroundColor, BackgroundColor);
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="s"></param>
        public void Write(string s)
        {
            s.ToList().ForEach(ch => {
                Write(ch);
            });
        }

        /// <summary>
        /// Sets the cursor location
        /// </summary>
        public void SetCursorPosition(int x, int y)
        {
            CursorLocation.X = x;
            CursorLocation.Y = y;
        }

        /// <summary>
        /// SetCursorLocation
        /// </summary>
        /// <param name="l">Cursor location</param>
        public void SetCursorPosition(IHasLocation l)
        {
            CursorLocation.Y = l.Location.Y;
            CursorLocation.X = l.Location.X;
        }

        /// <summary>
        /// SetCursorPosition
        /// </summary>
        /// <param name="p"></param>
        public void SetCursorPosition(IPoint p)
        {
            CursorLocation.Y = p.Y;
            CursorLocation.X = p.X;
        }

        /// <summary>
        /// Gets the cursor location
        /// </summary>
        public IPoint GetCursorPosition()
        {
            return CursorLocation;
        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="dr"></param>
        public void Clear(IColorScheme clearColor)
        {
            Console.ForegroundColor = clearColor.ForegroundColor;
            Console.BackgroundColor = clearColor.BackgroundColor;

            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }
            }
        }


        #endregion

        /// <summary>
        /// Buffer
        /// </summary>
        Glyph[,] Buffer;

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

        /// <summary>
        /// A display buffer may be "invalidated" when something in it's backing store changes. 
        /// This property could also be called "Dirty"
        /// </summary>
        public bool Invalidated { get; private set; }

        /// <summary>
        /// Invalidation of a display buffer may be 'forced' using this method.
        /// </summary>
        public void Invalidate()
        {
            Invalidated = true;
        }

        /// <summary>
        /// Validates this display buffer
        /// </summary>
        public void Validate()
        {
            Invalidated = false;
        }
    }
}
