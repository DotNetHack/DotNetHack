using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using DotNetHack.Core;

namespace DotNetHack.Definitions
{
    // ******************************
    // ** alternative event schema **
    // ******************************
    // 
    //    public class EColl : IdCollection<Event>
    //    {
    //        
    //    }
    //
    //    [Serializable]
    //    public class Event : Id
    //    {
    //        [XmlAttribute]
    //        public string Id { get; set; }
    //
    //        [XmlElement]
    //        public string ScriptBlock { get; set; }
    //    }


    [Serializable]
    public sealed class EventCollection : IXmlSerializable
    {
        private readonly Dictionary<string, string> _events
            = new Dictionary<string, string>();

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string this[string name]
        {
            get
            {
                return _events.ContainsKey(name) ?
                    _events[name] : string.Empty;
            }
            set
            {
                if (_events.ContainsKey(name))
                {
                    _events[name] = value;

                    return;
                }

                _events.Add(name, value);
            }
        }

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                _events.Add(reader.Name, reader.Value);
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            foreach (var e in _events)
            {
                writer.WriteAttributeString(e.Key, e.Value);
            }
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var e in _events)
            {
                sb.AppendLine($"{e.Key}:{e.Value}");
            }

            return sb.ToString();
        }

        #endregion
    }
}