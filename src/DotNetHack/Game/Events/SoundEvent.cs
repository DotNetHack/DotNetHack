using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;

namespace DotNetHack.Game.Events
{
    /// <summary>
    /// SoundEventArgs
    /// <remarks>If a tree falls in the forest does anyone hear it?</remarks>
    /// </summary>
    public class SoundEventArgs : GameEventArgs, IHasLocation
    {
        /// <summary>
        /// Create a new instance of sound event arguments
        /// </summary>
        /// <param name="aSound"></param>
        public SoundEventArgs(Sound aSound) { Sound = aSound; }

        /// <summary>
        /// The sound tied to this event.
        /// </summary>
        public Sound Sound { get; set; }

        /// <summary>
        /// Decibels
        /// </summary>
        public int Decibels { get { return Sound.SoundDecibels; } }

        /// <summary>
        /// The description of the sound.
        /// </summary>
        public string Description { get { return Sound.SoundDescription; } }

        /// <summary>
        /// The location of the sound.
        /// </summary>
        public Location3i Location 
        {
            get { return Sound.Location; }
            set { Sound.Location = value; }
        }
    }
}
