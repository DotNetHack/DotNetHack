using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DotNetHack.Utility.Media
{
    /// <summary>
    /// BaseSoundController
    /// </summary>
    public abstract class BaseSoundController
    {

        /// <summary>
        /// Initialize
        /// </summary>
        public virtual void Initialize()
        {
            if (OnSoundControllerInit != null)
                OnSoundControllerInit(this, new EventArgs());
        }

        /// <summary>
        /// Play
        /// </summary>
        public virtual void PlaySound(string aSoundFileName)
        {
            if (OnSoundPlayback != null)
                OnSoundPlayback(this, new EventArgs());
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Stop() 
        {
        
        }

        /// <summary>
        /// OnSoundPlayback
        /// </summary>
        protected event EventHandler OnSoundPlayback;

        /// <summary>
        /// Occurs when the sound controller is initialized.
        /// </summary>
        protected event EventHandler OnSoundControllerInit;

        /// <summary>
        /// OnSoundControllerInitFail
        /// </summary>
        protected event ErrorEventHandler OnSoundControllerInitFail;
    }
}
