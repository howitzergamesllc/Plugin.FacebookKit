
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login;

internal sealed partial class LoginManager : ILoginManager
{
    private readonly Facebook.Login.LoginManager _loginManager;

    internal LoginManager(DefaultAudience defaultAudience = DefaultAudience.Friends)
    {
        _loginManager = new Facebook.Login.LoginManager();
        if(defaultAudience != DefaultAudience.Friends)
        {
            Audience = defaultAudience;
            _loginManager.SetDefaultAudience(defaultAudience.ToNativeDefaultAudience());
        }
    }
    
    private LoginBehavior behavior;
    
    /// <inheritdoc />
    public LoginBehavior Behavior 
    { 
        get => behavior;
        set
        {
            if(behavior == value)
                return;

            behavior = value;
            _loginManager?.SetLoginBehavior(value.ToNativeLoginBehavior());
        }
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
            _loginManager?.SetDefaultAudience(value.ToNativeDefaultAudience());
        }
    }
    
    public string? messengerPageId;
    /// <inheritdoc />
    public string? MessengerPageId 
    { 
        get => messengerPageId;
        set
        {
            if(messengerPageId == value)
                return;

            messengerPageId = value;
            _loginManager?.SetMessengerPageId(value);
        }
    }

    public LoginAuthType authType;
    /// <inheritdoc />
    public LoginAuthType AuthType 
    { 
        get => authType;
        set
        {
            if(authType == value)
                return;

            authType = value;
            _loginManager?.SetAuthType(value.ToNativeAuthType());
        }
    }
    
    /// <inheritdoc />
    public LoginTracking Tracking { get; set; }
    
    public LoginTargetApp targetApp;
    /// <inheritdoc />
    public LoginTargetApp TargetApp 
    { 
        get => targetApp;
        set
        {
            if(targetApp == value)
                return;

            targetApp = value;
            _loginManager?.SetLoginTargetApp(value.ToNativeTargetApp());
        }
    }

    public bool isFamilyLogin;
    /// <inheritdoc />
    public bool IsFamilyLogin 
    { 
        get => isFamilyLogin;
        set
        {
            if(isFamilyLogin == value)
                return;

            isFamilyLogin = value;
            _loginManager?.SetFamilyLogin(value);
        }
    }

    public bool shouldSkipAccountDeduplication;
    /// <inheritdoc />
    public bool ShouldSkipAccountDeduplication 
    { 
        get => shouldSkipAccountDeduplication;
        set
        {
            if(shouldSkipAccountDeduplication == value)
                return;

            shouldSkipAccountDeduplication = value;
            _loginManager?.SetShouldSkipAccountDeduplication(value);
        }
    }
    
    /// <inheritdoc />
    public string DebugDescription() => $"LoginManager Behavior={Behavior}, Audience={Audience}, MessengerPageId={MessengerPageId}, " + 
        $"AuthType={AuthType}, Tracking=NotApplicable, TargetApp={TargetApp}, IsFamilyApp={IsFamilyLogin}, ShouldSkipAccountDeduplication={ShouldSkipAccountDeduplication}";

    /// <inheritdoc />
    public Task<ILoginResult> LoginAsync(LoginConfiguration configuration)
    {
        var tcs = new TaskCompletionSource<ILoginResult>();

        _loginManager.RegisterCallback(FacebookMainActivity.CallbackManager, new LoginCallback(tcs));

        _loginManager.LogIn(Platform.CurrentActivity, configuration.ToNativeConfiguration());

        return tcs.Task;
    }    

    /// <inheritdoc />
    public Task<ILoginResult> LoginAsync(IEnumerable<string> permissions)
    {
        var tcs = new TaskCompletionSource<ILoginResult>();

        _loginManager.RegisterCallback(FacebookMainActivity.CallbackManager, new LoginCallback(tcs));

        _loginManager.LogIn(Platform.CurrentActivity, permissions?.ToArray());

        return tcs.Task;
    }

    /// <inheritdoc />
    public Task<ILoginResult> ReauthorizeDataAccessAsync()
    {
        var tcs = new TaskCompletionSource<ILoginResult>();

        _loginManager.RegisterCallback(FacebookMainActivity.CallbackManager, new LoginCallback(tcs));
        _loginManager.ReauthorizeDataAccess(Platform.CurrentActivity);

        return tcs.Task;
    }
    
    /// <inheritdoc />
    public void Logout()
    {
        _loginManager.LogOut();
    }
}