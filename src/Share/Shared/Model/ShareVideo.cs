
namespace Plugin.FacebookKit.Share;

/// <summary>
/// A video for <see cref="ISharing"/>
/// </summary>
public sealed class ShareVideo : IShareMedia
{
    /// <summary>
    /// The raw video data.
    /// </summary>
    /// <remarks>
    /// Use this property when the video is available as in-memory data.
    /// </remarks>
    public byte[]? Data { get; set; }

    /// <summary>
    /// The uri of the video to share.
    /// </summary>
    /// <remarks>
    /// This may refer to a local file or a remote resource, depending on the platform.
    /// </remarks>
    public Uri? VideoUri { get; set; }

    /// <summary>
    /// The photo that represents the video.
    /// </summary>
    public SharePhoto? PreviewPhoto { get; set; }

    /// <summary>
    /// Internal Convenience method to build a new video object from a URL and an optional preview photo.
    /// </summary>
    public ShareVideo()
    {
    }

    /// <summary>
    /// Primary constructor method to build a new video object from a URL and an optional preview photo.
    /// </summary>
    /// <param name="videoUri">The URL to the video.</param>
    /// <param name="previewPhoto">The photo that represents the video.</param>
    public ShareVideo(Uri? videoUri, SharePhoto? previewPhoto = null)
    {
        VideoUri = videoUri;
        PreviewPhoto = previewPhoto;
    }

    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"ShareVideo Data={string.Join(", ", Data?.ToString())}, VideoUri={VideoUri?.AbsoluteUri}, PreviewPhoto={PreviewPhoto?.DebugDescription()}";
}