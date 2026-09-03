
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Android only) Specifies the target app to use for logging in.
/// </summary>
public enum LoginTargetApp
{
    /// <summary>
    /// Log in requests will use facebook for authorization.
    /// This is the default authorization type for login buttons.
    /// </summary>
    Facebook,

    /// <summary>
    /// Log in requests will use instagram for authorization.
    /// </summary>
    Instagram,

    /// <summary>
    /// The target app is unknown.
    /// </summary>
    Unknown = -1,
}
