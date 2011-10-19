using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Utility.Media;

namespace DotNetHack.Game
{
    /// <summary>
    /// Sound
    /// 
    /// 1dB  -  Not noticable
    /// 3dB  -  Barely noticeable
    /// 5dB  -  Clearly noticeable change
    /// 10dB  -  About twice as loud
    /// 20dB  -  About four times as loud
    /// 
    /// Aircraft at take-off (180)
    /// Fireworks (140)
    /// Snowmobile (120)
    /// Chain saw (110)
    /// Amplified music (110)
    /// Lawn mower (90)
    /// Noisy office (90)
    /// Vacuum cleaner (80)
    /// City traffic (80)
    /// Normal conversation (60)
    /// Refrigerator humming (40)
    /// Whisper (20)
    /// Leaves rustling (10)
    /// Calm breathing (10)
    /// 
    /// A clap of thunder from a nearby storm (120 dB) or a 
    /// gunshot (140-190 dB, depending on weapon), can both cause immediate damage.
    /// </summary>
    public class Sound : IHasLocation
    {

        /// <summary>
        /// 
        /// </summary>
        public static void DoSound(SoundEventType aSoundEventType)
        {
            string strSound = "";
            switch (aSoundEventType)
            {
                case SoundEventType.AlchemyPotionCreate:
                    strSound = "alchemy_create_001"; break;
                case SoundEventType.QuaffPotion:
                    strSound = "quaff_potion_001"; break;
                case SoundEventType.DropMetalArmour:
                    strSound = "armour_drop_001"; break;
                case SoundEventType.EquipMetalArmour:
                    strSound = "armour_drop_001"; break;
                case SoundEventType.FootStepHumanoid:
                    strSound = ""; break;
                case SoundEventType.SheathBluntWeapon:
                    strSound = "shield_drop_001"; break;
                case SoundEventType.WieldBluntWeapon:
                    strSound = "pickup_mace_001"; break;
                case SoundEventType.TrapTriggered:
                    strSound = "trap_trigger_001"; break;
                case SoundEventType.WieldLongSword:
                    strSound = "wield_longsword_001"; break;
                case SoundEventType.DropBladedWeapon:
                    strSound = "weapon_drop_001"; break;
                case SoundEventType.DropBluntWeapon:
                    strSound = "drop_blunt_weapon_001"; break;
                case SoundEventType.WieldShortSowrd:
                    strSound = "blacksmith_001"; break;
                case SoundEventType.PickupKey:
                    strSound = "pickup_key_001"; break;
                case SoundEventType.OpenLockedDoor:
                    strSound = "open_door_locked_001"; break;
                case SoundEventType.LowHealthIndicator:
                    strSound = "heart_beating_001"; break;
            }

            strSound += ".wav";

            if (!string.Empty.Equals(strSound))
                SoundController.Instance.PlaySound(strSound);
        }

        /// <summary>
        /// <remarks>
        /// Naming Convention:
        ///     "verb-class" - most descriptive attribute
        ///     "subclass" - secondary attribute
        /// </remarks>
        /// </summary>
        public enum SoundEventType
        {
            PickupKey,
            OpenLockedDoor,
            QuaffPotion,
            AlchemyPotionCreate,
            FootStepHumanoid,
            WieldLongSword,
            WieldShortSowrd,
            WieldBluntWeapon,
            SheathBluntWeapon,
            DropBluntWeapon,
            DropMetalArmour,
            DropBladedWeapon,
            EquipMetalArmour,
            TrapTriggered,
            LowHealthIndicator,
        }

        /// <summary>
        /// A sound
        /// </summary>
        /// <param name="aSource">The source of the sound</param>
        /// <param name="aDecibels">The magnitude of the sound.</param>
        public Sound(IHasLocation aSource, int aDecibels, string aDescription,
            bool aAmbient = false)
        {
            Location = aSource.Location;
            SoundDecibels = aDecibels;
            SoundDescription = aDescription;
            IsSoundAmbient = aAmbient;
        }

        /// <summary>
        /// An ambient sound
        /// </summary>
        /// <param name="aDecibels">db</param>
        /// <param name="aDescription">description</param>
        public Sound(int aDecibels, string aDescription)
        {
            IsSoundAmbient = true;
            SoundDecibels = aDecibels;
            SoundDescription = aDescription;
            Location = Location3i.Origin3i;
        }

        /// <summary>
        /// if the sound is ambient.
        /// </summary>
        public bool IsSoundAmbient { get; set; }

        /// <summary>
        /// the magnitude or loudness of the sound.
        /// </summary>
        public int SoundDecibels { get; set; }

        /// <summary>
        /// the sound description
        /// </summary>
        public string SoundDescription { get; set; }

        /// <summary>
        /// the source of the sound
        /// </summary>
        public Location3i Location { get; set; }

        /// <summary>
        /// DistanceTo
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public double DistanceTo(IHasLocation l)
        {
            if (l == null)
                return 0D;
            else if (l.Location == null)
                return 0D;
            return Location.Distance(l.Location);
        }
    }
}
