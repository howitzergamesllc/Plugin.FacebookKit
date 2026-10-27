# Plugin.FacebookKit

This is a wrapper library around the native Android and iOS Facebook SDKs which includes cross-platform APIs for Authentication and Sharing with Facebook Login and Facebook Sharing.


## Supported Features

| Feature | Plugin | Platforms |
|---------|--------|-----------|
| [Core](https://developers.facebook.com/documentation/main) | [Plugin.FacebookKit.Core](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Core.md) | Android, iOS, MacCatalyst |
| [Login](https://developers.facebook.com/documentation/facebook-login) | [Plugin.FacebookKit.Login](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Login.md) | Android, iOS, MacCatalyst |
| [Share](https://developers.facebook.com/documentation/sharing) | [Plugin.FacebookKit.Share](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Share.md) | Android, iOS, MacCatalyst |
| [Plugin] | [Plugin.FacebookKit](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Plugin.md) | Android, iOS, MacCatalyst |


## Nuget Packages

Versions of these packages and android dependencies have been chosen to align transitively with dotnet maui versions. For instance, selecting version 10.0.80 will align android transitive depencies with the same ones used with .NET Maui Version 10.0.80. Transitive dependencies can always be locked by adding package references to the project.

| Package | Version |
|---------|---------|
| [Plugin.FacebookKit](https://www.nuget.org/packages/Plugin.FacebookKit) | [![NuGet](https://img.shields.io/nuget/v/Plugin.FacebookKit.svg)](https://www.nuget.org/packages/Plugin.FacebookKit) |
| [Plugin.FacebookKit.Core](https://www.nuget.org/packages/Plugin.FacebookKit.Core) | [![NuGet](https://img.shields.io/nuget/v/Plugin.FacebookKit.Core.svg)](https://www.nuget.org/packages/Plugin.FacebookKit.Core) |
| [Plugin.FacebookKit.Login](https://www.nuget.org/packages/Plugin.FacebookKit.Login) | [![NuGet](https://img.shields.io/nuget/v/Plugin.FacebookKit.Login.svg)](https://www.nuget.org/packages/Plugin.FacebookKit.Login) |
| [Plugin.FacebookKit.Share](https://www.nuget.org/packages/Plugin.FacebookKit.Share) | [![NuGet](https://img.shields.io/nuget/v/Plugin.FacebookKit.Share.svg)](https://www.nuget.org/packages/Plugin.FacebookKit.Share) |


## Installing a package

The easiest way to install a package on Windows platforms is through Visual Studio Nuget package manager.
[InstallNuget](https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio)

The easiest way to install a package on Mac platform is add it using the terminal. Windows users can also do this too using the dotnet command line interface.
[InstallNuget](https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli)
```zsh
dotnet package add Plugin.FacebookKit
```

Visual studio can resolve the dependency automatically by adding the package reference directly to the .csproj file with the following text
```xml
<ItemGroup>
  <PackageReference Include="Plugin.FacebookKit" Version="10.0.80" />
</ItemGroup>
```


## Intro

This a custom cross platform implementation of binding packages that bind the native SDK's to C#. The information below shows developers the original SDK intent and how they were meant to be used. When reviewing app behavior, developers should always refer to the official Facebook [docs](https://developers.facebook.com/docs). Follow the steps here to get started.

1. [Register](https://developers.facebook.com/documentation/main/register) with Meta as a developer.
2. [Create](https://developers.facebook.com/documentation/main/create-an-app) an app.
3. (Optional) Select use cases such as authentication and access profile information. [Customize](https://developers.facebook.com/documentation/main/app-customization).
4. Implement facebook app project Id's, client tokens, and protocols into the AndroidManifest.xml and Info.plist files. See the sample/FacebookSample project or the following quickstart guides for additional setup details:
  - Android: 
    - [Login](https://developers.facebook.com/documentation/facebook-login/android)
    - [Share](https://developers.facebook.com/documentation/sharing/android#Additional)
  - Apple: 
    - [Login](https://developers.facebook.com/documentation/facebook-login/ios)
    - [Share](https://developers.facebook.com/documentation/sharing/ios#Additional)


## iOS Dependencies

| Package | Version |
|---------|---------|
| [plugin.Facebook.iOS.AEM](https://www.nuget.org/packages/plugin.Facebook.iOS.AEM) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.iOS.AEM.svg)](https://www.nuget.org/packages/plugin.Facebook.iOS.AEM) |
| [plugin.Facebook.iOS.Core](https://www.nuget.org/packages/plugin.Facebook.iOS.Core) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.iOS.Core.svg)](https://www.nuget.org/packages/plugin.Facebook.iOS.Core) |
| [plugin.Facebook.iOS.CoreBasics](https://www.nuget.org/packages/plugin.Facebook.iOS.CoreBasics) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.iOS.CoreBasics.svg)](https://www.nuget.org/packages/plugin.Facebook.iOS.CoreBasics) |
| [plugin.Facebook.iOS.GamingServices](https://www.nuget.org/packages/plugin.Facebook.iOS.GamingServices) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.iOS.GamingServices.svg)](https://www.nuget.org/packages/plugin.Facebook.iOS.GamingServices) |
| [plugin.Facebook.iOS.Login](https://www.nuget.org/packages/plugin.Facebook.iOS.Login) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.iOS.Login.svg)](https://www.nuget.org/packages/plugin.Facebook.iOS.Login) |
| [plugin.Facebook.iOS.Share](https://www.nuget.org/packages/plugin.Facebook.iOS.Share) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.iOS.Share.svg)](https://www.nuget.org/packages/plugin.Facebook.iOS.Share) |



## Android Dependencies

| Package | Version |
|---------|---------|
| [plugin.Facebook.Android.AudienceNetwork](https://www.nuget.org/packages/plugin.Facebook.Android.AudienceNetwork) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.AudienceNetwork.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.AudienceNetwork) |
| [plugin.Facebook.Android](https://www.nuget.org/packages/plugin.Facebook.Android) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.svg)](https://www.nuget.org/packages/plugin.Facebook.Android) |
| [plugin.Facebook.Android.Applinks](https://www.nuget.org/packages/plugin.Facebook.Android.Applinks) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.Applinks.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.Applinks) |
| [plugin.Facebook.Android.Core](https://www.nuget.org/packages/plugin.Facebook.Android.Core) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.Core.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.Core) |
| [plugin.Facebook.Android.Common](https://www.nuget.org/packages/plugin.Facebook.Android.Common) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.Common.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.Common) |
| [plugin.Facebook.Android.GamingServices](https://www.nuget.org/packages/plugin.Facebook.Android.GamingServices) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.GamingServices.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.GamingServices) |
| [plugin.Facebook.Android.Login](https://www.nuget.org/packages/plugin.Facebook.Android.Login) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.Login.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.Login) |
| [plugin.Facebook.Android.Messenger](https://www.nuget.org/packages/plugin.Facebook.Android.Messenger) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.Messenger.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.Messenger) |
| [plugin.Facebook.Android.Share](https://www.nuget.org/packages/plugin.Facebook.Android.Share) | [![NuGet](https://img.shields.io/nuget/v/plugin.Facebook.Android.Share.svg)](https://www.nuget.org/packages/plugin.Facebook.Android.Share) |



## Project Configuration

Be sure to change the `TargetFramework` this project uses (`net10.0-*`)

If using the native Facebook Button Controls is desired, they can be loaded by calling ".UseFacebookControls" in the `MauiProgram.cs` like this:

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
            .UseFacebookControls()
            .Build();
    }
}
```

If only using [Login](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Login.md) is desired, those individual controls can be loaded by calling ".UseFacebookLoginControls" in the `MauiProgram.cs` like this:

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
            .UseFacebookLoginControls()
            .Build();
    }
}
```

The same applies for the [Sharing](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Share.md) component.


## Windows specifics (Not Implemented)

### Calling the implementation instance on Windows
NOTE: Windows is not implemented. This plugin does not crash production Apps when deploying to Windows but calls to the implementation on Windows will throw a NullReferenceException. When deploying to Windows, Calls to implementations should be null checked like this:

```c#
var dialog = FacebookPluginShare.Current?.CreateShareDialog();
var loginManager = FacebookPluginLogin.Current?.CreateLoginManager();
```


## Android specifics

### To receive callbacks from the native Facebook SDK, register the callback manager.
```c#    
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        FacebookMainActivity.CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
    }
```


### (Login Only) Call initialize in the MainActivity.cs by overriding OnCreate
```c#    
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        FacebookPluginLogin.Initialize();
    }
```


### Ensure the `ApplicationId` in the `.csproj` file matches the `bundle_id` and `package_name` inside of the `[Info.plist|AndroidManifest.xml]` files:
```xml
<ApplicationId>com.example.myapp</ApplicationId>
```

Facebook requires adding the HashKey to the project App for testing purposes prior to publishing. To generate the HashKey, it can be computed on AppStart by implementing this in the MainActivity.cs by overriding OnCreate like this:

```csharp
protected override void OnCreate(Bundle? savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    
    PrintFacebookKeyHash();
}

private void PrintFacebookKeyHash()
{
    try
    {
        var packageInfo = PackageManager!.GetPackageInfo(PackageName!, Android.Content.PM.PackageInfoFlags.SigningCertificates);
        var signingInfo = packageInfo.SigningInfo;

        if (signingInfo is null)
        {
            Android.Util.Log.Debug("Facebook", "SigningInfo is null.");
            Console.WriteLine("Facebook", "SigningInfo is null.");
            Debug.WriteLine("Facebook", "SigningInfo is null.");
            return;
        }

        var signatures = signingInfo.HasMultipleSigners ? signingInfo.GetApkContentsSigners() : signingInfo.GetSigningCertificateHistory();

        foreach (var signature in signatures!)
        {
            using var sha1 = MessageDigest.GetInstance("SHA");

            sha1.Update(signature.ToByteArray());

            var hash = Android.Util.Base64.EncodeToString(sha1.Digest()!, Android.Util.Base64Flags.NoWrap);

            Android.Util.Log.Debug("Facebook", $"Key Hash: {hash}");
            Console.WriteLine($"Facebook HashKey: {hash}");
            Debug.WriteLine($"Facebook HashKey: {hash}");
        }
    }
    catch (Exception ex)
    {
        Android.Util.Log.Error("Facebook", $"Failed to get key hash: {ex}");
        Console.WriteLine($"Facebook Failed to get key hash: {ex}");
        Debug.WriteLine($"Facebook Failed to get key hash: {ex}");
    }
}
```


## iOS specifics

### To intialize Facebook SDK and get callbacks from the native Facebook SDK, register the SDK's AppDelegate. If using Login, call initialize here.
```c#    
using Foundation;
using UIKit;
using Plugin.FacebookKit.Core;

namespace ShareMauiSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions)
    {
        FacebookPluginLogin.Initialize();
        FacebookApplicationDelegate.DidFinishLaunching(application, launchOptions);
        return base.FinishedLaunching(application, launchOptions);;
    }

    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        return FacebookApplicationDelegate.OpenUrl(app, url, options);
    }
    
    public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
    {
        FacebookApplicationDelegate.Application(application, userActivity);
        return base.ContinueUserActivity(application, userActivity, completionHandler);
    }

    public override void OnActivated(UIApplication application)
    {
        FacebookApplicationDelegate.ActivateApp();
        base.OnActivated(application);
    }
}
```


## Documentation and samples

See the [docs](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs) for more details on feature implementation.

In the [samples](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/samples) folder there are two sample projects, one for sharing and one for login. 
Though there is no combinded sample, if using both features, developers can simply use [Plugin.FacebookKit](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Plugin.md).

To run the sample successfully, ensure to update the `Info.plist, Entitlements.plist, String.xml, AndroidManifest.xml` files to match the app project information in your facebook app project.


## License

The license developers are required to accept is a standard MIT license located here:
[License.md](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/License.md)


## Release notes

### Version 10.0.101
  - Updated Microsoft.Maui.Controls to 10.0.101.

### Version 10.0.100
  - Updated Microsoft.Maui.Controls to 10.0.100.

### Version 10.0.90
  - Updated Microsoft.Maui.Controls to 10.0.90.

### Version 10.0.80
  - Initial release.
