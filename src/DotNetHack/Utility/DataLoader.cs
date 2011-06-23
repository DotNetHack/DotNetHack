using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Items.Equipment.Weapons;
using System.IO;

namespace DotNetHack.Utility
{
    /// <summary>
    /// DatLoader
    /// </summary>
    public class DataLoader
    {
        /// <summary>
        /// Creates a new instance of DatLoader
        /// <param name="aDataPath">The path where data files are stored.</param>
        /// </summary>
        public DataLoader(string aDataPath)
        {
            DataPath = aDatPath;
        }

        /// <summary>
        /// LoadWeapons
        /// </summary>
        /// <returns></returns>
        public Weapon[] LoadWeapons() 
        {
            const string WEAPON_XML = "weapons.xml";
            string weaponDataFullPath = Path.Combine(DataPath, WEAPON_XML);
            if (!File.Exists(weaponDataFullPath))
                throw new ApplicationException();
        }

        /// <summary>
        /// DatPath
        /// </summary>
        public string DataPath { get; set; }
    }
}
