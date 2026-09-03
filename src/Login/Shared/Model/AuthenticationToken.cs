
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class AuthenticationToken : IAuthenticationToken
{
    /// <inheritdoc />
    public string TokenString { get; } = "";

    /// <inheritdoc />
    public string Nonce { get; } = "";

    /// <inheritdoc />
    public IAuthenticationTokenAppleExtras? AppleExtras { get; }

    /// <inheritdoc />
    public IAuthenticationTokenAndroidExtras? AndroidExtras { get; }
    
    /// <inheritdoc />
    public string DebugDescription() => $"TokenString={TokenString}, Nonce={Nonce}, AppleExtras={AppleExtras?.DebugDescription()}, AndroidExtras={AndroidExtras?.DebugDescription()}";
}

internal sealed partial class AuthenticationTokenAppleExtras : IAuthenticationTokenAppleExtras
{
    /// <inheritdoc />
    public string? GraphDomain { get; }
    
    /// <inheritdoc />
    public string DebugDescription() => $"AuthenticationTokenAppleExtras GraphDomain={GraphDomain}";
}

/// <inheritdoc />
internal sealed partial class AuthenticationTokenAndroidExtras : IAuthenticationTokenAndroidExtras
{
    /// <inheritdoc />
    public IAuthenticationTokenHeader? Header { get; }

    /// <inheritdoc />
    public IAuthenticationTokenClaims? Claims { get; }

    /// <inheritdoc />
    public string? Signature { get; }
    
    /// <inheritdoc />
    public string DebugDescription() => $"AuthenticationTokenAndroidExtras Header={Header?.DebugDescription()}, Payload={Claims?.DebugDescription()}, Signature={Signature}";
}

/// <inheritdoc />
internal sealed partial class AuthenticationTokenHeader : IAuthenticationTokenHeader
{
    /// <inheritdoc />
    public string? ALG { get; }

    /// <inheritdoc />
    public string? TYP { get; }

    /// <inheritdoc />
    public string? KID { get; }
    
    /// <inheritdoc />
    public string DebugDescription() => $"AuthenticationTokenHeader ALG={ALG}, TYP={TYP}, KID={KID}";
}

/// <inheritdoc />
internal sealed partial class AuthenticationTokenClaims : IAuthenticationTokenClaims
{
    /// <inheritdoc />
    public string? JTI { get; }

    /// <inheritdoc />
    public string? ISS { get; }

    /// <inheritdoc />
    public string? AUD { get; }

    /// <inheritdoc />
    public string? NONCE { get; }

    /// <inheritdoc />
    public long EXP { get; }

    /// <inheritdoc />
    public long IAT { get; }

    /// <inheritdoc />
    public string? SUB { get; }

    /// <inheritdoc />
    public string? NAME { get; }

    /// <inheritdoc />
    public string? GIVENNAME { get; }

    /// <inheritdoc />
    public string? MIDDLENAME { get; }

    /// <inheritdoc />
    public string? FAMILYNAME { get; }

    /// <inheritdoc />
    public string? EMAIL { get; }

    /// <inheritdoc />
    public string? PICTURE { get; }

    /// <inheritdoc />
    public IReadOnlySet<string>? USERFRIENDS { get; }

    /// <inheritdoc />
    public string? USERBIRTHDAY { get; }

    /// <inheritdoc />
    public IAgeRange? USERAGERANGE { get; }

    /// <inheritdoc />
    public ILocation? USERHOMETOWN { get; }

    /// <inheritdoc />
    public ILocation? USERLOCATION { get; }

    /// <inheritdoc />
    public string? USERGENDER { get; }

    /// <inheritdoc />
    public string? USERLINK { get; }
    
    /// <inheritdoc />
    public string DebugDescription() => $"AuthenticationTokenClaims JTI={JTI}, ISS={ISS}, AUD={AUD}, NONCE={NONCE}, EXP={EXP}, IAT={IAT}, SUB={SUB}, NAME={NAME}" +
        $"GIVENNAME={GIVENNAME}, MIDDLENAME={MIDDLENAME}, FAMILYNAME={FAMILYNAME}, EMAIL={EMAIL}, PICTURE={PICTURE}, USERFRIENDS={string.Join(", ", USERFRIENDS ?? Enumerable.Empty<string>())}" +
        $"USERBIRTHDAY={USERBIRTHDAY}, USERAGERANGE={USERAGERANGE?.DebugDescription()}, USERHOMETOWN={USERHOMETOWN?.DebugDescription()}, USERLOCATION={USERLOCATION?.DebugDescription()}" +
        $"USERGENDER={USERGENDER}, USERLINK={USERLINK}";
}