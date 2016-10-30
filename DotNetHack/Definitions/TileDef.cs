using System;
using System.Xml;
using System.Xml.Serialization;
using DotNetHack.Tools;

namespace DotNetHack.Definitions
{
    [Serializable]
    public class TileDef : IDef
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
        /// Gets or sets the glyph.
        /// </summary>
        /// <value>
        /// The glyph.
        /// </value>
        public Glyph Glyph { get; set; }
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public EventCollection Events { get; set; }
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public AttributeCollection Attributes { get; set; }

        /// <summary>
        /// Gets or sets the editor command for this definition
        /// </summary>
        /// <value>
        /// The editor command.
        /// </value>
        [XmlElement]
        public EditorCommand EditorCommand { get; set; }

        /// <summary>
        /// Gets or sets the script block.
        /// </summary>
        /// <value>
        /// The script block.
        /// </value>
        [XmlIgnore]
        public string ScriptBlock { get; set; }

        /// <summary>
        /// Gets or sets the script block c data.
        /// </summary>
        /// <value>
        /// The script block c data.
        /// </value>
        [XmlElement("ScriptBlock")]
        public XmlCDataSection ScriptBlockCData
        {
            get { return new XmlDocument().CreateCDataSection(ScriptBlock); }
            set { ScriptBlock = value.Value; }
        }
    }
}