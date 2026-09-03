
using Facebook;

namespace Plugin.FacebookKit.Core.Platforms.Android.Extensions;

public static class CoreExtensions
{        
    public static LoggingBehavior? ToNativeLoggingBehavior(this string behavior)
    {
        if(behavior == LoggingBehavior.AppEvents.Name()) return LoggingBehavior.AppEvents;
        if(behavior == LoggingBehavior.Cache.Name()) return LoggingBehavior.Cache;
        if(behavior == LoggingBehavior.DeveloperErrors.Name()) return LoggingBehavior.DeveloperErrors;
        if(behavior == LoggingBehavior.GraphApiDebugInfo.Name()) return LoggingBehavior.GraphApiDebugInfo;
        if(behavior == LoggingBehavior.GraphApiDebugWarning.Name()) return LoggingBehavior.GraphApiDebugWarning;
        if(behavior == LoggingBehavior.IncludeAccessTokens.Name()) return LoggingBehavior.IncludeAccessTokens;
        if(behavior == LoggingBehavior.IncludeRawResponses.Name()) return LoggingBehavior.IncludeRawResponses;
        if(behavior == LoggingBehavior.Requests.Name()) return LoggingBehavior.Requests;
        return null;
    }
}