
using Microsoft.Maui.Handlers;
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// The handler for the facebook LoginButton.
/// </summary>
public partial class LoginButtonHandler : ViewHandler<LoginButton, Facebook.Login.Widget.LoginButton>
{
    /// <summary>
    /// Property mapper for handling facebook LoginButton properties.
    /// </summary>
    public static IPropertyMapper<LoginButton, LoginButtonHandler> PropertyMapper
        = new PropertyMapper<LoginButton, LoginButtonHandler>(ViewMapper)
        {        
            [nameof(LoginButton.LoginText)] = MapLoginText,
            [nameof(LoginButton.LogoutText)] = MapLogoutText,
            [nameof(LoginButton.DefaultAudience)] = MapDefaultAudience,
            [nameof(LoginButton.Permissions)] = MapPermissions,
            [nameof(LoginButton.TooltipBehavior)] = MapTooltipBehavior,
            [nameof(LoginButton.TooltipColorStyle)] = MapTooltipColorStyle,
            [nameof(LoginButton.LoginBehavior)] = MapLoginBehavior,
            [nameof(LoginButton.MessengerPageId)] = MapMessengerPageId,
            [nameof(LoginButton.AuthType)] = MapAuthType,
        };

    /// <summary>
    /// The handler constructor.
    /// </summary>
    public LoginButtonHandler() : base(PropertyMapper) { }

    /// <summary>
    /// Connects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to connect.</param>
    protected override void ConnectHandler(Facebook.Login.Widget.LoginButton platformView)
    {
        platformView.Click += OnClick;
        platformView.LongClick += OnLongClick;
        platformView.KeyPress += OnKeyPress;

        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnect.</param>
    protected override void DisconnectHandler(Facebook.Login.Widget.LoginButton platformView)
    {
        platformView.Click -= OnClick;
        platformView.LongClick -= OnLongClick;
        platformView.KeyPress -= OnKeyPress;
        
        base.DisconnectHandler(platformView);
    }

    /// <summary>
    /// Creates the platform view.
    /// </summary>
    protected override Facebook.Login.Widget.LoginButton CreatePlatformView()
    {
        var button = new Facebook.Login.Widget.LoginButton(MauiContext?.Context);
        button.RegisterCallback(FacebookMainActivity.CallbackManager, new LoginCallback(VirtualView));
        return button;
    }
    
    /// <summary>
    /// Arranges the platform child layouts.
    /// </summary>
    /// <param name="frame">The frame representing the usable space of the platform view.</param>
    public override void PlatformArrange(Rect frame)
    {
        base.PlatformArrange(frame);

        var layout = PlatformView.Layout;
        if(layout is not null)
        {
            if(PlatformView.Width > layout.Width)
                layout.IncreaseWidthTo(PlatformView.Width);
            
            var drawables = PlatformView.GetCompoundDrawables();
            var icon = drawables.FirstOrDefault();
            if(icon is not null)
            {
                var iconWidth = icon.IntrinsicWidth;
                var gap = PlatformView.CompoundDrawablePadding;
                var textWidth = PlatformView.Layout?.GetLineWidth(0) ?? 0;
                var groupWidth = PlatformView.PaddingLeft + gap + iconWidth + gap + textWidth + PlatformView.PaddingRight;
                var groupLeft = (layout.Width - groupWidth) / 2f;
                var iconLeft = (int)groupLeft;
                var iconRight = iconLeft + iconWidth;
                icon.SetBounds(iconLeft, icon.Bounds.Top, iconRight, icon.Bounds.Bottom);
            }
        }
    }

    private static void MapLoginText(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.LoginText = view.LoginText;
    }

    private static void MapLogoutText(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.LogoutText = view.LogoutText;
    }

    private static void MapDefaultAudience(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.DefaultAudience = view.DefaultAudience.ToNativeDefaultAudience();
    }

    private static void MapPermissions(LoginButtonHandler handler, LoginButton view)
    {
        if (view.Permissions is null || view.Permissions.Count == 0)
        {
            handler.PlatformView.ClearPermissions();
            return;
        }

        var permissions = view.Permissions.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

        if (permissions.Length == 0)
            return;
            
        handler.PlatformView.Permissions = permissions;
    }

    private static void MapTooltipBehavior(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.SetToolTipMode(view.TooltipBehavior.ToNativeTooltipBehavior());
    }

    private static void MapTooltipColorStyle(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.ToolTipStyle = view.TooltipColorStyle.ToNativeTooltipColorStyle();
    }

    private static void MapLoginBehavior(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.LoginBehavior = view.LoginBehavior.ToNativeLoginBehavior();
    }

    private static void MapMessengerPageId(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.MessengerPageId = view.MessengerPageId;
    }

    private static void MapAuthType(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.AuthType = view.AuthType?.ToNativeAuthType();
    }

    private void OnKeyPress(object? sender, EventArgs e) => VirtualView?.RaisePressedEvent(this, e);

    private void OnLongClick(object? sender, EventArgs e) => VirtualView?.RaiseReleasedEvent(this, e);

    private void OnClick(object? sender, EventArgs e) => VirtualView?.RaiseClickedEvent(this, e);
}