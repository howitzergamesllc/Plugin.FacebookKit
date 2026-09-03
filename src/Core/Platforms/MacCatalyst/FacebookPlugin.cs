using Facebook.Core;
using Plugin.FacebookKit.Core.Platforms.MacCatalyst.Extensions;

namespace Plugin.FacebookKit.Core.Platforms.MacCatalyst;

/// <summary>
/// Provides methods for inspecting the Facebook SDK on Android.
/// </summary>
/// <remarks>
/// The FacebookSdk automatically initializes with appropriate settings for production mode. Changing settings here
/// should be avoided for best performance.
/// </remarks>
public static class FacebookPlugin
{
    /// <summary>
    /// The flag for adding users to the messaging customer base for WhatsApp. Set to true or false to explicitly include the field in the payload, or null to not send the field (default).
    /// </summary>
    public static int AddToMessagingCustomerBaseForWhatsApp
    {
        get => (int)FBSDKSettings.SharedSettings.AddToMessagingCustomerBaseForWhatsApp;
        set => FBSDKSettings.SharedSettings.AddToMessagingCustomerBaseForWhatsApp = value;
    }

    /// <summary>
    /// Flag to set whether identifier collection is enabled for advertising.
    /// </summary>
    public static bool AdvertiserIDCollectionEnabled
    {
        get => FBSDKSettings.SharedSettings.IsAdvertiserIDCollectionEnabled;
        set => FBSDKSettings.SharedSettings.IsAdvertiserIDCollectionEnabled = value;
    } 

    /// <summary>
    /// Flag to set whether tracking is enabled for advertising.
    /// </summary>
    public static bool AdvertiserTrackingEnabled
    {
        get => FBSDKSettings.SharedSettings.IsAdvertiserTrackingEnabled;
        set => FBSDKSettings.SharedSettings.IsAdvertiserTrackingEnabled = value;
    } 

    /// <summary>
    /// The Facebook application ID for the current app. This should only be called after the SDK has been initialized by calling FacebookSdk.sdkInitialize().
    /// </summary>
    public static string? ApplicationId 
    {
        get => FBSDKSettings.SharedSettings.AppID;
        set => FBSDKSettings.SharedSettings.AppID = value;
    }

    /// <summary>
    /// The application name. Automatically populated if the AndroidManifest.xml is complete with an application id. It can also be manually set here.
    /// </summary>
    public static string? ApplicationName 
    {
        get => FBSDKSettings.SharedSettings.DisplayName;
        set => FBSDKSettings.SharedSettings.DisplayName = value;
    }

    /// <summary>
    /// Indicates whether to use cached values for expensive metadata.
    /// </summary>
    public static bool ShouldUseCachedValuesForExpensiveMetadata
    {
        get => FBSDKSettings.SharedSettings.ShouldUseCachedValuesForExpensiveMetadata;
        set => FBSDKSettings.SharedSettings.ShouldUseCachedValuesForExpensiveMetadata = value;
    }

    /// <summary>
    /// The client token for the current app. This will be null unless explicitly set or unless loadDefaultsFromMetadata has been called.
    /// </summary>
    public static string? ClientToken 
    {
        get => FBSDKSettings.SharedSettings.ClientToken;
        set => FBSDKSettings.SharedSettings.ClientToken = value;
    }

    /// <summary>
    /// Sets whether or not to enable codeless debug logging. The default value is <c>false</c>.
    /// </summary>
    [Obsolete("Will be removed in the next major release.")]
    public static bool CodelessDebugLogEnabled 
    {
        get => FBSDKSettings.SharedSettings.CodelessDebugLogEnabled;
        set => FBSDKSettings.SharedSettings.CodelessDebugLogEnabled = value;
    }

    /// <summary>
    /// The base Facebook domain to use when making Web Requests; in production code this will always be "facebook.com".
    /// </summary>
    public static string? FacebookDomain => FBSDKSettings.SharedSettings.FacebookDomainPart;

    /// <summary>
    /// the Graph API version to use when making Graph requests. 
    /// This defaults to the latest Graph API version at the time when the Facebook SDK is shipped.
    /// </summary>
    public static string GraphApiVersion 
    {
        get => FBSDKSettings.SharedSettings.GraphAPIVersion;
        set => FBSDKSettings.SharedSettings.GraphAPIVersion = value;
    }

    /// <summary>
    /// Used to enable or disable logging, and other debug features. Defaults to enabled
    /// </summary>
    public static bool IsDebugEnabled 
    {
        get => FBSDKSettings.SharedSettings.IsCodelessDebugLogEnabled;
        set => FBSDKSettings.SharedSettings.IsCodelessDebugLogEnabled = value;
    }

    /// <summary>
    /// Certain logging behaviors are available for debugging beyond those that should be enabled in production.
    /// Checks if a particular extended logging behavior is enabled.
    /// </summary>
    public static bool IsLoggingBehaviorEnabled(string behavior) => FBSDKSettings.SharedSettings.IsLoggingBehaviorEnabled(behavior);

