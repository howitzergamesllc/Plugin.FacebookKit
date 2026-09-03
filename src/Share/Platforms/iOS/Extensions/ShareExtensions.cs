
using Foundation;
using Facebook.Share;
using UIKit;
using Plugin.FacebookKit.Core.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Share.Platforms.iOS.Extensions;

[Preserve(AllMembers = true)]
internal static class EnumExtensions
{        
    internal static ShareBridgeOptions ToShareBridgeOptions(this FBSDKShareBridgeOptions options)
    {
        return options switch
        {
            FBSDKShareBridgeOptions.Default => ShareBridgeOptions.Default,
            FBSDKShareBridgeOptions.PhotoAsset => ShareBridgeOptions.PhotoAsset,
            FBSDKShareBridgeOptions.PhotoImageURL => ShareBridgeOptions.PhotoImageUrl,
            FBSDKShareBridgeOptions.VideoAsset => ShareBridgeOptions.VideoAsset,
            FBSDKShareBridgeOptions.VideoData => ShareBridgeOptions.VideoData,
            _ => ShareBridgeOptions.Default,
        };
    }

    internal static FBSDKShareBridgeOptions ToNativeShareBridgeOptions(this ShareBridgeOptions options)
    {
        return options switch
        {
            ShareBridgeOptions.Default => FBSDKShareBridgeOptions.Default,
            ShareBridgeOptions.PhotoAsset => FBSDKShareBridgeOptions.PhotoAsset,
            ShareBridgeOptions.PhotoImageUrl => FBSDKShareBridgeOptions.PhotoImageURL,
            ShareBridgeOptions.VideoAsset => FBSDKShareBridgeOptions.VideoAsset,
            ShareBridgeOptions.VideoData => FBSDKShareBridgeOptions.VideoData,
            _ => FBSDKShareBridgeOptions.Default,
        };
    }

    internal static ShareDialogMode ToShareDialogMode(this FBSDKShareDialogMode mode)
    {
        return mode switch
        {
            FBSDKShareDialogMode.Automatic => ShareDialogMode.Automatic,
            FBSDKShareDialogMode.NativeMode => ShareDialogMode.NativeMode,
            FBSDKShareDialogMode.ShareSheet => ShareDialogMode.ShareSheet,
            FBSDKShareDialogMode.Browser => ShareDialogMode.Browser,
            FBSDKShareDialogMode.Web => ShareDialogMode.Web,
            FBSDKShareDialogMode.FeedBrowser => ShareDialogMode.FeedBrowser,
            FBSDKShareDialogMode.FeedWeb => ShareDialogMode.FeedWeb,
            _ => ShareDialogMode.Unknown,
        };
    }


    internal static FBSDKShareDialogMode ToNativeShareDialogMode(this ShareDialogMode mode)
    {
        return mode switch
        {
            ShareDialogMode.Automatic => FBSDKShareDialogMode.Automatic,
            ShareDialogMode.NativeMode => FBSDKShareDialogMode.NativeMode,
            ShareDialogMode.ShareSheet => FBSDKShareDialogMode.ShareSheet,
            ShareDialogMode.Browser => FBSDKShareDialogMode.Browser,
            ShareDialogMode.Web => FBSDKShareDialogMode.Web,
            ShareDialogMode.FeedBrowser => FBSDKShareDialogMode.FeedBrowser,
            ShareDialogMode.FeedWeb => FBSDKShareDialogMode.FeedWeb,
            _ => FBSDKShareDialogMode.Automatic,
        };
    }
}

[Preserve(AllMembers = true)]
internal static class ShareExtensions
{
    internal static readonly string[] ValidUriSchemesForInMemoryVideo =
    {
        "file",
        "content",
        "resource"
    };

    public static ISharingContent ToSharingContent(this IFBSDKSharingContent sharingContent)
    {
        return sharingContent switch 
        {
            FBSDKShareLinkContent content => content.ToShareLinkContent(),
            FBSDKSharePhotoContent content => content.ToSharePhotoContent(),
            FBSDKShareVideoContent content => content.ToShareVideoContent(),
            _ => throw new InvalidCastException("Invalid type, use one of the accepted types (FBSDKShareLinkContent, FBSDKSharePhotoContent, FBSDKShareVideoContent)")
        };
    }

    public static IFBSDKSharingContent ToNativeSharingContent(this ISharingContent sharingContent)
    {
        return sharingContent switch 
        {
            ShareCameraEffectContent content => content.ToNativeShareCameraEffectContent(),
            ShareLinkContent content => content.ToNativeShareLinkContent(),
            SharePhotoContent content => content.ToNativeSharePhotoContent(),
            ShareVideoContent content => content.ToNativeShareVideoContent(),
            _ => throw new InvalidCastException("Invalid type, use one of the accepted types (ShareLinkContent, SharePhotoContent, ShareVideoContent)")
        };
    }

