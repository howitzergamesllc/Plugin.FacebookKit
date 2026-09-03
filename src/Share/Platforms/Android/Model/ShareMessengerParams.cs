
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Parameters for sharing with facebook messenger
/// </summary>
public class ShareMessengerParams
{
    /// <summary>
    /// A local uri reference to photo or video content to share.
    /// </summary>
    public Uri? ContentUri { get; set; }
    
    /// <summary>
    /// An external Uri reference of the content to share.
    /// </summary>
    public Uri? ExternalUri { get; set; }

    /// <summary>
    /// The mime type to share with messenger
    /// </summary>
    public ShareMessengerMimeType MimeType { get; set; }

    /// <summary>
    /// Convenience method to build a new photo object with an imageURL.
    /// This method should only be used when adding photo content to open graph stories.
    /// For example, if you’re trying to share a photo from the web by itself, download the image and use
    /// <code>init(image:isUserGenerated:)</code> instead.
    /// </summary>
    /// <param name="contentUri">If the photo is resident in memory, this method supplies the data </param>
    /// <param name="mimeType">The type of content being shared. The default is "video/mp4" </param>
    /// <remarks>
    /// Acceptable mimeTypes
    /// <list type="bullet">
    /// <item>"image/*"</item>
    /// <item>"image/jpeg"</item>
    /// <item>"image/png"</item>
    /// <item>"image/gif"</item>
    /// <item>"image/webp"</item>
    /// <item>"video/*"</item>
    /// <item>"video/mp4"</item>
    /// <item>"audio/*"</item>
    /// <item>"audio/mpeg"</item>
    /// </list>
    /// </remarks>
    public ShareMessengerParams(Uri? contentUri, ShareMessengerMimeType mimeType = ShareMessengerMimeType.TextPlain)
    {
        ContentUri = contentUri;
        MimeType = mimeType;
    }
    
    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"ShareMessengerParams ContentUri={ContentUri?.AbsoluteUri}, MimeType={MimeType}, ExternalUri={ExternalUri?.AbsoluteUri}";
}