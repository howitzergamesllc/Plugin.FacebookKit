
using Facebook.Login;
using UIKit;
using Plugin.FacebookKit.Login.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Login;

internal sealed class LoginManager : ILoginManager
{
    private readonly FBSDKLoginManager _loginManager;

    internal LoginManager()
    {
        _loginManager = new FBSDKLoginManager();
        audience = DefaultAudience.Friends;
    }

    internal LoginManager(DefaultAudience defaultAudience)
    {
        _loginManager = new FBSDKLoginManager(defaultAudience.ToNativeDefaultAudience());
        this.audience = defaultAudience;
    }
    
    private LoginBehavior behavior;
    /// <inheritdoc />
    public LoginBehavior Behavior 
    { 
        get => behavior;
        set => behavior = value;
    }

    private DefaultAudience audience;
    /// <inheritdoc />
    public DefaultAudience Audience 
    { 
        get => audience;
        set
        {
            if(audience == value)
                return;
                
            audience = value;

            _loginManager?.DefaultAudience = value.ToNativeDefaultAudience();
        }
    }
    
    public string? messengerPageId;
    /// <inheritdoc />
    public string? MessengerPageId 
    { 
        get => messengerPageId;
        set => messengerPageId = value;
    }

    public LoginAuthType authType;
    /// <inheritdoc />
    public LoginAuthType AuthType 
    { 
        get => authType;
        set => authType = value;
    }
    
    public LoginTracking tracking;
    /// <inheritdoc />
    public LoginTracking Tracking 
    { 
        get => tracking;
        set => tracking = value;
    }

    public LoginTargetApp targetApp;
    /// <inheritdoc />
    public LoginTargetApp TargetApp 
    { 
        get => targetApp;
        set => targetApp = value;
    }

    public bool isFamilyLogin;
    /// <inheritdoc />
    public bool IsFamilyLogin 
    { 
        get => isFamilyLogin;
        set => isFamilyLogin = value;
    }

    public bool shouldSkipAccountDeduplication;
    /// <inheritdoc />
    public bool ShouldSkipAccountDeduplication 
    { 
        get => shouldSkipAccountDeduplication;
        set => shouldSkipAccountDeduplication = value;
    }
    
    /// <inheritdoc />
    public string DebugDescription() => $"LoginManager Behavior={Behavior}, Audience={Audience}, MessengerPageId={MessengerPageId}, " + 
        $"AuthType={AuthType}, Tracking=NotApplicable, TargetApp={TargetApp}, IsFamilyApp={IsFamilyLogin}, ShouldSkipAccountDeduplication={ShouldSkipAccountDeduplication}";

    public Task<ILoginResult> LoginAsync(LoginConfiguration configuration)
    {
        var tcs = new TaskCompletionSource<ILoginResult>();
        var viewController = GetViewController();

        _loginManager.LogIn(viewController, configuration.ToNativeConfiguration(behavior, messengerPageId, authType, tracking), CreateLoginResultHandler(tcs));

        return tcs.Task;
    }    

    public Task<ILoginResult> LoginAsync(IEnumerable<string> permissions)
    {
        var tcs = new TaskCompletionSource<ILoginResult>();
        var viewController = GetViewController();

        _loginManager.LogIn(permissions?.ToArray().ToNativePermissions() ?? [], viewController, CreateLoginResultHandler(tcs));

        return tcs.Task;
    }
    public Task<ILoginResult> ReauthorizeDataAccessAsync()
    {
        var tcs = new TaskCompletionSource<ILoginResult>();
        var viewController = GetViewController();

        _loginManager.ReauthorizeDataAccess(viewController, CreateLoginResultHandler(tcs));

        return tcs.Task;
    }
    
    public void Logout()
    {
        _loginManager.LogOut();
    }

    private static UIViewController? GetViewController()
    {
		return UIApplication.SharedApplication?
			.ConnectedScenes?
			.OfType<UIWindowScene>()?
			.SelectMany(s => s.Windows)?
			.FirstOrDefault(w => w.IsKeyWindow)?
			.RootViewController;
    }

    private FBSDKLoginManagerLoginResultBlock CreateLoginResultHandler(TaskCompletionSource<ILoginResult> tcs)
    {
        return new FBSDKLoginManagerLoginResultBlock((result, error) =>
        {
            if (error != null)
            {
                tcs.TrySetException(error.ToLoginException());
                return;
            }
            if(result is not null)
            {
                tcs.TrySetResult(result.ToLoginResult());
                return;
            }
            
            tcs.TrySetException(new LoginException(LoginErrorCode.Unknown, "Facebook login completed without a result or error."));
        });
    }
}