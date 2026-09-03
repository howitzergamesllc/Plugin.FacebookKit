
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Share.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Share;

/// <inheritdoc />
public sealed partial class ShareDialog : IShareDialog
{
    private Facebook.Share.Widget.ShareDialog? _shareDialog;
    
    internal Facebook.Share.Widget.ShareDialog? NativeShareDialog
    {
        get => _shareDialog;
        set
        {
            if (ReferenceEquals(_shareDialog, value))
                return;

            _shareDialog = value;
        }
    }

    private Facebook.Share.Model.ShareContent? _nativeContent;
    
    internal Facebook.Share.Model.ShareContent? NativeContent
    {
        get => _nativeContent;
        set
        {
            if (ReferenceEquals(_nativeContent, value))
                return;

            _nativeContent = value;

            if (_shareContent is null)
                _shareContent = value?.ToSharingContent();
        }
    }

    private ISharingContent? _shareContent;

    /// <inheritdoc />
    public ISharingContent? ShareContent
    {
        get => _shareContent;
        set
        {
            if (ReferenceEquals(_shareContent, value))
                return;

            _shareContent = value;

            var nativeContent = value?.ToNativeSharingContent();

            NativeContent = nativeContent;
        }
    }

    /// <inheritdoc />
    public ShareDialogMode Mode { get; set; }

    internal Facebook.IFacebookCallback? SharingCallback {get; private set;}
    
    /// <inheritdoc />
    public bool CanShow => _shareDialog?.CanShow(_nativeContent, Mode.ToNativeShareDialogMode()) ?? false;

    /// <inheritdoc />
    public bool Show()
    {
        try
        { 
            _shareDialog?.Show(_nativeContent);
        }
        catch(Exception e)
        {
            var innerExcetption = e.InnerException is not null ? $" InnerException Message: {e.InnerException.Message}, StackTrace: {e.InnerException.StackTrace}" : "";
            Console.WriteLine($"ShareDialog.Show Exception Message: {e.Message}, StackTrace: {e.StackTrace}" + innerExcetption);
            return false;
        }
        return true;
    }

    /// <inheritdoc />
    public bool ShouldFailOnDataError
    {
        get => _shareDialog?.ShouldFailOnDataError ?? false;
        set
        {
            if (_shareDialog is not null)
                _shareDialog.ShouldFailOnDataError = value;
        }
    }

    internal ShareDialog(Facebook.Share.Widget.ShareDialog shareDialog)
    {
        Mode = ShareDialogMode.Automatic;

        _shareDialog = shareDialog;
        
        SharingCallback ??= new SharingCallback(this);
        shareDialog.RegisterCallback(FacebookMainActivity.CallbackManager, SharingCallback, FacebookPluginShareImplementation.GetNextRequestCode());

        ShouldFailOnDataError = shareDialog.ShouldFailOnDataError;
    }

    internal ShareDialog(ISharingContent sharingContent, ShareDialogMode mode = ShareDialogMode.Automatic)
    {
        Mode = mode;

        ShareContent = sharingContent;

        var activity = Platform.CurrentActivity;

        _shareDialog = new Facebook.Share.Widget.ShareDialog(activity);

        SharingCallback ??= new SharingCallback(this);
        _shareDialog.RegisterCallback(FacebookMainActivity.CallbackManager, SharingCallback, FacebookPluginShareImplementation.GetNextRequestCode());

        ShouldFailOnDataError = _shareDialog.ShouldFailOnDataError;
    }

    /// <inheritdoc />
    public static ISharingDialog ShowWithContent(ISharingContent sharingContent, ShareDialogMode mode)
    {
        var dialog = new ShareDialog(sharingContent) { Mode = mode };

        dialog.Show();

        return dialog;
    }

    /// <inheritdoc />
    public static ISharingDialog? DialogWithContent(ISharingContent sharingContent, ShareDialogMode mode) => new ShareDialog(sharingContent) {Mode = mode};
}