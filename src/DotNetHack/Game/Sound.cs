using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

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
        public double DistanceTo(IHasLocation l) { return Location.Distance(l.Location); }
    }
}
