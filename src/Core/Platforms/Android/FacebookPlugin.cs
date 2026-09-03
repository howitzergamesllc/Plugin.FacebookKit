
using Content = Android.Content;
using Facebook;
using Plugin.FacebookKit.Core.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Core.Platforms.Android;

/// <summary>
/// Provides methods for inspecting the Facebook SDK on Android.
/// </summary>
/// <remarks>
/// </remarks>
public static class FacebookPlugin
{
    /// <summary>
    /// (OBSOLETE) Automatically called on app start. Developers can call <see cref="FullyInitialize"/> if needed.
    /// </summary>
    /// <param name="context">The main android context to initialize Facebook with.</param>
    [Obsolete("SdkInitialized was replaced with .FullyInitialize. FacebookSdk.FullyInitialize is called automatically at app start.")]
    public static void Initialize(Content.Context context) => FacebookSdk.SdkInitialize(context);

    /// <summary>
    /// Automatically called on app start. Developers can check <see cref="IsInitialized"/> in the create lifecycle event prior to calling this.
    /// </summary>
    /// <remarks>
    /// <see cref="AutoInitEnabled"/> should be set to false when manually initializing.
    /// </remarks>
    public static void FullyInitialize() => FacebookSdk.FullyInitialize();

    /// <summary>
    /// The flag for adding users to the messaging customer base for WhatsApp. Set to true or false to explicitly include the field in the payload, or null to not send the field (default).
    /// </summary>
    public static bool AddToMessagingCustomerBaseForWhatsApp
    {
        get => FacebookSdk.AddToMessagingCustomerBaseForWhatsApp.BooleanValue();
        set => FacebookSdk.AddToMessagingCustomerBaseForWhatsApp = value ? Java.Lang.Boolean.True : Java.Lang.Boolean.False;
    }

    /// <summary>
    /// Flag to set whether identifier collection is enabled for advertising.
    /// </summary>
    public static bool AdvertiserIDCollectionEnabled
    {
        get => FacebookSdk.AdvertiserIDCollectionEnabled;
        set => FacebookSdk.AdvertiserIDCollectionEnabled = value;
    } 

    /// <summary>
    /// Gets the context Facebook was intitialized with.
    /// </summary>
    public static Content.Context ApplicationContext => FacebookSdk.ApplicationContext;

    /// <summary>
    /// The Facebook application ID for the current app. This should only be called after the SDK has been initialized by calling FacebookSdk.sdkInitialize().
    /// </summary>
    public static string? ApplicationId 
    {
        get => FacebookSdk.ApplicationId;
        set => FacebookSdk.ApplicationId = value;
    }

    /// <summary>
    /// The application name. Automatically populated if the AndroidManifest.xml is complete with an application id. It can also be manually set here.
    /// </summary>
    public static string? ApplicationName 
    {
        get => FacebookSdk.ApplicationName;
        set => FacebookSdk.ApplicationName = value;
    }

    /// <summary>
    /// Sets whether or not to disable auto initialization of the facebook SDK. The default value is <c>true</c>.
    /// </summary>
    public static bool AutoInitEnabled 
    {
        get => FacebookSdk.AutoInitEnabled;
        set => FacebookSdk.AutoInitEnabled = value;
    }

    /// <summary>
    /// Sets whether or not to bypass native app switching for dialogs (LoginDialog, ShareDialog, and GameRequestDialog). The default value is <c>false</c>.
    /// </summary>
    public static bool BypassAppSwitch 
    {
        get => FacebookSdk.BypassAppSwitch;
        set => FacebookSdk.BypassAppSwitch = value;
    }

    /// <summary>
    /// the cache directory to use for caching responses, etc. The default will be the value returned by Context.getCacheDir() 
    /// when the SDK was initialized, but it can be overridden.
    /// </summary>
    public static DirectoryInfo CacheDir
    {
        get => new(FacebookSdk.CacheDir.AbsolutePath);
        set => FacebookSdk.CacheDir = new Java.IO.File(value.FullName);
    }

