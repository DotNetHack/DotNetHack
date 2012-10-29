using System;
using System.Collections.Generic;
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
        /// LoadRecentTileSetMappings
        /// </summary>
        /// <param name="parent">the parent toolstrip menu item</param>
        /// <param name="action">the action that occurs when it's clicked.</param>
        internal static void LoadRecentTileSetMappings(ToolStripMenuItem parent, Action<string> action)
        {
            #region Recent TileSets

            if (Properties.Settings.Default.RecentTileSets == null)
            {
                Properties.Settings.Default.RecentTileSets = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.Save();
            }
            else
            {
                foreach (string s in Properties.Settings.Default.RecentTileSets)
                {
                    ToolStripMenuItem tmpNewMenuItem = new ToolStripMenuItem(s);
                    tmpNewMenuItem.Click += (object senderInner, EventArgs eInner) => { action(s); };
                    parent.DropDownItems.Add(tmpNewMenuItem);
                }
            }

            #endregion
        }
    }
}
