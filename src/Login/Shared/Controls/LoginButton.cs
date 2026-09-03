
namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// A Facebook Login Button instance.
/// </summary>
/// <remarks>
/// <para>
/// NOTE: When using the iOS facebook sdk <see cref="LoginButton"/>, <see cref="LoginTracking"/> must be set to <see cref="LoginTracking.Limited"/>
/// for manual image loading to work on iOS.
/// </para>
/// </remarks>
public class LoginButton : ContentView
{
    /// <summary>
    /// Raised when login button is pressed.
    /// </summary>
    public event EventHandler? Pressed;

    /// <summary>
    /// Raised when login button is released.
    /// </summary>
    public event EventHandler? Released;

    /// <summary>
    /// Raised when login button is clicked.
    /// </summary>
    public event EventHandler? Clicked;

    /// <summary>
    /// Raised when login completed
    /// </summary>
    public event EventHandler<LoggedInEventArgs>? LoginCompleted;

    /// <summary>
    /// Raised when logged out
    /// </summary>
    public event EventHandler<LoggedOutEventArgs>? LogOutCompleted;
    
    /// <summary>
    /// (Android only) Identifies the <see cref="LoginText"/> bindable property.
    /// </summary>
    public static readonly BindableProperty LoginTextProperty = BindableProperty.Create(nameof(LoginText), typeof(string), typeof(LoginButton), default(string));

    /// <summary>
    /// (Android only) Identifies the <see cref="LogoutText"/> bindable property.
    /// </summary>
    public static readonly BindableProperty LogoutTextProperty = BindableProperty.Create(nameof(LogoutText), typeof(string), typeof(LoginButton), default(string));


    /// <summary>
    /// Identifies the <see cref="DefaultAudience"/> bindable property.
    /// </summary>
    public static readonly BindableProperty DefaultAudienceProperty = BindableProperty.Create(nameof(DefaultAudience), typeof(DefaultAudience), typeof(LoginButton), DefaultAudience.Friends);

    /// <summary>
    /// Identifies the <see cref="Permissions"/> bindable property.
    /// </summary>
    public static readonly BindableProperty PermissionsProperty = BindableProperty.Create(nameof(Permissions), typeof(IList<string>), typeof(LoginButton), new List<string>());

    /// <summary>
    /// Identifies the <see cref="TooltipBehavior"/> bindable property.
    /// </summary>
    /// <remarks>
    /// Controls when the Facebook login button displays its tooltip.
    /// </remarks>
    public static readonly BindableProperty TooltipBehaviorProperty = BindableProperty.Create(nameof(TooltipBehavior), typeof(TooltipBehavior), typeof(LoginButton), TooltipBehavior.Automatic);

    /// <summary>
    /// Identifies the <see cref="TooltipColorStyle"/> bindable property.
    /// </summary>
    /// <remarks>
    /// Controls the color style used when displaying the Facebook login button tooltip.
    /// </remarks>
    public static readonly BindableProperty TooltipColorStyleProperty = BindableProperty.Create(nameof(TooltipColorStyle), typeof(TooltipColorStyle), typeof(LoginButton), TooltipColorStyle.FriendlyBlue);

    /// <summary>
    /// Identifies the <see cref="LoginTracking"/> bindable property.
    /// </summary>
    public static readonly BindableProperty LoginTrackingProperty = BindableProperty.Create(nameof(LoginTracking), typeof(LoginTracking), typeof(LoginButton), LoginTracking.Limited);

    /// <summary>
    /// Identifies the <see cref="LoginBehavior"/> bindable property.
    /// </summary>
    public static readonly BindableProperty LoginBehaviorProperty = BindableProperty.Create(nameof(LoginBehavior), typeof(LoginBehavior), typeof(LoginButton), LoginBehavior.NativeWithFallback);

    /// <summary>
    /// (Apple Only) Identifies the <see cref="Nonce"/> bindable property.
    /// </summary>
    public static readonly BindableProperty NonceProperty = BindableProperty.Create(nameof(Nonce), typeof(string), typeof(LoginButton), default(string));

    /// <summary>
    /// Identifies the <see cref="MessengerPageId"/> bindable property.
    /// </summary>
    public static readonly BindableProperty MessengerPageIdProperty = BindableProperty.Create(nameof(MessengerPageId), typeof(string), typeof(LoginButton), default(string));
    
    /// <summary>
    /// (Android only) Identifies the <see cref="TargetApp"/> bindable property.
    /// </summary>
    public static readonly BindableProperty TargetAppProperty = BindableProperty.Create(nameof(TargetApp), typeof(LoginTargetApp?), typeof(LoginButton), LoginTargetApp.Facebook);

    /// <summary>
    /// Identifies the <see cref="AuthType"/> bindable property.
    /// </summary>
    public static readonly BindableProperty AuthTypeProperty = BindableProperty.Create(nameof(AuthType), typeof(LoginAuthType?), typeof(LoginButton), LoginAuthType.Rerequest);

