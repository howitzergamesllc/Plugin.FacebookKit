using Foundation;
using UIKit;
using Facebook.Login;
using Microsoft.Maui.Handlers;
using CoreGraphics;
using Plugin.FacebookKit.Login.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// The handler for the facebook LoginButton.
/// </summary>
public partial class LoginButtonHandler : ViewHandler<LoginButton, FBSDKLoginButton>
{
    /// <summary>
    /// Property mapper for handling facebook LoginButton properties.
    /// </summary>
    public static IPropertyMapper<LoginButton, LoginButtonHandler> PropertyMapper
        = new PropertyMapper<LoginButton, LoginButtonHandler>(ViewMapper)
        {        
            [nameof(LoginButton.DefaultAudience)] = MapDefaultAudience,
            [nameof(LoginButton.Permissions)] = MapPermissions,
            [nameof(LoginButton.LoginTracking)] = MapLoginTracking,
            [nameof(LoginButton.TooltipBehavior)] = MapTooltipBehavior,
            [nameof(LoginButton.TooltipColorStyle)] = MapTooltipColorStyle,
            [nameof(LoginButton.LoginBehavior)] = MapLoginBehavior,
            [nameof(LoginButton.Nonce)] = MapNonce,
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
    protected override void ConnectHandler(FBSDKLoginButton platformView)
    {
        platformView.TouchUpInside += OnTouchUpInside;
        platformView.TouchUpOutside += OnTouchUpOutside;
        platformView.TouchDown += OnTouchDown;
        platformView.Completed += OnLoggedIn;
        platformView.LoggedOut += OnLoggedOut;
        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnect.</param>
    protected override void DisconnectHandler(FBSDKLoginButton platformView)
    {
        platformView.TouchUpInside -= OnTouchUpInside;
        platformView.TouchUpOutside -= OnTouchUpOutside;
        platformView.TouchDown -= OnTouchDown;
        platformView.Completed -= OnLoggedIn;
        platformView.LoggedOut -= OnLoggedOut;
        base.DisconnectHandler(platformView);
    }

    /// <summary>
    /// Creates the platform view.
    /// </summary>
    protected override FBSDKLoginButton CreatePlatformView()
    {
        var button = new FBSDKLoginButton(CGRect.Empty);
        return button;
    }

    private static void MapDefaultAudience(LoginButtonHandler handler, LoginButton view)
    {
        var nativeAudience = view.DefaultAudience.ToNativeDefaultAudience();

        if(nativeAudience == handler.PlatformView.DefaultAudience)
            return;

        handler.PlatformView.DefaultAudience = nativeAudience;
    }

    private static void MapPermissions(LoginButtonHandler handler, LoginButton view)
    {
        if (view.Permissions is null || view.Permissions.Count == 0)
            return;

        var permissions = view.Permissions.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

        if (permissions.Length == 0)
            return;

        handler.PlatformView.Permissions = permissions;
    }

    private static void MapTooltipBehavior(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.TooltipBehavior = view.TooltipBehavior.ToNativeTooltipBehavior();
    }

    private static void MapTooltipColorStyle(LoginButtonHandler handler, LoginButton view)
    {
        handler.PlatformView.TooltipColorStyle = view.TooltipColorStyle.ToNativeTooltipColorStyle();
    }

    private static void MapLoginTracking(LoginButtonHandler handler, LoginButton view)
    {
        var nativeType = view.LoginTracking.ToNativeLoginTracking();

        if(nativeType == handler.PlatformView.LoginTracking)
            return;

        handler.PlatformView.LoginTracking = nativeType;
    }

    private static void MapLoginBehavior(LoginButtonHandler handler, LoginButton view)
    {
        var nativeType = view.LoginBehavior.ToNativeAppSwitch();

        if(nativeType == handler.PlatformView.AppSwitch)
            return;

        handler.PlatformView.AppSwitch = nativeType;
    }

    private static void MapNonce(LoginButtonHandler handler, LoginButton view)
    {
        if(String.IsNullOrEmpty(view.Nonce) || view.Nonce == handler.PlatformView.Nonce)
            return;

        handler.PlatformView.Nonce = view.Nonce;
    }

    private static void MapMessengerPageId(LoginButtonHandler handler, LoginButton view)
    {
        if(String.IsNullOrEmpty(view.MessengerPageId) || view.MessengerPageId == handler.PlatformView.MessengerPageId)
            return;

        handler.PlatformView.MessengerPageId = view.MessengerPageId;
    }

    private static void MapAuthType(LoginButtonHandler handler, LoginButton view)
    {
        var nativeType = view.AuthType.ToNativeAuthType();

        if(nativeType == handler.PlatformView.AuthType)
            return;
        
        handler.PlatformView.AuthType = nativeType;
    }
    
    /// <summary>
    /// Arranges the platform child layouts.
    /// </summary>
    /// <param name="frame">The frame representing the usable space of the platform view.</param>
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
    
    private void OnLoggedIn(object? sender, FBSDKLoginCompletedEventArgs e) => 
        VirtualView?.RaiseLoginCompleted(this, new LoggedInEventArgs(e.Result?.ToLoginResult(), e.Error?.ToLoginException()));

    private void OnLoggedOut(object? sender, EventArgs e) => VirtualView?.RaiseLogoutCompleted(this, new LoggedOutEventArgs());

    private void OnTouchDown(object? sender, EventArgs e) => VirtualView?.RaisePressedEvent(this, e);

    private void OnTouchUpOutside(object? sender, EventArgs e) => VirtualView?.RaiseReleasedEvent(this, e);

    private void OnTouchUpInside(object? sender, EventArgs e)
    {
        VirtualView?.RaiseClickedEvent(this, e);
    }
}