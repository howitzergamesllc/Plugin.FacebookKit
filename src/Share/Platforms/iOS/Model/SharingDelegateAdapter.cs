
using Facebook.Share;
using Foundation;
using Plugin.FacebookKit.Core.Platforms.iOS.Extensions;
using Plugin.FacebookKit.Share.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Share;

internal sealed class SharingDelegateAdapter : FBSDKSharingDelegate
{
    private readonly ISharing _owner;

    public SharingDelegateAdapter(ISharing owner)
    {
        _owner = owner;
    }

    public override void DidComplete(IFBSDKSharing sharer, NSDictionary<NSString, NSObject> results)
    {
        _owner.RaiseCompleted(_owner, new FacebookSharingCompletedEventArgs(results.ToDictionary()));
    }

    public override void DidFail(IFBSDKSharing sharer, NSError error)
    {
        _owner.RaiseFailed(_owner, new FacebookSharingFailedEventArgs(error.ToException()));
    }

    public override void DidCancel(IFBSDKSharing sharer)
    {
        _owner.RaiseCancelled(_owner);
    }
}