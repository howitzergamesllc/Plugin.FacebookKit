
using Graphics = Android.Graphics;
using Plugin.FacebookKit.Core.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Share.Platforms.Android.Extensions;

internal static class EnumExtensions
{
    internal static ShareDialogMode ToShareDialogMode(this Facebook.Share.Widget.ShareDialog.Mode mode)
    {
        if(mode == Facebook.Share.Widget.ShareDialog.Mode.Automatic) return ShareDialogMode.Automatic;
        if(mode == Facebook.Share.Widget.ShareDialog.Mode.Native) return ShareDialogMode.NativeMode;
        if(mode == Facebook.Share.Widget.ShareDialog.Mode.Web) return ShareDialogMode.Browser;
        return ShareDialogMode.Unknown;
    }


    internal static Facebook.Share.Widget.ShareDialog.Mode ToNativeShareDialogMode(this ShareDialogMode mode)
    {
        return mode switch
        {
            ShareDialogMode.Automatic => Facebook.Share.Widget.ShareDialog.Mode.Automatic,
            ShareDialogMode.NativeMode => Facebook.Share.Widget.ShareDialog.Mode.Native,
            ShareDialogMode.Browser => Facebook.Share.Widget.ShareDialog.Mode.Web,
            _ => Facebook.Share.Widget.ShareDialog.Mode.Automatic,
        };
    }
    
    internal static string ToNativeMimeType(this ShareMessengerMimeType mimeType)
    {
        return mimeType switch
        {
            ShareMessengerMimeType.TextPlain => MimeConstants.TextPlain,
            ShareMessengerMimeType.ImagePng => MimeConstants.ImagePng,
            ShareMessengerMimeType.VideoMp4 => MimeConstants.VideoMp4,
            ShareMessengerMimeType.AudioMpeg => MimeConstants.AudioMpeg,
            _ => MimeConstants.TextPlain
        };
    }

    internal static ShareMessengerMimeType ToMimeType(this string mimeType)
    {
        return mimeType switch
        {
            MimeConstants.TextPlain => ShareMessengerMimeType.TextPlain,
            MimeConstants.ImagePng => ShareMessengerMimeType.ImagePng,
            MimeConstants.VideoMp4 => ShareMessengerMimeType.VideoMp4,
            MimeConstants.AudioMpeg => ShareMessengerMimeType.AudioMpeg,
            _ => ShareMessengerMimeType.TextPlain
        };
    }
}

internal static class ShareExtensions
{
    internal static readonly string[] ValidUriSchemesForMessengerParams =
    {
        "file",
        "content",
        "resource"
    };

    internal static ISharingContent ToSharingContent(this Facebook.Share.Model.ShareContent sharingContent)
    {
        return sharingContent switch 
        {
            Facebook.Share.Model.ShareCameraEffectContent content => content.ToShareCameraEffectContent(),
            Facebook.Share.Model.ShareLinkContent content => content.ToShareLinkContent(),
            Facebook.Share.Model.SharePhotoContent content => content.ToSharePhotoContent(),
            Facebook.Share.Model.ShareVideoContent content => content.ToShareVideoContent(),
            _ => throw new InvalidCastException("Invalid type, use one of the accepted types (ShareLinkContent, SharePhotoContent, ShareVideoContent, ShareCameraEffectContent)")
        };
    }

    internal static Facebook.Share.Model.ShareContent ToNativeSharingContent(this ISharingContent sharingContent)
    {
        return sharingContent switch 
        {
            ShareCameraEffectContent content => content.ToNativeShareCameraEffectContent(),
            ShareLinkContent content => content.ToNativeShareLinkContent(),
            SharePhotoContent content => content.ToNativeSharePhotoContent(),
            ShareVideoContent content => content.ToNativeShareVideoContent(),
            _ => throw new InvalidCastException("Invalid type, use one of the accepted types (ShareLinkContent, SharePhotoContent, ShareVideoContent, ShareCameraEffectContent)")
        };
    }

