
namespace Plugin.FacebookKit.Login;

/// <summary>
/// The login behavior preference to use for a login attempt.
/// Login behavior allows users to control how the app logs in.
/// </summary>
/// <remarks>
/// iOS uses AppSwitch Enabled or Disabled which is equivalent to a native login behavior. 
/// To disable AppSwitch select the following types.
/// <list type="bullet">
/// <item>DialogOnly</item>
/// <item>WebOnly</item>
/// </list>
/// All other types will default to enabling AppSwitch.
/// </remarks>
public enum LoginBehavior
{
    /// <summary>
    /// Specifies that login should attempt login in using a native app in the Facebook Family of Apps, and if that does not work, fall back to web dialog auth. This is the default behavior.
    /// </summary>
    /// <remarks>
    /// On iOS, sets AppSwitch = <c>true</c>.
    /// </remarks>
    NativeWithFallback = 0,

    /// <summary>
    /// Specifies that login should only attempt to login using a native app in the Facebook Family of Apps. If the native app cannot be used, then the login fails.
    /// </summary>
    /// <remarks>
    /// On iOS, sets AppSwitch = <c>true</c>.
    /// </remarks>
    NativeOnly = 1,
    
    /// <summary>
    /// Specifies that login should only attempt to use Katana Proxy Login.
    /// </summary>
    /// <remarks>
    /// On iOS, sets AppSwitch = <c>true</c>.
    /// </remarks>
    KatanaOnly = 2,
    
    /// <summary>
    /// Specifies that only the web dialog auth should be used.
    /// </summary>
    /// <remarks>
    /// On iOS, sets AppSwitch = <c>false</c>.
    /// </remarks>
    WebOnly = 3,

    /// <summary>
    /// Specifies that only the web dialog auth (from anywhere) should be used
    /// </summary>
    /// <remarks>
    /// On iOS, sets AppSwitch = <c>false</c>.
    /// </remarks>
    DialogOnly = 4,

    /// <summary>
    /// Specifies that device login authentication flow should be used. Use it via ({@link com.facebook.login.widget.DeviceLoginButton DeviceLoginButton} or ({@link com.facebook.login.DeviceLoginManager DeviceLoginManager} to authenticate.
    /// </summary>
    /// <remarks>
    /// On iOS, sets AppSwitch = <c>true</c>.
    /// </remarks>
    DeviceAuth = 5,

    /// <summary>
    /// The type was unknown. This could be an update to the facebook-ios-sdk.
    /// </summary>
    /// <remarks>
    /// On iOS, sets AppSwitch = <c>true</c>.
    /// </remarks>
    Unknown = -1,
}