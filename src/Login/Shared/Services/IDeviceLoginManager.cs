
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Use this class to perform a device login flow.
/// </summary>
/// <remarks>
/// <para>
/// Android's DeviceLoginManager essentially extends LoginManager with a RedirectUri. <see cref="Start"/> 
/// calls the same Login method as LoginManager synchronously. The <see cref="Completed"/> event
/// can be subscribed to for a <see cref="ILoginResult"/>.
/// </para>
/// <para>
/// The device login flow starts by requesting a code from the device login API.
/// This class informs the delegate when this code is received. You should then present the
/// code to the user to enter. In the meantime, this class polls the device login API
/// periodically and informs the delegate of the results.
/// See <a href="https://developers.facebook.com/docs/facebook-login/for-devices">Facebook Device Login</a>.
/// </para>
/// </remarks>
public interface IDeviceLoginManager
{
    /// <summary>
    /// Gets the permissions requested by this device login flow.
    /// </summary>
    IReadOnlyList<string> Permissions { get; set; }

    /// <summary>
    /// The optional URL to redirect the user to after they complete the login.
    /// The URL must be configured in your App Settings -> Advanced -> OAuth Redirect URIs
    /// </summary>
    Uri? RedirectUrl { get; set; }

    /// <summary>
    /// Starts and completes the device login flow
    /// This instance will retain self until the flow is finished or cancelled.
    /// </summary>
    /// <remarks>
    /// <para>NOTE: On android, <see cref="IDeviceLoginManager"/> inherits <see cref="ILoginManager"/> so this call was abstracted
    /// to use ILoginManager.Login syncronously instead of LoginAsync.</para>
    /// Subscribe to <see cref="Completed"/> to receive <see cref="ILoginResult"/>'s.
    /// </remarks>
    void Start();

    /// <summary>
    /// (Apple Only) Attempts to cancel the device login flow.
    /// </summary>
    void Cancel();

    /// <summary>
    /// Raised when the device code is received and should be presented to the user.
    /// </summary>
    event EventHandler<DeviceLoginStartedEventArgs>? Started;

    /// <summary>
    /// Raised when login completes successfully.
    /// </summary>
    event EventHandler<LoggedInEventArgs>? Completed;

    /// <summary>
    /// (Android only) Target user id for the device request, if any.
    /// </summary>
    string? DeviceAuthenticationUserTargetId { get; set; }

    /// <summary>
    /// (Android only) The login behavior of the login manager instance.
    /// </summary>
    LoginBehavior Behavior { get; set; }

    /// <summary>
    /// (Android only) The default audience behavior of the login manager instance.
    /// </summary>
    DefaultAudience Audience { get; set; }
    
    /// <summary>
    /// (Android only) The authentication type behavior of the login manager instance.
    /// </summary>
    LoginAuthType AuthType { get; set; }

    /// <summary>
    /// (Android only) The authentication type behavior of the login manager instance.
    /// </summary>
    LoginTargetApp TargetApp { get; set; }

    /// <summary>
    /// (Android only) Determines whether we are using the cross Family of Apps login experience.
    /// </summary>
    bool IsFamilyLogin { get; set; }

    /// <summary>
    /// (Android only) Determines if we should skip deduplicating account during x-FoA login.
    /// </summary>
    bool ShouldSkipAccountDeduplication { get; set; }

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}