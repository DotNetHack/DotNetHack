using DotNetHack.Serialization;
using System;
using System.Collections.Generic;
using System.IO;

namespace DotNetHack.Shared.Objects
{
    /// <summary>
    /// EditorEntity
    /// <remarks>
    /// An editor entity if any high level editor object that can be saved:
    /// <list type="bullet">
    /// <item>TileSetMapping</item>
    /// <item>ScriptFile</item>
    /// </list>
    /// </remarks>
    /// </summary>
    public struct MetaEntity : IEquatable<MetaEntity>
    {
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="path">the path where the entities live</param>
        /// <param name="entities">the entities to load into</param>
        public static void Load()
        {
            if (File.Exists(MetaEntitiesFullPath))
                MetaEntities = Persisted.Read<List<MetaEntity>>(MetaEntitiesFullPath);
            else MetaEntities = new List<MetaEntity>();
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="path">the path where the entities file lives.</param>
        /// <param name="entities">entities to be saved</param>
        public static void Save()
        {
            MetaEntities.Write(MetaEntitiesFullPath);
        }

        /// <summary>
        /// EditorEntity
        /// </summary>
        /// <param name="fileName">the file name of this editor entity</param>
        public MetaEntity(MetaEntityType entityType, string fileName)
            : this()
        {
            MetaEntityType = entityType;
            FileName = fileName;
            LastUpdated = DateTime.Now;
            Saved = true;
        }

        /// <summary>
        /// Saved
        /// </summary>
        public bool Saved { get; set; }

        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// LastUpdated
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// EditorEntityType
        /// </summary>
        public MetaEntityType MetaEntityType { get; set; }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other">the other to compare to</param>
        /// <returns></returns>
        public bool Equals(MetaEntity other)
        {
            if (string.IsNullOrEmpty(this.FileName) ||
                string.IsNullOrEmpty(other.FileName))
                // TODO: Log for debugging purposes.
                return false;

            return this.FileName.Equals(other.FileName) &&
                this.MetaEntityType.Equals(other.MetaEntityType);
        }

        /// <summary>
        /// MetaEntities
        /// </summary>
        public static List<MetaEntity> MetaEntities = null;

        /// <summary>
        /// MetaEntitiesPath
        /// </summary>
        public static string MetaEntitiesPath
        {
            get { return Properties.Settings.Default.MetaEntitiesPath; }
            set
            {
                Properties.Settings.Default.MetaEntitiesPath = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// EntitiesFileName
        /// </summary>
        const string EntitiesFileName = "meta-entities.xml";

        /// <summary>
        /// MetaEntitiesFullPath
        /// </summary>
        public static string MetaEntitiesFullPath
        {
            get
            {
                return Path.Combine(MetaEntitiesPath, EntitiesFileName);
            }
        }
    }
}