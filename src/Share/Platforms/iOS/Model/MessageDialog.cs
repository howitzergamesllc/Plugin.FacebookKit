
using Facebook.Share;
using Plugin.FacebookKit.Share.Platforms.iOS.Extensions;

using Foundation;

namespace Plugin.FacebookKit.Share;

/// <inheritdoc />
public sealed partial class MessageDialog : IMessageDialog
{    
    private FBSDKMessageDialog? _messageDialog;
    
    internal FBSDKMessageDialog? NativeMessageDialog
    {
        get => _messageDialog;
        set
        {
            if (ReferenceEquals(_messageDialog, value))
                return;

            _messageDialog = value;

            if (_messageDialog is not null && _nativeContent is not null)
                _messageDialog.ShareContent = _nativeContent;
        }
    }

    private FBSDKShareLinkContent? _nativeContent;
    
    internal FBSDKShareLinkContent? NativeContent
    {
        get => _nativeContent;
        set
        {
            if (ReferenceEquals(_nativeContent, value))
                return;

            _nativeContent = value;

            if (_linkContent is null)
                _linkContent = value?.ToShareLinkContent();

            if (_shareContent is null)
                _shareContent = _linkContent;

            if(_messageDialog is not null)
                _messageDialog.ShareContent = value;
        }
    }

    private FBSDKSharingDelegate? SharingDelegate {get; set;}
    
    private ShareLinkContent? _linkContent;
    
    /// <inheritdoc />
    public ShareLinkContent? LinkContent
    {
        get => _linkContent;
        set
        {
            if (ReferenceEquals(_linkContent, value))
                return;

            _linkContent = value;

            var nativeContent = value?.ToNativeShareLinkContent();

            NativeContent = nativeContent;
        }
    }
    
    /// <inheritdoc />
    public ShareDialogMode Mode { get; set; }
    
    private ISharingContent? _shareContent;

    /// <inheritdoc />
    [Obsolete("MessageDialog only supports ShareLinkContent. Use the ShareLinkContent constructor instead.",false)]
    public ISharingContent? ShareContent
    {
        get => _shareContent;
        set
        {
            if(value is not ShareLinkContent)
                throw new ArgumentException("ShareLinkContent is the only compatible type for MessageDialog.");

            if (ReferenceEquals(_shareContent, value))
                return;

            _shareContent = value;

            if (_messageDialog is not null)
                _messageDialog.ShareContent = value?.ToNativeSharingContent();
        }
    }
    
    /// <inheritdoc />
    public bool CanShow => _messageDialog?.CanShow ?? false;

    /// <inheritdoc />
    public bool Show() => _messageDialog?.Show() ?? false;

    /// <inheritdoc />
    public bool ShouldFailOnDataError
    {
        get => _messageDialog?.ShouldFailOnDataError ?? false;
        set
        {
            if (_messageDialog is not null)
                _messageDialog.ShouldFailOnDataError = value;
        }
    }

    internal MessageDialog(FBSDKMessageDialog messageDialog)
    {
        _messageDialog = messageDialog;

        SharingDelegate = new SharingDelegateAdapter(this);
        messageDialog.Delegate = SharingDelegate;
        
        if(messageDialog.ShareContent is FBSDKShareLinkContent nativeContent)
            NativeContent = nativeContent;

        ShouldFailOnDataError = messageDialog.ShouldFailOnDataError;
    }

    internal MessageDialog(ISharingContent content)
    {
        LinkContent = (ShareLinkContent)content;

        _messageDialog = new FBSDKMessageDialog(NativeContent, null);

        SharingDelegate = new SharingDelegateAdapter(this);
        _messageDialog.Delegate = SharingDelegate;

        ShouldFailOnDataError = _messageDialog.ShouldFailOnDataError;
    }

    /// <inheritdoc />
    public static IMessageDialog ShowWithContent(ISharingContent sharingContent) =>
        FBSDKMessageDialog.ShowWithContent(sharingContent.ToNativeSharingContent(), null).ToMessageDialog();

    /// <inheritdoc />
    public static IMessageDialog DialogWithContent(ISharingContent sharingContent) =>
        FBSDKMessageDialog.DialogWithContent(sharingContent.ToNativeSharingContent(), null).ToMessageDialog();

    /// <inheritdoc />
    public bool Validate(ShareBridgeOptions options, out Exception? exception)
    {
        var valid = _messageDialog!.Validate(
            options.ToNativeShareBridgeOptions(),
            out NSError? error);

        exception = error?.ToException();

        return valid;
    }
}