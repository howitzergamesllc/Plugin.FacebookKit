
using System.Collections;

namespace Plugin.FacebookKit.Core.Platforms.iOS.Extensions;

/// <summary>
/// Global object conversions for Apple platforms
/// </summary>
[Preserve(AllMembers = true)]
public static class ObjectExtensions
{
    /// <summary>
    /// Converts a Apple NSDictionary to Shared Dictionary.
    /// </summary>
    /// <param name="dictionary">The NSDictionary to convert</param>
    /// <returns>Shared Dictionary type.</returns>
    public static Dictionary<string, object?> ToDictionary(this NSDictionary dictionary)
    {
        var result = new Dictionary<string, object?>();

        foreach (var key in dictionary.Keys)
        {
            if (key is NSString nsKey)
            {
                result[nsKey.ToString()] = ConvertNSObject(dictionary.ObjectForKey(key));
            }
        }

        return result;
    }

    private static object? ConvertNSObject(NSObject? value)
    {
        switch (value)
        {
            case null:
                return null;

            case NSNull:
                return null;

            case NSString s:
                return s.ToString();

            case NSNumber n:
                return n;

            case NSDictionary dict:
                return dict.ToDictionary();

            case NSArray array:
            {
                var list = new List<object?>();

                foreach (NSObject item in array)
                    list.Add(ConvertNSObject(item));

                return list;
            }

            default:
                return value;
        }
    }
    
    /// <summary>
    /// Coverts native Apple NSUrl to shared Uri
    /// </summary>
    /// <param name="url">The native NSUrl</param>
    /// <returns>The shared Uri.</returns>
    public static Uri? ToUri(this NSUrl? url)
    {
        if(url is null || String.IsNullOrEmpty(url.AbsoluteString))
            return null;

        return new Uri(url.AbsoluteString);
    }

    /// <summary>
    /// Converts shared readonly Dictionary to a native Apple NSDictionary.
    /// </summary>
    /// <param name="dictionary">The shared dictonary to convert.</param>
    /// <returns>The native Apple NSDictionary</returns>
    public static NSDictionary<NSString, NSObject> ToNSDictionaryFromNonGeneric(this IReadOnlyDictionary<string, object> dictionary)
    {
        if(dictionary.Count > 0) {
            var nsDictionary = new NSMutableDictionary<NSString, NSObject>();

            foreach(var entry in dictionary) {
                PutIntoNSDictionary(new KeyValuePair<string, object>(entry.Key.ToString(), entry.Value), ref nsDictionary);
            }
            return NSDictionary<NSString, NSObject>.FromObjectsAndKeys(
                nsDictionary.Values.ToArray(),
                nsDictionary.Keys.ToArray(),
                (nint) nsDictionary.Count);
        } else {
            return new NSDictionary<NSString, NSObject>();
        }
    }

    /// <summary>
    /// Converts a generic shared Dictionary to a native Apple NSDictionary.
    /// </summary>
    /// <param name="dictionary">The shared dictonary to convert.</param>
    /// <returns>The native Apple NSDictionary</returns>
    public static NSDictionary<NSString, NSObject> ToNSDictionaryFromNonGeneric(this IDictionary dictionary)
    {
        if(dictionary.Count > 0) {
            var nsDictionary = new NSMutableDictionary<NSString, NSObject>();

            foreach(DictionaryEntry entry in dictionary) {
                PutIntoNSDictionary(new KeyValuePair<string, object>(entry.Key.ToString()!, entry.Value!), ref nsDictionary);
            }
            return NSDictionary<NSString, NSObject>.FromObjectsAndKeys(
                nsDictionary.Values.ToArray(),
                nsDictionary.Keys.ToArray(),
                (nint) nsDictionary.Count);
        } else {
            return new NSDictionary<NSString, NSObject>();
        }
    }

    private static void PutIntoNSDictionary(KeyValuePair<string, object> pair, ref NSMutableDictionary<NSString, NSObject> nsDictionary)
    {
        switch(pair.Value) {
            case bool x:
                nsDictionary.Add((NSString) pair.Key, new NSNumber(x));
                break;
            case double x:
                nsDictionary.Add((NSString) pair.Key, new NSNumber(x));
                break;
            case float x:
                nsDictionary.Add((NSString) pair.Key, new NSNumber(x));
                break;
            case long x:
                nsDictionary.Add((NSString) pair.Key, new NSNumber(x));
                break;
            case int x:
                nsDictionary.Add((NSString) pair.Key, new NSNumber(x));
                break;
            case short x:
                nsDictionary.Add((NSString) pair.Key, new NSNumber(x));
                break;
            case string x:
                nsDictionary.Add((NSString) pair.Key, new NSString(x));
                break;
            case NSObject x:
                nsDictionary.Add((NSString) pair.Key, x);
                break;
            default:
                if(pair.Value is Enum @enum) {
                    nsDictionary.Add((NSString) pair.Key, new NSNumber(Convert.ToInt64(@enum)));
                    break;
                } else if(pair.Value == null) {
                    nsDictionary.Add((NSString) pair.Key, new NSNull());
                    break;
                } else {
                    throw new ArgumentException($"Couldn't put object of type {pair.Value.GetType()} into NSDictionary");
                }
        }
    }

    /// <summary>
    /// Coverts a native UIImage to byte array.
    /// </summary>
    /// <param name="image">The UIImage to convert.</param>
    /// <returns>byte array information of an image.</returns>
    public static byte[]? ToBytes(this UIImage image)
    {
        using var data = image.AsPNG();

        return data?.ToArray();
    }

    /// <summary>
    /// Coverts native NSData objects to byte array.
    /// </summary>
    /// <param name="data">The native NSData to convert</param>
    /// <returns>byte array of the native data.</returns>
    public static byte[]? ToShareData(this NSData? data)
    {
        return data?.ToArray();
    }
}