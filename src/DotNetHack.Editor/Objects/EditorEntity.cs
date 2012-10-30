using DotNetHack.Serialization;
using System;
using System.IO;

namespace DotNetHack.Editor.Objects
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
    public struct EditorEntity
    {
        /// <summary>
        /// EditorEntity
        /// </summary>
        /// <param name="fileName">The list of editor entities to load</param>
        /// <returns>An array of editor entities.</returns>
        public static void Load(out EditorEntity[] entities)
        {
            if (File.Exists(EntitiesFileName))
            {
                entities = Persisted.Read<EditorEntity[]>(EntitiesFileName);
            }
            else
            {
                entities = default(EditorEntity[]);
            }
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="entities">entities to be saved</param>
        public static void Save(ref EditorEntity[] entities)
        {
            entities.Write(EntitiesFileName);
        }

        /// <summary>
        /// EditorEntity
        /// </summary>
        /// <param name="fileName">the file name of this editor entity</param>
        public EditorEntity(EditorEntityType entityType, string fileName)
            : this()
        {
            EditorEntityType = entityType;
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
        public EditorEntityType EditorEntityType { get; set; }

        /// <summary>
        /// EntitiesFileName
        /// </summary>
        const string EntitiesFileName = "editor-entities.xml";
    }
}