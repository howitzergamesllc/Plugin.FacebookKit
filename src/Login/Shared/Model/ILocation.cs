
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents a location associated with a Facebook user profile.
/// </summary>
/// <remarks>
/// A location contains a unique identifier and a display name.
/// </remarks>
public interface ILocation
{
    /// <summary>
    /// Gets the unique identifier for the location.
    /// </summary>
    /// <value>
    /// The location identifier.
    /// </value>
    string? Id { get; }

    /// <summary>
    /// Gets the display name of the location.
    /// </summary>
    /// <value>
    /// The location name.
    /// </value>
    string? Name { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}