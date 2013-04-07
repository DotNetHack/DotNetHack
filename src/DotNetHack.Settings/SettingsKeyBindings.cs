using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Settings
{
    /// <summary>
    /// SettingsKeyBindings
    /// </summary>
    [Serializable]
    public class SettingsKeyBindings : SettingsGroup
    {
        /// <summary>
        /// SettingsKeyBindings
        /// </summary>
        public SettingsKeyBindings()
            : base("key_bindings") { }

        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            Serialization.Persisted.Write<SettingsKeyBindings>(this, FileName);
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <returns></returns>
        public SettingsKeyBindings Load()
        {
            return Serialization.Persisted.Read<SettingsKeyBindings>(FileName);
        }

        /// <summary>
        /// CharacterSheet
        /// </summary>
        public Keys CharacterSheet { get; set; }

        /// <summary>
        /// Inventory
        /// </summary>
        public Keys Inventory { get; set; }
    }
}
