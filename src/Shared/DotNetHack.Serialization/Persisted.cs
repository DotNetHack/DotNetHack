using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DotNetHack.Serialization
{
    /// <summary>
    /// Extension method that rides on top of all obects.
    /// </summary>
    public static class Persisted
    {
        #region Various supported interfaces may reside here.

        /// <summary>
        /// For complex objects that have implement IPersisted they can use 
        /// Read directly without having to drop down to the string level.
        /// </summary>
        public interface IPersisted
        {
            /// <summary>
            /// The location that this disk-file that this IPersisted(T) resides in.
            /// </summary>
            string FileName { get; set; }
        }

        #endregion

        /// <summary>
        /// Read a templated type from a fully qualified file-path; return the deserialized object.
        /// </summary>
        /// <typeparam name="T">The templated type that willl be returned.</typeparam>
        /// <param name="strFullPath">The fully qualified file path that will be deserialized.</param>
        /// <returns>The result of deserialize, casted as <c>T</c></returns>
        /// <exception cref="IOException">{strFullPath} not found</exception>
        public static T Read<T>(this string strFullPath)
        {
            if (strFullPath == null) throw new ArgumentNullException("strFullPath");
            if (!File.Exists(strFullPath))
                throw new IOException(string.Format("{0} not found", strFullPath));
            using (Stream fs = new FileStream(strFullPath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Read a templated generic type from the passed <see cref="IPersisted"/>.
        /// </summary>
        /// <typeparam name="T">The templated type being persisted.</typeparam>
        /// <param name="aPersisted">The actual object being peristed.</param>
        /// <returns></returns>
        public static T Read<T>(this IPersisted aPersisted)
        {
            return aPersisted.FileName.Read<T>();
        }

        /// <summary>
        /// Write the templated type (aObj) <c>to</c> the fully qualified file-path.  
        /// <remarks>If the path <c>does not</c> exist, the full-directory-tree <c>will</c> be created.</remarks>
        /// </summary>
        /// <typeparam name="T">The templated type that willl be written to disk.</typeparam>
        /// <param name="aObj">The actual object that is written to disk.</param>
        /// <param name="strFullPath">The fully qualified file-path.
        /// <example>c:\temp\out\1.xml</example>
        /// <example>.\out\2.xml</example>
        /// <example>3.xml</example>
        /// </param>
        /// <returns>true when the operation was a success.</returns>
        public static bool Write<T>(this T aObj, string strFullPath)
        {
            if (strFullPath == null) throw new ArgumentNullException("strFullPath");

            try
            {
                var strDirectory = Path.GetDirectoryName(strFullPath);
                if (strDirectory != null && (!Directory.Exists(strDirectory) && !string.Empty.Equals(strDirectory)))
                    Directory.CreateDirectory(strDirectory);
                var tmpFileMode =  FileMode.CreateNew;
                if (File.Exists(strFullPath))
                    tmpFileMode = FileMode.Truncate;
                using (var tmpRawStream = File.Open(strFullPath, tmpFileMode))
                using (var tmpXmlWriter = new XmlTextWriter(tmpRawStream, new UTF8Encoding()))
                    new XmlSerializer(aObj.GetType()).Serialize(tmpXmlWriter, aObj);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Writes the IPersisted object to the location defined in the interface.
        /// <see cref="IPersisted"/>
        /// </summary>
        /// <param name="aObj">The actual object that is written to disk.</param>
        /// <returns>true when the operation was a success.</returns>
        public static bool Write(this IPersisted aObj)
        {
            return aObj.Write(aObj.FileName);
        }
    }
}