    internal static Facebook.Messenger.ShareToMessengerParams? ToNativeShareParams(this ISharingContent sharingContent)
    {
        return sharingContent switch 
        {
            ShareCameraEffectContent content => content.CameraToNativeShareParams(),
            ShareLinkContent content => content.LinkToNativeShareParams(),
            SharePhotoContent content => content.PhotoToNativeShareParams(),
            ShareVideoContent content => content.VideoToNativeShareParams(),
            _ => throw new InvalidCastException("Invalid type, use one of the accepted types (ShareLinkContent, SharePhotoContent, ShareVideoContent, ShareCameraEffectContent)")
        };
    }

    internal static ShareMessengerParams? ToShareParams(this ISharingContent sharingContent)
    {
        return sharingContent switch 
        {
            ShareCameraEffectContent content => content.CameraToShareParams(),
            ShareLinkContent content => content.LinkToShareParams(),
            SharePhotoContent content => content.PhotoToShareParams(),
            ShareVideoContent content => content.VideoToShareParams(),
            _ => throw new InvalidCastException("Invalid type, use one of the accepted types (ShareLinkContent, SharePhotoContent, ShareVideoContent, ShareCameraEffectContent)")
        };
    }

    internal static SharePhoto?[] ToSharePhotos(this Facebook.Share.Model.SharePhoto?[] photos)
    {
        if(photos is null || photos.Length == 0)
            return [];

        return photos.Select(p => p.ToSharePhoto()).ToArray();
    }

    internal static SharePhoto? ToSharePhoto(this Facebook.Share.Model.SharePhoto? photo)
    {
        if (photo?.Bitmap is null)
            return null;

        var bytes = photo.Bitmap.ToBytes();

        if (bytes is not { Length: > 0 })
            return null;

        return new SharePhoto(bytes, photo.UserGenerated)
        {
            Caption = photo.Caption,
        };
    }

    internal static Facebook.Share.Model.SharePhoto[] ToNativePhotos(this SharePhoto?[] photos)
    {
        if(photos is null || photos.Length == 0)
            return [];

        var nativephotos = photos.Select(p => p.ToNativePhoto()).OfType<Facebook.Share.Model.SharePhoto>().ToArray();
        
        return nativephotos;
    }

    internal static Facebook.Share.Model.SharePhoto? ToNativePhoto(this SharePhoto? photo)
    {
        if (photo?.ImageData is not { Length: > 0 })
            return null;

        var image = photo.ImageData.ToBitmap();

        if (image is null || image.Handle == IntPtr.Zero)
            return null;

        var builder = new Facebook.Share.Model.SharePhoto.Builder();
        builder.SetBitmap(image);
        builder.SetUserGenerated(photo.IsUserGenerated);
        builder.SetCaption(photo.Caption);
        return builder.Build();
    }

    internal static Facebook.Messenger.ShareToMessengerParams PhotoToNativeShareParams(this SharePhotoContent content)
    {
        var photo = content.Photos.FirstOrDefault();

        if(photo is null || System.String.IsNullOrEmpty(photo.ImageUri?.AbsoluteUri))
            throw new NullReferenceException("SharePhotoContent.ISharingContent and Photos.FirstOrDefault().ImageUri cannot be null when using messenger legacy sharing.");

        if(!ValidUriSchemesForMessengerParams.Contains(photo.ImageUri.Scheme))
            throw new NullReferenceException($"SharePhotoContent.Photos.FirstOrDefault().ImageUri.Scheme is invalid. Please use a valid scheme type: {string.Join(", ", ValidUriSchemesForMessengerParams)}");

        return Facebook.Messenger.ShareToMessengerParams
            .NewBuilder(photo?.ImageUri.ToNativeUri(), MimeConstants.ImagePng)
            .SetExternalUri(content.ContentUri.ToNativeUri())
            .Build();
    }

