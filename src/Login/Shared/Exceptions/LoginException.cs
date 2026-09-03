
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents an error that occurred during a Facebook login operation.
/// </summary>
public sealed class LoginException : Exception
{
    /// <summary>
    /// (Apple only) Initializes a new instance of the <see cref="LoginException"/> class.
    /// </summary>
    public LoginException(LoginErrorCode code, string message, Exception? innerException = null) : base(message, innerException)
    {
        Code = code;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginException"/> class.
    /// </summary>
    public LoginException(string message, Exception? innerException = null) : base(message, innerException)
    {
    }

    /// <summary>
    /// (Apple only) Gets the Facebook login error code.
    /// </summary>
    public LoginErrorCode Code { get; }

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    public string DebugDescription() => $"DeviceLoginException Code={Code}, Message={Message}, Source={Source}, StackTrace={StackTrace}, " +
        $"InnerExceptionMessage={InnerException?.Message}, Source={InnerException?.Source}, StackTrace={InnerException?.StackTrace}";
}