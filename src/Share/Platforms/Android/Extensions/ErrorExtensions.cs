
using Facebook;

namespace Plugin.FacebookKit.Share.Platforms.Android.Extensions;

internal static class ErrorExtensions
{
    /// <summary>
    /// Converts an optional <see cref="FacebookException"/> into a managed exception.
    /// </summary>
    /// <param name="error">
    /// The native error to convert.
    /// </param>
    /// <returns>
    /// A managed exception, or a generic exception if the native error is null.
    /// </returns>
    public static Core.FacebookException ToException(this Facebook.FacebookException? error)
    {
        return error is null ? new Core.FacebookException("An unknown native error occurred.") : 
            new Core.FacebookException(error);
    }
}