    internal static ShareMessengerParams PhotoToShareParams(this SharePhotoContent content)
    {
        var photo = content.Photos.FirstOrDefault();

        if(content is null || System.String.IsNullOrEmpty(photo?.ImageUri?.AbsoluteUri))
            throw new NullReferenceException("SharePhotoContent.ISharingContent and Photos.FirstOrDefault().ImageUri cannot be null when using messenger legacy sharing.");

        if(!ValidUriSchemesForMessengerParams.Contains(photo.ImageUri.Scheme))
            throw new NullReferenceException($"SharePhotoContent.Photos.FirstOrDefault().ImageUri.Scheme is invalid. Please use a valid scheme type: {string.Join(", ", ValidUriSchemesForMessengerParams)}");

        return new ShareMessengerParams(photo.ImageUri, ShareMessengerMimeType.ImagePng){ ExternalUri = content.ContentUri };
    }

    internal static ShareVideo ToShareVideo(this Facebook.Share.Model.ShareVideo video)
    {
        if (video.LocalUrl is null || video.LocalUrl?.Path?.Length == 0)
            return new ShareVideo();

        return new ShareVideo(video.LocalUrl.ToUri());
    }

    internal static Facebook.Share.Model.ShareVideo ToNativeVideoFromUri(this ShareVideo video)
    {
        if (string.IsNullOrEmpty(video.VideoUri?.AbsoluteUri))
            throw new InvalidOperationException("ShareVideo does not contain video data.");

        var builder = new Facebook.Share.Model.ShareVideo.Builder();
        builder.SetLocalUrl(video.VideoUri.ToNativeUri());
        return builder.Build();
    }

    internal static Facebook.Messenger.ShareToMessengerParams VideoToNativeShareParams(this ShareVideoContent content)
    {
        if(content is null || System.String.IsNullOrEmpty(content.Video.VideoUri?.AbsoluteUri))
            throw new NullReferenceException("ShareVideoContent.ISharingContent and Video.VideoUri?.AbsoluteUri cannot be null when using messenger legacy sharing.");

        if(!ValidUriSchemesForMessengerParams.Contains(content.Video.VideoUri.Scheme))
            throw new NullReferenceException($"ShareVideoContent.Video.VideoUri.Scheme is invalid. Please use a valid scheme type: {string.Join(", ", ValidUriSchemesForMessengerParams)}");

        return Facebook.Messenger.ShareToMessengerParams
            .NewBuilder(content.Video.VideoUri.ToNativeUri(), MimeConstants.VideoMp4)
            .SetExternalUri(content.ContentUri.ToNativeUri())
            .Build();
    }

    internal static ShareMessengerParams VideoToShareParams(this ShareVideoContent content)
    {
        if(content is null || System.String.IsNullOrEmpty(content.Video.VideoUri?.AbsoluteUri))
            throw new NullReferenceException("ShareVideoContent.ISharingContent and Video.VideoUri?.AbsoluteUri cannot be null when using messenger legacy sharing.");

        if(!ValidUriSchemesForMessengerParams.Contains(content.Video.VideoUri.Scheme))
            throw new NullReferenceException($"ShareVideoContent.Video.VideoUri.Scheme is invalid. Please use a valid scheme type: {string.Join(", ", ValidUriSchemesForMessengerParams)}");

        return new ShareMessengerParams(content.Video.VideoUri, ShareMessengerMimeType.VideoMp4){ ExternalUri = content.ContentUri };
    }

    internal static ShareDialog ToShareDialog(this Facebook.Share.Widget.ShareDialog shareDialog) => 
        new ShareDialog(shareDialog);

    internal static HashTag ToHashTag(this Facebook.Share.Model.ShareHashtag hash)
    {
        return new HashTag(hash.Hashtag){ };
    }

    internal static Facebook.Share.Model.ShareHashtag ToNativeHashTag(this HashTag hashtag) 
    {
        var builder = new Facebook.Share.Model.ShareHashtag.Builder();
        builder.SetHashtag(hashtag.StringRepresentation);
        return builder.BuildTyped();
    }

