
using Facebook;

namespace Plugin.FacebookKit.Share;

internal sealed class SharingCallback : Java.Lang.Object, IFacebookCallback
{
    private readonly ISharing? sharer;

    public SharingCallback(ISharing sharer)
    {
        this.sharer = sharer;
    }

    public void OnSuccess(Java.Lang.Object genericResult)
    {
        var result = genericResult as Facebook.Share.ISharer.Result;
        sharer?.RaiseCompleted(sharer, new FacebookSharingCompletedEventArgs((new Dictionary<string, object?>(){["PostId"] = result?.PostId}).AsReadOnly<string,object?>()));
    }

    public void OnError(FacebookException genericException)
    {
        var exception = genericException as FacebookException;
        sharer?.RaiseFailed(sharer, new FacebookSharingFailedEventArgs(new Core.FacebookException(exception)));
    }

    public void OnCancel()
    {
        sharer?.RaiseCancelled(sharer);
    }
}