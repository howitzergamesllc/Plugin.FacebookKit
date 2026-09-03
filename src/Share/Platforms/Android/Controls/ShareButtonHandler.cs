
using Microsoft.Maui.Handlers;
using Plugin.FacebookKit.Core;

namespace Plugin.FacebookKit.Share.Controls;

/// <summary>
/// The handler to represent a Facebook ShareButton.
/// </summary>
public sealed partial class ShareButtonHandler : ViewHandler<ShareButton, Facebook.Share.Widget.ShareButton>
{
    /// <summary>
    /// The ShareButtonHandler property mapper.
    /// </summary>
    public static IPropertyMapper<ShareButton, ShareButtonHandler> PropertyMapper
        = new PropertyMapper<ShareButton, ShareButtonHandler>(ViewMapper)
        {
            [nameof(ShareButton.ShareDialog)] = MapShareDialog
        };

    /// <summary>
    /// The ShareButtonHandler constructor.
    /// </summary>
    public ShareButtonHandler() : base(PropertyMapper) { }

    /// <summary>
    /// Create the native platform view.
    /// </summary>
    /// <returns>The native platform view</returns>
    protected override Facebook.Share.Widget.ShareButton CreatePlatformView()
    {
        var button = new Facebook.Share.Widget.ShareButton(MauiContext?.Context);
        return button; 
    }

    /// <summary>
    /// Arranges the child layouts of the platform view.
    /// </summary>
    /// <param name="frame">The frame representing the useable space of the platform view.</param>
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
        
    /// <summary>
    /// Connects the platform view events to the virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to connect.</param>
    protected override void ConnectHandler(Facebook.Share.Widget.ShareButton platformView)
    {
        platformView.Click += OnClick;
        platformView.LongClick += OnLongClick;
        platformView.KeyPress += OnKeyPress;

        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events to the virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnects.</param>
    protected override void DisconnectHandler(Facebook.Share.Widget.ShareButton platformView)
    {
        platformView.Click -= OnClick;
        platformView.LongClick -= OnLongClick;
        platformView.KeyPress -= OnKeyPress;
        
        base.DisconnectHandler(platformView);
    }

    private static void MapShareDialog(ShareButtonHandler handler, ShareButton view)
    {
        if(view.ShareDialog is not ShareDialog shareDialog || shareDialog.NativeContent is null)
            return;
            
        handler.PlatformView.RegisterCallback(FacebookMainActivity.CallbackManager, shareDialog.SharingCallback, FacebookPluginShareImplementation.GetNextRequestCode());
        handler.PlatformView.ShareContent = shareDialog.NativeContent;
    }

    private void OnKeyPress(object? sender, EventArgs e) => VirtualView?.RaisePressedEvent(this, e);

    private void OnLongClick(object? sender, EventArgs e) => VirtualView?.RaiseReleasedEvent(this, e);

    private void OnClick(object? sender, EventArgs e) => VirtualView?.RaiseClickedEvent(this, e);
}