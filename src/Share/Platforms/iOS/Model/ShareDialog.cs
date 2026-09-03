

using Facebook.Share;
using Foundation;
using UIKit;
using Plugin.FacebookKit.Share.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Share;

/// <inheritdoc />
public sealed partial class ShareDialog : IShareDialog
{
    private FBSDKShareDialog? _shareDialog;

    private FBSDKSharingDelegate? SharingDelegate {get; set;}

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

            if (_shareDialog is not null)
                _shareDialog.ShareContent = value?.ToNativeSharingContent();
        }
    }

    /// <inheritdoc />
    public ShareDialogMode Mode
    {
        get => _shareDialog?.Mode.ToShareDialogMode() ?? ShareDialogMode.Unknown;
        set
        {
            if (_shareDialog is not null)
                _shareDialog.Mode = value.ToNativeShareDialogMode();
        }
    }
    
    /// <inheritdoc />
    public bool CanShow => _shareDialog?.CanShow ?? false;

    /// <inheritdoc />
    public bool Show() => _shareDialog?.Show() ?? false;

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

    internal ShareDialog(FBSDKShareDialog shareDialog)
    {
        _shareDialog = shareDialog;

        SharingDelegate = new SharingDelegateAdapter(this);
        _shareDialog.Delegate = SharingDelegate;

        ShareContent = shareDialog.ShareContent?.ToSharingContent();

        Mode = shareDialog.Mode.ToShareDialogMode();

        ShouldFailOnDataError = shareDialog.ShouldFailOnDataError;
    }
    
    internal ShareDialog(FBSDKShareDialog shareDialog, ShareCameraEffectContent cameraEffectContent)
    {
        _shareDialog = shareDialog;

        SharingDelegate = new SharingDelegateAdapter(this);
        _shareDialog.Delegate = SharingDelegate;

        if(shareDialog.ShareContent is FBSDKShareCameraEffectContent nativeContent)
        {
            nativeContent.EffectArguments = cameraEffectContent.EffectArguments.ToNativeCameraEffectArguments();
            nativeContent.EffectTextures = cameraEffectContent.EffectTextures.ToNativeCameraEffectTextures();
        }

        ShareContent = cameraEffectContent;

        Mode = shareDialog.Mode.ToShareDialogMode();

        ShouldFailOnDataError = shareDialog.ShouldFailOnDataError;
    }

    internal ShareDialog(ISharingContent sharingContent)
    {
        _shareDialog = new FBSDKShareDialog(GetViewController(), sharingContent.ToNativeSharingContent(), null);

        SharingDelegate = new SharingDelegateAdapter(this);
        _shareDialog.Delegate = SharingDelegate;

        ShareContent = sharingContent;

        Mode = _shareDialog.Mode.ToShareDialogMode();

        ShouldFailOnDataError = _shareDialog.ShouldFailOnDataError;
    }

    /// <inheritdoc />
    public static ISharingDialog ShowWithContent(ISharingContent sharingContent) => 
        FBSDKShareDialog.ShowFromViewController(GetViewController(), sharingContent.ToNativeSharingContent(), null)
        .ToShareDialog(sharingContent);

    /// <inheritdoc />
    public static ISharingDialog? DialogWithContent(ISharingContent sharingContent) => 
        FBSDKShareDialog.DialogWithViewController(GetViewController(), sharingContent.ToNativeSharingContent(), null)
        .ToShareDialog(sharingContent);

    private static UIViewController? GetViewController()
    {
		return UIApplication.SharedApplication?
			.ConnectedScenes?
			.OfType<UIWindowScene>()?
			.SelectMany(s => s.Windows)?
			.FirstOrDefault(w => w.IsKeyWindow)?
			.RootViewController;
    }

    /// <inheritdoc />
    public bool Validate(ShareBridgeOptions options, out Exception? exception)
    {
        var valid = _shareDialog!.Validate(
            options.ToNativeShareBridgeOptions(),
            out NSError? error);

        if(error is NSError nsError)
            exception = nsError?.ToException();
        else
            exception = null;

        return valid;
    }
}