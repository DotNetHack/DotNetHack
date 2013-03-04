using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace DotNetHack.TestLib
{
    /// <summary>
    /// ExtensionMethods specifically for testing
    /// TODO: Adding method chaining for Eq, Gt, Lt, Le,Ge
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// IsTrue
        /// </summary>
        /// <param name="value">determine if this value is true</param>
        public static void IsTrue(this bool @value)
        {
            Assert.IsTrue(@value);
        }

        /// <summary>
        /// IsFalse
        /// </summary>
        /// <param name="value">determine if this value is false</param>
        public static void IsFalse(this bool @value)
        {
            Assert.IsFalse(@value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void AllProps<T>(this T obj, Predicate<T> predicate, string msg = "")
        {
            const BindingFlags DefaultFlags = BindingFlags.Instance 
                | BindingFlags.Public | BindingFlags.DeclaredOnly;

            foreach (var prop in typeof(T).GetProperties(DefaultFlags))
            {
                var propValue = prop.GetGetMethod().Invoke(obj, new object[] { });

                Assert.IsTrue(predicate((T)propValue), msg);
            }
        }

        /// <summary>
        /// Ge
        /// </summary>
        /// <param name="a">lhs</param>
        /// <param name="b">rhs</param>
        public static void Ge(this IComparable a, IComparable b)
        {
            Assert.IsTrue(a.CompareTo(b) >= 0);
        }

        /// <summary>
        /// Gt
        /// </summary>
        /// <param name="a">lhs</param>
        /// <param name="b">rhs</param>
        public static void Gt(this IComparable a, IComparable b)
        {
            Assert.IsTrue(a.CompareTo(b) > 0);
        }

        /// <summary>
        /// Le
        /// </summary>
        /// <param name="a">lhs</param>
        /// <param name="b">rhs</param>
        public static void Le(this IComparable a, IComparable b)
        {
            Assert.IsTrue(a.CompareTo(b) <= 0);
        }

        /// <summary>
        /// Lt
        /// </summary>
        /// <param name="a">lhs</param>
        /// <param name="b">rhs</param>
        public static void Lt(this IComparable a, IComparable b)
        {
            Assert.IsTrue(a.CompareTo(b) < 0);
        }

        /// <summary>
        /// Eq
        /// </summary>
        /// <param name="a">lhs</param>
        /// <param name="b">rhs</param>
        public static void Eq(this IComparable a, IComparable b)
        {
            Assert.AreEqual(0, a.CompareTo(b));
        }
    }
}
