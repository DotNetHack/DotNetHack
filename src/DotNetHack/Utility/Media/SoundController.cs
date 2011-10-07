using System;
using System.Collections.Generic;

namespace DotNetHack.Utility.Media
{
    /// <summary>
    /// SoundController
    /// Manages the interleaved playback of sounds for DotNetHack.
    /// <seealso cref="http://msdn.microsoft.com/en-us/library/ff650316.aspx"/>
    /// <seealso cref="http://opensebj.blogspot.com/2009/02/naudio-tutorial-2-mixing-multiple-wave.html"/>
    /// <remarks>Depends upon NAudio</remarks>
    /// </summary>
    public partial class SoundController : BaseSoundController
    {

        #region constructor

        /// <summary>
        /// Creates a new instance of sound conroller.
        /// <remarks>private to disallow creation outside of singleton-pattern specs.</remarks>
        /// </summary>
        SoundController() { }

        #endregion

        #region public facing properties

        /// <summary>
        /// The <c>accessor</c> for the singleton SoundController.
        /// <remarks>Interface with this object through here.</remarks>
        /// </summary>
        public static SoundController Instance
        {
            get
            {
                if (_instance == null)
                    lock (_syncRoot)
                        _instance = new SoundController();
                return _instance;
            }
        }

        #endregion

        #region static fields

        /// <summary>
        /// <c>the</c> singleton'ed instance
        /// </summary>
        private static volatile SoundController _instance;

        /// <summary>
        /// Aides in supporting multi-threaded access.
        /// </summary>
        private static object _syncRoot = new Object();

        #endregion
    }
}
