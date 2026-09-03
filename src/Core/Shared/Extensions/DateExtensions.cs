
namespace Plugin.FacebookKit.Core;

/// <summary>
/// Share date extensions used globally.
/// </summary>
#if IOS || MACCATALYST
[Preserve(AllMembers = true)]
#endif
public static class DataExtensions
{    
    /// <summary>
    /// Converts nuint in seconds to a <see cref="TimeSpan"/>
    /// </summary>
    public static TimeSpan ToTimeSpanFromSeconds(this nuint seconds)
    {
        return TimeSpan.FromSeconds(seconds);
    }
}