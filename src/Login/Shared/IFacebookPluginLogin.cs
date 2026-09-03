
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Manages the global FacebookLogin state, monitors notfication changes for <see cref="IAccessToken"/> and <see cref="IProfile"/> 
/// (only if <see cref="AutomaticallyUpdateProfileOnAccessTokenChange"/> is <c>true</c>), provides methods to create
/// <see cref="ILoginManager"/> and <see cref="IDeviceLoginManager"/>.
/// </summary>
public interface IFacebookPluginLogin : IDisposable
{
	/// <summary>
	/// An event that fires whenever the <see cref="IAccessToken"/> changes. (Refreshes, expires, etc.)
	/// </summary>
	event EventHandler<AccessTokenChangedEventArgs>? AccessTokenChanged;

	/// <summary>
	/// An event that fires whenever the <see cref="IProfile"/> changes. (i.e. Login/Logout)
	/// </summary>
    event EventHandler<ProfileChangedEventArgs>? ProfileChanged;

	/// <summary>
	/// Indicates whether the current <see cref="IProfile"/> will automatically observe access token changes.
	/// </summary>
	bool AutomaticallyUpdateProfileOnAccessTokenChange { get; set; }

	/// <summary>
	/// The `currentAccessToken` is a convenient representation of the token of the
	/// current user and is used by other SDK components (like <see cref="ILoginManager"/>)
	/// </summary>
	IAccessToken? CurrentAccessToken { get; }

	/// <summary>
	///  Refresh the current access token's permission state and extend the token's expiration date, if possible.
	/// </summary>
	/// <param name="tokenRefreshedAction">If provided, the action to be performed when token refresh is completed.</param>
	/// <remarks>
	/// On a successful refresh, the <see cref="CurrentAccessToken"/> will be updated so you typically only need to
  	/// observe the <see cref="AccessTokenChanged"/> event.
 	/// If a token is already expired, it cannot be refreshed.</remarks>
	void RefreshCurrentAccessToken(Action tokenRefreshedAction);

	/// <summary>
	/// Creates a new <see cref="ILoginManager"/> for signing into facebook.Provides methods for logging the user in and out.
	/// It works directly with <see cref="IAccessToken"/> (for data access) and <see cref="IAuthenticationToken"/> (for authentication);
	/// it sets the “current” tokens upon successful authorizations (or sets to null in case of <see cref="ILoginManager.Logout"/>).
	/// You should check <see cref="IAccessToken"/>.Current before calling a login method to see if there is
	/// a cached token available (typically in a <see cref="Page.OnAppearing"/> implementation).
	/// </summary>
	/// <param name="defaultAudience">The default is set to <see cref="DefaultAudience.Friends"/></param>
	/// <remarks>
	/// <list type="bullet">
	/// <item>Warning If you are managing your own tokens outside of <see cref="IAccessToken"/>, you will need to set
	/// <see cref="IAccessToken"/>.Current before calling a login method to authorize further permissions on your tokens.</item>
	/// </list>
	/// </remarks>
	/// <returns>A new <see cref="ILoginManager"/> with an empty source.</returns>
	ILoginManager CreateLoginManager(DefaultAudience defaultAudience = DefaultAudience.Friends);

	/// <summary>
	/// Creates a new <see cref="IDeviceLoginManager"/>. Use this class to perform a device login flow.
	/// </summary>
	/// <param name="permissions">The facebook permissions to request for the device login. Defaults to requesting no permissions.</param>
	/// <param name="enableSmartLogin">(Apple only) Defaults to true. Enables or disables smart login for devices.</param>
	/// <returns>A new <see cref="IDeviceLoginManager"/>.</returns>
	/// <remarks>	
	/// The device login flow starts by requesting a code from the device login API.
	/// This class informs the delegate when this code is received. You should then present the
	/// code to the user to enter. In the meantime, this class polls the device login API
	/// periodically and informs the delegate of the results.
	/// See <a href="https://developers.facebook.com/docs/facebook-login/for-devices">Facebook Device Login</a>.
	/// </remarks>
	IDeviceLoginManager CreateDeviceLoginManager(string[]? permissions = null, bool enableSmartLogin = true);

	/// <summary>
	///  Loads the current profile and passes it to the completion block.
	/// </summary>
	/// <remarks>
	/// note:
	/// If the profile is already loaded, this method will call the completion block synchronously, otherwise it
	/// will begin a graph request to update <code>current</code> and then call the completion block when finished.
	/// <ul>
	///   <li>
	///     Parameter: completion The block to be executed once the profile is loaded.
	///   </li>
	/// </ul>
	/// </remarks>
	/// <returns>An asynchronous task that completes with an instance of the global <see cref="IProfile"/></returns>
	Task<IProfile?> LoadCurrentProfileAsync();

	/// <summary>
	/// The `currentProfile` is a convenient representation of the profile of the
	/// current user and is used by other SDK components (like <see cref="ILoginManager"/>)
	/// </summary>
	IProfile? CurrentProfile { get; }
}
