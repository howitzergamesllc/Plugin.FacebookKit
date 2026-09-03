using Foundation;
using UIKit;
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Login;

namespace LoginMauiSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions)
    {
        FacebookPluginLogin.Initialize();
        FacebookApplicationDelegate.DidFinishLaunching(application, launchOptions);
        return base.FinishedLaunching(application, launchOptions);
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
