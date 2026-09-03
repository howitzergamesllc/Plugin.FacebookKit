
namespace Plugin.FacebookKit.Share;

/// <summary>
/// The common interface for sharing buttons.
/// See FBSendButton and FBShareButton
/// </summary>
public interface ISharingButton
{
    /// <summary>
    /// The content to be shared.
    /// </summary>
    ISharingContent ShareContent { get; set; }
}