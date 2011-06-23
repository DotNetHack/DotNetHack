using System;
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
        /// ParseArgs
        /// </summary>
        public static void ParseArgs(string[] argv) 
        {
            const string ARG__DEBUG = "-d";
            foreach (string s in argv)
                if (s.Equals(ARG__DEBUG))
                    R.IsDebug = true;
        }
	}
}

