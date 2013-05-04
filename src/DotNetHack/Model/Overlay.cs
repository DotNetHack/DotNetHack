using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Model
{
    /// <summary>
    /// An Overlay is a templated type generally used as part of substrate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Overlay<T>
        where T : new()
    {
        /// <summary>
        /// Overlay
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <param name="d"></param>
        public Overlay(Substrate substrate, int w, int h, int d)
        {
            Substrate = substrate;
            D = new T[w, h, d];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public T this[int x, int y, int z]
        {
            get { return D[x, y, z]; }
            set { D[x, y, z] = value; }
        }

        /// <summary>
        /// 3-dimensional array containing the data for this overlay.
        /// </summary>
        private readonly T[, ,] D;

        /// <summary>
        /// Substrate
        /// </summary>
        public Substrate Substrate { get; private set; }
    }
}