    internal static MessageDialog ToMessageDialog(this Facebook.Share.Widget.MessageDialog messageDialog) =>
        new MessageDialog(messageDialog);

    internal static ShareCameraEffectContent ToShareCameraEffectContent(this Facebook.Share.Model.ShareCameraEffectContent content)
    {
        return new ShareCameraEffectContent()
        {
            EffectID = content.EffectId,
            EffectArguments = content.Arguments.ToCameraEffectArguments(),
            EffectTextures = content.Textures.ToCameraEffectTextures(),
            ContentUri = content.ContentUrl.ToUri(),
            Hashtag = content.ShareHashtag.ToHashTag(),
            PeopleIds = content.PeopleIds.ToArray(),
            PlaceId = content.PlaceId,
            Reference = content.Ref,
            PageId = content.PageId
        };
    }

    internal static CameraEffectArguments ToCameraEffectArguments(this Facebook.Share.Model.CameraEffectArguments nativeArguments)
    {
        var arguments = new CameraEffectArguments();

        foreach(var key in nativeArguments.KeySet())
        {
            var value = nativeArguments.Get(key);
            arguments.SetString(key, value.ToString());
        }

        return arguments;
    }

    internal static CameraEffectTextures ToCameraEffectTextures(this Facebook.Share.Model.CameraEffectTextures nativeTextures)
    {
        var textures = new CameraEffectTextures();
        var keySet = nativeTextures.KeySet();
        foreach(var key in nativeTextures.KeySet())
        {
            Graphics.Bitmap value = nativeTextures.GetTextureBitmap(key);
            textures[key] = value.ToBytes();
        }

        return textures;
    }

    internal static Facebook.Share.Model.ShareCameraEffectContent ToNativeShareCameraEffectContent(this ShareCameraEffectContent content)
    {
        var builder = new Facebook.Share.Model.ShareCameraEffectContent.Builder();
        builder.SetEffectId(content.EffectID);
        builder.SetArguments(content.EffectArguments.ToNativeCameraEffectArguments());
        builder.SetTextures(content.EffectTextures.ToNativeCameraEffectTextures());
        builder.SetContentUrl(content.ContentUri.ToNativeUri());
        builder.SetShareHashtag(content.Hashtag?.ToNativeHashTag());
        builder.SetPeopleIds(content.PeopleIds);
        builder.SetPlaceId(content.PlaceId);
        builder.SetRef(content.Reference);
        builder.SetPageId(content.PageId);
        return builder.Build();
    }

    internal static Facebook.Messenger.ShareToMessengerParams CameraToNativeShareParams(this ShareCameraEffectContent content)
    {
        if(content is null || (content.ContentUri is null))
            throw new NullReferenceException("ShareCameraEffectContent.ISharingContent and ContentUri cannot be null when using messenger legacy sharing.");

        if(!ValidUriSchemesForMessengerParams.Contains(content.ContentUri.Scheme))
            throw new NullReferenceException($"ShareCameraEffectContent.ContentUri.Scheme is invalid. Please use a valid scheme type: {string.Join(", ", ValidUriSchemesForMessengerParams)}");

        return Facebook.Messenger.ShareToMessengerParams
            .NewBuilder(content.ContentUri.ToNativeUri(), MimeConstants.ImagePng)
            .Build();
    }

    internal static ShareMessengerParams CameraToShareParams(this ShareCameraEffectContent content)
    {
        if(content is null || content.ContentUri is null)
            throw new NullReferenceException("ShareCameraEffectContent.ISharingContent and ContentUri cannot be null when using messenger legacy sharing.");

        return new ShareMessengerParams(content.ContentUri, ShareMessengerMimeType.ImagePng);
    }

