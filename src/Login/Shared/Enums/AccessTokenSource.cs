
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Android Only) Specifies the source of the <see cref="AccessToken"/>.
/// </summary>
public enum AccessTokenSource
{
    /// <summary>
    /// Indicates an access token has not been obtained, or is otherwise invalid.
    /// </summary>
    None,

    /// <summary>
    /// Indicates an access token was obtained by the user logging in through the Facebook app for Android using the web login dialog.
    /// </summary>
    FacebookAppWeb,

    /// <summary>
    /// Indicates an access token was obtained by the user logging in through the Facebook app for Android using the native login dialog.
    /// </summary>
    FacebookAppNative,

    /// <summary>
    /// Indicates an access token was obtained by asking the Facebook app for the current token based on permissions the user has already granted to the app. 
    /// No dialog was shown to the user in this case.
    /// </summary>
    FacebookAppService,

    /// <summary>
    /// Indicates an access token was obtained by the user logging in through the Web-based dialog.
    /// </summary>
    WebView,

    /// <summary>
    /// Indicates an access token was obtained by the user logging in through the Web-based dialog on a Chrome Custom Tab.
    /// </summary>
    ChromeCustomTab,

    /// <summary>
    /// Indicates an access token is for a test user rather than an actual Facebook user.
    /// </summary>
    TestUser,

    /// <summary>
    /// Indicates an access token constructed with a Client Token.
    /// </summary>
    ClientToken,

    /// <summary>
    /// Indicates an access token constructed from facebook.com/device
    /// </summary>
    DeviceAuth,

    /// <summary>
    /// Indicates an access token was obtained by the user logging in through the Instagram app for Android using the web login dialog.
    /// </summary>
    InstagramAppWeb,

    /// <summary>
    /// Indicates an access token was obtained by the user logging in to Instagram through the Web-based dialog on a Chrome Custom Tab.
    /// </summary>
    InstagramChromeTab,

    /// <summary>
    /// Indicates an access token was obtained by the user logging in to Instagram through the Web-based dialog.
    /// </summary>
    InstagramWebView,

    /// <summary>
    /// The source was unknown.
    /// </summary>
    Unknown = -1,
}
