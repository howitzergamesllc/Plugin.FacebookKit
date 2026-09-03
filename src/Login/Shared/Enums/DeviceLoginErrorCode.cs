
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Apple Only) Specifies error codes returned during device login operations.
/// </summary>
public enum DeviceLoginErrorCode
{
    /// <summary>
    /// Indicates that the device is polling too frequently.
    /// </summary>
    ExcessivePolling = 1349172,

    /// <summary>
    /// Indicates that the user declined to authorize the application.
    /// </summary>
    AuthorizationDeclined = 1349173,

    /// <summary>
    /// Indicates that the user has not yet authorized the application.
    /// Continue polling until authorization is completed or the request expires.
    /// </summary>
    AuthorizationPending = 1349174,

    /// <summary>
    /// Indicates that the device login code has expired.
    /// </summary>
    CodeExpired = 1349152,

    /// <summary>
    /// The type was unknown. This could be an update to the facebook-ios-sdk.
    /// </summary>
    Unknown = -1,
}