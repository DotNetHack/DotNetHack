using DotNetHack.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI
{
    /// <summary>
    /// DisplayBufferCursor
    /// </summary>
    public class DisplayBufferCursor
    {
        /// <summary>
        /// Create a new display buffer cursor
        /// </summary>
        public DisplayBufferCursor(DisplayBuffer buffer)
        {
            CursorLocation = new Point(0, 0);
            ParentBuffer = buffer;
        }

        /// <summary>
        /// The display buffer from which this display buffer cursor came
        /// </summary>
        public DisplayBuffer ParentBuffer { get; set; }

        /// <summary>
        /// currentPoint
        /// </summary>
        public IPoint CursorLocation { get; set; }

        /// <summary>
        /// The foreground color
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }

        /// <summary>
        /// The background color
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="c">the character to write</param>
        public void Write(char c)
        {
            this.ParentBuffer[CursorLocation] = new Glyph(c, ForegroundColor, BackgroundColor);
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
        /// Gets the cursor location
        /// </summary>
        public IPoint GetCursorPosition()
        {
            return CursorLocation;
        }
    }
}
