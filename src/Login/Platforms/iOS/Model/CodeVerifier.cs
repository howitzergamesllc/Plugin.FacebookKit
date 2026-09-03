
using Facebook.Login;

namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
public sealed partial class CodeVerifier
{
    private readonly FBSDKCodeVerifier? nativeCodeVerifier;

    /// <summary>   
    /// Initializes a new code verifier instance with a random string value
    /// </summary>
    public CodeVerifier()
    {
        nativeCodeVerifier = new FBSDKCodeVerifier();
        Value = nativeCodeVerifier.Value;
        Challenge = nativeCodeVerifier.Challenge;
    }

    /// <summary>
    /// Attempts to initialize a new code verifier instance with the given string.
    /// Creation will fail and return nil if the string is invalid.
    /// @param string the code verifier string
    /// </summary>
    /// <param name="code">The code verifier string</param>
    public CodeVerifier(string code)
    {
        Value = code;
        nativeCodeVerifier = new FBSDKCodeVerifier(code);
        Challenge = nativeCodeVerifier.Challenge;
    }
}