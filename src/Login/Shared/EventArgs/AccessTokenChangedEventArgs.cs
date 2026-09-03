
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Provides the updated global static <see cref="FacebookPluginLogin.CurrentToken"/>.
/// </summary>
public sealed class AccessTokenChangedEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccessTokenChangedEventArgs"/> class.
    /// </summary>
    /// <param name="currentToken">
    /// The global static <see cref="FacebookPluginLogin.CurrentToken"/>
    /// </param>
    public AccessTokenChangedEventArgs(IAccessToken? currentToken)
    {
        CurrentToken = currentToken;
    }

    /// <summary>
    /// The global <see cref="FacebookPluginLogin.CurrentToken"/>
    /// </summary>
    public IAccessToken? CurrentToken { get; }
}
