
using Microsoft.Maui.Handlers;
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// The handler for the Facebook ProfilePictureView.
/// </summary>
public class ProfilePictureViewHandler : ViewHandler<ProfilePictureView, Facebook.Login.Widget.ProfilePictureView>
{
    /// <summary>
    /// The ProfielPictureViewHandler property mapper.
    /// </summary>
    public static IPropertyMapper<ProfilePictureView, ProfilePictureViewHandler> PropertyMapper
        = new PropertyMapper<ProfilePictureView, ProfilePictureViewHandler>(ViewMapper)        
        {
            [nameof(ProfilePictureView.Profile)] = MapProfile,
            [nameof(ProfilePictureView.PictureMode)] = MapPictureMode,
            [nameof(ProfilePictureView.ShouldUpdateOnProfileChange)] = MapShouldUpdateOnProfileChange,
        };

    /// <summary>
    /// The ProfielPictureViewHandler constructor.
    /// </summary>
    public ProfilePictureViewHandler() : base(PropertyMapper) { }
    
    internal event EventHandler<FacebookExceptionEventArgs>? OnFacebookError;

    /// <summary>
    /// Connects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to connect.</param>
    protected override void ConnectHandler(Facebook.Login.Widget.ProfilePictureView platformView)
    {
        VirtualView.OnFacebookError += OnFacebookError;
        base.ConnectHandler(platformView);
    }

    /// <summary>
    /// Disconnects the platform view events with virtual view events.
    /// </summary>
    /// <param name="platformView">The platform view to disconnect.</param>
    protected override void DisconnectHandler(Facebook.Login.Widget.ProfilePictureView platformView)
    {
        VirtualView.OnFacebookError -= OnFacebookError;
        base.DisconnectHandler(platformView);
    }

    /// <summary>
    /// Creates the platform view.
    /// </summary>
    protected override Facebook.Login.Widget.ProfilePictureView CreatePlatformView()
    {
        var profilePictureView = new Facebook.Login.Widget.ProfilePictureView(MauiContext?.Context);
        profilePictureView.OnErrorListener = new PictureViewErrorListener(this);
        return profilePictureView;
    }

    private static void MapProfile(ProfilePictureViewHandler handler, ProfilePictureView view)
    {
        if(view.Profile is null)
            return;

        handler.PlatformView.ProfileId = view.Profile.UserId;
    }
    
    private static void MapPictureMode(ProfilePictureViewHandler handler, ProfilePictureView view)
    {
        handler.PlatformView.Cropped = view.PictureMode != ProfilePictureMode.Album;
        handler.PlatformView.PresetSize = view.PictureMode.ToNativePictureMode();
    }
    
    private static void MapShouldUpdateOnProfileChange(ProfilePictureViewHandler handler, ProfilePictureView view)
    {
        handler.PlatformView.ShouldUpdateOnProfileChange = view.PictureMode != ProfilePictureMode.Album;
    }

    internal void SetDefaultProfilePicture(Image image)
    {
        PlatformView.SetDefaultProfilePicture(image.ToNativeImage());
    }
    
    internal void RaiseFailed(ProfilePictureViewHandler profilePicture, FacebookExceptionEventArgs e) => OnFacebookError?.Invoke(profilePicture, e);
}