
using Foundation;
using Plugin.FacebookKit.Core;

namespace Plugin.FacebookKit.Share.Platforms.iOS.Extensions;

[Preserve(AllMembers = true)]
internal static class ErrorExtensions
{
    /// <summary>
    /// Converts an optional <see cref="NSError"/> into a managed exception.
    /// </summary>
    /// <param name="error">
    /// The native error to convert.
    /// </param>
    /// <returns>
    /// A managed exception, or a generic exception if the native error is null.
    /// </returns>
    public static FacebookException ToException(this NSError? error)
    {
        return error is not null ? new FacebookException(new NSErrorException(error)) : new FacebookException("An unknown native error occurred.");
    }

    /// <summary>
    /// Converts an optional managed exception into an <see cref="NSError"/>.
    /// </summary>
    /// <param name="exception">
    /// The exception to convert.
    /// </param>
    /// <returns>
    /// An <see cref="NSError"/> representing the exception.
    /// </returns>
    public static NSError ToNSError(this Exception? exception)
    {
        if (exception is null)
        {
            return new NSError(new NSString("ShareMauiSample"), -1, new NSDictionary(NSError.LocalizedDescriptionKey, "An unknown error occurred."));
        }

        return new NSError(new NSString("ShareMauiSample"), -1, new NSDictionary(NSError.LocalizedDescriptionKey, exception.Message));
    }
}