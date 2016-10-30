namespace DotNetHack.Core
{
    /// <summary>
    /// Actor
    /// </summary>
    public class Actor : IHasLocation
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; set; }
    }
}