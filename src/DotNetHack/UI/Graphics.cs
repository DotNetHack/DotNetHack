using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetHack.Game;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.UI
{
    /// <summary>
    /// Graphics
    /// </summary>
    public static partial class Graphics
    {
        /// <summary>
        /// extension method allowing a CursorState to be set right off the bat.
        /// </summary>
        /// <param name="value">the cursor state to set effective immediate</param>
        public static void Set(this CursorState value)
        {
            Console.SetCursorPosition(value.X, value.Y);
            Console.ForegroundColor = value.FG;
            Console.BackgroundColor = value.BG;
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public static void Initialize()
        {
            Initialize(Console.WindowWidth, 
                Console.WindowHeight);
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public static void Initialize(int w, int h) 
        {
            // Kill cursor visibility
            Console.CursorVisible = false;
            Console.SetWindowSize(w, h);
        }

        /// <summary>
        /// ShowGraphicsInfo
        /// </summary>
        public static void ShowGraphicsInfo()
        {
            Console.WriteLine("Width: {0}, Height: {1}", 
                Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine("Max-Width: {0}, Max-Height: {1}", 
                Console.LargestWindowWidth, Console.LargestWindowHeight);
        }

        /// <summary>
        /// ScreenCenter
        /// <value>The location of the center of the screen.</value>
        /// </summary>
        public static Location2i ScreenCenter
        {
            get 
            {
                return new Location2i(Console.WindowWidth / 2, 
                    Console.WindowHeight / 2);
            }
        }

        /// <summary>
        /// The width of the screen.
        /// </summary>
        public static int ScreenWidth { get { return Console.WindowWidth; } }

        /// <summary>
        /// The height of the screen.
        /// </summary>
        public static int ScreenHeight { get { return Console.WindowHeight; } }

        /// <summary>
        /// Clear
        /// </summary>
        public static void Clear(Colour aColour)
        {
            Console.BackgroundColor = aColour.FG;
            Console.ForegroundColor = aColour.BG;
            Console.Clear();
        }

        /// <summary>
        /// Clear
        /// </summary>
        public static void Clear() { Clear(Colour.Standard); }

        /// <summary>
        /// Clear the passed display region
        /// </summary>
        /// <param name="dr"></param>
        public static void Clear(DisplayRegion dr)
        {
            for (int x = dr.P1.X; x < dr.P2.X; ++x)
                for (int y = dr.P1.Y; y < dr.P2.Y; ++y)
                {
                    UI.Graphics.CursorToLocation(x, y);
                    Console.Write(' ');
                }
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="aDrawable">A drawable object or thing</param>
        public static void Draw(IDrawable aDrawable)
        {
            // Move the cursor to the drawble location.
            CursorToLocation(aDrawable.Location);

            // Save this for later
            Colour tmpColor = Colour.CurrentColour;

            // we're not coming this far to findout a colour isn't set.
            if (aDrawable.C == null)
                aDrawable.C = Colour.Standard;

            // Set the colour
            aDrawable.C.Set();

            // Draw the character
            Console.Write(aDrawable.G);

            // Set the colour back to what we saved at the beginning of the method.
            tmpColor.Set();
        }

        /// <summary>
        /// CursorToLocation brings the cursor to the specified location.
        /// </summary>
        /// <param name="aLocation">The location to bring the cursor to.</param>
        public static void CursorToLocation(Location2i aLocation) 
        {
            CursorToLocation(aLocation.X, aLocation.Y);
        }

        /// <summary>
        /// CursorToLocation brings the cursor to the specified location.
        /// </summary>
        /// <param name="x">The X-Coordinate</param>
        /// <param name="y">The Y-Coordinate</param>
        public static void CursorToLocation(int x, int y) 
        {
            Console.SetCursorPosition(x, y);
        }
    }
}

