using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Events
{
    /// <summary>
    /// GUISelectionEventArgs
    /// </summary>
    public class GUISelectionEventArgs : GUIEventArgs
    {
        /// <summary>
        /// GUISelectionEventArgs
        /// </summary>
        public GUISelectionEventArgs(SelectionEventType type)
        {
            Type = type;
        }

        /// <summary>
        /// Type
        /// </summary>
        public SelectionEventType Type { get; private set; }

        /// <summary>
        /// SelectionEventType
        /// </summary>
        public enum SelectionEventType { Selected, Deselected}
    }
}
