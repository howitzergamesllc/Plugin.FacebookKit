
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Passed to openURL to indicate which default audience to use for sessions that post data to Facebook.
/// Certain operations such as publishing a status or publishing a photo require an audience. When the user
/// grants an application permission to perform a publish operation, a default audience is selected as the
/// publication ceiling for the application. This enumerated value allows the application to select which
/// audience to ask the user to grant publish permission for.
/// </summary>
public enum DefaultAudience
{
    /// <summary>
    /// This is the DefaultAudience setting.
    /// Indicates that the user’s friends are able to see posts made by the application
    /// </summary>
    Friends = 0,

    /// <summary>
    /// Indicates that only the user is able to see posts made by the application
    /// </summary>
    OnlyMe = 1,

    /// <summary>
    /// Indicates that all Facebook users are able to see posts made by the application
    /// </summary>
    Everyone = 2,

    /// <summary>
    /// The type was unknown. This could be an update to the facebook-ios-sdk.
    /// </summary>
    Unknown = -1,
}
