
namespace Plugin.FacebookKit.Login.Platforms.Android.Extensions;

public static class DataExtensions
{
    public static DateTimeOffset ToDateTimeOffset(this Java.Util.Date date)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(date.Time);
    }
    
    public static Java.Util.Date? ToNativeDate(this DateTimeOffset? dateTimeOffset)
    {
        if (dateTimeOffset is null)
            return null;

        return new Java.Util.Date(dateTimeOffset.Value.ToUnixTimeMilliseconds());
    }
}