using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Model
{
    /// <summary>
    /// Substrate
    /// </summary>
    public class Substrate
    {
        /// <summary>
        /// Substrate
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="d"></param>
        public Substrate(int w, int h, int d)
        {
            ItemOverlay = new Overlay<Stack<DNHObject>>(this, w, h, d);
            MapOverlay = new Overlay<DNHObject>(this, w, h, d);
            NPCOverlay = new Overlay<Stack<DNHObject>>(this, w, h, d);
        }

        /// <summary>
        /// MapOverlay
        /// </summary>
        public Overlay<DNHObject> MapOverlay { get; set; }

        /// <summary>
        /// ItemOverlay
        /// </summary>
        public Overlay<Stack<DNHObject>> ItemOverlay { get; set; }

        /// <summary>
        /// NPCOverlay
        /// </summary>
        public Overlay<Stack<DNHObject>> NPCOverlay { get; set; }
    }
}
