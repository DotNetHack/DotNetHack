namespace DotNetHack
{
    /// <summary>
    /// ILocation
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// The x-coordinate
        /// </summary>
        /// <value>
        /// The x-coordinate
        /// </value>
        int X { get; }

        /// <summary>
        /// Gets the y-coordinate
        /// </summary>
        /// <value>
        /// The y-coordinate
        /// </value>
        int Y { get; }

        /// <summary>
        /// The z-coordinate
        /// </summary>
        /// <value>
        /// The z-coordinate
        /// </value>
        int Z { get; }
    }
}