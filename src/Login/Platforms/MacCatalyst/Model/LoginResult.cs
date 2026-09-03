
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class LoginResult : ILoginResult
{
    internal LoginResult(IAccessToken? token, IAuthenticationToken? authenticationToken, ILoginResultAppleExtras appleExtras,
        IReadOnlySet<string>? grantedPermissions, IReadOnlySet<string>? declinedPermissions)
    {
        Token = token;
        AuthenticationToken = authenticationToken;
        AppleExtras = appleExtras;
        GrantedPermissions = grantedPermissions?.ToHashSet() ?? new HashSet<string>();
        DeclinedPermissions = declinedPermissions?.ToHashSet() ?? new HashSet<string>();
    }
}

/// <inheritdoc />
internal sealed partial class LoginResultAppleExtras : ILoginResultAppleExtras
{
    internal LoginResultAppleExtras(bool isCancelled)
    {
        IsCancelled = isCancelled;
    }
}