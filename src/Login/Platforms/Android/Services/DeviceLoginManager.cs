
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Core.Platforms.Android.Extensions;
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login;
internal sealed class DeviceLoginManager : IDeviceLoginManager
{
    private readonly Facebook.Login.DeviceLoginManager _native;

    internal DeviceLoginManager(IReadOnlyList<string> permissions, bool enableSmartLogin = true)
    {
        _native = new Facebook.Login.DeviceLoginManager();
        Permissions = permissions.ToArray();
    }

    public IReadOnlyList<string> Permissions { get; set; }

    private string? deviceAuthenticationUserTargetId;
    /// <inheritdoc />
    public string? DeviceAuthenticationUserTargetId 
    { 
        get => deviceAuthenticationUserTargetId;
        set
        {
            if(deviceAuthenticationUserTargetId == value)
                return;

            deviceAuthenticationUserTargetId = value;
            _native?.DeviceAuthTargetUserId = value;
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
            _native?.SetLoginBehavior(value.ToNativeLoginBehavior());
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
            _native?.SetDefaultAudience(value.ToNativeDefaultAudience());
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
            _native?.SetMessengerPageId(value);
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
            _native?.SetAuthType(value.ToNativeAuthType());
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
            _native?.SetLoginTargetApp(value.ToNativeTargetApp());
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
            _native?.SetFamilyLogin(value);
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
            _native?.SetShouldSkipAccountDeduplication(value);
        }
    }

    public Uri? RedirectUrl
    {
        get => _native.DeviceRedirectUri?.ToUri();
        set
        {
            if(_native.DeviceRedirectUri?.ToString() == value?.AbsoluteUri)
                return;

            _native.DeviceRedirectUri = value.ToNativeUri();
        }
    }
    
    /// <inheritdoc />
    public string DebugDescription() => $"DeviceLoginManager Behavior={Behavior}, Audience={Audience}, MessengerPageId={MessengerPageId}, " + 
        $"AuthType={AuthType}, Tracking=NotApplicable, TargetApp={TargetApp}, IsFamilyApp={IsFamilyLogin}, ShouldSkipAccountDeduplication={ShouldSkipAccountDeduplication}" +
        $"DeviceAuthenticationUserTargetId={DeviceAuthenticationUserTargetId}, DeviceRedirectUrl={RedirectUrl?.AbsoluteUri}, " +
        $"Permissions={string.Join(", ", Permissions)}";

    public void Start()
    {
        _native.RegisterCallback(FacebookMainActivity.CallbackManager, new LoginCallback(this));
        _native.LogIn(Platform.CurrentActivity, Permissions.ToHashSet());
    }

    public void Cancel(){}
    
    public event EventHandler<DeviceLoginStartedEventArgs>? Started;

    public event EventHandler<LoggedInEventArgs>? Completed;

    public void OnLoginCompleted(object? sender, LoggedInEventArgs e) =>  
        Completed?.Invoke(this, e);
}