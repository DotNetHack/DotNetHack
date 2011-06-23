using System;
using System.IO;

namespace DotNetHack.Utility
{
    /// <summary>
    /// LockFile object
    /// </summary>
    public class LockFile : IDisposable
    {
        /// <summary>
        /// LockFile
        /// <remarks>The option of using FileOptions.DeleteOnClose was scrapped because
        /// a FileStream would have to be maintained.  Since we dont actually write to a lock file
        /// We've opted to skip the stream and therefore DeleteOnClose.
        /// </remarks>
        /// </summary>
        /// <param name="aLockPath">aLockPath</param>
        public LockFile(string aLockPath, bool aLock = true)
        {
            // Immediately set the lock file path, as the combination of the path 
            // combined with the the actual lock file extension.
            LockFilePath = Path.Combine(aLockPath, LOCK_FILE);

            // GetLock
            if (aLock == true)
                GetLock();
        }

        /// <summary>
        /// Create a LockFile. Just creating the lock file does not *create* the lock file itself
        /// until the call to <c>GetLock()</c> is made.
        /// </summary>
        /// <param name="aLockPath"></param>
        public LockFile(string aLockPath)
            : this(aLockPath, false)
        { }

        /// <summary>
        /// Get a lock on the path that this LockFile was created with.
        /// <remarks>If the file is not locked (<c>.lock</c> does not exist) then 
        /// create a <c>.lock</c> file.
        /// <c>catch (DirectoryNotFoundException) { }</c> is not required since supertype
        /// <c>(IOException)</c> is already caught. All other exceptions are not caught *intentionally*.
        /// </remarks>
        /// </summary>
        public bool GetLock()
        {
            if (!IsLocked)
                try { File.Create(LockFilePath); }
                catch (IOException) { }
                catch (Exception ex) { throw new LockFileException("Unable to create lock file.", ex); }
            return IsLocked;
        }

        /// <summary>
        /// Remove the lock on the path that this LockFile was created with.
        /// <remarks>
        /// If the <c>.lock</c> file is present remove it.
        /// <c>catch (DirectoryNotFoundException) { }</c> is not required since supertype
        /// <c>(IOException)</c> is already caught. All other exceptions are not caught *intentionally*.
        /// </remarks>
        /// </summary>
        public bool RemoveLock()
        {
            if (IsLocked)
                try { File.Delete(LockFilePath); }
                catch (IOException) { }
                catch (Exception ex) { throw new LockFileException("Unable to remove lock file.", ex); }
            return !IsLocked;
        }

        /// <summary>
        /// Is this file path locked with a lock file?
        /// </summary>
        /// <returns><value>true - if lock exists</value></returns>
        public bool IsLocked
        {
            get { return File.Exists(LockFilePath); }
        }

        /// <summary>
        /// Disposes of this <see cref="LockFile"/> such that a lock wont be accidentally 
        /// persisted across several instances a the program.
        /// </summary>
        public void Dispose() { RemoveLock(); }

        /// <summary>
        /// The lock file path as represented by this lock file.
        /// </summary>
        private string LockFilePath { get; set; }

        /// <summary>
        /// The lock file is a file named ".lock".
        /// </summary>
        const string LOCK_FILE = ".lock";

        /// <summary>
        /// LockException
        /// </summary>
        public class LockFileException : Exception
        {
            /// <summary>
            /// Creates a new LockFileException
            /// </summary>
            public LockFileException() { }

            /// <summary>
            /// Creates a new LockFileException
            /// </summary>
            /// <param name="message">The message that describes the error.</param>
            public LockFileException(string message)
                : base(message) { }

            /// <summary>
            /// Creates a new LockFileException
            /// </summary>
            /// <param name="message">The message that describes the error</param>
            /// <param name="innerException">The inner exception of the error, the cause.</param>
            public LockFileException(string message, Exception innerException)
                : base(message, innerException) { }
        }
    }
}
