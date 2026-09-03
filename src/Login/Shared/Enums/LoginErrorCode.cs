
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Apple only) Custom error codes returned during login operations.
/// </summary>
public enum LoginErrorCode
{
    /// <summary>
    /// Reserved error code.
    /// </summary>
    Reserved = 300,

    /// <summary>
    /// Unknown login error.
    /// </summary>
    Unknown = 301,

    /// <summary>
    /// The user's password has changed and they must log in again.
    /// </summary>
    PasswordChanged = 302,

    /// <summary>
    /// The user must log in to Facebook to restore access.
    /// </summary>
    UserCheckpointed = 303,

    /// <summary>
    /// Permission request failed because the user changed.
    /// </summary>
    UserMismatch = 304,

    /// <summary>
    /// The user must confirm their Facebook account before logging in.
    /// </summary>
    UnconfirmedUser = 305,

    /// <summary>
    /// The system account integration is disabled.
    /// </summary>
    SystemAccountAppDisabled = 306,

    /// <summary>
    /// The system account store is unavailable.
    /// </summary>
    SystemAccountUnavailable = 307,

    /// <summary>
    /// The login response did not contain a valid challenge string.
    /// </summary>
    BadChallengeString = 308,

    /// <summary>
    /// The returned ID token was invalid.
    /// </summary>
    InvalidIdToken = 309,

    /// <summary>
    /// A required access token was missing.
    /// </summary>
    MissingAccessToken = 310
}