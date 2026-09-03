
namespace Plugin.FacebookKit.Core;

/// <summary>
/// Provides data for a failed facebook operation.
/// </summary>
public sealed class FacebookExceptionEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookExceptionEventArgs"/> class.
    /// </summary>
    /// <param name="error">
    /// The error that caused the facebook operation to fail.
    /// </param>
    public FacebookExceptionEventArgs(FacebookException error)
    {
        Error = error;
    }

    /// <summary>
    /// Gets the error that caused the facebook operation to fail.
    /// </summary>
    public FacebookException Error { get; }
}