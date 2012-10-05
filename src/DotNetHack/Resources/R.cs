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
            var size_t = Properties.Settings.Default.TileSize;
            Bitmap img = new Bitmap(size_t, size_t);
            Graphics.FromImage(Properties.Resources.X11tiles_32_32)
                .DrawImage(img, 0, 0, xCoord * size_t, yCoord * size_t);
            return img;
        }
    }
}