    /// <summary>
    /// Sets whether data such as those generated through AppEventsLogger and sent to Facebook should be restricted from being used 
    /// for purposes other than analytics and conversions, such as targeting ads to this user. Defaults to false. 
    /// This value is stored on the device and persists across app launches. Changes to this setting will apply to app events currently queued to be flushed.
    /// </summary>
    public static bool IsEventDataUsageLimited
    {
        get => FBSDKSettings.SharedSettings.IsEventDataUsageLimited;
        set => FBSDKSettings.SharedSettings.IsEventDataUsageLimited = value;
    }
    
    /// <summary>
    /// The version of the current Facebook SDK.
    /// </summary>
    public static string SdkVersion => FBSDKSettings.SharedSettings.SdkVersion;

    /// <summary>
    /// The time and day advertising tracking was enabled.
    /// </summary>
    public static DateTimeOffset? AdvertiserTrackingEnabledTimestamp => FBSDKSettings.SharedSettings.AdvertiserTrackingEnabledTimestamp?.ToDateTimeOffset();

    /// <summary>
    /// The status of advertising tracking (Allowed, Disawllowed, Unspecified).
    /// </summary>
    public static string AdvertisingTrackingStatus => FBSDKSettings.SharedSettings.AdvertisingTrackingStatus.ToString();

    /// <summary>
    /// The app url scheme
    /// </summary>
    public static string? AppURLSchemeSuffix => FBSDKSettings.SharedSettings.AppURLSchemeSuffix;

    /// <summary>
    /// The app url scheme
    /// </summary>
    public static string? DebugDescription => FBSDKSettings.SharedSettings.DebugDescription;

    /// <summary>
    /// The date and time the app was installed.
    /// </summary>
    public static DateTimeOffset? InstallTimestamp => FBSDKSettings.SharedSettings.InstallTimestamp?.ToDateTimeOffset();

    /// <summary>
    /// The GraphAPI debug parameter value.
    /// </summary>
    public static string? GraphAPIDebugParameterValue => FBSDKSettings.SharedSettings.GraphAPIDebugParameterValue;

    /// <summary>
    /// Indicates if advertising event tracking time is sufficiently delayed.
    /// </summary>
    public static bool? IsATETimeSufficientlyDelayed => FBSDKSettings.SharedSettings.IsATETimeSufficientlyDelayed;

    /// <summary>
    /// Indicates if data processing is restricted.
    /// </summary>
    public static bool? IsDataProcessingRestricted => FBSDKSettings.SharedSettings.IsDataProcessingRestricted;

    /// <summary>
    /// Indicates if domain errors are enabled.
    /// </summary>
    public static bool IsDomainErrorEnabled 
    {
        get => FBSDKSettings.SharedSettings.IsDomainErrorEnabled;
        set => FBSDKSettings.SharedSettings.IsDomainErrorEnabled = value;
    }

    /// <summary>
    /// Indicates if graph error recovery is enabled.
    /// </summary>
    public static bool IsGraphErrorRecoveryEnabled
    {
        get => FBSDKSettings.SharedSettings.IsGraphErrorRecoveryEnabled;
        set => FBSDKSettings.SharedSettings.IsGraphErrorRecoveryEnabled = value;
    }

    /// <summary>
    /// Indicates if store kit ad network reporting is enabled.
    /// </summary>
    public static bool? IsSKAdNetworkReportEnabled => FBSDKSettings.SharedSettings.IsSKAdNetworkReportEnabled;

    /// <summary>
    /// Returns the JPEG compression quality used
    /// </summary>
    public static double JPEGCompressionQuality
    {
        get => FBSDKSettings.SharedSettings.JPEGCompressionQuality;
        set => FBSDKSettings.SharedSettings.JPEGCompressionQuality = value;
    }

    /// <summary>
    /// Returns the JPEG compression quality used
    /// </summary>
    public static double LimitedLoginAutoRefreshInterval
    {
        get => FBSDKSettings.SharedSettings.LimitedLoginAutoRefreshInterval;
        set => FBSDKSettings.SharedSettings.LimitedLoginAutoRefreshInterval = value;
    }

    /// <summary>
    /// Indicates of token optimization should be used.
    /// </summary>
    public static bool ShouldUseTokenOptimizations
    {
        get => FBSDKSettings.SharedSettings.ShouldUseTokenOptimizations;
        set => FBSDKSettings.SharedSettings.ShouldUseTokenOptimizations = value;
    }

    /// <summary>
    /// The user agent suffix used.
    /// </summary>
    public static string? UserAgentSuffix
    {
        get => FBSDKSettings.SharedSettings.UserAgentSuffix;
        set => FBSDKSettings.SharedSettings.UserAgentSuffix = value;
    }
}
