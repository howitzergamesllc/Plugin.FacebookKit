
using Android.App;
using Android.Content;
using Android.Content.PM;
using Plugin.FacebookKit.Core;

namespace ShareMauiSample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        FacebookMainActivity.CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
    }
}
