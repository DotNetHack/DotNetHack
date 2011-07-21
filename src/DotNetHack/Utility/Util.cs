using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace DotNetHack.Utility
{
    /// <summary>
    /// Utility Classes and Methods
    /// </summary>
    public static class Util
    {
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