    public static SharePhoto?[] ToSharePhotos(this FBSDKSharePhoto?[] photos)
    {
        if(photos is null || photos.Length == 0)
            return [];

        return photos.Select(p => p.ToSharePhoto()).ToArray();
    }

public static SharePhoto? ToSharePhoto(this FBSDKSharePhoto? photo)
{
    if (photo?.Image is null)
        return null;

    var bytes = photo.Image.ToBytes();

    if (bytes is not { Length: > 0 })
        return null;

    return new SharePhoto(bytes, photo.IsUserGenerated)
    {
        Caption = photo.Caption,
    };
}

    public static FBSDKSharePhoto[] ToNativePhotos(this SharePhoto?[] photos)
    {
        if(photos is null || photos.Length == 0)
            return [];

        var nativephotos = photos.Select(p => p.ToNativePhoto()).OfType<FBSDKSharePhoto>().ToArray();
        
        return nativephotos;
    }

    public static FBSDKSharePhoto? ToNativePhoto(this SharePhoto? photo)
    {
        if (photo?.ImageData is not { Length: > 0 })
            return null;

        using var nsData = NSData.FromArray(photo.ImageData);
        var image = UIImage.LoadFromData(nsData);

        if (image is null || image.Handle == IntPtr.Zero)
            return null;

        return new FBSDKSharePhoto(image, photo.IsUserGenerated)
        {
            Image = image,
            IsUserGenerated = photo.IsUserGenerated,
            Caption = photo.Caption
        };
    }

    public static ShareVideo ToShareVideo(this FBSDKShareVideo video)
    {
        if (video?.Data is null || video.Data.Length == 0)
            return new ShareVideo();

        var bytes = video.Data.ToShareData();

        if (bytes is { Length: > 0 })
        {
            var shareVideo = new ShareVideo(video.VideoURL?.ToUri(), video.PreviewPhoto.ToSharePhoto());

            shareVideo.Data = bytes;

            return shareVideo;
        }
        else
        {
            var shareVideo = new ShareVideo(video.VideoURL?.ToUri(), video.PreviewPhoto.ToSharePhoto());

            shareVideo.VideoUri = video.VideoURL?.ToUri();

            return shareVideo;
        }
    }

    public static FBSDKShareVideo ToNativeVideoFromData(this ShareVideo video)
    {
        ArgumentNullException.ThrowIfNull(video);

        if (video.Data is not { Length: > 0 })
            throw new InvalidOperationException("ShareVideo does not contain video data.");

        using var data = NSData.FromArray(video.Data);

        return new FBSDKShareVideo(data, video.PreviewPhoto.ToNativePhoto())
        {
            Data = data
        };
    }

    public static FBSDKShareVideo ToNativeVideoFromUri(this ShareVideo video)
    {
        Console.WriteLine("ToNativeVideoFromUri");
        ArgumentNullException.ThrowIfNull(video);

        if (string.IsNullOrWhiteSpace(video.VideoUri?.AbsoluteUri) || !ValidUriSchemesForInMemoryVideo.Contains(video.VideoUri?.Scheme))
            throw new InvalidOperationException($"ShareVideo does not contain a valid video URI of Scheme={string.Join(", ", ValidUriSchemesForInMemoryVideo)}.");

        var asset = Task.Run(() => video.VideoUri?.AbsoluteUri.ToPHAsset()).GetAwaiter().GetResult();
        ArgumentNullException.ThrowIfNull(asset);
        
        return new FBSDKShareVideo(asset, null);
    }

    public static ShareDialog ToShareDialog(this FBSDKShareDialog shareDialog) => 
        new ShareDialog(shareDialog);

    public static ShareDialog ToShareDialog(this FBSDKShareDialog shareDialog, ISharingContent content)
    {
        if (content is ShareCameraEffectContent cameraEffectContent)
            return new ShareDialog(shareDialog, cameraEffectContent);

        return new ShareDialog(shareDialog);
    }

    public static HashTag ToHashTag(this FBSDKHashtag hash)
    {
        return new HashTag(hash.StringRepresentation)
        {
            Hash = hash.Hash
        };
    }

    public static FBSDKHashtag ToNativeHashTag(this HashTag hashtag) => 
        new FBSDKHashtag(hashtag.StringRepresentation ?? "");

    public static MessageDialog ToMessageDialog(this FBSDKMessageDialog messageDialog) =>
        new MessageDialog(messageDialog);

