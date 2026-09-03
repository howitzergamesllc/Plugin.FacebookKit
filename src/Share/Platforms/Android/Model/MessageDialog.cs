
using Facebook;
using Android.Content;
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Share.Platforms.Android.Extensions;
using ShareExtensions = Plugin.FacebookKit.Share.Platforms.Android.Extensions.ShareExtensions;
using FacebookException = Plugin.FacebookKit.Core.FacebookException;

namespace Plugin.FacebookKit.Share;

/// <inheritdoc />
public sealed partial class MessageDialog : IMessageDialog
{

    private ShareMessengerParams? _shareParams;
    
    internal ShareMessengerParams? ShareParams
    {
        get => _shareParams;
        set
        {
            if (ReferenceEquals(_shareParams, value))
                return;

            _shareParams = value;

            if(_nativeShareParams is null && ShareExtensions.ValidUriSchemesForMessengerParams.Contains(value?.ContentUri?.Scheme))
                _nativeShareParams = value?.ToNativeShareParams();
        }
    }

    private Facebook.Messenger.ShareToMessengerParams? _nativeShareParams;
    
    internal Facebook.Messenger.ShareToMessengerParams? NativeShareParams
    {
        get => _nativeShareParams;
        set
        {
            if (ReferenceEquals(_nativeShareParams, value))
                return;

            _nativeShareParams = value;

            if(_shareParams is null)
                _shareParams = value?.ToShareParams();
        }
    }

    private Facebook.Share.Widget.MessageDialog? _messageDialog;
    
    internal Facebook.Share.Widget.MessageDialog? NativeMessageDialog
    {
        get => _messageDialog;
        set
        {
            if (ReferenceEquals(_messageDialog, value))
                return;

            _messageDialog = value;
        }
    }

    private Facebook.Share.Model.ShareContent? _nativeContent;
    
    internal Facebook.Share.Model.ShareContent? NativeContent
    {
        get => _nativeContent;
        set
        {
            if(value is not Facebook.Share.Model.ShareLinkContent && value is not Facebook.Share.Model.ShareCameraEffectContent)
                throw new ArgumentException("ShareLinkContent and ShareCameraEffectContent are the only two compatible types for MessageDialog.");

            if (ReferenceEquals(_nativeContent, value))
                return;

            _nativeContent = value;

            if (_shareContent is null)
                _shareContent = value?.ToSharingContent();
                
            if (_nativeShareParams is null)
                NativeShareParams = ShareParams?.ToNativeShareParams();
        }
    }

    internal Facebook.IFacebookCallback? SharingCallback {get; private set;}
    
    /// <inheritdoc />
    public ShareDialogMode Mode { get; set; }
    
    private ISharingContent? _shareContent;

    /// <inheritdoc />
    public ISharingContent? ShareContent
    {
        get => _shareContent;
        set
        {
            if(value is not ShareLinkContent && value is not ShareCameraEffectContent)
                throw new ArgumentException("ShareLinkContent and ShareCameraEffectContent are the only two compatible types for MessageDialog.");

            if (ReferenceEquals(_shareContent, value))
                return;

            _shareContent = value;
            
            if (_nativeContent is null)
                _nativeContent = value?.ToNativeSharingContent();
                
            if (_shareParams is null)
                ShareParams = value?.ToShareParams();
        }
    }
    
    /// <summary>
    /// Indicates whether it is possible to show the dialog for of the specified type.
    /// </summary>
    /// <remarks>
    /// Only two supported types for MessageDialog (<see cref="ShareLinkContent"/>, <see cref="ShareCameraEffectContent"/>).
    /// </remarks>
    /// <param name="content"><see cref="ShareLinkContent"/>, <see cref="ShareCameraEffectContent"/></param>
    /// <returns>True if the content can be shown.</returns>
    public static bool CanShowStatic(ISharingContent content)
    {    
        var nativeType = content switch
        {
            ShareLinkContent => typeof(Facebook.Share.Model.ShareLinkContent),
            ShareCameraEffectContent => typeof(Facebook.Share.Model.ShareCameraEffectContent),
            _ => null
        };

        return nativeType != null && Facebook.Share.Widget.MessageDialog.CanShow( Java.Lang.Class.FromType(nativeType));
    }

