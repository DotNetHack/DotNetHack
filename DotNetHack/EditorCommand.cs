using System;
using System.Xml.Serialization;

namespace DotNetHack
{
    /// <summary>
    /// EditorCommand
    /// </summary>
    [Serializable]
    public sealed class EditorCommand
    {
        /// <summary>
        /// Gets or sets the console key.
        /// </summary>
        /// <value>
        /// The console key.
        /// </value>
        [XmlAttribute]
        public ConsoleKey ConsoleKey { get; set; }

        /// <summary>
        /// Gets or sets the modifiers.
        /// </summary>
        /// <value>
        /// The modifiers.
        /// </value>
        [XmlAttribute]
        public ConsoleModifiers Modifiers { get; set; }
    }
}