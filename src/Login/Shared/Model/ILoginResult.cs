
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents the result of a login attempt using <see cref="ILoginManager"/>.
/// </summary>
public interface ILoginResult
{
    /// <summary>
    /// Gets the access token returned from the login attempt.
    /// </summary>
    IAccessToken? Token { get; }

    /// <summary>
    /// Gets the authentication token returned from the login attempt.
    /// </summary>
    IAuthenticationToken? AuthenticationToken { get; }

    /// <summary>
    /// Gets the permissions granted by the user.
    /// </summary>
    IReadOnlySet<string>? GrantedPermissions { get; }

    /// <summary>
    /// Gets the permissions declined by the user.
    /// </summary>
    IReadOnlySet<string>? DeclinedPermissions { get; }

    /// <summary>
    /// Extra parameters for apple from <see cref="LoginResult"/>
    /// </summary>
    ILoginResultAppleExtras? AppleExtras { get; }

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}

/// <summary>
/// Extra parameters for apple from <see cref="LoginResult"/>
/// </summary>
public interface ILoginResultAppleExtras
{
    /// <summary>
    /// Indicates of the login flow was cancelled by the user.
    /// </summary>
    bool IsCancelled { get; }

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}