
namespace Plugin.FacebookKit.Share;

/// <summary>
/// The common interface for components that initiate sharing.
/// See <see cref="ShareDialog"/>, <see cref="MessageDialog"/>.
/// </summary>
public interface ISharing : ISharingDelegate, ISharingValidatable
{
    /// <summary>
    /// Gets or sets the content to be shared.
    /// </summary>
    ISharingContent? ShareContent { get; set; }

    /// <summary>
    /// A boolean value that indicates whether the receiver should fail if it finds an error with the share content.
    /// If <code>false</code>, the sharer will still be displayed without the data that was misconfigured.  For example, an
    /// invalid <code>placeID</code> specified on the <code>shareContent</code> would produce a data error.
    /// </summary>
    bool ShouldFailOnDataError { get; set; }
}