# Core
NOTE: If using Plugin.FacebookKit, installation of Core and SDK customization is already included.

### Nuget

Installing using the dotnet command line interface.
```zsh
dotnet package add Plugin.FacebookKit.Core
```


## Setup

Basic Facebook Setup instructions: [BasicSetup](https://developers.facebook.com/documentation/ios/getting-started)
Follow the basic Plugin.FacebookKit instructions for installing here [BasicPluginSetup](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/Readme.md)


## Initialization

Both platforms auto initialize, just make sure to follow the [BasicPluginSetup](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/Readme.md) instructions to get the native SDK callbacks for sharing and login.


## Customization

The native SDK properties for each platform have been made statically available for customization. However, developers should use caution when accessing the properties and some changes can have permanent effects on the installation until the implementing App is cleaned is reinstalled. To change the native settings, override each platforms App create lifecycle event.


### iOS specifics

For customizing the installation on iOS, add the correct namespace to the top of the AppDelegate and override the FinishedLaunching method in the AppDelegate.
Here is an example of disabling Advertising ID tracking.

```csharp
using Plugin.FacebookKit.Core.Platforms.iOS;

public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions)
{
    FacebookPlugin.AdvertiserTrackingEnabled = false;
    FacebookApplicationDelegate.DidFinishLaunching(application, launchOptions);
    return base.FinishedLaunching(application, launchOptions);;
}
```

### Android specifics

- For customizing the installation on Android, add the correct namespace to the top of the MainActivity.cs and override the OnCreate method in the MainActivity.
Here is an example of disabling Advertising ID tracking.

```csharp
using Plugin.FacebookKit.Core.Platforms.Android;

protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
{
    base.OnActivityResult(requestCode, resultCode, data);
    FacebookPlugin.AdvertiserIDCollectionEnabled = false;
    FacebookMainActivity.CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
}
```