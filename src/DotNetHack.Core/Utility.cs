using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.Core
{
    /// <summary>
    /// Utility Classes and Methods
    /// </summary>
    public static class Util
    {


        /// <summary>
        /// Compute a as a percentage in relation to b.
        /// (a/b)*100
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <returns>the percentage</returns>
        public static double Percent(int a, int b)
        {
            return (a / (b * 1.0)) * 100.00;
        }

        /// <summary>
        /// Sigmoid, squashes input to [0,1]
        /// http://en.wikipedia.org/wiki/Sigmoid_function
        /// return 2 / (1 + System.Math.Exp(-2 * n)) - 1;
        /// </summary>
        /// <param name="n">the input x, for f(x)</param>
        /// <returns></returns>
        public static double Sigmoid(double n)
        {
            return 1 / (1 + System.Math.Exp(-n));
        }

        /// <summary>
        /// <see cref="http://stackoverflow.com/questions/129389/how-do-you-do-a-deep-copy-an-object-in-net-c-specifically"/>
        /// </summary>
        /// <typeparam name="T">The type to deep copy</typeparam>
        /// <param name="obj">The objec to deep copy</param>
        /// <returns>The deep copied result.</returns>
        public static T DeepCopy<T>(T obj)
        {
            object result = null;

            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                result = (T)formatter.Deserialize(ms);
                ms.Close();
            }

            return (T)result;
        }
    }
}
