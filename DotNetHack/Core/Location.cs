using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetHack.Core
{
    /// <summary>
    /// Location
    /// </summary>
    /// <seealso cref="System.Xml.Serialization.IXmlSerializable" />
    [Serializable]
    public struct Location : IXmlSerializable, ILocation
    {
        #region instance fields

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Gets the origin.
        /// </summary>
        /// <value>
        /// The origin.
        /// </value>
        public static readonly Location Origin  = new Location();

        #region properties

        /// <summary>
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public int Z { get; }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y { get; }

        /// <summary>
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X { get; }

        #endregion

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            int x, y, z;

            int.TryParse(reader.GetAttribute("X"), out x);
            int.TryParse(reader.GetAttribute("Y"), out y);
            int.TryParse(reader.GetAttribute("Z"), out z);

            this = new Location(x, y, z);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("X", X.ToString());
            writer.WriteAttributeString("Y", Y.ToString());
            writer.WriteAttributeString("Z", Z.ToString());
        }

        #endregion

        #region Equality members

        public bool Equals(Location other)
        {
            return Z == other.Z && Y == other.Y && X == other.X;
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
            return obj is Location && Equals((Location)obj);
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
                var hashCode = Z;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ X;
                return hashCode;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Distances the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static double Distance(Location a, Location b)
        {
            var xSq = Math.Pow(b.X - a.X, 2);
            var ySq = Math.Pow(b.Y - b.Y, 2);
            var zSq = Math.Pow(b.Y - b.Z, 2);

            return Math.Sqrt(xSq + ySq + zSq);
        }

        /// <summary>
        /// Distances the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns></returns>
        public double Distance(Location a)
        {
            return Distance(this, a);
        }

        #endregion

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }

        /// <summary>
        /// Offsets the specified x offset.
        /// </summary>
        /// <param name="xOffset">The x offset.</param>
        /// <param name="yOffset">The y offset.</param>
        /// <param name="zOffset">The z offset.</param>
        public Location Offset(int xOffset, int yOffset, int zOffset)
        {
            return this = new Location(X + xOffset, Y + yOffset, Z + zOffset);
        }
    }
}