
using Android.Widget;
using Microsoft.Maui.Handlers;
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// The handler for the Facebook LoginToolTip
/// </summary>
public partial class LoginTooltipViewHandler : ViewHandler<LoginTooltipView, Android.Views.View>
{
    /// <summary>
    /// The LoginToolTip property mapper.
    /// </summary>
    public static IPropertyMapper<LoginTooltipView, LoginTooltipViewHandler> PropertyMapper
        = new PropertyMapper<LoginTooltipView, LoginTooltipViewHandler>(ElementMapper)        
        {
            [nameof(LoginTooltipView.DisplayDuration)] = MapDisplayDuration,
            [nameof(LoginTooltipView.Message)] = MapMessage,
            [nameof(LoginTooltipView.AnchorView)] = MapAnchorView,
            [nameof(LoginTooltipView.ColorStyle)] = MapColorStyle,
        };

    /// <summary>
    /// The LoginToolTip constructor.
    /// </summary>
    public LoginTooltipViewHandler() : base(PropertyMapper) { }

    private Facebook.Login.Widget.ToolTipPopup? nativePopup;
    private string? lastVirtualMessage;
    private View? lastVirtualAnchorView;
    private bool autoShowing;

    /// <summary>
    /// Connects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to connect.</param>
    protected override void ConnectHandler(Android.Views.View platformView)
    {
        UpdateNativePopup();
        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnect.</param>
    protected override void DisconnectHandler(Android.Views.View platformView)
    {
        nativePopup?.Dismiss();
        nativePopup = null;

        base.DisconnectHandler(platformView);
    }

    /// <summary>
    /// Creates the platform view.
    /// </summary>
    protected override Android.Views.View CreatePlatformView()
    {
        return new FrameLayout(MauiContext!.Context!);
    }

    /// <summary>
    /// Arranges the child layouts of the platformview.
    /// </summary>
    public override void PlatformArrange(Rect frame)
    {
        base.PlatformArrange(frame);
        
        if(autoShowing)
            return;

        if(frame.Width > 0 || frame.Height > 0)
        {
            nativePopup?.Show();
            autoShowing = true;
        }
        
    }

    internal void PresentFrom()
    {
        nativePopup?.Show();
    }

    internal void Dismiss()
    {
        nativePopup?.Dismiss();
    }

    private void UpdateNativePopup()
    {
        nativePopup?.Dismiss();
        nativePopup = null;

        if (VirtualView.Message is null || VirtualView.AnchorView is null)
            return;

        var anchor = VirtualView.AnchorView;
        
        if (anchor is null)
            return;

        anchor.HandlerChanged += OnHandlerChanged;

        void OnHandlerChanged(object? sender, EventArgs e)
        {
            if(sender is View view && view.Handler is IViewHandler handler && handler.PlatformView is Android.Views.View nativeView)
            {
                if(VirtualView.Message == lastVirtualMessage && VirtualView.AnchorView == lastVirtualAnchorView)
                    return;

                lastVirtualMessage = VirtualView.Message;
                lastVirtualAnchorView = VirtualView.AnchorView;

                if(nativePopup is null)
                {
                    nativePopup = new Facebook.Login.Widget.ToolTipPopup(VirtualView.Message, nativeView);
                    nativePopup?.SetNuxDisplayTime((long)VirtualView.DisplayDuration.TotalMilliseconds);
                    nativePopup?.SetStyle(VirtualView.ColorStyle.ToNativeTooltipColorStyle());
                }
            }
            anchor.HandlerChanged -= OnHandlerChanged;
        }
    }
    
    private static void MapDisplayDuration(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        handler.nativePopup?.SetNuxDisplayTime((long)view.DisplayDuration.TotalSeconds);
    }

    private static void MapMessage(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        if(view.Message is null || view.AnchorView is null)
            return;

        handler.UpdateNativePopup();
    }

    private static void MapAnchorView(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        if(view.Message is null || view.AnchorView is null)
            return;

        handler.UpdateNativePopup();
    }
    
    private static void MapColorStyle(LoginTooltipViewHandler handler, LoginTooltipView view)
    {
        handler.nativePopup?.SetStyle(view.ColorStyle.ToNativeTooltipColorStyle());
    }

    private void OnTooltipWillAppear(object? sender, EventArgs e) => VirtualView.RaiseAppearingEvent(this, e);
    private void OnTooltipWillNotAppear(object? sender, EventArgs e) => VirtualView.RaiseNotAppearingEvent(this, e);
}