    internal static ShareLinkContent ToShareLinkContent(this Facebook.Share.Model.ShareLinkContent content)
    {
        var uri = content.ContentUrl.ToUri();
        return new ShareLinkContent()
        {
            Quote = content.Quote,
            IsMusicAttachmentAllowed = false,
            ContentUri = uri,
            Hashtag = content.ShareHashtag.ToHashTag(),
            PeopleIds = content.PeopleIds.ToArray(),
            PlaceId = content.PlaceId,
            Reference = content.Ref,
            PageId = content.PageId,
        };
    }

    internal static Facebook.Share.Model.ShareLinkContent ToNativeShareLinkContent(this ShareLinkContent content)
    {
        var builder = new Facebook.Share.Model.ShareLinkContent.Builder();
        builder.SetQuote(content.Quote);
        builder.SetContentUrl(content.ContentUri.ToNativeUri());
        builder.SetShareHashtag(content.Hashtag?.ToNativeHashTag());
        builder.SetPeopleIds(content.PeopleIds);
        builder.SetPlaceId(content.PlaceId);
        builder.SetRef(content.Reference);
        builder.SetPageId(content.PageId);
        return builder.Build();
    }
    
    internal static Facebook.Messenger.ShareToMessengerParams? LinkToNativeShareParams(this ShareLinkContent content)
    {
        var contentUriNull = System.String.IsNullOrEmpty(content.ContentUri?.AbsoluteUri);
        if(content is null || (content.AndroidExtras is null &&  contentUriNull))
            throw new NullReferenceException("ShareLinkContent.ISharingContent and ContentUri plus ShareLinkContent.ShareLinkAndroidExtras cannot be null when using messenger legacy sharing. Either provide ContentUri or ShareLinkAndroidExtras.");

        if(contentUriNull)
            return null;

        return Facebook.Messenger.ShareToMessengerParams
            .NewBuilder(content.ContentUri.ToNativeUri(), content.AndroidExtras?.MimeType.ToNativeMimeType())
            .SetExternalUri(content.AndroidExtras?.ExternalUri.ToNativeUri())
            .Build();
    }
    
    internal static ShareMessengerParams? LinkToShareParams(this ShareLinkContent content)
    {
        if(content is null || (content.AndroidExtras is null && System.String.IsNullOrEmpty(content.ContentUri?.AbsoluteUri)))
            throw new NullReferenceException("ShareLinkContent.ISharingContent and ContentUri plus ShareLinkContent.ShareLinkAndroidExtras cannot be null when using ShareLinkContent with messenger legacy sharing. Either provide ContentUri or ShareLinkAndroidExtras.");

        if(content.AndroidExtras is null)
            return null;

        return new ShareMessengerParams(content.ContentUri, content.AndroidExtras.MimeType){ ExternalUri = content.AndroidExtras.ExternalUri };
    }

    internal static SharePhotoContent ToSharePhotoContent(this Facebook.Share.Model.SharePhotoContent content)
    {
        var photos = content.Photos.ToArray().ToSharePhotos();

        return new SharePhotoContent(photos)
        {
            Photos = photos,
            ContentUri = content.ContentUrl.ToUri(),
            Hashtag = content.ShareHashtag?.ToHashTag(),
            PeopleIds = content.PeopleIds.ToArray(),
            PlaceId = content.PlaceId,
            Reference = content.Ref,
            PageId = content.PageId,
        };
    }

    internal static Facebook.Share.Model.SharePhotoContent ToNativeSharePhotoContent(this SharePhotoContent content)
    {
        var builder = new Facebook.Share.Model.SharePhotoContent.Builder();
        builder.SetContentUrl(content.ContentUri.ToNativeUri());
        builder.SetPhotos(content.Photos.ToNativePhotos());
        builder.SetShareHashtag(content.Hashtag?.ToNativeHashTag());
        builder.SetPeopleIds(content.PeopleIds);
        builder.SetPlaceId(content.PlaceId);
        builder.SetRef(content.Reference);
        builder.SetPageId(content.PageId);
        return builder.Build();
    }

