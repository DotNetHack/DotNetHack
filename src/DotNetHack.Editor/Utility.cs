
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Editor
{
    /// <summary>
    /// Utility
    /// </summary>
    internal static class Utility
    {
        /// <summary>
        /// RecentTileSetMappings
        /// </summary>
        /// <returns></returns>
        internal static List<string> RecentTileSetMappings()
        {
            List<string> tmpReturn = new List<string>(Properties.Settings.Default.RecentTileSets.Count);

            if (Properties.Settings.Default.RecentTileSets == null)
            {
                Properties.Settings.Default.RecentTileSets = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }

            foreach(string s in Properties.Settings.Default.RecentTileSets)
                tmpReturn.Add(s);

            return tmpReturn;
        }
    }
}
