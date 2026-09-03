
using Foundation;
using Photos;
using SafariServices;

namespace Plugin.FacebookKit.Share.Platforms.iOS.Extensions;

[Preserve(AllMembers = true)]
internal static class ImageSourceExtensions
{
    public static async Task<byte[]> ToBytesAsync(this ImageSource imageSource)
    {
        Stream? stream = imageSource switch
        {
            StreamImageSource streamSource => await streamSource.Stream(CancellationToken.None),

            FileImageSource fileSource => await FileSystem.OpenAppPackageFileAsync(fileSource.File),

            UriImageSource uriSource => await new HttpClient().GetStreamAsync(uriSource.Uri),

            _ => null
        };

        if (stream is null)
            return Array.Empty<byte>();

        using var memory = new MemoryStream();

        await stream.CopyToAsync(memory);

        return memory.ToArray();
    }

    public static PHAsset? ToPHAsset(this string filePath)
    {
        string? localIdentifier = null;

        PHPhotoLibrary.SharedPhotoLibrary.PerformChangesAndWait(() =>
            {
                if(filePath is null)
                    return;

                var url = NSUrl.FromString(filePath);
                
                if(url is null)
                    return;
                    
                var request = PHAssetChangeRequest.FromVideo(url);
                localIdentifier = request?.PlaceholderForCreatedAsset?.LocalIdentifier;
            }, out var error);

        if (error is not null)
            throw new NSErrorException(error);

        if (string.IsNullOrEmpty(localIdentifier))
            return null;

        var assets = PHAsset.FetchAssetsUsingLocalIdentifiers(new[] { localIdentifier }, null);

        return assets.FirstObject as PHAsset;
    }

    public static async Task<PHAsset?> ToPHAssetAsync(string filePath)
    {
        var status = await PHPhotoLibrary.RequestAuthorizationAsync(PHAccessLevel.AddOnly);

        if (status != PHAuthorizationStatus.Authorized)
            return null;

        var tcs = new TaskCompletionSource<PHAsset?>(TaskCreationOptions.RunContinuationsAsynchronously);

        string? localIdentifier = null;

        PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
            {                
                if(filePath is null)
                    return;

                var url = NSUrl.FromString(filePath);
                
                if(url is null)
                    return;
                    
                var request = PHAssetChangeRequest.FromVideo(url);
                localIdentifier =request?.PlaceholderForCreatedAsset?.LocalIdentifier;
            },
            (success, error) =>
            {
                if (!success)
                {
                    tcs.TrySetException(error is not null ? new NSErrorException(error) : new Exception("Failed to create PHAsset."));
                    return;
                }

                if (string.IsNullOrEmpty(localIdentifier))
                {
                    tcs.TrySetResult(null);
                    return;
                }

                var assets = PHAsset.FetchAssetsUsingLocalIdentifiers( new[] { localIdentifier }, null);
                tcs.TrySetResult(assets.FirstObject as PHAsset);
            });

        return await tcs.Task;
    }

}
