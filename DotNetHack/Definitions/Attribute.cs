﻿using System;
using System.Xml.Serialization;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{

    /// <summary>
    /// Attribute
    /// </summary>
    [Serializable]
    public sealed class Attribute : Id
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [XmlElement]
        public object Value { get; set; }
    }
}