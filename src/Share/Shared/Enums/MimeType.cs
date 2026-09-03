
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Specifies mimetype when using legacy messenger parameters.
/// </summary>
public enum ShareMessengerMimeType : int
{
    /// <summary>
    /// Sets messenger parameter to mime type "text/plain".
    /// </summary>
    TextPlain = 0,

    /// <summary>
    /// Sets messenger parameter to mime type "image/png".
    /// </summary>
    ImagePng = 1,

    /// <summary>
    /// Sets messenger parameter to mime type "video/mp4".
    /// </summary>
    VideoMp4 = 2,

    /// <summary>
    /// Sets messenger parameter to mime type "audio/mpeg".
    /// </summary>
    AudioMpeg = 3,

    /// <summary>
    /// Sets messenger parameter to mime type "text/plain" but attempts to make <see cref="ShareLinkContent.Quote"/> reference <see cref="ShareLinkContent.EntityURI"/>.
    /// </summary>
    HyperLink = 4,
}