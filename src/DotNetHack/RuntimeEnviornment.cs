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
        /// Static .ctor
        /// </summary>
        static R() { Random = new Random(); }

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
            R.WorkingDirectory = @"..\..\..\..\";

            InitializePath(R.WorkingDirectory);
            InitializePath(R.DatDirectory);
            InitializePath(R.DatSoundsDirectory);
#endif
        }

        public static string DatSoundsDirectory
        {
            get { return Path.Combine(DatDirectory, DAT_SOUNDS_FOLDER); }
        }

        public static string DatDirectory
        {
            get { return Path.Combine(WorkingDirectory, DAT_FOLDER); }
        }

        public static string MonsterFile
        {
            get { return Path.Combine(DatDirectory, DAT_MONSTERS); }
        }

        public static string ExceptionFile
        {
            get { return Path.Combine(DatDirectory, LOG_EXCEPTION); }
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

        const string DAT_FOLDER = "dat";
        const string DAT_SOUNDS_FOLDER = "sounds";
        const string DAT_MONSTERS = "monsters.dat";
        const string LOG_EXCEPTION = "exceptions.log";

        /// <summary>
        /// Random
        /// </summary>
        public static Random Random { get; set; }
    }
}

