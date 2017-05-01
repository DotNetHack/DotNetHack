using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetHack.Core
{
    /// <summary>
    /// Glyph struct
    /// </summary>
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    public struct Glyph : IXmlSerializable, IEquatable<Glyph>
    {
        /// <summary>
        /// The empty glyph
        /// </summary>
        public static readonly Glyph Empty = new Glyph();

        /// <summary>
        /// Initializes a new instance of the <see cref="Glyph" /> struct.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="fg">The fg.</param>
        public Glyph(char g, ConsoleColor fg)
            : this(g, fg, ConsoleColor.Black)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Glyph" /> struct.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="fg">The fg.</param>
        /// <param name="bg">The bg.</param>
        public Glyph(char g, ConsoleColor fg, ConsoleColor bg)
        {
            G = g;
            FG = fg;
            BG = bg;
        }

        /// <summary>
        /// The background color
        /// </summary>
        /// <value>
        /// The bg.
        /// </value>
        public ConsoleColor BG { get; }

        /// <summary>
        /// The foreground color
        /// </summary>
        /// <value>
        /// The fg.
        /// </value>
        public ConsoleColor FG { get; }

        /// <summary>
        /// The symbol
        /// </summary>
        /// <value>
        /// The g.
        /// </value>
        public char G { get; }

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
            char g;
            char.TryParse(reader.GetAttribute("G"), out g);

            ConsoleColor fg;
            Enum.TryParse(reader.GetAttribute("FG"), out fg);

            ConsoleColor bg;
            Enum.TryParse(reader.GetAttribute("BG"), out bg);

            this = new Glyph(g, fg, bg);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("G", G.ToString());
            writer.WriteAttributeString("FG", FG.ToString());
            writer.WriteAttributeString("BG", BG.ToString());
        }

        #endregion

        #region Equality members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Glyph other)
        {
            return BG == other.BG && FG == other.FG && G == other.G;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. 
        /// </returns>
        /// <param name="obj">The object to compare with the current instance. </param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Glyph && Equals((Glyph)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)BG;
                hashCode = (hashCode * 397) ^ (int)FG;
                hashCode = (hashCode * 397) ^ G.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Glyph left, Glyph right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Glyph left, Glyph right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}