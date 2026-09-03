
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (iOS use only) Provides information returned when starting a device login flow.
/// This information is used to display the login code and continue polling
/// until the user completes authorization.
/// </summary>
public interface IDeviceLoginCodeInfo
{
    /// <summary>
    /// Gets the unique identifier for this login flow.
    /// </summary>
    string Identifier { get; }

    /// <summary>
    /// Gets the short user code that should be presented to the user.
    /// </summary>
    string LoginCode { get; }

    /// <summary>
    /// Gets the verification URL where the user can enter the login code.
    /// </summary>
    Uri? VerificationUrl { get; }

    /// <summary>
    /// Gets the date and time when the login code expires.
    /// </summary>
    DateTimeOffset ExpirationDate { get; }

    /// <summary>
    /// Gets the interval between polling requests while waiting for authorization.
    /// </summary>
    TimeSpan PollingInterval { get; }

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}