    /// <summary>
    /// Helper to show the provided com.facebook.share.model.ShareContent using the providedActivity.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static bool ShowStatic(ISharingContent content)
    {
        if(content is not ShareLinkContent && content is not ShareCameraEffectContent)
            throw new FacebookException("Invalid ShareContent used, only ShareLinkContent and ShareCameraEffectContent may be used.");

        var messageDialog = new MessageDialog(content);

        try
        { 
            var canShow = messageDialog.NativeMessageDialog?.CanShow(messageDialog.NativeContent) ?? false;
            Facebook.Share.Widget.MessageDialog.Show(Platform.CurrentActivity, messageDialog.NativeContent);
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
    public bool CanShow => _messageDialog?.CanShow(_nativeContent, Mode.ToNativeShareDialogMode()) ?? false;

    /// <inheritdoc />
    public bool Show()
    {
        try
        { 
            if (ShareExtensions.ValidUriSchemesForMessengerParams.Contains(_shareParams?.ContentUri?.Scheme))
            {
                //Manual intent creation workaround until facebook reexposes PLATFORM_ACTIVITY for com.facebook.orca
                ShowMediaContentUsingMessengerUtility();
            }
            else if(_shareContent is ShareLinkContent linkContent && linkContent.AndroidExtras is not null)
            {
                //Manual intent creation workaround until facebook reexposes PLATFORM_ACTIVITY for com.facebook.orca
                ShowLinkContentUsingMessengerUtility();
            }
            //ShareLinkContent from com.facebook.share
            else 
            {
                //Currently failing because PLATFORM_ACTIVITY is no longer available from facebook messenger (com.facebook.orca).
                _messageDialog?.Show(_nativeContent);
            }
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
        get => _messageDialog?.ShouldFailOnDataError ?? false;
        set
        {
            if (_messageDialog is not null)
                _messageDialog.ShouldFailOnDataError = value;
        }
    }

    internal MessageDialog(Facebook.Share.Widget.MessageDialog messageDialog)
    {
        Mode = ShareDialogMode.NativeMode;

        _messageDialog = messageDialog;

        SharingCallback ??= new SharingCallback(this);
        messageDialog.RegisterCallback(FacebookMainActivity.CallbackManager, SharingCallback, FacebookPluginShareImplementation.GetNextRequestCode());

        ShouldFailOnDataError = messageDialog.ShouldFailOnDataError;
    }

    internal MessageDialog(ISharingContent content, ShareDialogMode mode = ShareDialogMode.NativeMode)
    {
        Mode = mode;

        ShareContent = content;

        var activity = Platform.CurrentActivity;

        _messageDialog = new Facebook.Share.Widget.MessageDialog(activity);

        SharingCallback ??= new SharingCallback(this);
        _messageDialog.RegisterCallback(FacebookMainActivity.CallbackManager, SharingCallback, FacebookPluginShareImplementation.GetNextRequestCode());

        ShouldFailOnDataError = _messageDialog.ShouldFailOnDataError;
    }

    /// <inheritdoc />
    public static IMessageDialog ShowWithContent(ISharingContent sharingContent, ShareDialogMode mode = ShareDialogMode.NativeMode)
    {
        var dialog = new MessageDialog(sharingContent, mode);

        MessageDialog.ShowStatic(sharingContent);

        return dialog;
    }

    /// <inheritdoc />
    public static IMessageDialog DialogWithContent(ISharingContent sharingContent, ShareDialogMode mode = ShareDialogMode.NativeMode) => new MessageDialog(sharingContent, mode);

    internal void ShowLinkContentUsingMessengerUtility()
    {
        if(_shareParams is null)
            return;

        if (!FacebookPluginShareImplementation.MessengerUtility.HasMessengerInstalled(Platform.AppContext))
        {
            FacebookPluginShareImplementation.MessengerUtility.OpenMessengerInPlayStore(Platform.AppContext);
        }
        else
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetFlags(ActivityFlags.GrantReadUriPermission);
            intent.SetType(_shareParams.MimeType.ToNativeMimeType());

            switch (_shareParams.MimeType)
            {
                case ShareMessengerMimeType.HyperLink:
                    SetIntentForMessengerHyperlink(intent);
                    break;
                case ShareMessengerMimeType.TextPlain:
                    SetIntentForMessengerText(intent);
                    break;
                default:
                    return;
            }
            
            intent.PutExtra(Facebook.Messenger.MessengerUtils.ExtraAppId, FacebookSdk.ApplicationId);
            intent.PutExtra(Facebook.Messenger.MessengerUtils.ExtraExternalUri, _shareParams.ExternalUri.ToNativeUri());

            Platform.CurrentActivity?.StartActivityForResult(intent, FacebookPluginShareImplementation.GetNextRequestCode());
        }
    }    
    
    private void ShowMediaContentUsingMessengerUtility()
    {
        if(_nativeShareParams is null)
            return;

        if (!FacebookPluginShareImplementation.MessengerUtility.HasMessengerInstalled(Platform.AppContext))
        {
            FacebookPluginShareImplementation.MessengerUtility.OpenMessengerInPlayStore(Platform.AppContext);
        }
        else
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetFlags(ActivityFlags.GrantReadUriPermission);
            intent.SetType(_nativeShareParams.MimeType);

            switch (_shareParams?.MimeType)
            {
                case ShareMessengerMimeType.ImagePng:
                    SetIntentForMessengerPhoto(intent);
                    break;
                case ShareMessengerMimeType.VideoMp4:
                    SetIntentForMessengerVideo(intent);
                    break;
                case ShareMessengerMimeType.AudioMpeg:
                    SetIntentForMessengerAudio(intent);
                    break;
                default:
                    return;
            }
            
            intent.PutExtra(Facebook.Messenger.MessengerUtils.ExtraAppId, FacebookSdk.ApplicationId);
            intent.PutExtra(Facebook.Messenger.MessengerUtils.ExtraMetadata, _nativeShareParams.MetaData);
            intent.PutExtra(Facebook.Messenger.MessengerUtils.ExtraExternalUri, _nativeShareParams.ExternalUri);

            Platform.CurrentActivity?.StartActivityForResult(intent, FacebookPluginShareImplementation.GetNextRequestCode());
        }
    }

    private void SetIntentForMessengerText(Intent intent)
    {
        var message = ShareContent is ShareLinkContent shareLinkContent ? shareLinkContent.Quote : "";
        intent.PutExtra(Intent.ExtraText, message);
        intent.SetPackage("com.facebook.orca");
    }

    private void SetIntentForMessengerHyperlink(Intent intent)
    {
        var message = ShareContent is ShareLinkContent shareLinkContent ? shareLinkContent.Quote : "";
        intent.PutExtra(Intent.ExtraText, message + _shareParams?.ExternalUri );
        intent.SetPackage("com.facebook.orca");
    }

    private void SetIntentForMessengerPhoto(Intent intent)
    {
        intent.PutExtra("android.intent.extra.STREAM", _nativeShareParams?.Uri.LoadContentUri());
        intent.SetPackage("com.facebook.orca");
    }

    private void SetIntentForMessengerVideo(Intent intent)
    {
        intent.PutExtra("android.intent.extra.STREAM", _nativeShareParams?.Uri.LoadContentUri());
        intent.SetPackage("com.facebook.orca");
    }

    private void SetIntentForMessengerAudio(Intent intent)
    {
        intent.PutExtra("android.intent.extra.STREAM", _nativeShareParams?.Uri.LoadContentUri());
        intent.SetPackage("com.facebook.orca");
    }
}