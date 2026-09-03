
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Apple Only) Defines the errors that can occur while refreshing a Limited Login session.
/// </summary>
public enum LimitedLoginRefreshErrorCode
{
    /// <summary>
    /// No current authentication token exists for a Limited Login session.
    /// </summary>
    NoCurrentToken = 0,

    /// <summary>
    /// The current session is not a Limited Login session.
    /// </summary>
    NotLimitedLogin,

    /// <summary>
    /// The existing Facebook session has expired and the user must log in again.
    /// </summary>
    LoginRequired,

    /// <summary>
    /// Additional user consent is required before refreshing the session.
    /// </summary>
    ConsentRequired,

    /// <summary>
    /// The refreshed token belongs to a different user than the current session.
    /// </summary>
    UserMismatch,

    /// <summary>
    /// A network error prevented the refresh request from completing.
    /// </summary>
    NetworkError,

    /// <summary>
    /// The refresh request exceeded the allowed timeout period.
    /// </summary>
    Timeout,

    /// <summary>
    /// Refresh attempts are currently being throttled by the client.
    /// </summary>
    RateLimited,

    /// <summary>
    /// The server returned an invalid or unexpected refresh response.
    /// </summary>
    InvalidResponse,

    /// <summary>
    /// The user cancelled an interactive authentication flow.
    /// </summary>
    Cancelled,

    /// <summary>
    /// Limited Login refresh is disabled by a server-side feature flag.
    /// </summary>
    FeatureDisabled,

    /// <summary>
    /// The current platform does not support the required refresh mechanism.
    /// </summary>
    UnsupportedPlatform,

    /// <summary>
    /// The current token does not contain the required DPoP binding information.
    /// </summary>
    NotDpopBound,

    /// <summary>
    /// The SDK could not create or retrieve the DPoP key required for refresh.
    /// </summary>
    DpopKeyGenerationFailed,

    /// <summary>
    /// An unknown error occurred during Limited Login refresh.
    /// </summary>
    Unknown
}
