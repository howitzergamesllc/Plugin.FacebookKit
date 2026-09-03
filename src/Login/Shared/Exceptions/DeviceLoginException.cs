
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents an error that occurred during a Facebook device login operation.
/// </summary>
public sealed class DeviceLoginException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceLoginException"/> class.
    /// </summary>
    public DeviceLoginException(DeviceLoginErrorCode code, string message, Exception? innerException = null) : base(message, innerException)
    {
        Code = code;
    }

    /// <summary>
    /// Gets the Facebook device login error code.
    /// </summary>
    public DeviceLoginErrorCode Code { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    public string DebugDescription() => $"DeviceLoginException Code={Code}, Message={Message}, Source={Source}, StackTrace={StackTrace}, " +
        $"InnerExceptionMessage={InnerException?.Message}, Source={InnerException?.Source}, StackTrace={InnerException?.StackTrace}";
}