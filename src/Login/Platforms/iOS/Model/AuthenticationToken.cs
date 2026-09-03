
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class AuthenticationToken : IAuthenticationToken
{
    internal AuthenticationToken(string tokenString, string nonce, IAuthenticationTokenAppleExtras appleExtras)
    {
        TokenString = tokenString;
        Nonce = nonce;
        AppleExtras = appleExtras;
    }
}

internal sealed partial class AuthenticationTokenAppleExtras : IAuthenticationTokenAppleExtras
{
    internal AuthenticationTokenAppleExtras(string graphDomain)
    {
        GraphDomain = graphDomain;
    }
}
