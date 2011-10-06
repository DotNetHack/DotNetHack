using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;
using System.Security;

namespace DotNetHack.Utility
{
    /// <summary>
    /// Reg
    /// </summary>
    public class Reg
    {
        /*
        public static bool SyncEnabled
        {
            // Definsively init things like this in the negative = )
            get { return Convert.ToBoolean(SoftwareKey.GetValue("SyncEnabled", false)); }
            set { SoftwareKey.SetValue("SyncEnabled", value); }
        }*/

        /// <summary>
        /// Reg
        /// </summary>
        public Reg(string aRegistryHome)
        {
            try
            {
                UserKey = Registry.CurrentUser;
                SoftwareKey = UserKey.CreateSubKey(aRegistryHome,
                    RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            catch (Exception ex) { throw new DNHackException("Registry exception", ex); }
        }

        #region Instance Fields

        /// <summary>
        /// UserKey
        /// </summary>
        public RegistryKey UserKey;

        /// <summary>
        /// SoftwareKey
        /// </summary>
        public  RegistryKey SoftwareKey;

        #endregion
    }
}
