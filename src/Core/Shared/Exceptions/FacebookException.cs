
namespace Plugin.FacebookKit.Core;

/// <summary>
/// Provides data for a failed facebook operation.
/// </summary>
public sealed class FacebookException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The exception that caused the facebook operation to fail.</param>
    public FacebookException(string? message, Exception? innerException = null)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookException"/> class
    /// from the underlying exception.
    /// </summary>
    /// <param name="error">The error that caused the facebook operation to fail.</param>
    public FacebookException(Exception error)
        : base(error.Message, error)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FacebookException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    public FacebookException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Gets the error that caused the facebook operation to fail.
    /// </summary>
    public Exception? InnerError => InnerException;
}
