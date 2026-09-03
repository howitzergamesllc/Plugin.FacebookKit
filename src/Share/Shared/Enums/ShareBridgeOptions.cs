
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Specifies options used when bridging share content to Facebook.
/// </summary>
[Flags]
public enum ShareBridgeOptions : ulong
{
    /// <summary>
    /// Default bridge options are enabled.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Includes photo asset support.
    /// </summary>
    PhotoAsset = 1UL << 0,

    /// <summary>
    /// Includes photo URL support.
    /// </summary>
    PhotoImageUrl = 1UL << 1,

    /// <summary>
    /// Includes video asset support.
    /// </summary>
    VideoAsset = 1UL << 2,

    /// <summary>
    /// Includes video data support.
    /// </summary>
    VideoData = 1UL << 3,

    /// <summary>
    /// Includes web hashtag support.
    /// </summary>
    WebHashtag = 1UL << 4
}