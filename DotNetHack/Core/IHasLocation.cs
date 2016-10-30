namespace DotNetHack.Core
{
    /// <summary>
    /// Any object that has a location
    /// </summary>
    public interface IHasLocation
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        Location Location { get; set; }
    }
}