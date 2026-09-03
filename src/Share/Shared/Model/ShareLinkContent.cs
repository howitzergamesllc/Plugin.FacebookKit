
namespace Plugin.FacebookKit.Share;

/// <summary>
/// A model for status and link <see cref="ISharingContent"/> to be shared.
/// </summary>
public sealed class ShareLinkContent : ISharingContent
{
    /// <summary> 
    /// Some quote text of the link. If specified, the quote text will render with custom styling on top of the link.
    /// </summary>
    public string? Quote { get; set; }

    /// <summary>
    /// URI for the resource available at the URL which will be used to identify resources
    /// </summary>
    public string? EntityURI { get; set; }

    /// <summary>
    /// True if music is allowed to be attached.
    /// </summary>
    public bool IsMusicAttachmentAllowed { get; set; }

    /// <summary>
    /// URL for the content being shared.
    /// This URL will be checked for all link meta tags for linking in platform specific ways.
    /// See documentation for App Links (https://developers.facebook.com/docs/applinks/)
    /// </summary>
    public Uri? ContentUri { get; set; }

    /// <summary>
    /// Hashtag for the content being shared.
    /// </summary>
    public HashTag? Hashtag { get; set; }
    
    /// <summary>
    /// List of IDs for taggable people to tag with this content.
    /// See documentation for Taggable Friends
    /// (https://developers.facebook.com/docs/graph-api/reference/user/taggable_friends)
    /// </summary>
    public string[] PeopleIds { get; set; } = [];

    /// <summary>
    /// The ID for a place to tag with this content.
    /// </summary>
    public string? PlaceId { get; set; }

    /// <summary>
    /// A value to be added to the referrer URL when a person follows a link from this shared content on feed.
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// For shares into Messenger, this pageID will be used to map the app to page and attach attribution to the share.
    /// </summary>
    public string? PageId { get; set; }
    
    /// <summary>
    /// A unique identifier for a share involving this content, useful for tracking purposes.
    /// </summary>
    public string? ShareUUID { get; }

    /// <summary>
    /// Sets the Extra parameters needed for android messenger share workaround.
    /// </summary>
    public ShareLinkAndroidExtras? AndroidExtras { get; set; }
    
    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"ShareLinkContent Quote={Quote}, EntityUri={EntityURI}, IsMusicAttachmentAllowed={IsMusicAttachmentAllowed}, ContentUri={ContentUri?.AbsoluteUri}, " +
        $"HashTag={Hashtag?.DebugDescription()}, PeopleIds={string.Join(", ", PeopleIds)}, PlaceId={PlaceId}, Reference={Reference}, PageId={PageId}, ShareUUID={ShareUUID}, AndroidExtras={AndroidExtras?.DebugDescription()}";
}

/// <summary>
/// Extra parameters needed for android messenger share workaround.
/// </summary>
public sealed class ShareLinkAndroidExtras()
{
    /// <summary>
    /// External URL for the content being linked. For use with legacy share messenger parameters
    /// </summary>
    public Uri? ExternalUri { get; set; }

    /// <summary>
    /// Sets the mimetype when using legacy share messenger parameters.
    /// </summary>
    public ShareMessengerMimeType MimeType { get; set; }

    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"ShareLinkAndroidExtras ExternalUri={ExternalUri?.AbsoluteUri}, MimeType={MimeType}.";
}