    internal static ShareVideoContent ToShareVideoContent(this Facebook.Share.Model.ShareVideoContent content)
    {
        return new ShareVideoContent(content.Video.ToShareVideo())
        {
            Video = content.Video.ToShareVideo(),
            ContentUri = content.ContentUrl.ToUri(),
            Hashtag = content.ShareHashtag?.ToHashTag(),
            PeopleIds = content.PeopleIds.ToArray(),
            PlaceId = content.PlaceId,
            Reference = content.Ref,
            PageId = content.PageId,
        };
    }

    internal static Facebook.Share.Model.ShareVideoContent ToNativeShareVideoContent(this ShareVideoContent content)
    {
        var builder = new Facebook.Share.Model.ShareVideoContent.Builder();
        builder.SetVideo(content.Video.ToNativeVideoFromUri());
        builder.SetContentUrl(content.ContentUri.ToNativeUri());
        builder.SetShareHashtag(content.Hashtag?.ToNativeHashTag());
        builder.SetPeopleIds(content.PeopleIds);
        builder.SetPlaceId(content.PlaceId);
        builder.SetRef(content.Reference);
        builder.SetPageId(content.PageId);
        return builder.Build();
    }

    internal static Facebook.Share.Model.CameraEffectArguments ToNativeCameraEffectArguments(this CameraEffectArguments arguments)
    {
        ArgumentNullException.ThrowIfNull(arguments);

        var builder = new Facebook.Share.Model.CameraEffectArguments.Builder();

        foreach (var pair in arguments.Values)
        {
            switch (pair.Value)
            {
                case string value:
                    builder.PutArgument(pair.Key, value);
                    break;

                case string[] values:
                    foreach(var arraypair in values)
                    {
                        builder.PutArgument(pair.Key, arraypair);
                    }
                    break;
            }
        }

        return builder.BuildTyped();
    }

    internal static Facebook.Share.Model.CameraEffectTextures ToNativeCameraEffectTextures(this CameraEffectTextures textures)
    {
        ArgumentNullException.ThrowIfNull(textures);
        
        var builder = new Facebook.Share.Model.CameraEffectTextures.Builder();

        foreach (var pair in textures.Images)
        {
            builder.PutTexture(pair.Key, pair.Value.ToBitmap());
        }

        return builder.BuildTyped();
    }
    

    internal static ShareMessengerParams ToShareParams(this Facebook.Messenger.ShareToMessengerParams parameters)
    {
        if(parameters is null || parameters.Uri is null || System.String.IsNullOrEmpty(parameters.Uri.ToString()))
            throw new NullReferenceException("ShareMessengerParams and ContentUri cannot be null when using messenger legacy sharing.");

        if(!ValidUriSchemesForMessengerParams.Contains(parameters.Uri.Scheme))
            throw new NullReferenceException($"ShareMessengerParams.ContentUri.Scheme is invalid. Please use a valid scheme type: {string.Join(", ", ValidUriSchemesForMessengerParams)}");

        return new ShareMessengerParams(parameters.Uri.ToUri(), parameters.MimeType.ToMimeType()) 
            {
                ExternalUri = parameters.ExternalUri.ToUri()
            };
    }

    internal static Facebook.Messenger.ShareToMessengerParams ToNativeShareParams(this ShareMessengerParams parameters)
    {
        if(parameters is null || parameters.ContentUri is null || System.String.IsNullOrEmpty(parameters.ContentUri.ToString()))
            throw new NullReferenceException("ShareMessengerParams and ContentUri cannot be null when using messenger legacy sharing.");

        if(!ValidUriSchemesForMessengerParams.Contains(parameters.ContentUri.Scheme))
            throw new NullReferenceException($"ShareMessengerParams.ContentUri.Scheme is invalid. Please use a valid scheme type: {string.Join(", ", ValidUriSchemesForMessengerParams)}");

        return Facebook.Messenger.ShareToMessengerParams.NewBuilder(parameters.ContentUri.ToNativeUri(), parameters.MimeType.ToNativeMimeType())
            .SetExternalUri(parameters.ExternalUri.ToNativeUri())
            .Build();
    }
}