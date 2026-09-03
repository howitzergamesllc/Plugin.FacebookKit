
using Facebook.Share;
using Foundation;
using Microsoft.Maui.Handlers;
using UIKit;

namespace Plugin.FacebookKit.Share.Controls;

/// <summary>
/// The handler to represent a Facebook SendButton.
/// </summary>
public sealed partial class SendButtonHandler : ViewHandler<SendButton, FBSDKSendButton>
{
    /// <summary>
    /// The SendButtonHandler property mapper
    /// </summary>
    public static IPropertyMapper<SendButton, SendButtonHandler> PropertyMapper
        = new PropertyMapper<SendButton, SendButtonHandler>(ViewMapper)
        {
            [nameof(SendButton.MessageDialog)] = MapDialogContent,
            [nameof(SendButton.ShareContent)] = MapShareContent
        };

    /// <summary>
    /// The SendButtonHandler constructor.
    /// </summary>
    public SendButtonHandler() : base(PropertyMapper) { }

    /// <summary>
    /// Create the native platform view.
    /// </summary>
    /// <returns>The native platform view</returns>
    protected override FBSDKSendButton CreatePlatformView()
    {
        var button = new FBSDKSendButton();

        if(VirtualView.MessageDialog is MessageDialog dialog)
        {
            button.ShareContent = dialog.NativeContent;
            button.Dialog = dialog.NativeMessageDialog;
        }

        return button; 
    }

    /// <summary>
    /// Arranges the child layouts of the platform view.
    /// </summary>
    /// <param name="frame">The frame representing the useable space of the platform view.</param>
    public override void PlatformArrange(Rect frame)
    {    
        base.PlatformArrange(frame);

        PlatformView.Frame = new CoreGraphics.CGRect(frame.X, frame.Y, frame.Width, frame.Height);

        var height = (float)frame.Height;
        var padding = height * 0.05f;

        var existingImage = PlatformView.ImageForState(UIControlState.Normal);
        var existingTitle = PlatformView.Title(UIControlState.Normal);
        var existingCornerRaidus = PlatformView.Layer.CornerRadius;
        
        var existingBackgroundColor = PlatformView.BackgroundColor;
        var existingTitleColor = PlatformView.TitleColor(UIControlState.Normal);
        var existingFont = PlatformView.TitleLabel.Font;

        var configuration = PlatformView.Configuration ?? UIButtonConfiguration.FilledButtonConfiguration;

        var background = OperatingSystem.IsIOSVersionAtLeast(18, 0) ? UIBackgroundConfiguration.ListCellConfiguration
            : UIBackgroundConfiguration.ListPlainCellConfiguration;

        background.BackgroundColor = UIColor.SystemBlue;
        background.CornerRadius = existingCornerRaidus;

        configuration.CornerStyle = UIButtonConfigurationCornerStyle.Fixed;
        configuration.Background = background;

        configuration.Image = ResizeImage(existingImage, height * 0.75f);
        
        configuration.Title = existingTitle;
        configuration.TitleTextAttributesTransformer = TransformUIButtonText(existingFont, existingTitleColor);

        configuration.BaseBackgroundColor = existingBackgroundColor;
        configuration.BaseForegroundColor = existingTitleColor;

        configuration.ContentInsets = new NSDirectionalEdgeInsets(padding, padding, padding, padding);

        configuration.ImagePlacement = NSDirectionalRectEdge.Leading;

        configuration.TitleAlignment = UIButtonConfigurationTitleAlignment.Center;

        PlatformView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;

        PlatformView.Configuration = configuration;
    }

    private UIImage ResizeImage(UIImage image, nfloat size)
    {
        if(OperatingSystem.IsIOSVersionAtLeast(17, 0))
        {
            var renderer = new UIGraphicsImageRenderer(
                new CoreGraphics.CGSize(size, size));

            return renderer.CreateImage(context =>
            {
                image.Draw(new CoreGraphics.CGRect(0, 0, size, size));
            });
        }
        else
        {
            UIGraphics.BeginImageContextWithOptions(new CoreGraphics.CGSize(size, size), false, 0);

            image.Draw(new CoreGraphics.CGRect(0, 0, size, size));

            var resized = UIGraphics.GetImageFromCurrentImageContext();

            UIGraphics.EndImageContext();

            return resized!;
        }
    }

    private UIConfigurationTextAttributesTransformerHandler TransformUIButtonText(UIFont existingFont, UIColor existingTitleColor) 
    {
        return new UIConfigurationTextAttributesTransformerHandler(attributes =>
        {
            var mutable = new NSMutableDictionary(attributes);

            mutable[UIStringAttributeKey.Font] = existingFont;

            if (existingTitleColor != null)
                mutable[UIStringAttributeKey.ForegroundColor] = existingTitleColor;

            return mutable;
        });
    }

    /// <summary>
    /// Connects the platform view events to the virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to connect.</param>
    protected override void ConnectHandler(FBSDKSendButton platformView)
    {
        platformView.TouchUpInside += OnTouchUpInside;
        platformView.TouchUpOutside += OnTouchUpOutside;
        platformView.TouchDown += OnTouchDown;

        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events to the virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnects.</param>
    protected override void DisconnectHandler(FBSDKSendButton platformView)
    {
        platformView.TouchUpInside -= OnTouchUpInside;
        platformView.TouchUpOutside -= OnTouchUpOutside;
        platformView.TouchDown -= OnTouchDown;
        
        base.DisconnectHandler(platformView);
    }

    private static void MapDialogContent(SendButtonHandler handler, SendButton view)
    {
        if (view.MessageDialog is not MessageDialog messageDialog)
            return;

        handler.PlatformView.ShareContent = messageDialog.NativeContent;
        handler.PlatformView.Dialog = messageDialog.NativeMessageDialog;
    }

    private static void MapShareContent(SendButtonHandler handler, SendButton view)
    {
        if (view.MessageDialog is not MessageDialog messageDialog)
            return;

        handler.PlatformView.ShareContent = messageDialog.NativeContent;
    }
    
    private void OnTouchDown(object? sender, EventArgs e) => VirtualView?.RaisePressedEvent(sender, e);

    private void OnTouchUpOutside(object? sender, EventArgs e) => VirtualView?.RaiseReleasedEvent(sender, e);

    private void OnTouchUpInside(object? sender, EventArgs e) => VirtualView?.RaiseClickedEvent(sender, e);
}