
using System.Globalization;

namespace Plugin.FacebookKit.Core.Platforms.iOS.Extensions;

/// <summary>
/// Global date conversion methods used by Apple.
/// </summary>
[Preserve(AllMembers = true)]
public static class DataExtensions
{    
    /// <summary>
    /// Converts native NSDecimalNumber to a shared decimal value.
    /// </summary>
    /// <param name="number">The native NSDecimalNumber to convert.</param>
    /// <returns>The shared decimal value.</returns>
    public static decimal ToDecimal(this NSDecimalNumber number)
    {
        if (number == null) return new decimal(0);
        return decimal.Parse(number.StringValue, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Coverts native NSDate to a shared DateTimeOffset
    /// </summary>
    /// <param name="date">The native NSDate to convert</param>
    /// <returns>The shared DateTimeOffset.</returns>
    public static DateTimeOffset ToDateTimeOffset(this NSDate date)
    {
        var reference = new DateTimeOffset(2001, 1, 1, 0, 0, 0, TimeSpan.Zero);

        return reference.AddSeconds(date.SecondsSinceReferenceDate);
    }
    
    /// <summary>
    /// Coverts shared DateTimeOffset to native NSDate.
    /// </summary>
    /// <param name="dateTimeOffset">The shared date to convert.</param>
    /// <returns>Native NSDate.</returns>
    public static NSDate? ToNSDate(this DateTimeOffset? dateTimeOffset)
    {
        if (dateTimeOffset is null)
            return null;

        return NSDate.FromTimeIntervalSince1970(dateTimeOffset.Value.ToUnixTimeSeconds());
    }
    
    /// <summary>
    /// Coverts native NSDate to a shared DateTime.
    /// </summary>
    /// <param name="date">The native NSDate to convert</param>
    /// <returns>The shared DateTime.</returns>
    public static DateTime ToDateTime(this NSDate date)
    {
        if(date == null)
            return DateTime.MinValue;
        
        var reference = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        return reference.AddSeconds(date.SecondsSinceReferenceDate);
    }
}