    /// <summary>
    /// The callback request code offset. The request codes starting at this offset and the next 100 values are used by the Facebook SDK.
    /// </summary>
    public static int CallbackRequestCodeOffset => FacebookSdk.CallbackRequestCodeOffset;

    /// <summary>
    /// The client token for the current app. This will be null unless explicitly set or unless loadDefaultsFromMetadata has been called.
    /// </summary>
    public static string? ClientToken 
    {
        get => FacebookSdk.ClientToken;
        set => FacebookSdk.ClientToken = value;
    }

    /// <summary>
    /// Sets whether or not to enable codeless debug logging. The default value is <c>false</c>.
    /// </summary>
    public static bool CodelessDebugLogEnabled 
    {
        get => FacebookSdk.CodelessDebugLogEnabled;
        set => FacebookSdk.CodelessDebugLogEnabled = value;
    }
    
    /// <summary>
    /// Flag indicating if codeless setup is enabled.
    /// </summary>
    public static bool CodelessSetupEnabled => FacebookSdk.CodelessSetupEnabled;

    /// <summary>
    /// The Executor used by the SDK for non-AsyncTask background work.
    /// By default this uses AsyncTask Executor via reflection if the API level is high enough. 
    /// Otherwise this creates a new Executor with defaults similar to those used in AsyncTask.
    /// </summary>
    public static Java.Util.Concurrent.IExecutor Executor 
    {
        get => FacebookSdk.Executor;
        set => FacebookSdk.Executor = value;
    }

    /// <summary>
    /// The base Facebook domain to use when making Web Requests; in production code this will always be "facebook.com".
    /// </summary>
    public static string? FacebookDomain => FacebookSdk.FacebookDomain;

    /// <summary>
    /// The base Facebook gaming domain to use when making Web Requests; in production code this will always be "fb.gg".
    /// This is required for Custom Update Dialogs which always need to use fb.gg
    /// </summary>
    public static string? FacebookGamingDomain => FacebookSdk.FacebookGamingDomain;

    /// <summary>
    /// the Graph API version to use when making Graph requests. 
    /// This defaults to the latest Graph API version at the time when the Facebook SDK is shipped.
    /// </summary>
    public static string? GraphApiVersion 
    {
        get => FacebookSdk.GraphApiVersion;
        set => FacebookSdk.GraphApiVersion = value;
    }

    /// <summary>
    /// The base Facebook domain to use when making Graph API requests; in production code this will normally be "facebook.com". However certain Access Tokens are meant to be used with other domains. Currently gaming -> fb.g
    /// This checks the current Access Token (if any) and returns the correct domain to use.
    /// </summary>
    public static string? GraphDomain => FacebookSdk.GraphDomain;

    /// <summary>
    /// Indicates if custom tab prefetching is enabled.
    /// </summary>
    public static bool HasCustomTabsPrefetching 
    {
        get => FacebookSdk.HasCustomTabsPrefetching;
        set => FacebookSdk.HasCustomTabsPrefetching = value;
    }

    /// <summary>
    /// Indicates if app switching should be disabled for logging out.
    /// </summary>
    public static bool IgnoreAppSwitchToLoggedOut 
    {
        get => FacebookSdk.IgnoreAppSwitchToLoggedOut;
        set => FacebookSdk.IgnoreAppSwitchToLoggedOut = value;
    }

    /// <summary>
    /// The base Instagram domain to use when making Web Requests; in production code this will always be "instagram.com".
    /// </summary>
    public static string? InstagramDomain => FacebookSdk.InstagramDomain;

    /// <summary>
    /// the Intent URI Package Target configured by the application. This specifies the package name to target when launching intent URIs during login redirects.
    /// Note: This should be just the package name (e.g., "com.example.app"). The SDK will automatically construct the intent URI format: "intent://[packageName]"
    /// </summary>
    public static string? IntentUriPackageTarget => FacebookSdk.IntentUriPackageTarget;

    /// <summary>
    /// Used to enable or disable logging, and other debug features. Defaults to BuildConfig.DEBUG.
    /// </summary>
    public static bool IsDebugEnabled 
    {
        get => FacebookSdk.IsDebugEnabled;
        set => FacebookSdk.IsDebugEnabled = value;
    }

