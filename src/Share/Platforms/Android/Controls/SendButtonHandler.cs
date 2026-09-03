
using Microsoft.Maui.Handlers;
using Plugin.FacebookKit.Core;

namespace Plugin.FacebookKit.Share.Controls;

/// <summary>
/// The handler to represent a Facebook SendButton.
/// </summary>
public sealed partial class SendButtonHandler : ViewHandler<SendButton, Facebook.Share.Widget.SendButton>
{
    /// <summary>
    /// The SendButtonHandler property mapper.
    /// </summary>
    public static IPropertyMapper<SendButton, SendButtonHandler> PropertyMapper
        = new PropertyMapper<SendButton, SendButtonHandler>(ViewMapper)
        {
            [nameof(SendButton.ShareContent)] = MapSendDialog
        };

    /// <summary>
    /// The SendButtonHandler constructor.
    /// </summary>
    public SendButtonHandler() : base(PropertyMapper) { }

    /// <summary>
    /// Create the native platform view.
    /// </summary>
    /// <returns>The native platform view</returns>
    protected override Facebook.Share.Widget.SendButton CreatePlatformView()
    {
        var button = new Facebook.Share.Widget.SendButton(MauiContext?.Context);
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
    protected override void ConnectHandler(Facebook.Share.Widget.SendButton platformView)
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
    protected override void DisconnectHandler(Facebook.Share.Widget.SendButton platformView)
    {
        platformView.Click -= OnClick;
        platformView.LongClick -= OnLongClick;
        platformView.KeyPress -= OnKeyPress;
        
        base.DisconnectHandler(platformView);
    }

    private static void MapSendDialog(SendButtonHandler handler, SendButton view)
    {
        if (view.MessageDialog is not MessageDialog messageDialog)
            return;

        handler.PlatformView.ShareContent = messageDialog.NativeContent;
    }
    
    private void OnKeyPress(object? sender, EventArgs e) => VirtualView?.RaisePressedEvent(this, e);

    private void OnLongClick(object? sender, EventArgs e) => VirtualView?.RaiseReleasedEvent(this, e);

    private void OnClick(object? sender, EventArgs e)
    {
        PlatformView.RegisterCallback(FacebookMainActivity.CallbackManager, ((MessageDialog)VirtualView.MessageDialog).SharingCallback, FacebookPluginShareImplementation.GetNextRequestCode());
        VirtualView?.RaiseClickedEvent(this, e);
    }
}