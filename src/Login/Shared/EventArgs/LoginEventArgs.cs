
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Provides data for a completed Facebook login operation.
/// </summary>
/// <remarks>
/// On apple products, a <see cref="LoginException"/> can return with the <see cref="LoginResult"/>
/// On android, only a <see cref="LoginResult"/> returns;
/// </remarks>
public sealed class LoggedInEventArgs : EventArgs
{
    /// <summary>
    /// (Android Only) Initializes a new instance of the <see cref="LoggedInEventArgs"/> class.
    /// </summary>
    /// <param name="result">
    /// The result of the login operation.
    /// </param>
    public LoggedInEventArgs(ILoginResult? result)
    {
        Result = result;
    }

    /// <summary>
    /// (Android Only) Initializes a new instance of the <see cref="LoggedInEventArgs"/> class.
    /// </summary>
    /// <param name="exception">
    /// The exception that occurred during login, if the operation failed; otherwise, <see langword="null"/>.
    /// </param>
    public LoggedInEventArgs(LoginException? exception)
    {
        Exception = exception;
    }

    /// <summary>
    /// (Apple Only) Initializes a new instance of the <see cref="LoggedInEventArgs"/> class.
    /// </summary>
    /// <param name="result">
    /// The result of the login operation.
    /// </param>
    /// <param name="exception">
    /// The exception that occurred during login, if the operation failed; otherwise, <see langword="null"/>.
    /// </param>
    public LoggedInEventArgs(ILoginResult? result, LoginException? exception)
    {
        Result = result;
        Exception = exception;
    }
    
    /// <summary>
    /// (Apple Only) Initializes a new instance of the <see cref="LoggedInEventArgs"/> class.
    /// </summary>
    /// <param name="result">
    /// The result of the login operation.
    /// </param>
    /// <param name="exception">
    /// The exception that occurred during login, if the operation failed; otherwise, <see langword="null"/>.
    /// </param>
    public LoggedInEventArgs(ILoginResult? result, DeviceLoginException? exception)
    {
        Result = result;
        DeviceException = exception;
    }

    /// <summary>
    /// Gets the result of the login operation.
    /// </summary>
    public ILoginResult? Result { get; }

    /// <summary>
    /// (Apple Only) Gets the exception that occurred during the login operation, if any.
    /// </summary>
    public LoginException? Exception { get; }

    /// <summary>
    /// (Apple Only) Gets the exception that occurred during the login operation, if any.
    /// </summary>
    public DeviceLoginException? DeviceException { get; }
}

/// <summary>
/// Provides data for a completed Facebook logout operation.
/// </summary>
public sealed class LoggedOutEventArgs : EventArgs
{
}
