

namespace Plugin.FacebookKit.Login;

internal class FacebookProfileTracker : Facebook.ProfileTracker
{
    protected override void OnCurrentProfileChanged(Facebook.Profile oldProfile, Facebook.Profile currentProfile)
    {
        FacebookPluginLoginImplementation? implementation = FacebookPluginLogin.Current as FacebookPluginLoginImplementation;
        implementation?.ProfileDidChange();
    }
}