using System;

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
    internal struct EditorEntity
    {
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
        /// 
        /// </summary>
        public EditorEntityType EditorEntityType { get; private set; }
    }
}