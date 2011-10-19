using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetHack.UI
{
    /// <summary>
    /// ProgressBar
    /// </summary>
    public class ProgressBar : Widget
    {
        /// <summary>
        /// Creates a new instance of <c>ProgressBar</c>
        /// </summary>
        public ProgressBar(string text)
        {
            Value = 0.0;
            Text = text;
            Width = DefaultWidth;

            // init progress-bar colour scheme
            TC = ConsoleColor.Yellow;
            BG = ConsoleColor.Cyan;
            FG = ConsoleColor.White;
        }

        /// <summary>
        /// Draw
        /// </summary>
        public override void Show()
        {
            base.Show();

            // set-up the colour scheme
            Console.ForegroundColor = FG;
            Console.BackgroundColor = BG;

            // actually perform the drawing mechanicially
            for (int index = 0; index < Width; index++)
            {
                // deliniate progress using colour.
                if (index > (Width / 100.0) * Value && Value > 0)
                    Console.BackgroundColor = TC;

                // draw the text
                if (index > TextOffset)
                {
                    int offset = index - TextOffset - 1;
                    if (offset < Text.Length)
                    {
                        var tmpFG1 = Console.ForegroundColor;
                        Console.ForegroundColor = FG;
                        Console.Write(Text[offset]);
                        Console.ForegroundColor = tmpFG1;
                    }
                }

                // write a specific charcter  to the screen
                //  '    running     '
                Console.Write(DisplayGlyph);
                Console.SetCursorPosition(X + index, Y);
            }
        }

        /// <summary>
        /// the text offset is used in positioning calculations.
        /// </summary>
        int TextOffset { get { return ((Width / 2)) - (Text.Length / 2); } }

        /// <summary>
        /// The text displayed inside of the progress bar
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// the current percentage as represented by this progress bar.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Padding on both the left and right side of progress bar.
        /// </summary>
        const int Padding = 2;

        /// <summary>
        /// the default width for any progress bar.
        /// </summary>
        const int DefaultWidth = 20;

        /// <summary>
        /// the character used for displaying percentage complete
        /// </summary>
        const char DisplayGlyph = ' ';

        /// <summary>
        /// foreground colour, generally text for a progress bar
        /// </summary>
        readonly ConsoleColor FG;

        /// <summary>
        /// the background colour
        /// </summary>
        readonly ConsoleColor BG;

        /// <summary>
        /// a third colour, for % that has been completed
        /// </summary>
        readonly ConsoleColor TC;
    }
}
