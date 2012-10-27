using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Shared
{
    /// <summary>
    /// Shared Runtime and Resources
    /// </summary>
    public static class R
    {
        /// <summary>
        /// GetTile
        /// </summary>
        /// <param name="img">the image object to write to</param>
        /// <param name="xCoord">the xCoord mod tile-size</param>
        /// <param name="yCoord">the yCoord mod tile--size</param>
        /// <returns>the tile that exist within the selected bounding(tileSize) location</returns>
        public static Bitmap GetTile(int xCoord, int yCoord)
        {
            int tileSize = Properties.Settings.Default.TileSize;

            //a holder for the result
            Bitmap result = new Bitmap(tileSize, tileSize);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.DrawImage(Properties.Resources.X11tiles_32_32,
                    new Rectangle(0, 0, tileSize, tileSize),
                    new Rectangle(xCoord * tileSize, yCoord * tileSize, tileSize, tileSize),
                    GraphicsUnit.Pixel);
            }

            return result;
        }

        /// <summary>
        /// MoveImageByOffsetPoint
        /// <remarks>moves the specificed image by the offset vector</remarks>
        /// </summary>
        /// <param name="image">thes image that will be adjusted by offset.</param>
        /// <param name="offsetPoint">the offset point to move the top lhs to.</param>
        public static Bitmap MoveImageByOffsetPoint(System.Drawing.Image image, Point offsetVector)
        {
            //a holder for the result
            Bitmap result = new Bitmap(image.Width, image.Height);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Point tmpPointMod32 = new Point(32 % offsetVector.X, 32 % offsetVector.Y);

                //draw the image into the target bitmap
                graphics.DrawImage(image, tmpPointMod32.X, tmpPointMod32.Y, result.Width - offsetVector.X, result.Height - offsetVector.Y);
            }

            //return the resulting bitmap
            return result;
        }


        /// <summary>
        /// ResizeImage
        /// </summary>
        /// <param name="image">the image to be resized</param>
        /// <param name="width">the width</param>
        /// <param name="height">the height</param>
        /// <returns>the resized image</returns>
        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            //a holder for the result
            Bitmap result = new Bitmap(width, height);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //draw the image into the target bitmap
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            //return the resulting bitmap
            return result;
        }
    }
}
