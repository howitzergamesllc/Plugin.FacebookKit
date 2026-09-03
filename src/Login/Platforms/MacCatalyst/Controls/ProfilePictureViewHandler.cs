
using CoreGraphics;
using Facebook.Core;
using Microsoft.Maui.Handlers;
using Plugin.FacebookKit.Login.Platforms.MacCatalyst.Extensions;

namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// The handler for the Facebook ProfilePictureView.
/// </summary>
public partial class ProfilePictureViewHandler : ViewHandler<ProfilePictureView, FBSDKProfilePictureView>
{
    /// <summary>
    /// The ProfielPictureViewHandler property mapper.
    /// </summary>
    public static IPropertyMapper<ProfilePictureView, ProfilePictureViewHandler> PropertyMapper
        = new PropertyMapper<ProfilePictureView, ProfilePictureViewHandler>(ViewMapper)        
        {
            [nameof(ProfilePictureView.Profile)] = MapProfile,
            [nameof(ProfilePictureView.PictureMode)] = MapPictureMode,
        };

    /// <summary>
    /// The ProfielPictureViewHandler constructor.
    /// </summary>
    public ProfilePictureViewHandler() : base(PropertyMapper) { }

    /// <summary>
    /// Connects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to connect.</param>
    protected override void ConnectHandler(FBSDKProfilePictureView platformView)
    {
        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnect.</param>
    protected override void DisconnectHandler(FBSDKProfilePictureView platformView)
    {
        base.DisconnectHandler(platformView);
    }

    /// <summary>
    /// Creates the platform view.
    /// </summary>
    protected override FBSDKProfilePictureView CreatePlatformView()
    {
        var profilePictureView = new FBSDKProfilePictureView(CGRect.Empty);
        return profilePictureView;
    }
    
    private static void MapProfile(ProfilePictureViewHandler handler, ProfilePictureView view)
    {
        if(view.Profile is null || view.Profile.UserId is null)
            return;

        handler.PlatformView.ProfileID = view.Profile.UserId;
        handler.PlatformView.SetNeedsImageUpdate();
    }
    
    private static void MapPictureMode(ProfilePictureViewHandler handler, ProfilePictureView view)
    {
        handler.PlatformView.PictureMode = view.PictureMode.ToNativePictureMode();
        handler.PlatformView.SetNeedsImageUpdate();
    }
}