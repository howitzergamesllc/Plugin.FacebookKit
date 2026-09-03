# Login

[Facebook Login](https://developers.facebook.com/documentation/facebook-login) signs into the Facebook SDK, requests permission, obtains and displays profile information.


## Installation

If not using the [Plugin.FacebookPlugin](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Plugin.md) bundle, you must install [Plugin.Facebook.Core](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/docs/Core.md) as well.

### Nuget

Installing using the dotnet command line interface.
```zsh
dotnet package add Plugin.FacebookKit.Login
```


## Setup

Basic Facebook Setup instructions: [BasicSetup](https://developers.facebook.com/documentation/ios/getting-started)
Follow the basic Plugin.FacebookKit instructions for installing here [BasicPluginSetup](https://github.com/howitzergamesllc/Plugin.FacebookKit/blob/main/Readme.md)
For device login to work you must enable it in your facebook app settings: [Devices](https://developers.facebook.com/documentation/facebook-login/for-devices).

Initialize first and optionally set the "UpdateProfileAutomaticallyOnTokenChanged" setting. Default is true;
```csharp
FacebookPluginShare.Initialize();
```

Listen to TokenChanged and ProfileChanged notifications to get usefull token and profile information.
```csharp
FacebookPluginShare.Current?.AccessTokenChanged += OnAccessTokenChanged;
FacebookPluginShare.Current?.ProfileChanged += OnProfileChanged;
```

Get the global static token and profile objects.
```csharp
FacebookPluginShare.CurrentToken;
FacebookPluginShare.CurrentProfile;
```

### iOS specifics

Recently the facebook sdk for iOS has switched to limited login. See (https://developers.facebook.com/documentation/facebook-login/ios/limited-login) for more details.
Limited login prevents DeviceLoginManager and ProfilePictureView from working correctly. Since there is no Valid AccessToken, the native Graph API calls fail. The facebook profile can still be loaded into memory manually like so:
```csharp
var uri = FacebookPluginShare.CurrentProfile.ImageURL.AbsoluteUri;
mainimage.Source = ImageSource.FromUri(new Uri(uri));
```

### Android specifics

None


## Usage

To use FacebookPluginLogin controls simply call .UseFacebookLoginControls() on the MauiBuilder
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

### Facebook Controls

This package comes with a Facebook LoginButton, TooltipView, and ProfilePictureView. Each can be added directly into xaml like this.

First at the top of the page clear the namespace
```xml
<?xml version="1.0" encoding="UTF-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:facebook="clr-namespace:Plugin.FacebookKit.Login.Controls;assembly=Plugin.FacebookKit.Login"
             x:Class="LoginMauiSample.MainPage">
```

### Facebook Profile Picture View (Android and MacCatalyst only)

```csharp
/// <para>
/// NOTE: With Facebook SDK 18.1.0 and newer, ios defaults to limited login mode.
/// Limited login mode does not have a valid access token so Graph API calls will fail. ProfilePicureView
/// depends on these Graph API calls succeeding when setting the <see cref="Profile"/> property.
/// The profile picture can still be loaded by using <see cref="ImageSource.FromUri(Uri)"/> 
/// and using <see cref="IFacebookPluginLogin.CurrentProfile"/> and inputing <see cref="IProfile.ImageURL"/>.
/// </para>
/// <para>
/// NOTE: When using the facebook sdk <see cref="LoginButton"/>, <see cref="LoginTracking"/> must be set to <see cref="LoginTracking.Limited"/>
/// for manual image loading to work.
/// </para>
```
```xml
<facebook:ProfilePictureView x:Name="profilePicture" HeightRequest="185" WidthRequest="185"
    PictureMode="Large"/>
```

### Facebook TooltipView

This tool tip view can be used to assist with user sign in flow by providing helpful sign in tips.
```xml
<facebook:LoginTooltipView x:Name="ToolTipView" DisplayDuration="8" Tagline="Login"
    Message="Welcome To Facebook Login. Tooltip example."
    HorizontalOptions="Fill" />
```

### Facebook LoginButton

A default sign in buttion will have LoginTracking.Limited, LoginBehavior.NativeAppWithFallback (ios = AppSwitch.Enabled), and AuthType.Rerequest.
(iOS Only with facebook-ios-sdk Version >= 18.1.0) Setting LoginTracking.Enabled (Classic Facebook Signin) interrupts the sign in flow and an invalid profile is generated.
```xml
<facebook:LoginButton
    x:Name="LogInBtn"
    HorizontalOptions="Fill" >
    <facebook:LoginButton.Permissions>
        <x:String>public_profile</x:String>
    </facebook:LoginButton.Permissions>
</facebook:LoginButton>
```

### Manual login using DeviceLoginManager

Devices such as tv's, printers, etc. can also be signed into facebook by prompting the user to go to a website [DeviceSignInUrl](https://www.facebook.com/device) and entering a 8 digit alphanumeric code.

First create the device login manager.
```csharp
private readonly IDeviceLoginManager deviceLoginManager;

deviceLoginManager ??= FacebookPluginLogin.Current?.CreateDeviceLoginManager();
```

Subscribe to the DeviceSignInStarted and DeviceStartedCompleted events.
```csharp
deviceLoginManager?.Started += OnDeviceLoginStarted;
deviceLoginManager?.Completed += OnDeviceLoginCompleted;
```

The event subscription should present the url instructions and the 8 digit alphanumeric code to the user.
```csharp
private void OnDeviceLoginStarted(object? manager, DeviceLoginStartedEventArgs e)
{
    if(e.CodeInfo is not null)
    {
        if(deviceLoginView is null)
        {
            deviceLoginView = new DeviceLoginView(){ CodeInfo = e.CodeInfo, Dismiss = CancelDeviceLogin };
            layout.Add(deviceLoginView);
        }
    }
}
```

The on device login completed event is a good place to remove the DeviceLoginView and unsubscribe from DeviceLoginManager events.
```csharp
private void OnDeviceLoginCompleted(object? manager, DeviceLoginCompletedEventArgs e)
{
    if(deviceLoginView is not null)
    {
        layout.Remove(deviceLoginView);
        deviceLoginManager.Started -= OnDeviceLoginStarted;
        deviceLoginManager.Completed -= OnDeviceLoginCompleted;
        deviceLoginView = null;
    }
}
```

Additionally the the DeviceSignIn view should contain a Cancel button that calls deviceLoginManager.Cancel() and removes the DeviceLoginView, and unsubscribes from event firing from deviceLoginManager.
```csharp
private void CancelDeviceLogin()
{
    if(deviceLoginView is not null)
    {
        layout.Remove(deviceLoginView);
        deviceLoginView = null;
    }
    if(deviceLoginManager is not null)
    {
        deviceLoginManager.Cancel();
        deviceLoginManager.Started -= OnDeviceLoginStarted;
        deviceLoginManager.Completed -= OnDeviceLoginCompleted;
        deviceLoginManager = null;
    }
}
```

Here is an example deviceLoginView control
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentView xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="LoginMauiSample.DeviceLoginView">

    <Border BackgroundColor="Aquamarine">
        <VerticalStackLayout x:Name="layout" Padding="30,0" Spacing="25">
            <Label Text="Device Login Example" Style="{StaticResource SubHeadline}"
                SemanticProperties.HeadingLevel="Level2" />

            <Label x:Name="signInUrl" TextColor="Black" Style="{StaticResource SubHeadline}"
                FontSize="14" SemanticProperties.HeadingLevel="Level2" />

            <Label x:Name="code" TextColor="Black" FontAttributes="Bold"
                Style="{StaticResource SubHeadline}" FontSize="20"
                SemanticProperties.HeadingLevel="Level2" />

            <Button x:Name="CancelBtn" Text="Cancel" Clicked="CancelDeviceLogin"
                HorizontalOptions="Fill" />
        </VerticalStackLayout>
    </Border>

</ContentView>
```

Code behind
```csharp
namespace LoginMauiSample;

public partial class DeviceLoginView : ContentView
{
    public DeviceLoginView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty CodeInfoProperty = BindableProperty.Create(nameof(CodeInfo), typeof(IDeviceLoginCodeInfo), typeof(DeviceLoginView), null, BindingMode.OneWay, propertyChanged: DeviceLoginCodeInfoChanged);
    public static readonly BindableProperty DismissProperty = BindableProperty.Create(nameof(Dismiss), typeof(Action), typeof(DeviceLoginView), null, BindingMode.OneWay);


    public IDeviceLoginCodeInfo CodeInfo
    {
        get => (IDeviceLoginCodeInfo)GetValue(CodeInfoProperty);
        set => SetValue(CodeInfoProperty, value);
    }
    
    public Action Dismiss
    {
        get => (Action)GetValue(DismissProperty);
        set => SetValue(DismissProperty, value);
    }

    public static void DeviceLoginCodeInfoChanged(BindableObject control, object? oldValue, object? newValue)
    {
        if(newValue is null)
            return;

        ((DeviceLoginView)control).signInUrl.Text = "Go To: " + ((IDeviceLoginCodeInfo)newValue).VerificationUrl?.ToString();
        ((DeviceLoginView)control).code.Text = "Enter Code: " + ((IDeviceLoginCodeInfo)newValue).LoginCode;
    }

    public void CancelDeviceLogin(object? sender, EventArgs e) => Dismiss();
}
```

Once set up is complete, simply initiate the device sign in flow by calling Start().
```csharp
private void DeviceLogin(object? sender, EventArgs e)
{
    deviceLoginManager.Start();
}
```
