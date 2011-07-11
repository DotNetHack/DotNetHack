using System;
using System.IO;
namespace DotNetHack
{
    /// <summary>
    /// The RuntimeEnviornment is comprised of the various <c>settings</c> used
    /// at run-time. Debugging switches, directories, etc.
    /// </summary>
    public static class R
    {
        /// <summary>
        /// IsDebug can be used to determine if realtile debugging has been 
        /// enabled.  This is not to be confused with conditional compilation symbols.
        /// </summary>
        public static bool IsDebug { get; set; }

        /// <summary>
        /// The working directory for DNH.
        /// </summary>
        public static string WorkingDirectory { get; set; }

        /// <summary>
        /// ParseArgs
        /// </summary>
        public static void ParseArgs(string[] argv)
        {
            const string ARG__DEBUG = "-d";
            foreach (string s in argv)
                if (s.Equals(ARG__DEBUG))
                    R.IsDebug = true;
#if DEBUG
            // Until something better comes along.
            R.WorkingDirectory = "C:\\DNH\\";
            InitializePath(R.WorkingDirectory);
#endif
        }

        /// <summary>
        /// InitializePath.
        /// Initializes the working path for DNH.
        /// </summary>
        /// <param name="aPath">The path to initialize.</param>
        static bool InitializePath(string aFullPath)
        {
            try
            {
                if (!Directory.Exists(aFullPath))
                    Directory.CreateDirectory(aFullPath);
            }
            catch { return false; }
            return true;
        }
    }
}

