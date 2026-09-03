
namespace Plugin.FacebookKit.Share;

/// <summary>
/// A model for <see cref="ISharingContent"/> to share with a Facebook camera effect.
/// </summary>
public class ShareCameraEffectContent : ISharingContent
{
    /// <summary>
    /// ID of the camera effect to use.
    /// </summary>
    public string EffectID { get; set; } = "";
    
    /// <summary>
    /// The <see cref="CameraEffectArguments"/> for the effect.
    /// </summary>
    public CameraEffectArguments EffectArguments { get; set; } = new();

    /// <summary>
    /// The <see cref="CameraEffectTextures"/> for the effect
    /// </summary>
    public CameraEffectTextures EffectTextures { get; set; } = new();

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
    public string DebugDescription() => $"ShareCameraEffectContent EffectId={EffectID}, EffectArguments={EffectArguments?.DebugDescription()}, EffectTextures={EffectTextures?.DebugDescription()}, ContentUri={ContentUri?.AbsoluteUri}, " +
        $"HashTag={Hashtag?.DebugDescription()}, PeopleIds={string.Join(", ", PeopleIds)}, PlaceId={PlaceId}, Reference={Reference}, PageId={PageId}, ShareUUID={ShareUUID}";
}