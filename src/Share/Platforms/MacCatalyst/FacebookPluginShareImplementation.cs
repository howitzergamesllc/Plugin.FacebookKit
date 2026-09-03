
using Foundation;

namespace Plugin.FacebookKit.Share;

[Preserve(AllMembers = true)]
internal sealed class FacebookPluginShareImplementation : NSObject, IFacebookPluginShare
{
	public IShareDialog CreateShareDialog(ISharingContent sharingContent, ShareDialogMode mode = ShareDialogMode.Automatic) =>
		new ShareDialog(sharingContent);

	public IMessageDialog CreateMessageDialog(ISharingContent sharingContent, ShareDialogMode mode = ShareDialogMode.NativeMode) =>
		new MessageDialog(sharingContent);
}