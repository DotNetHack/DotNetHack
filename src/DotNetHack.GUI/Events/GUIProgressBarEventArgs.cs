using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Events
{
    /// <summary>
    /// GUIEventProgressBarEventArgs
    /// </summary>
    public class GUIProgressBarEventArgs : GUIEventArgs
    {
        /// <summary>
        /// GUIEventProgressBarEventArgs
        /// </summary>
        /// <param name="value"></param>
        public GUIProgressBarEventArgs(double newValue, double prevValue)
        {
            NewValue = newValue;
            PreviousValue = prevValue;
        }

        /// <summary>
        /// NewValue
        /// </summary>
        public double PreviousValue { get; private set; }

        /// <summary>
        /// NewValue
        /// </summary>
        public double NewValue { get; private set; }
    }
}
