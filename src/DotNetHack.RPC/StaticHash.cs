using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.RPC
{
    /// <summary>
    /// Static hash class used in authentication.
    /// </summary>
    public static class StaticHash
    {
        /// <summary>
        /// ToHashString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHashString(this string value)
        {
            return value.GetHash().ToHashString();
        }

        /// <summary>
        /// Converts a byte array into a hash string
        /// </summary>
        /// <param name="byteArray">the byte array to convert into a hash string.</param>
        /// <returns></returns>
        public static string ToHashString(this byte[] byteArray)
        {
            string retVal = string.Empty;
            foreach (var @byte in byteArray)
                retVal += String.Format("{0:X}", @byte);
            return retVal;
        }

        /// <summary>
        /// Returns the <c>SHA-1</c> hash for the passed string
        /// </summary>
        /// <param name="aHashThis">The string to hash.</param>
        /// <remarks>The string is first turned into a byte array; then a unique seed is 
        /// appended to that array such that the hash is unique only for a specific perioud
        /// of time.  Have a look at <see cref="HashAlgorithm"/> if you like.</remarks>
        /// <returns></returns>
        public static byte[] GetHash(this string aHashThis)
        {
            // Convert the string 
            byte[] byteArray = new byte[20];
            byteArray.Initialize();
            byteArray = aHashThis.ToByteArray();

            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(byteArray);
        }

        /// <summary>
        /// Returns the passed string as a byte array.
        /// </summary>
        /// <param name="aInString">The string to return as a byte array.</param>
        /// <returns>A byte array representing the passed string; with an empty element @ the end
        /// for the seed to be placed.</returns>
        private static byte[] ToByteArray(this string aInString)
        {
            // Create an empty byte array with the same length as aInString; and instantiate
            // an index counter @ zero.
            byte[] retVal = new byte[aInString.Length + 1];
            int index = 0x0000;

            // Index through all characters in the inString, 
            // add it to the return array; increment index.
            foreach (char ch in aInString)
            {
                retVal.SetValue((byte)ch, index);
                index++;
            }

            return retVal;
        }
    }
}
