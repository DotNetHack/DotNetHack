using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Resources
{
    /// <summary>
    /// Resource Access
    /// </summary>
    public static class R
    {
        /// <summary>
        /// GetTile
        /// </summary>
        /// <param name="img">the image object to write to</param>
        /// <param name="xCoord">the xCoord mod tile-size</param>
        /// <param name="yCoord">the yCoord mod tile--size</param>
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
                    new Rectangle(tileSize * xCoord, tileSize * yCoord, 
                        tileSize * (xCoord + 1), tileSize * (yCoord + 1)), 
                        GraphicsUnit.Pixel);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
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
