using System;

namespace DotNetHack.Editor.Objects
{
    /// <summary>
    /// EditorEntity
    /// </summary>
    internal struct EditorEntity
    {
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
    }
}