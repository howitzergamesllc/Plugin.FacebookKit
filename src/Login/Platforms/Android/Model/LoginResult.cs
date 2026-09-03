
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class LoginResult : ILoginResult
{
    internal LoginResult(IAccessToken? token, IAuthenticationToken? authenticationToken, IReadOnlySet<string> grantedPermissions, IReadOnlySet<string> declinedPermissions)
    {
        Token = token;
        AuthenticationToken = authenticationToken;
        GrantedPermissions = grantedPermissions;
        DeclinedPermissions = declinedPermissions;
    }
}