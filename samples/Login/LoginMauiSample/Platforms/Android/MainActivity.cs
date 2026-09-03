using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Login;

namespace LoginMauiSample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        FacebookPluginLogin.Initialize();
    }
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        FacebookMainActivity.CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
    }
}