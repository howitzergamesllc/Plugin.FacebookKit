
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Specifies the presentation mode used when displaying a Facebook share dialog.
/// </summary>
/// <remarks>
/// The selected mode determines how the Facebook SDK attempts to present the
/// sharing experience. If the preferred mode is unavailable, the SDK may fall
/// back to another supported mode depending on the platform and installed apps.
/// </remarks>

public enum ShareDialogMode : long
{
    /// <summary>
    /// Automatically selects the most appropriate presentation mode.
    /// </summary>
    Automatic = 0,

    /// <summary>
    /// Presents the share dialog using the native Facebook application, if available.
    /// </summary>
    NativeMode = 1,

    /// <summary>
    /// Presents the platform's native share sheet.
    /// </summary>
    ShareSheet = 2,

    /// <summary>
    /// Presents the share dialog in the system browser.
    /// </summary>
    Browser = 3,

    /// <summary>
    /// Presents the share dialog in a web-based interface.
    /// </summary>
    Web = 4,

    /// <summary>
    /// Presents the legacy Feed dialog in the system browser.
    /// </summary>
    /// <remarks>
    /// This mode exists for backwards compatibility and may not be supported
    /// by newer versions of the Facebook SDK.
    /// </remarks>
    FeedBrowser = 5,

    /// <summary>
    /// Presents the legacy Feed dialog in a web-based interface.
    /// </summary>
    /// <remarks>
    /// This mode exists for backwards compatibility and may not be supported
    /// by newer versions of the Facebook SDK.
    /// </remarks>
    FeedWeb = 6,
    
    /// <summary>
    /// The share dialog mode is unknown.
    /// </summary>
    /// <remarks>
    /// This could either be because the facebook added a new mode or an error occured.
    /// </remarks>
    Unknown = -1
}