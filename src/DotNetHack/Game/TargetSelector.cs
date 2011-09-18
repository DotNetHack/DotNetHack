using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.NPC;

namespace DotNetHack.Game
{
    /// <summary>
    /// TargetSelector 
    /// <remarks>Used to select targets.</remarks>
    /// </summary>
    public class TargetSelector
    {
        /// <summary>
        /// Creates a new instance of TargetSelector
        /// </summary>
        /// <param name="aTargets"></param>
        public TargetSelector(IEnumerable<NonPlayerControlled> aTargets)
        {
            SelectTargets = aTargets.ToArray();
        }

        /// <summary>
        /// Gets the next target in the target selection schedule.
        /// </summary>
        /// <returns></returns>
        public NonPlayerControlled NextTarget()
        {
            if (index >= SelectTargets.Length) index = 0;
            SelectedTarget = SelectTargets[index++];
            return SelectedTarget;
        }

        /// <summary>
        /// If this target selector has targets.
        /// </summary>
        public bool HasTargets { get { return SelectTargets.Length > 0; } }

        /// <summary>
        /// SelectTargets
        /// </summary>
        NonPlayerControlled[] SelectTargets;

        /// <summary>
        /// The current SelectedTarget.
        /// </summary>
        NonPlayerControlled SelectedTarget { get; set; }

        /// <summary>
        /// The index of the selected target.
        /// </summary>
        int index = 0;
    }
}
