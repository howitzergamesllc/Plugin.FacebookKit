
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents a code verifier used in the PKCE (Proof Key for Code Exchange)
/// process. This is a cryptographically random string using the characters
/// A-Z, a-z, 0-9, and the punctuation characters -._~ (hyphen, period,
/// underscore, and tilde), between 43 and 128 characters long.
/// </summary>
public sealed partial class CodeVerifier
{
    /// <summary>
    /// The string value of the code verifier.
    /// </summary>
    public string Value { get; set; } = "";

    /// <summary>
    /// The SHA256 hashed challenge of the code verifier
    /// </summary>
    public string Challenge { get; set; } = "";

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    public string DebugDescription() => $"Value={Value}, Challenge={Challenge}";
}