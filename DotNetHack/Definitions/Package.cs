using System;
using System.IO;
using System.Xml.Serialization;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{
    [Serializable]
    public class Package : Id
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tile set.
        /// </summary>
        /// <value>
        /// The tile set.
        /// </value>
        public TileSet TileSet { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ItemDefs Items { get; set; }

        /// <summary>
        /// Gets or sets the maps.
        /// </summary>
        /// <value>
        /// The maps.
        /// </value>
        public MapDefs Maps { get; set; }

        /// <summary>
        /// The package serializer
        /// </summary>
        private static readonly XmlSerializer PackageSerializer = new XmlSerializer(typeof(Package));

        /// <summary>
        /// Saves the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void Save(string fileName)
        {
            using (var sr = new StreamWriter(File.OpenWrite(fileName)))
            {
                PackageSerializer.Serialize(sr, this);
            }
        }

        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static Package Load(string fileName)
        {
            using (var streamReader = new StreamReader(File.OpenRead(fileName)))
            {
                return PackageSerializer.Deserialize(streamReader) as Package;
            }
        }
    }
}