
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Configuration options used to modify the behavior of a login attempt.
/// </summary>
public sealed class LoginConfiguration
{
    /// <summary>
    /// Creates a new login configuration.
    /// </summary>
    /// <param name="permissions">Permissions requested during login.</param>
    public LoginConfiguration(IReadOnlySet<string>? permissions = null)
    {
        Permissions = permissions ?? new HashSet<string>();
    }

    /// <summary>
    /// Attempts to initialize a new configuration with the expected parameters.
    /// A valid nonce must be a non-empty string without whitespace.
    /// Creation of the configuration will fail if the nonce is invalid.
    /// </summary>
    /// <param name="permissions">The requested permissions for the login attempt. Defaults to an empty set.</param>
    /// <param name="nonce">The nonce that the configuration was created with.
    /// A unique nonce will be used if none is provided to the initializer.</param>
    /// <param name="codeVerifier">The code verifier used in the PKCE process.</param>
    public LoginConfiguration(string nonce, IReadOnlySet<string>? permissions = null,  CodeVerifier? codeVerifier = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nonce);

        Nonce = nonce;
        Permissions = permissions ?? new HashSet<string>();
        CodeVerifier = codeVerifier;
    }

    /// <summary>
    /// Permissions requested during the login attempt.
    /// </summary>
    public IReadOnlySet<string> Permissions { get; } = new HashSet<string>();

    /// <summary>
    /// Nonce used for the login request.
    /// </summary>
    public string Nonce { get; } = "";
    
    /// <summary>
    /// Gets the PKCE code verifier used for the login request.
    /// </summary>
    /// <remarks>
    /// If specified, the code verifier is used to support Proof Key for Code Exchange (PKCE)
    /// during the authentication flow. If <see langword="null"/>, a code verifier may be
    /// generated automatically by the underlying platform implementation, if supported.
    /// </remarks>
    public CodeVerifier? CodeVerifier { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    public string DebugDescription() => $"LoginConfiguration Permissions={string.Join(", ", Permissions)}, Nonce={Nonce}, CodeVerifier={CodeVerifier?.DebugDescription()}";
}