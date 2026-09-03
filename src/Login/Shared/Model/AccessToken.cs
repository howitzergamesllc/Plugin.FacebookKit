
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
public sealed partial class AccessToken : IAccessToken
{
    /// <inheritdoc />
    public string TokenString { get; } = "";

    /// <inheritdoc />
    public string AppId { get; } = "";
    
    /// <inheritdoc />
    public string UserId { get; } = "";
    
    /// <inheritdoc />
    public DateTimeOffset? ExpirationDate { get; }
    
    /// <inheritdoc />
    public DateTimeOffset? DataAccessExpirationDate { get; }

    /// <inheritdoc />
    public DateTimeOffset? RefreshDate { get; }

    /// <inheritdoc />
    public IReadOnlySet<string> GrantedPermissions { get; } = new HashSet<string>();

    /// <inheritdoc />
    public IReadOnlySet<string> DeclinedPermissions { get; } = new HashSet<string>();

    /// <inheritdoc />
    public IReadOnlySet<string> ExpiredPermissions { get; } = new HashSet<string>();

    /// <inheritdoc />
    public bool IsExpired { get; }

    /// <inheritdoc />
    public bool IsDataAccessExpired { get; }

    /// <inheritdoc />
    public IAccessTokenAndroidExtras? AndroidExtras { get; }

    /// <inheritdoc />
    public string DebugDescription() => $"TokenString={TokenString}, GrantedPermissions={string.Join(", ", GrantedPermissions)}, " +
        $"DeclinedPermissions={string.Join(", ", DeclinedPermissions)}, ExpiredPermissions={string.Join(", ", ExpiredPermissions)}, AppId={AppId}, UserId={UserId}, " + 
        $"ExpirationDate={ExpirationDate} RefreshDate={RefreshDate}, IsExpired={IsExpired}, IsD                                                                                                                             ataAccessExpired={IsDataAccessExpired}, " +
        $"IsActive={IsActive}, AndroidExtras={AndroidExtras?.DebugDescription()}";
}

/// <inheritdoc />
public sealed partial class AccessTokenAndroidExtras : IAccessTokenAndroidExtras
{
    /// <inheritdoc />
    public AccessTokenSource? Source { get; }

    /// <inheritdoc />
    public string? GraphDomain { get; }

    /// <inheritdoc />
    public bool IsInstagramToken { get; }

    /// <inheritdoc />
    public string DebugDescription() => $"AccessTokenAndroidExtras Source={Source}, GraphDomain={GraphDomain}, IsInstagramToken={IsInstagramToken}";
}