using System;

namespace DotNetHack.Editor.Objects
{
    /// <summary>
    /// EditorObject
    /// </summary>
    public struct EditorObject
    {
        /// <summary>
        /// The filename of this editor object.
        /// </summary>
        public string FileName;

        /// <summary>
        /// Has this editor object been saved?
        /// </summary>
        public bool Saved;
    }
}
