
using Plugin.FacebookKit.Core;

namespace Plugin.FacebookKit.Login.Controls;

/// <summary>
/// A view to display a profile picture. 
/// </summary>
/// <remarks>
/// <para>
/// NOTE: iOS defaults to limited login mode.
/// Limited login mode does not have a valid access token so Graph API calls will fail. ProfilePicureView
/// depends on these Graph API calls succeeding when setting the <see cref="Profile"/> property.
/// The profile picture can still be loaded by using <see cref="ImageSource.FromUri(Uri)"/> 
/// and using <see cref="FacebookPluginLogin.CurrentProfile"/> and inputing <see cref="IProfile.ImageURL"/>.
/// </para>
/// <para>
/// NOTE: When using the iOS facebook sdk <see cref="LoginButton"/>, <see cref="LoginTracking"/> must be set to <see cref="LoginTracking.Limited"/>
/// for manual image loading to work.
/// </para>
/// <para>
/// NOTE: Extra event, property and method for android only:
/// <list type="bullet">
/// <item><see cref="OnFacebookError"/></item>
/// <item><see cref="ShouldUpdateOnProfileChange"/></item>
/// <item><see cref="SetDefaultProfilePicture"/></item>
/// </list>
/// </para>
/// </remarks>
public class ProfilePictureView : ContentView
{
    /// <summary>
    /// Identifies the <see cref="Profile"/> bindable property.
    /// </summary>
    public static readonly BindableProperty ProfileProperty = BindableProperty.Create(nameof(Profile), typeof(IProfile), typeof(ProfilePictureView), null, BindingMode.OneWay);

    /// <summary>
    /// The profile to contruce the picture view from.
    /// </summary>
    public IProfile? Profile
    {
        get => (IProfile?)GetValue(ProfileProperty);
        set => SetValue(ProfileProperty, value);
    }
    
    /// <summary>
    /// Gets the profile identifier associated with the current <see cref="Profile"/>.
    /// </summary>
    public string? ProfileId => Profile?.UserId;

    /// <summary>
    /// Identifies the <see cref="PictureMode"/> bindable property.
    /// </summary>
    public static readonly BindableProperty PictureModeProperty = BindableProperty.Create(nameof(PictureMode), typeof(ProfilePictureMode), typeof(ProfilePictureView), ProfilePictureMode.Square, BindingMode.OneWay);

    /// <summary>
    /// The mode for the receiver to determine the aspect ratio of the source image.
    /// </summary>
    /// <remarks>
    /// Android only has sizes, small, medium, large and a IsCropped property. The following will default to a cropped photo.
    /// <list type="bullet">
    /// <item><see cref="ProfilePictureMode.Square"/>. Defaults to normal size.</item>
    /// <item><see cref="ProfilePictureMode.Small"/></item>
    /// <item><see cref="ProfilePictureMode.Normal"/></item>
    /// <item><see cref="ProfilePictureMode.Large"/></item>
    /// </list>
    /// For an uncropped normal size photo, use <see cref="ProfilePictureMode.Album"/>.
    /// </remarks>
    public ProfilePictureMode PictureMode
    {
        get => (ProfilePictureMode)GetValue(PictureModeProperty);
        set => SetValue(PictureModeProperty, value);
    }
    
    /// <summary>
    /// (Android only) Event raised by this <see cref="ProfilePictureView"/> when a facebook error occurs. Contains <see cref="FacebookExceptionEventArgs"/>.
    /// </summary>
    public event EventHandler<FacebookExceptionEventArgs>? OnFacebookError;

    /// <summary>
    /// (Android only) Identifies the <see cref="ShouldUpdateOnProfileChange"/> bindable property.
    /// </summary>
    public static readonly BindableProperty ShouldUpdateOnProfileChangeProperty = BindableProperty.Create(nameof(ShouldUpdateOnProfileChange), typeof(bool), typeof(ProfilePictureView), true, BindingMode.OneWay);

    /// <summary>
    /// (Android only) The mode for the receiver to determine the aspect ratio of the source image.
    /// </summary>
    /// <remarks>
    /// Default value is <c>true</c>
    /// </remarks>
    public bool ShouldUpdateOnProfileChange
    {
        get => (bool)GetValue(ShouldUpdateOnProfileChangeProperty);
        set => SetValue(ShouldUpdateOnProfileChangeProperty, value);
    }
    
    /// <summary>
    /// (Android only) The ProfilePictureView will display the provided image while the specified profile is being loaded, or if the specified profile is not available.
    /// </summary>
    /// <param name="image">The image to render until the actual profile is loaded.</param>
    public void SetDefaultProfilePicture(Image image)
    {
#if ANDROID
        (Handler as ProfilePictureViewHandler)?.SetDefaultProfilePicture(image);
#endif
    }
}
