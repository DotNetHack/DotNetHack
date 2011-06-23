using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetHack.Game.Interfaces;
using DotNetHack.Game.Items;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DotNetHack.Game.Monsters;

namespace DotNetHack.Game
{
    /*
    public static class WorldExtensions
    {
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="aWorldFile">aWorldFile</param>
        /// <returns></returns>
        public static World Load(string aWorldFile)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (FileStream tmpRawStream = File.Open(aWorldFile, FileMode.Open))
                return (World)binFormatter.Deserialize(tmpRawStream);
        }

        /// <summary>
        /// SaveAs
        /// </summary>
        public static bool SaveAs(this World aWorld, string aWorldFile)
        {
            try
            {
                // Create a new binary formatter
                BinaryFormatter binFormatter = new BinaryFormatter();

                using (FileStream tmpRawStream = File.Open(aWorldFile, FileMode.OpenOrCreate))
                    binFormatter.Serialize(tmpRawStream, aWorld);

                return true;
            }
            catch { return false; }
        }
    }
    
    /// <summary>
    /// World
    /// </summary>
    [Serializable]
    public class World : Dungeon
    {
        /// <summary>
        /// World
        /// </summary>
        World() { }

        // public DistantLocation

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static World GetInstance()
        {
            if (_instance == null)
                _instance = new World();

            return _instance;
        }

        public static World _instance;
    }*/
}