    /// <summary>
    /// (Android only) the text to display when the user needs to sign in.
    /// </summary>
    public string? LoginText
    {
        get => (string?)GetValue(LoginTextProperty);
        set => SetValue(LoginTextProperty, value);
    }

    /// <summary>
    /// (Android only) the text to display when the user is signed in.
    /// </summary>
    public string? LogoutText
    {
        get => (string?)GetValue(LogoutTextProperty);
        set => SetValue(LogoutTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the default audience to use when requesting publish permissions.
    /// </summary>
    /// <remarks>
    /// This value is used only when publish permissions are requested during login.
    /// </remarks>
    public DefaultAudience DefaultAudience
    {
        get => (DefaultAudience)GetValue(DefaultAudienceProperty);
        set => SetValue(DefaultAudienceProperty, value);
    }

    /// <summary>
    /// Gets or sets the permissions to request during login.
    /// </summary>
    /// <remarks>
    /// Request only the permissions your application needs. Additional permissions
    /// should be requested when they are required rather than during the initial login.
    /// </remarks>
    public IList<string>? Permissions
    {
        get => (IList<string>?)GetValue(PermissionsProperty);
        set => SetValue(PermissionsProperty, value);
    }

    /// <summary>
    /// Gets or sets the desired tooltip behavior.
    /// </summary>
    /// <remarks>
    /// Controls when the tooltip is displayed by the Facebook login button.
    /// </remarks>
    public TooltipBehavior TooltipBehavior
    {
        get => (TooltipBehavior)GetValue(TooltipBehaviorProperty);
        set => SetValue(TooltipBehaviorProperty, value);
    }

    /// <summary>
    /// Gets or sets the desired tooltip color style.
    /// </summary>
    /// <remarks>
    /// Controls the color appearance of the tooltip displayed by the Facebook login button.
    /// </remarks>
    public TooltipColorStyle TooltipColorStyle
    {
        get => (TooltipColorStyle)GetValue(TooltipColorStyleProperty);
        set => SetValue(TooltipColorStyleProperty, value);
    }

    /// <summary>
    /// (Apple Only) Gets or sets the tracking preference used for login attempts.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="LoginTracking.Enabled"/>.
    /// </remarks>
    public LoginTracking LoginTracking
    {
        get => (LoginTracking)GetValue(LoginTrackingProperty);
        set => SetValue(LoginTrackingProperty, value);
    }

    /// <summary>
    /// Gets or sets the application switch behavior used during login.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="LoginBehavior.NativeWithFallback"/>.
    /// </remarks>
    public LoginBehavior LoginBehavior
    {
        get => (LoginBehavior)GetValue(LoginBehaviorProperty);
        set => SetValue(LoginBehaviorProperty, value);
    }

    /// <summary>
    /// (Apple Only) Gets or sets the nonce used for login attempts.
    /// </summary>
    /// <remarks>
    /// A valid nonce must be a non-empty string that contains no whitespace.
    /// If an invalid value is supplied, the native Facebook SDK generates a nonce automatically.
    /// </remarks>
    public string? Nonce
    {
        get => (string?)GetValue(NonceProperty);
        set => SetValue(NonceProperty, value);
    }

    /// <summary>
    /// Gets or sets the optional Messenger page identifier used for login attempts.
    /// </summary>
    public string? MessengerPageId
    {
        get => (string?)GetValue(MessengerPageIdProperty);
        set => SetValue(MessengerPageIdProperty, value);
    }
    
    /// <summary>
    /// (Android only) Gets or sets the app target for authorization. Defaults to <see cref="LoginTargetApp.Facebook"/>
    /// </summary>
    public LoginTargetApp? TargetApp
    {
        get => (LoginTargetApp?)GetValue(TargetAppProperty);
        set => SetValue(TargetAppProperty, value);
    }

    /// <summary>
    /// Gets or sets the login authorization type to use in the login request. Defaults to <see cref="LoginAuthType.Rerequest"/>
    /// </summary>
    /// <remarks>
    /// NOTE: On iOS, set this property to <see langword="null"/> to avoid requesting permissions
    /// that the user has previously denied.
    /// </remarks>
    public LoginAuthType? AuthType
    {
        get => (LoginAuthType?)GetValue(AuthTypeProperty);
        set => SetValue(AuthTypeProperty, value);
    }

    internal void RaisePressedEvent(object? sender, EventArgs e) => Pressed?.Invoke(sender, e);
    internal void RaiseReleasedEvent(object? sender, EventArgs e) => Released?.Invoke(sender, e);
    internal void RaiseClickedEvent(object? sender, EventArgs e) => Clicked?.Invoke(sender, e);
    internal void RaiseLoginCompleted(object? sender, LoggedInEventArgs e) => LoginCompleted?.Invoke(sender, e);
    internal void RaiseLogoutCompleted(object? sender, LoggedOutEventArgs e) => LogOutCompleted?.Invoke(sender, e);
}