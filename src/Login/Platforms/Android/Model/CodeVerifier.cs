
using System.Security.Cryptography;
using System.Text;

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
    /// Initializes a new code verifier instance with a random string value
    /// </summary>
    public CodeVerifier()
    {
        Value = GenerateCodeVerifier();
        Challenge = GenerateCodeChallenge(Value);
    }

    /// <summary>
    /// Attempts to initialize a new code verifier instance with the given string.
    /// Creation will fail and return nil if the string is invalid.
    /// @param string the code verifier string
    /// </summary>
    /// <param name="code">The code verifier string to use</param>
    public CodeVerifier(string code)
    {
        Value = code;
        Challenge = GenerateCodeChallenge(code);
    }

    private static string GenerateCodeVerifier()
    {
        // 32 random bytes produces a 43-character Base64URL string.
        Span<byte> bytes = stackalloc byte[32];
        RandomNumberGenerator.Fill(bytes);

        return Base64UrlEncode(bytes);
    }

    private static string GenerateCodeChallenge(string codeVerifier)
    {
        byte[] hash = SHA256.HashData(
            Encoding.UTF8.GetBytes(codeVerifier));

        return Base64UrlEncode(hash);
    }

    private static string Base64UrlEncode(ReadOnlySpan<byte> bytes)
    {
        return Convert.ToBase64String(bytes)
            .Replace('+', '-')
            .Replace('/', '_')
            .TrimEnd('=');
    }
}