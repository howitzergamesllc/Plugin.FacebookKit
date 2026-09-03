
using Graphics = Android.Graphics;
using Android.Runtime;
using Java.Lang;
using Net = Android.Net;

namespace Plugin.FacebookKit.Core.Platforms.Android.Extensions;

/// <summary>
/// Global object conversion extansions vor Android platforms.
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// Converts a shared typed dictionary to a native JavaDictionary
    /// </summary>
    /// <param name="dictionary">The shared dictionary to convert</param>
    /// <returns>A native JavaDictionary</returns>
    public static JavaDictionary<Java.Lang.String, Java.Lang.Object> ToNativeDictionaryFromNonGeneric(this IReadOnlyDictionary<string, object> dictionary)
    {
        if(dictionary.Count > 0) {
            var nativeDictionary = new JavaDictionary<Java.Lang.String, Java.Lang.Object>();

            foreach(var entry in dictionary) {
                PutIntoNativeDictionary(new KeyValuePair<string, object>(entry.Key.ToString(), entry.Value), ref nativeDictionary);
            }
            return nativeDictionary;
        } else {
            return new JavaDictionary<Java.Lang.String, Java.Lang.Object>();
        }
    }

    private static void PutIntoNativeDictionary(KeyValuePair<string, object> pair, ref JavaDictionary<Java.Lang.String, Java.Lang.Object> nativeDictionary)
    {
        var key = pair.Key;

        if(key is null)
            return;

        var javastring = new Java.Lang.String(key);

        switch(pair.Value) {
            case bool x:
                nativeDictionary.Add(javastring, x);
                break;
            case double x:
                nativeDictionary.Add(javastring, x);
                break;
            case float x:
                nativeDictionary.Add(javastring, x);
                break;
            case long x:
                nativeDictionary.Add(javastring, x);
                break;
            case int x:
                nativeDictionary.Add(javastring, x);
                break;
            case short x:
                nativeDictionary.Add(javastring, x);
                break;
            case string x:
                nativeDictionary.Add(javastring, new Java.Lang.String(x));
                break;
            case Java.Lang.Object x:
                nativeDictionary.Add(javastring, x);
                break;
            default:
                if(pair.Value is Java.Lang.Enum @enum) {
                    nativeDictionary.Add(javastring, Convert.ToInt64(@enum));
                    break;
                } else if(pair.Value == null) {
                    nativeDictionary.Add(javastring, null!);
                    break;
                } else {
                    throw new ArgumentException($"Couldn't put object of type {pair.Value.GetType()} into JavaDictionary");
                }
        }
    }

    /// <summary>
    /// Converts a native generic dicitonary to a shared dictionary
    /// </summary>
    /// <param name="dictionary">The native JavaDictionary</param>
    /// <returns>A shared dictionary</returns>
    public static Dictionary<string, object?> ToDictionary(this JavaDictionary dictionary)
    {
        var result = new Dictionary<string, object?>();

        foreach (var key in dictionary.Keys)
        {
            if (key is Java.Lang.String nativeKey)
            {
                result[nativeKey.ToString()] = ConvertNativeObject((Java.Lang.Object)dictionary[key]!);
            }
        }

        return result;
    }    

    /// <summary>
    /// Converts a shared dictionary with native Java Integer to to a shared dictionary with int.
    /// </summary>
    /// <param name="dictionary">The native JavaDictionary</param>
    /// <returns>A shared dictionary</returns>
    public static Dictionary<string, int>? ToDictionary(this IDictionary<string, Integer>? dictionary)
    {
        if(dictionary is null || dictionary.Count == 0)
            return null;

        var result = new Dictionary<string, int>();

        foreach (var key in dictionary.Keys)
        {
            if (key is string nativeKey)
            {
                if(ConvertNativeObject((Java.Lang.Object)dictionary[key]) is int value)
                    result[nativeKey] = value;
            }
        }

        return result;
    }

    private static object? ConvertNativeObject(Java.Lang.Object? value)
    {
        switch (value)
        {
            case null:
                return null;

            case Java.Lang.String s:
                return s.ToString();

            case Java.Lang.Number n:
                return n;

            case JavaDictionary dict:
                return dict.ToDictionary();

            case JavaArray<Java.Lang.Object> array:
            {
                var list = new List<object?>();

                foreach (Java.Lang.Object item in array)
                    list.Add(ConvertNativeObject(item));

                return list;
            }

            default:
                return value;
        }
    }

    /// <summary>
    /// Coverts a native Android bitmap to a shared byte array.
    /// </summary>
    /// <param name="bitmap">The native bitmap to convert.</param>
    /// <returns>A shared byte array representing an image.</returns>
    public static byte[] ToBytes(this Graphics.Bitmap bitmap)
    {
        using var stream = new MemoryStream();

        var format = Graphics.Bitmap.CompressFormat.Png;

        if(format is null)
            return [];

        if (!bitmap.Compress(format, 100, stream))
        {
            return [];
        }

        return stream.ToArray();
    }

    /// <summary>
    /// Coverts byte array image data to a native Android Bitmap
    /// </summary>
    /// <param name="bytes">The shared byte array to convert.</param>
    /// <returns>A native Android Bitmap.</returns>
    public static Graphics.Bitmap? ToBitmap(this byte[] bytes)
    {
        if (bytes is not { Length: > 0 })
            return null;

        return Graphics.BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
    }

    /// <summary>
    /// Converts a native Uri to a shared Uri.
    /// </summary>
    /// <param name="uri">The native uri to convert.</param>
    /// <returns>The shared uri.</returns>
    public static Uri? ToUri (this Net.Uri? uri)
    {
        if(uri is null)
            return null;

        var path = uri.ToString();

        if(path is null || System.String.IsNullOrEmpty(path))
            return null;

        return new Uri(path);
    }

    /// <summary>
    /// Converts a shared Uri to a native Uri.
    /// </summary>
    /// <param name="uri">The shared uri to convert.</param>
    /// <returns>The native uri.</returns>
    public static Net.Uri? ToNativeUri (this Uri? uri)
    {
        if(uri is null || string.IsNullOrEmpty(uri.AbsoluteUri))
            return null;

        return Net.Uri.Parse(uri.AbsoluteUri);
    }
}