    /// <summary>
    /// Determines if the code value is within FacebookSdk's range of internal codes. 
    /// This does not include request codes that you explicitly set on the dialogs, buttons or LoginManager. 
    /// The range of request codes that the SDK uses starts at the callbackRequestCodeOffset and continues for the next 100 values.
    /// </summary>
    /// <param name="code">The code value to check.</param>
    /// <returns><c>true</c> if the request code is within the range used by Facebook SDK requests.</returns>
    public static bool IsFacebookRequestCode(int code) => FacebookSdk.IsFacebookRequestCode(code);

    /// <summary>
    /// Indicates if the SDK is "FULLY" initialized.
    /// </summary>
    [Obsolete("Use IsInitialized instead.")]
    public static bool IsFullyInitialized => FacebookSdk.IsFullyInitialized;

    /// <summary>
    /// Indicates if the SDK is initialized.
    /// </summary>
    public static bool IsInitialized => FacebookSdk.IsInitialized;

    /// <summary>
    /// Certain logging behaviors are available for debugging beyond those that should be enabled in production.
    /// Checks if a particular extended logging behavior is enabled.
    /// </summary>
    public static bool IsLoggingBehaviorEnabled(string behavior) => FacebookSdk.IsLoggingBehaviorEnabled(behavior.ToNativeLoggingBehavior());

    /// <summary>
    /// Indicates if the SDK should fallback and read the legacy token. This is turned off by default for performance.
    /// </summary>
    public static bool LegacyTokenUpgradeSupported 
    {
        get => FacebookSdk.LegacyTokenUpgradeSupported;
        set => FacebookSdk.LegacyTokenUpgradeSupported = value;
    }

    /// <summary>
    /// Returns whether data such as those generated through AppEventsLogger and sent to Facebook should be restricted from being used for purposes other than analytics and conversions, 
    /// such as targeting ads to this user. Defaults to false. This value is stored on the device and persists across app launches.
    /// </summary>
    /// <param name="context">Used to read the value.</param>
    /// <returns><c>true</c> if event and data usage is limited.</returns>
    public static bool GetLimitEventAndDataUsage(Content.Context context) => FacebookSdk.GetLimitEventAndDataUsage(context);

    /// <summary>
    /// Sets whether data such as those generated through AppEventsLogger and sent to Facebook should be restricted from being used 
    /// for purposes other than analytics and conversions, such as targeting ads to this user. Defaults to false. 
    /// This value is stored on the device and persists across app launches. Changes to this setting will apply to app events currently queued to be flushed.
    /// </summary>
    /// <param name="context">Used to persist this value across app runs.</param>
    /// <param name="limitEventUsage">Set to <c>true</c> to limit event and data usage.</param>
    public static void SetLimitEventAndDataUsage(Content.Context context, bool limitEventUsage) => FacebookSdk.SetLimitEventAndDataUsage(context, limitEventUsage);
    

    /// <summary>
    /// Gets the logging behaviors currently enabled for the Facebook SDK.
    /// </summary>
    public static ICollection<string> LoggingBehaviors => FacebookSdk.LoggingBehaviors.Select(p => p.ToString()).ToArray();

    /// <summary>
    /// Flag indicating if the Facebook monitor is enabled.
    /// </summary>
    public static bool MonitorEnabled 
    {
        get => FacebookSdk.MonitorEnabled;
        set => FacebookSdk.MonitorEnabled = value;
    }

    /// <summary>
    /// The threshold used to report progress on requests. Note that the value will be read when the request is started and cannot 
    /// be changed during a request (or batch) execution.
    /// </summary>
    public static long OnProgressThreshold 
    {
        get => FacebookSdk.OnProgressThreshold;
        set => FacebookSdk.OnProgressThreshold = value;
    }

    /// <summary>
    /// The https redirectURI configured by the application. This is a secure method to pass the login token to a verified receiver.
    /// </summary>
    public static string RedirectURI => FacebookSdk.RedirectURI;

    /// <summary>
    /// The version of the current Facebook SDK.
    /// </summary>
    public static string SdkVersion => FacebookSdk.SdkVersion;
}
