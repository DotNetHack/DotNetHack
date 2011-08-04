using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Events;

namespace DotNetHack.Game.Items.Equipment.Armour
{
    /// <summary>
    /// ArmourWorn
    /// </summary>
    [Serializable]
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
                if (TakeOff(WornArmour[aArmour.ArmourLocation], confirm))
                    WornArmour.Add(aArmour.ArmourLocation, aArmour);
            }
            else WornArmour.Add(aArmour.ArmourLocation, aArmour);
            
            // fire off events.
            if (OnFinishedDressingManeuver != null)
                OnFinishedDressingManeuver(this,
                    new EquipmentEventArgs<DressingActionType, IArmour>(
                    DressingActionType.PutOn, aArmour));
        }

        /// <summary>
        /// Take off a piece of worn armour.
        /// </summary>
        /// <param name="?"></param>
        public bool TakeOff(IArmour aArmour, bool confirm = true)
        {
            if (WornArmour.ContainsKey(aArmour.ArmourLocation))
            {
                if (RemoveArmourConfirm != null && confirm)
                {
                    if (RemoveArmourConfirm(
                        string.Format("Remove {0}?", aArmour.Name))) { }
                }
                else WornArmour.Remove(aArmour.ArmourLocation);

                // fire off events.
                if (OnFinishedDressingManeuver != null)
                    OnFinishedDressingManeuver(this,
                        new EquipmentEventArgs<DressingActionType, IArmour>(
                            DressingActionType.TakeOff, aArmour));

                return true;
            }

            if (OnFinishedDressingManeuver != null)
                OnFinishedDressingManeuver(this,
                    new EquipmentEventArgs<DressingActionType, IArmour>(
                        DressingActionType.Neither, aArmour));

            return false;
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
        /// occurs any time a dressing manuver occurs
        /// </summary>
        public event EventHandler<EquipmentEventArgs<DressingActionType,
            IArmour>> OnFinishedDressingManeuver;

        /// <summary>
        /// The type of dressing action type
        /// </summary>
        public enum DressingActionType { PutOn, TakeOff, Neither };

        /// <summary>
        /// The associative dictionary of worn Armour.
        /// </summary>
        
        [System.Xml.Serialization.XmlIgnore]
        public Dictionary<ArmourLocation, IArmour> WornArmour { get; set; }
    }
}

