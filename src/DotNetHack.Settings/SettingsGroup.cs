using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotNetHack.Settings
{
    /// <summary>
    /// SettingsGroup is a group of similar settings
    /// </summary>
    [Serializable]
    public abstract class SettingsGroup
    {
        /// <summary>
        /// Supports serialization
        /// </summary>
        public SettingsGroup()
        {
        }

        /// <summary>
        /// Creates a new SettingsGroup
        /// </summary>
        public SettingsGroup(string groupName)
        {
            GroupName = groupName;
        }

        /// <summary>
        /// GroupName
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// SettingsExtension
        /// </summary>
        public const string SettingsExtension = ".dnh.settings";

        /// <summary>
        /// The file name for this group settings
        /// </summary>
        [XmlIgnore]
        public string FileName 
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Path.ChangeExtension(GroupName, SettingsExtension));
            }
        }
    }
}
