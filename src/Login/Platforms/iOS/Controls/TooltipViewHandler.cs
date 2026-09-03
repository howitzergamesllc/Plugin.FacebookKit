
using Facebook.Login;
using Microsoft.Maui.Handlers;
using UIKit;
using Plugin.FacebookKit.Login.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// The handler for the Facebook LoginToolTip
/// </summary>
public partial class LoginTooltipViewHandler : ViewHandler<LoginTooltipView, FBSDKLoginTooltipView>
{
    /// <summary>
    /// The LoginToolTip property mapper.
    /// </summary>
    public static IPropertyMapper<LoginTooltipView, LoginTooltipViewHandler> PropertyMapper
        = new PropertyMapper<LoginTooltipView, LoginTooltipViewHandler>(ViewMapper)        
        {
            [nameof(LoginTooltipView.DisplayDuration)] = MapDisplayDuration,
            [nameof(LoginTooltipView.Tagline)] = MapTagline,
            [nameof(LoginTooltipView.Message)] = MapMessage,
            [nameof(LoginTooltipView.AnchorView)] = MapAnchorView,
            [nameof(LoginTooltipView.ColorStyle)] = MapColorStyle,
        };

    /// <summary>
    /// The LoginToolTip constructor.
    /// </summary>
    public LoginTooltipViewHandler() : base(PropertyMapper) { }
    private View? lastVirtualAnchorView;
    
    /// <summary>
    /// Connects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to connect.</param>
    protected override void ConnectHandler(FBSDKLoginTooltipView platformView)
    {
        platformView.WillAppear += OnTooltipWillAppear;
        platformView.WillNotAppear += OnTooltipWillNotAppear;
        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnect.</param>
    protected override void DisconnectHandler(FBSDKLoginTooltipView platformView)
    {
        platformView.WillAppear -= OnTooltipWillAppear;
        platformView.WillNotAppear -= OnTooltipWillNotAppear;
        base.DisconnectHandler(platformView);
    }

    /// <summary>
    /// Creates the platform view.
    /// </summary>
    protected override FBSDKLoginTooltipView CreatePlatformView()
    {
        var tooltipView = new FBSDKLoginTooltipView();
        return tooltipView;
    }

    internal void PresentFrom()
    {
        if (lastVirtualAnchorView?.Handler?.PlatformView is UIView nativeView)
        {
            PlatformView.PresentFromView(nativeView);
        }
    }

    internal void Dismiss()
    {
        PlatformView.Dismiss();
    }
    
    private static void MapDisplayDuration(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        handler.PlatformView.DisplayDuration = view.DisplayDuration.TotalSeconds;
    }
    
    private static void MapTagline(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        handler.PlatformView.Tagline = view.Tagline;
    }

    private static void MapMessage(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        handler.PlatformView.Message = view.Message;
    }

    private static void MapAnchorView(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        handler.lastVirtualAnchorView = view.AnchorView;
    }
    
    private static void MapColorStyle(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        handler.PlatformView.ColorStyle = view.ColorStyle.ToNativeTooltipColorStyle();
    }

    private void OnTooltipWillAppear(object? sender, EventArgs e) => VirtualView.RaiseAppearingEvent(this, e);
    private void OnTooltipWillNotAppear(object? sender, EventArgs e) => VirtualView.RaiseNotAppearingEvent(this, e);
}