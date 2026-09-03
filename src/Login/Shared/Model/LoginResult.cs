
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class LoginResult : ILoginResult
{
    /// <inheritdoc />
    public IAccessToken? Token { get; }

    /// <inheritdoc />
    public IAuthenticationToken? AuthenticationToken { get; }

    /// <inheritdoc />
    public ILoginResultAppleExtras? AppleExtras { get; }

    /// <inheritdoc />
    public IReadOnlySet<string> GrantedPermissions { get; } = new HashSet<string>();

    /// <inheritdoc />
    public IReadOnlySet<string> DeclinedPermissions { get; } = new HashSet<string>();
    
    /// <inheritdoc />
    public string DebugDescription() => $"Token={Token?.DebugDescription()}, AuthenticationToken={AuthenticationToken?.DebugDescription()}, " +
        $"AppleExtras={AppleExtras?.DebugDescription()}, GrantedPermissions={string.Join(", ", GrantedPermissions)}, DeclinedPermissions={string.Join(", ", DeclinedPermissions)}";
}

/// <inheritdoc />
internal sealed partial class LoginResultAppleExtras : ILoginResultAppleExtras
{
    /// <inheritdoc />
    public bool IsCancelled { get; }

    /// <inheritdoc />
    public string DebugDescription() => $"AppleExtras IsCancelled={IsCancelled}";
}