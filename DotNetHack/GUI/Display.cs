using System;
using System.Diagnostics;
using DotNetHack.Core;

namespace DotNetHack.GUI
{
    /// <summary>
    /// Display
    /// </summary>
    public sealed class Display
    {
        /// <summary>
        /// The stopwatch for recording rendering times
        /// </summary>
        private readonly Stopwatch _stopwatch = new Stopwatch();

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
        /// The _current buffer
        /// </summary>
        private DisplayBuffer _current;

        /// <summary>
        /// The offscreen buffer
        /// </summary>
        private DisplayBuffer _offScreen;

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Display(int width, int height)
        {
            Width = width;
            Height = height;
            _current = new DisplayBuffer(width, height);
            _offScreen = new DisplayBuffer(width, height);

#if DEBUG
            _stopwatch.Start();
#endif
        }

        /// <summary>
        /// Renders the contents of the display buffer
        /// </summary>
        public void Render()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    if (_current[x, y] == _offScreen[x, y])
                    {
                        continue;
                    }

                    Console.SetCursorPosition(x, y);

                    var glyph = _current[x, y];
                    Console.ForegroundColor = glyph.FG;
                    Console.BackgroundColor = glyph.BG;
                    Console.Write((char) glyph.G);
                }
            }

            SwapBuffers();

#if _DEBUG
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("FPS: " + ++_ticks / _stopwatch.Elapsed.TotalSeconds + "    ");
#endif
        }

        /// <summary>
        /// Swaps the buffers.
        /// </summary>
        private void SwapBuffers()
        {
            var tmp = _current;
            _current = _offScreen;
            _offScreen = tmp;
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
            get { return _current[x, y]; }
            set { _current.Set(x, y, value); }
        }
    }
}