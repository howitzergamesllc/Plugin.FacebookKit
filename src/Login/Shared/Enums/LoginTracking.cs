
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Apple Only) Specifies the login tracking mode to use for a login attempt.
/// <para>
/// <see cref="Enabled"/> performs the standard Facebook Login flow.
/// </para>
/// <para>
/// <see cref="Limited"/> performs the Limited Login flow, which provides
/// enhanced privacy protections and returns an authentication token instead
/// of a traditional access token.
/// </para>
/// </summary>
public enum LoginTracking
{
    /// <summary>
    /// Uses the standard Facebook Login flow.
    /// </summary>
    Enabled = 0,

    /// <summary>
    /// Uses the Limited Login flow.
    /// </summary>
    Limited = 1,

    /// <summary>
    /// The type was unknown. This could be an update to the facebook-ios-sdk.
    /// </summary>
    Unknown = -1,
}