    public static FBSDKShareCameraEffectContent ToNativeShareCameraEffectContent(this ShareCameraEffectContent content)
    {
        return new FBSDKShareCameraEffectContent
        {
            EffectID = content.EffectID,
            EffectArguments = content.EffectArguments.ToNativeCameraEffectArguments(),
            EffectTextures = content.EffectTextures.ToNativeCameraEffectTextures(),
            ContentURL = content.ContentUri,
            Hashtag = content.Hashtag?.ToNativeHashTag(),
            PeopleIDs = content.PeopleIds,
            PlaceID = content.PlaceId,
            Ref = content.Reference,
            PageID = content.PageId,
        };
    }

    public static ShareLinkContent ToShareLinkContent(this FBSDKShareLinkContent content)
    {
        return new ShareLinkContent()
        {
            Quote = content.Quote,
            EntityURI = content.EntityURI,
            IsMusicAttachmentAllowed = content.IsMusicAttachmentAllowed,
            ContentUri = content.ContentURL,
            Hashtag = content.Hashtag?.ToHashTag(),
            PeopleIds = content.PeopleIDs,
            PlaceId = content.PlaceID,
            Reference = content.Ref,
            PageId = content.PageID,
        };
    }

    public static FBSDKShareLinkContent ToNativeShareLinkContent(this ShareLinkContent content)
    {
        return new FBSDKShareLinkContent
        {
            Quote = content.Quote,
            EntityURI = content.EntityURI,
            IsMusicAttachmentAllowed = content.IsMusicAttachmentAllowed,
            ContentURL = content.ContentUri,
            Hashtag = content.Hashtag?.ToNativeHashTag(),
            PeopleIDs = content.PeopleIds,
            PlaceID = content.PlaceId,
            Ref = content.Reference,
            PageID = content.PageId,
        };
    }

    public static SharePhotoContent ToSharePhotoContent(this FBSDKSharePhotoContent content)
    {
        var photos = content.Photos.ToSharePhotos();

        return new SharePhotoContent(photos)
        {
            Photos = photos,
            ContentUri = content.ContentURL,
            Hashtag = content.Hashtag?.ToHashTag(),
            PeopleIds = content.PeopleIDs,
            PlaceId = content.PlaceID,
            Reference = content.Ref,
            PageId = content.PageID,
        };
    }

    public static FBSDKSharePhotoContent ToNativeSharePhotoContent(this SharePhotoContent content)
    {
        return new FBSDKSharePhotoContent
        {
            Photos = content.Photos.ToNativePhotos(),
            ContentURL = content.ContentUri,
            Hashtag = content.Hashtag?.ToNativeHashTag(),
            PeopleIDs = content.PeopleIds,
            PlaceID = content.PlaceId,
            Ref = content.Reference,
            PageID = content.PageId,
        };
    }

    public static ShareVideoContent ToShareVideoContent(this FBSDKShareVideoContent content)
    {
        return new ShareVideoContent(content.Video.ToShareVideo())
        {
            Video = content.Video.ToShareVideo(),
            ContentUri = content.ContentURL,
            Hashtag = content.Hashtag?.ToHashTag(),
            PeopleIds = content.PeopleIDs,
            PlaceId = content.PlaceID,
            Reference = content.Ref,
            PageId = content.PageID,
        };
    }

    public static FBSDKShareVideoContent ToNativeShareVideoContent(this ShareVideoContent content)
    {
        return new FBSDKShareVideoContent()
        {
            Video = content.Video.Data is null ? content.Video.ToNativeVideoFromUri() : content.Video.ToNativeVideoFromData(),
            ContentURL = content.ContentUri,
            Hashtag = content.Hashtag?.ToNativeHashTag(),
            PeopleIDs = content.PeopleIds,
            PlaceID = content.PlaceId,
            Ref = content.Reference,
            PageID = content.PageId,
        };
    }

    public static FBSDKCameraEffectArguments ToNativeCameraEffectArguments(this CameraEffectArguments arguments)
    {
        ArgumentNullException.ThrowIfNull(arguments);

        var native = new FBSDKCameraEffectArguments();

        foreach (var pair in arguments.Values)
        {
            switch (pair.Value)
            {
                case string value:
                    native.SetString(value, pair.Key);
                    break;

                case string[] values:
                    native.SetArray(values, pair.Key);
                    break;
            }
        }

        return native;
    }

    public static FBSDKCameraEffectTextures ToNativeCameraEffectTextures(this CameraEffectTextures textures)
    {
        ArgumentNullException.ThrowIfNull(textures);

        var native = new FBSDKCameraEffectTextures();

        foreach (var pair in textures.Images)
        {
            using var data = Foundation.NSData.FromArray(pair.Value);
            using var image = UIKit.UIImage.LoadFromData(data);

            native.SetImage(image, pair.Key);
        }

        return native;
    }
}