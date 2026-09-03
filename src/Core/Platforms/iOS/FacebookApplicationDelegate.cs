
using Facebook.Core;

namespace Plugin.FacebookKit.Core;

/// <summary>
/// Global call back implementations for Facebook Sharing and Login SDKs.
/// </summary>
/// <remarks>
/// Each of these methods must be called by overriding life cycle events in the AppDelegate's for Apple platforms.
/// </remarks>
public sealed class FacebookApplicationDelegate
{
    /// <summary>
    /// Calls DidFinishLaunching on the shared instance of the FBSDKApplicationDelegate. 
    /// Required for initializing the Facebook SDK on Apple devices.
    /// </summary>
    /// <param name="application">The main application</param>
    /// <param name="launchOptions">Launch options used for the App if any.</param>
    /// <remarks>
    /// This can be implemented by overriding the FinishedLaunching lifecycle event in the AppDelegate class of each Apple platform.
    /// </remarks>
    public static void DidFinishLaunching(UIApplication application, NSDictionary? launchOptions) => FBSDKApplicationDelegate.SharedInstance.DidFinishLaunching(application, launchOptions);

    /// <summary>
    /// Calls OpenURL on the shared instance of the FBSDKApplicationDelegate. 
    /// Required for initializing the Facebook SDK on Apple devices.
    /// </summary>
    /// <param name="app">The main application</param>
    /// <param name="url">The URL to handle.</param>
    /// <param name="options">Options applied, if any</param>
    /// <remarks>
    /// This can be implemented by overriding the OpenUrl lifecycle event in the AppDelegate class of each Apple platform and returning this call instead of the original call.
    /// See https://developers.facebook.com/documentation/ios/getting-started for more details.
    /// </remarks>
    public static bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options) => FBSDKApplicationDelegate.SharedInstance.OpenUrl(app, url, options);

    /// <summary>
    /// Calls Application on the shared instance of the FBSDKApplicationDelegate. 
    /// Required for initializing the Facebook SDK on Apple devices.
    /// </summary>
    /// <param name="application">The main application</param>
    /// <param name="userActivity">The user activity to continue.</param>
    /// <remarks>
    /// This can be implemented by overriding the ContinueUserActivity lifecycle event in the AppDelegate class of each Apple platform.
    /// See https://developers.facebook.com/documentation/ios/getting-started for more details.
    /// </remarks>
    public static bool Application(UIApplication application, NSUserActivity userActivity) => FBSDKApplicationDelegate.SharedInstance.Application(application, userActivity);

    /// <summary>
    /// Calls ActivateApp on the shared instance of the FBSDKAppEvents. 
    /// Required if manually tracking app events on Apple devices.
    /// </summary>
    /// <remarks>
    /// This can be implemented by overriding the OnActivated lifecycle event in the AppDelegate class of each Apple platform.
    /// See https://developers.facebook.com/documentation/ios/getting-started for more details.
    /// </remarks>
    public static void ActivateApp() => FBSDKAppEvents.Shared.ActivateApp();
}