
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login;

internal sealed class FacebookPluginLoginImplementation : Java.Lang.Object, IFacebookPluginLogin
{
    public event EventHandler<AccessTokenChangedEventArgs>? AccessTokenChanged;
    public event EventHandler<ProfileChangedEventArgs>? ProfileChanged;

    private static FacebookAccessTokenTracker? accessTokenTracker;
    internal static FacebookAccessTokenTracker? AccessTokenTracker
    {
        get => accessTokenTracker;
        private set
        {
            if(value is null || ReferenceEquals(value, accessTokenTracker))
                return;

            accessTokenTracker = value;
        }
    }

    private static FacebookProfileTracker? profileTracker;
    internal static FacebookProfileTracker? ProfileTracker
    {
        get => profileTracker;
        private set
        {
            if(value is null || ReferenceEquals(value, profileTracker))
                return;

            profileTracker = value;
        }
    }

    private bool automaticallyUpdateProfileOnAccessTokenChange;
    public bool AutomaticallyUpdateProfileOnAccessTokenChange 
    { 
        get => automaticallyUpdateProfileOnAccessTokenChange;
        set
        {
            if(automaticallyUpdateProfileOnAccessTokenChange ==value)
                return;

            if(value)
                AccessTokenChanged += UpdateProfileOnAccessTokenChange;
            else
                AccessTokenChanged -= UpdateProfileOnAccessTokenChange;

            automaticallyUpdateProfileOnAccessTokenChange = value;
        }
    }

    private bool _initialized;

    internal static void Initialize(bool automaticallyUpdateProfileOnAccessTokenChange = true)
    {
        var instance = FacebookPluginLogin.Current as FacebookPluginLoginImplementation;

        if (instance is null || instance._initialized)
            return;
        
        AccessTokenTracker = new FacebookAccessTokenTracker();
        ProfileTracker = new FacebookProfileTracker();
        
        if(automaticallyUpdateProfileOnAccessTokenChange)
            instance.AccessTokenChanged += instance.UpdateProfileOnAccessTokenChange;

        instance._initialized = true;
    }

    private void UpdateProfileOnAccessTokenChange(object? sender, AccessTokenChangedEventArgs e) =>
        Facebook.Profile.FetchProfileForCurrentAccessToken();

    internal void AccessTokenDidChange()
    {
        AccessTokenChanged?.Invoke(this, new AccessTokenChangedEventArgs(CurrentAccessToken));
    }

    internal void ProfileDidChange()
    {
        ProfileChanged?.Invoke(this, new ProfileChangedEventArgs(CurrentProfile));
    }

    public IAccessToken? CurrentAccessToken => Facebook.AccessToken.CurrentAccessToken.ToToken();

    public void RefreshCurrentAccessToken(Action tokenRefreshedAction) => Facebook.AccessToken.RefreshCurrentAccessTokenAsync(new FacebookAccessTokenRefreshedCallback(tokenRefreshedAction));

    public Task<IProfile?> LoadCurrentProfileAsync()
    {
        Facebook.Profile.FetchProfileForCurrentAccessToken();
        var task = new Task<IProfile?>(() => Facebook.Profile.CurrentProfile.ToProfile());
        return task;
    }

    public IProfile? CurrentProfile => Facebook.Profile.CurrentProfile.ToProfile();

	public ILoginManager CreateLoginManager(DefaultAudience defaultAudience = default) =>
		new LoginManager(defaultAudience);

	public IDeviceLoginManager CreateDeviceLoginManager(string[]? permissions, bool enableSmartLogin = true) =>
		new DeviceLoginManager(permissions ?? [], enableSmartLogin);

    protected override void Dispose(bool disposing)
    {
        if(disposing)
        {
            AccessTokenTracker?.StopTracking();
            ProfileTracker?.StopTracking();
        }
        base.Dispose(disposing);
    }
}