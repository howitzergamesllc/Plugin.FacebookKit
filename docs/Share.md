# Share

[Facebook Share](https://developers.facebook.com/documentation/sharing) allows users to share embedded photo
content as well as links to remote photos, videos, store pages, and more.


## Installation
If not using the [Plugin.FacebookPlugin](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Plugin.md) bundle, you must install [Plugin.Facebook.Core](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Core.md) as well.

### Nuget
Installing using the dotnet command line interface.
```zsh
dotnet package add Plugin.FacebookKit.Share
```


## Setup

Basic Facebook Setup instructions: [BasicSetup](https://developers.facebook.com/documentation/ios/getting-started)
Follow the basic Plugin.FacebookKit instructions for installing here [BasicPluginSetup](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/Readme.md)

### iOS specifics

For video sharing, the following Key must be added to the info.plist.

```xml
<key>NSPhotoLibraryUsageDescription</key>
<string>Allow access to your photos and videos to share with Facebook.</string>
```

### Android specifics

Currently, the native MessageDialog can't resolve "PlatformActivity" from the latest Facebook messenger apps on Galaxy S21's. This plugin implemented a workaround to sharing through messenger with some drawbacks.

With this workaround, apps can send text, hyperlinks, photos, videos, and audio through messenger but without any callbacks. When using the regular Intent emitted by the messenger App, a successful share will still resolve to a platform activity of "Cancelled".


## Usage Examples

To use FacebookPluginShare controls simply call .UseFacebookShareControls() on the MauiBuilder
```c#
using Plugin.FacebookKit;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        return MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            ...
            .UseFacebookShareControls()
            .Build();
    }
}
```

### Facebook Controls

This package comes with a Facebook ShareButton and SendButton. Each can be added directly into xaml like this.

First at the top of the page clear the namespace
```xml
<?xml version = "1.0" encoding = "UTF-8"?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
            xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
            xmlns:facebook="clr-namespace:Plugin.FacebookKit.Share.Controls;assembly=Plugin.FacebookKit.Share"
            x:Class="ShareMauiSample.MainPage">
```

### (Sharing an Image with Facebook Share Button)

Sharing an image using the Facebook Share button is easier than ever. Create the button.
```xml
<facebook:FacebookShareButton x:Name="ImageMemoryShareBtn"/>
```

And set the image content.
```csharp
var photo = new SharePhoto(await LoadImageBytes("nameofyourphoto.png"), false);
var photoContent = new SharePhotoContent([photo]);
ImageMemoryShareBtn.ShareContent = photoContent;
```

### (Sending an Image with Facebook Send Button)

Sending content requires MessageDialog which is only compatible with ShareLinkContent objects.
Sharing an image using the Facebook Share button is easier than ever. Create the button.
```xml
<facebook:FacebookSendButton x:Name="ImageSendBtn"/>
```

And set the share link content referencing the remote image uri.
```csharp
var shareLinkContent = new ShareLinkContent()
{
    Quote = "ShareLinkContentExample",
    ContentUri = new Uri("https://play-lh.googleusercontent.com/3wB6CwK-0w5nq2FNgvTj9hvX_DttTnsB8nfiTgIVmGIAEXW0typUDypiczHtwKjDZvVx0PCOwS0a3nQXonpG=w5120-h2880-rw"),
};
```

Create the MessageDialog 
```csharp
var dialog = FacebookPluginShare.Current?.CreateMessageDialog(linkContent);
```

(Optional) Subscribe and respond to sharing events.
```csharp
dialog.OnShareCompleted += OnShareCompleted;
dialog.OnShareFailed += OnShareFailed;
dialog.OnShareCancelled += OnShareCancelled;
```

Set the content and dialog to the send button
```csharp
ImageSendBtn.LinkContent = linkContent;
ImageSendBtn.MessageDialog = dialog;
```


## Usage Example 

### (Sharing an Image Manually)

For sharing an maui ImageAsset photo from the app, load the image into byte[].
```csharp
private async Task<byte[]> LoadImageBytes(string imageResource)
{
    await using var stream = await FileSystem.OpenAppPackageFileAsync(imageResource);

    using var ms = new MemoryStream();
    await stream.CopyToAsync(ms);

    return ms.ToArray();
}
```

Create a new SharePhoto object with the byte[].
```csharp
var photo = new SharePhoto(await LoadImageBytes("nameofyourphoto.png"), false);
```

Create a new SharePhotoContent object with the photo(s).
```csharp
var photoContent = new SharePhotoContent([photo]){ Reference = nameof(ManualImageShareBtn).ToString()};
```

(Optional) Add a Tag to the photo for facebook to add if desired.
```csharp
photoContent.Hashtag = new HashTag("#swipewriter")
{
    Hash = 1
};
```

Create the share dialog to present to the user.
```csharp
var dialog = FacebookPluginShare.Current?.CreateShareDialog(photoContent);
```

(Optional) Subscribe and respond to sharing events.
```csharp
dialog.OnShareCompleted += OnShareCompleted;
dialog.OnShareFailed += OnShareFailed;
dialog.OnShareCancelled += OnShareCancelled;

private void OnShareCompleted(object? sender, FacebookSharingCompletedEventArgs e)
{
    if(sender is ISharing sharer)
    {
        Console.WriteLine($"OnShareComplete Sharer: {sharer.ShareContent?.Reference}");
        Debug.WriteLine($"OnShareComplete Sharer: {sharer.ShareContent?.Reference}");
        if(e is not null && e.Results is not null)
        {
            foreach(var kvp in e.Results)
            {
                Console.WriteLine($"OnShareComplete Key: {kvp.Key}, Value: {kvp.Value?.ToString()}");
                Debug.WriteLine($"OnShareComplete Key: {kvp.Key}, Value: {kvp.Value?.ToString()}");
            }
        }
    }
}

private void OnShareFailed(object? sender, FacebookSharingFailedEventArgs e)
{
    if(sender is ISharing sharer)
    {
        Console.WriteLine($"OnShareFailed Sharer: {sharer.ShareContent?.Reference}");
        Debug.WriteLine($"OnShareFailed Sharer: {sharer.ShareContent?.Reference}");
        Console.WriteLine($"OnShareFailed Error: {e.Error.Message}");
        Debug.WriteLine($"OnShareFailed Error: {e.Error.Message}");
    }
}

private void OnShareCancelled(object? sender, EventArgs e)
{
    if(sender is ISharing sharer)
    {
        Console.WriteLine($"OnShareCancelled Sharer: {sharer.ShareContent?.Reference}");
        Debug.WriteLine($"OnShareCancelled Sharer: {sharer.ShareContent?.Reference}");
    }
}
```

Show the dialog.
```csharp
dialog.Show();
```
