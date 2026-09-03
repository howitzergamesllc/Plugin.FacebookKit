
namespace Plugin.FacebookKit.Login;

internal class FacebookAccessTokenTracker : Facebook.AccessTokenTracker
{
    protected override void OnCurrentAccessTokenChanged(Facebook.AccessToken oldAccessToken, Facebook.AccessToken currentAccessToken)
    {
        FacebookPluginLoginImplementation? implementation = FacebookPluginLogin.Current as FacebookPluginLoginImplementation;
        implementation?.AccessTokenDidChange();
    }
}