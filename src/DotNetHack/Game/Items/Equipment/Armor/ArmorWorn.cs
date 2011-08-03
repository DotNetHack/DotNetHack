using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Items.Equipment.Armour
{
    /// <summary>
    /// ArmourWorn
    /// </summary>
    public class ArmourWorn
    {
        /// <summary>
        /// Creates a new instance of worn armour.
        /// </summary>
        public ArmourWorn()
        {
            WornArmour = new Dictionary<ArmourLocation, IArmour>();
        }

        /// <summary>
        /// Puts on a piece of armour. Can possibily be interrupted with a 
        /// confirmation to remove a peice if that delegate is !null.
        /// </summary>
        /// <param name="aArmour">The peice of armour to put on</param>
        /// <returns></returns>
        public void PutOn(IArmour aArmour, bool confirm = true)
        {
            if (WornArmour.ContainsKey(aArmour.ArmourLocation))
            {
                if (RemoveArmourConfirm != null && confirm)
                {
                    if (RemoveArmourConfirm(string.Format("Remove {0}?", aArmour.Name)))
                        WornArmour.Remove(aArmour.ArmourLocation);
                }
                else 
                    WornArmour.Remove(aArmour.ArmourLocation);                
            }

            WornArmour.Add(aArmour.ArmourLocation, aArmour);

            OnFinishedDressingManeuver(this, new WearEventArgs(aArmour,
                WearEventArgs.DressingActionType.PutOn));
        }

        /// <summary>
        /// Take off a piece of worn armour.
        /// </summary>
        /// <param name="?"></param>
        public void TakeOff(IArmour aArmour, bool confirm = true)
        {
            if (WornArmour.ContainsKey(aArmour.ArmourLocation))
                WornArmour.Remove(aArmour.ArmourLocation);

            OnFinishedDressingManeuver(this, 
                new WearEventArgs(aArmour, WearEventArgs.DressingActionType.TakeOff));
        }

        /// <summary>
        /// Where, uses a predicate to return an enumeration.
        /// </summary>
        /// <param name="aPredicate">The predicate.</param>
        /// <returns>an enumeration that satisfies the predicate.</returns>
        public IEnumerable<IArmour> Where(Func<IArmour, bool> aPredicate) 
        {
            foreach (IArmour iArmour in WornArmour.Values)
                if (aPredicate(iArmour))
                    yield return iArmour;
        }

        /// <summary>
        /// Confirm delegate for remove armour.
        /// </summary>
        Input.Confirm RemoveArmourConfirm = null;

        /// <summary>
        /// Occurs when the dressing maneuver is complete.
        /// </summary>
        public event EventHandler<WearEventArgs> OnFinishedDressingManeuver;

        //public  FinishedDressingManeuver;

        /// <summary>
        /// Events arguments for a wear event
        /// </summary>
        public class WearEventArgs : EventArgs
        {
            /// <summary>
            /// Creates a new instance of wear event arguments
            /// </summary>
            /// <param name="aArmour">The armour involved</param>
            /// <param name="aType">The type of dressing maneuver</param>
            public WearEventArgs(IArmour aArmour, DressingActionType aType)
            {
                Armour = aArmour;
                ManeuverType = aType;
            }

            /// <summary>
            /// The type of dressing action type
            /// </summary>
            public enum DressingActionType { PutOn, TakeOff, Neither };

            /// <summary>
            /// DressingActionType
            /// </summary>
            public DressingActionType ManeuverType { get; set; }

            /// <summary>
            /// Armour
            /// </summary>
            public IArmour Armour { get; set; }
        }

        /// <summary>
        /// The associative dictionary of worn Armour.
        /// </summary>
        public Dictionary<ArmourLocation, IArmour> WornArmour { get; set; }
    }
}
