
using Facebook.Login;
using UIKit;
using Foundation;
using Plugin.FacebookKit.Login.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Login;

internal sealed class DeviceLoginManager : IDeviceLoginManager
{
    private readonly FBSDKDeviceLoginManager _native;

    internal DeviceLoginManager(IEnumerable<string> permissions, bool enableSmartLogin)
    {
        _native = new FBSDKDeviceLoginManager(permissions.ToArray(), enableSmartLogin);
        this.permissions = permissions.ToArray();
        _native.Started += OnLoginStarted;
        _native.Completed += OnLoginCompleted;
    }

    /// <inheritdoc />
    public LoginBehavior Behavior { get; set; }

    /// <inheritdoc />
    public DefaultAudience Audience { get; set; }
    
    /// <inheritdoc />
    public string? MessengerPageId { get; set; }

    /// <inheritdoc />
    public LoginAuthType AuthType { get; set; }
    
    /// <inheritdoc />
    public LoginTracking Tracking { get; set; }

    /// <inheritdoc />
    public LoginTargetApp TargetApp { get; set; }

    /// <inheritdoc />
    public bool IsFamilyLogin { get; set; }

    /// <inheritdoc />
    public bool ShouldSkipAccountDeduplication { get; set; }

    /// <inheritdoc />
    public string? DeviceAuthenticationUserTargetId { get; set; }

    private IReadOnlyList<string> permissions;
    /// <inheritdoc />
    public IReadOnlyList<string> Permissions
    {
        get => permissions;
        set
        {
            if(permissions.ToHashSet().SetEquals(permissions))
                return;

            Console.WriteLine($"[Plugin.FacebookKit.Login] WARNING: Permissions cannot be set on a {nameof(DeviceLoginManager)} on iOS and MacCatalyst \n" +
                $"Please recreate {nameof(DeviceLoginManager)}");

            permissions = value;
        }
    }
        
    /// <inheritdoc />
    public string DebugDescription() => $"DeviceLoginManager Behavior={Behavior}, Audience={Audience}, MessengerPageId={MessengerPageId}, " + 
        $"AuthType={AuthType}, Tracking={Tracking}, TargetApp=NotApplicable, IsFamilyApp=NotApplicable, ShouldSkipAccountDeduplication=NotApplicable" +
        "DeviceAuthenticationUserTargetId=NotApplicable";

    public Uri? RedirectUrl
    {
        get
        {
            var absolute = _native.RedirectURL?.AbsoluteString;
            return string.IsNullOrWhiteSpace(absolute) ? null : new Uri(absolute);
        }

        set
        {
            _native.RedirectURL = value is null ? null : new NSUrl(value.AbsoluteUri);
        }
    }

    public void Start() => _native.Start();

    public void Cancel() => _native.Cancel();
    
    public event EventHandler<DeviceLoginStartedEventArgs>? Started;

    public event EventHandler<LoggedInEventArgs>? Completed;

    private void OnLoginStarted(object? sender, FBSDKDeviceLoginStartedEventArgs e) => 
        Started?.Invoke(this, new DeviceLoginStartedEventArgs(e.CodeInfo.ToCodeInfo()));

    private void OnLoginCompleted(object? sender, FBSDKDeviceLoginCompletedEventArgs e) =>  
        Completed?.Invoke(this, new LoggedInEventArgs(e.Result?.ToDeviceLoginResult(), e.Error?.ToDeviceLoginException()));
}