
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Specifies the type of login authorization request.
/// </summary>
public enum LoginAuthType
{
    /// <summary>
    /// Requests previously declined permissions.
    /// This is the default authorization type for login buttons.
    /// </summary>
    Rerequest,

    /// <summary>
    /// Requests permissions when the user's data access has expired.
    /// </summary>
    Reauthorize,

    /// <summary>
    /// The type was unknown. This could be an update to the facebook-ios-sdk.
    /// </summary>
    Unknown = -1,
}
