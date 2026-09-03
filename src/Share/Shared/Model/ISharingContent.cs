
namespace Plugin.FacebookKit.Share;

/// <summary>
/// A base interface for content to be shared.
/// </summary>
public interface ISharingContent
{
    /// <summary>
    /// URL for the content being shared.
    /// This URL will be checked for all link meta tags for linking in platform specific ways.
    /// See documentation for App Links (https://developers.facebook.com/docs/applinks/)
    /// </summary>
    Uri? ContentUri { get; set; }

    /// <summary>
    /// Hashtag for the content being shared.
    /// </summary>
    HashTag? Hashtag { get; set; }
    
    /// <summary>
    /// List of IDs for taggable people to tag with this content.
    /// See documentation for Taggable Friends
    /// (https://developers.facebook.com/docs/graph-api/reference/user/taggable_friends)
    /// </summary>
    /// <remarks>
    /// Passing in invalid people ids (i.e [""]) will cause a no-op silent failure.
    /// </remarks>
    string[] PeopleIds { get; set; }

    /// <summary>
    /// The ID for a place to tag with this content.
    /// </summary>
    string? PlaceId { get; set; }

    /// <summary>
    /// A value to be added to the referrer URL when a person follows a link from this shared content on feed.
    /// </summary>
    string? Reference { get; set; }

    /// <summary>
    /// For shares into Messenger, this pageID will be used to map the app to page and attach attribution to the share.
    /// </summary>
    string? PageId { get; set; }
    
    /// <summary>
    /// A unique identifier for a share involving this content, useful for tracking purposes.
    /// </summary>
    string? ShareUUID { get; }
    
    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription();
}