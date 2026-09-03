
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Provides methods for logging the user in and out.
/// It works directly with <see cref="IAccessToken"/> (for data access) and <see cref="IAuthenticationToken"/> (for authentication);
/// it sets the “current” tokens upon successful authorizations (or sets to null in case of <see cref="Logout"/>).
/// You should check <see cref="IAccessToken"/>.Current before calling a login method to see if there is
/// a cached token available (typically in a <see cref="Page.OnAppearing"/> implementation).
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item>Warning If you are managing your own tokens outside of <see cref="IAccessToken"/>, you will need to set
/// <see cref="IAccessToken"/>.Current before calling a login method to authorize further permissions on your tokens.</item>
/// </list>
/// </remarks>
public interface ILoginManager
{
    /// <summary>
    /// The login behavior of the login manager instance.
    /// </summary>
    LoginBehavior Behavior { get; set; }

    /// <summary>
    /// The default audience behavior of the login manager instance.
    /// </summary>
    DefaultAudience Audience { get; set; }
    
    /// <summary>
    /// Messenger page identifier associated with this request.
    /// </summary>
    string? MessengerPageId { get; set; }

    /// <summary>
    /// The authentication type behavior of the login manager instance.
    /// </summary>
    LoginAuthType AuthType { get; set; }
    
    /// <summary>
    /// (Apple only) The tracking  preference. Defaults to <see cref="LoginTracking.Enabled"/>.
    /// </summary>
    LoginTracking Tracking { get; set; }
    
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
    /// Logs the user in or authorizes additional permissions.
    /// Use this method when asking for permissions. You should only ask for permissions when they
    /// are needed and the value should be explained to the user. You can inspect the
    /// <see cref="ILoginResult.DeclinedPermissions"/> to provide more information
    /// to the user if they decline permissions.
    /// To reduce unnecessary login attempts, you should typically check if <see cref="IAccessToken"/>.Current
    /// already contains the permissions you need. If it does, you probably do not need to call this method.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>Warning You can only perform one login call at a time. Calling a login method before the completion handler is
    /// called on a previous login attempt will result in an error.</item>
    /// <item>Warning This method will present a UI to the user and thus should be called on the main thread.</item>
    /// </list>
    /// </remarks>
    /// <param name="configuration">Configuration the login configuration to use.</param>
    /// <returns>A asynchronous task that completes with a <see cref="ILoginResult"/> instance.</returns>
    Task<ILoginResult> LoginAsync(LoginConfiguration configuration);
    
    /// <summary>
    /// Logs the user in or authorizes additional permissions.
    /// Use this method when asking for read permissions. You should only ask for permissions when they
    /// are needed and explain the value to the user. You can inspect the <see cref="LoggedInEventArgs"/>
    /// for <see cref="ILoginResult.DeclinedPermissions"/> to provide more information to the user if they decline permissions.
    /// You typically should check if <see cref="IAccessToken"/>.Current already contains the permissions you need before
    /// asking to reduce unnecessary login attempts. For example, you could perform that check in <see cref="Page.OnAppearing"/>
    /// <remarks>
    /// <list type="bullet">
    /// <item>Warning You can only perform one login call at a time. Calling a login method before the completion handler is
    /// called on a previous login attempt will result in an error.</item>
    /// <item>Warning This method will present a UI to the user and thus should be called on the main thread.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <param name="permissions">permissions the optional array of permissions. Note this is converted to NSSet and is only</param>
    /// <returns>A asynchronous task that completes with an <see cref="ILoginResult"/> instance</returns>
    Task<ILoginResult> LoginAsync(IEnumerable<string> permissions);

    /// <summary>
    /// Requests user’s permission to reathorize application’s data access, after it has expired due to inactivity.
    /// Use this method when you need to reathorize your app’s access to user data via the Graph API.
    /// You should only call this after access has expired.
    /// You should provide as much context to the user as possible as to why you need to reauthorize the access, the
    /// scope of access being reathorized, and what added value your app provides when the access is reathorized.
    /// You can inspect the <see cref="LoggedInEventArgs"/> for <see cref="ILoginResult.DeclinedPermissions"/> to provide 
    /// more information to the user if they decline permissions.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>(Apple Only) Warning This method will reauthorize using a <see cref="LoginConfiguration"/> with <see cref="LoginTracking.Enabled"/>.</item>
    /// <item>Warning This method will present UI the user. You typically should call this if <see cref="IAccessToken.IsDataAccessExpired"/> is true.</item>
    /// </list>
    /// </remarks>
    /// <returns>An asynchronous task that completes with a <see cref="ILoginResult"/></returns>
    Task<ILoginResult> ReauthorizeDataAccessAsync();

    /// <summary>
    /// Logs the user out
    /// This nulls out the singleton instances of <see cref="IAccessToken"/>, <see cref="IAuthenticationToken"/> and <see cref="IProfile"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>Note This is only a client side logout. It will not log the user out of their Facebook account</item>
    /// </list>
    /// </remarks>
    void Logout();

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}
