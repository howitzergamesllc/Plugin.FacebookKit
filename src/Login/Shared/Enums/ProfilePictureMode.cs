
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Specifies how a Facebook profile picture should be displayed.
/// </summary>
/// <remarks>
/// Android only has sizes, small, medium, large and a IsCropped property. The following will default to a cropped photo.
/// <list type="bullet">
/// <item><see cref="Square"/>. Defaults to normal size.</item>
/// <item><see cref="Small"/></item>
/// <item><see cref="Normal"/></item>
/// <item><see cref="Large"/></item>
/// </list>
/// For an uncropped normal size photo, use <see cref="Album"/>.
/// </remarks>
public enum ProfilePictureMode
{
    /// <summary>
    /// Displays a square-cropped version of the profile picture.
    /// </summary>
    Square = 0,

    /// <summary>
    /// Displays the profile picture using its original aspect ratio.
    /// </summary>
    /// <remarks>On android, this defualts to a cropped photo.</remarks>
    Normal = 1,

    /// <summary>
    /// Displays an album-sized version of the profile picture using its original aspect ratio.
    /// </summary>
    /// <remarks>On android, this defualts to a normal sized uncropped photo.</remarks>
    Album = 2,

    /// <summary>
    /// Displays a small version of the profile picture using its original aspect ratio.
    /// </summary>
    /// <remarks>On android, this defualts to a cropped photo.</remarks>
    Small = 3,

    /// <summary>
    /// Displays a large version of the profile picture using its original aspect ratio.
    /// </summary>
    /// <remarks>On android, this defualts to a cropped photo.</remarks>
    Large = 4,
}