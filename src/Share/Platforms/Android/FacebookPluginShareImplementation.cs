
namespace Plugin.FacebookKit.Share;

internal sealed class FacebookPluginShareImplementation : Java.Lang.Object, IFacebookPluginShare
{
    private static readonly Lazy<Facebook.Messenger.MessengerUtils> messengerUtility = new(() => Facebook.Messenger.MessengerUtils.Instance);
    internal static Facebook.Messenger.MessengerUtils MessengerUtility => messengerUtility.Value;

	private static int nextRequestCode = 1000;
    
    internal static int GetNextRequestCode()
    {
        return Interlocked.Increment(ref nextRequestCode);
    }

	public IShareDialog CreateShareDialog(ISharingContent sharingContent, ShareDialogMode mode = ShareDialogMode.Automatic) =>
		new ShareDialog(sharingContent, mode);

	public IMessageDialog CreateMessageDialog(ISharingContent sharingContent, ShareDialogMode mode = ShareDialogMode.NativeMode) =>
		new MessageDialog(sharingContent, mode);
}