
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents the user's age range information returned by Facebook.
/// </summary>
/// <remarks>
/// The age range may contain only a minimum age, only a maximum age,
/// or both values. A missing value indicates that Facebook did not
/// provide that boundary.
/// </remarks>
public interface IAgeRange
{
    /// <summary>
    /// Gets the minimum age for the user, if specified.
    /// </summary>
    /// <value>
    /// The minimum age as a positive integer; otherwise, <see langword="null"/>.
    /// </value>
    int? Min { get; }

    /// <summary>
    /// Gets the maximum age for the user, if specified.
    /// </summary>
    /// <value>
    /// The maximum age as a positive integer; otherwise, <see langword="null"/>.
    /// </value>
    int? Max { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}