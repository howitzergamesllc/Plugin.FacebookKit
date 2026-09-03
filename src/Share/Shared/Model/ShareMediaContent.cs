
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Media <see cref="ISharingContent"/> consisting of one or more medias (photo or video) 
/// to be shared using the Facebook Share SDK.
/// </summary>
public class ShareMediaContent : ISharingContent
{
    /// <summary>
    /// Gets or sets the collection of media to share.
    /// </summary>
    /// <remarks>
    /// The collection may contain one or more <see cref="IShareMedia"/> instances.
    /// </remarks>
    public IShareMedia?[] Media { get; set; } = [];

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
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"ShareMediaContent Media={string.Join(", ", Media.Select(p => p?.DebugDescription()))}, ContentUri={ContentUri?.AbsoluteUri}, " +
        $"HashTag={Hashtag?.DebugDescription()}, PeopleIds={string.Join(", ", PeopleIds)}, PlaceId={PlaceId}, Reference={Reference}, PageId={PageId}, ShareUUID={ShareUUID}";
}