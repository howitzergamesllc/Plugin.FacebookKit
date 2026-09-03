
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
public sealed partial class  AccessToken : IAccessToken
{
    private readonly Facebook.AccessToken? nativeAccessToken;

    internal AccessToken(Facebook.AccessToken nativeAccessToken)
    {
        this.nativeAccessToken = nativeAccessToken;
        TokenString = nativeAccessToken.Token ?? "";
        GrantedPermissions = nativeAccessToken.Permissions?.ToRawPermissions() ?? new HashSet<string>();
        DeclinedPermissions = nativeAccessToken.DeclinedPermissions?.ToRawPermissions() ?? new HashSet<string>();
        ExpiredPermissions = nativeAccessToken.ExpiredPermissions?.ToRawPermissions() ?? new HashSet<string>();
        AppId = nativeAccessToken.ApplicationId;
        UserId = nativeAccessToken.UserId;
        ExpirationDate = nativeAccessToken.Expires.ToDateTimeOffset();
        RefreshDate = nativeAccessToken.LastRefresh.ToDateTimeOffset();
        DataAccessExpirationDate = nativeAccessToken.DataAccessExpirationTime.ToDateTimeOffset();
        IsExpired = nativeAccessToken.IsExpired;
        IsDataAccessExpired = nativeAccessToken.IsDataAccessExpired;
        AndroidExtras = new AccessTokenAndroidExtras(nativeAccessToken.Source.ToTokenSource(), nativeAccessToken.GraphDomain, nativeAccessToken.IsInstagramToken);
    }
        
    /// <summary>
    /// A public constructor to generate a custom managed AccessToken that will be set to <see cref="IFacebookPluginLogin.CurrentAccessToken"/>.
    /// This initializer should only be used for advanced apps that manage tokens explicitly.
    /// </summary>
    /// <param name="tokenString"></param>
    /// <param name="grantedPermissions">Granted permissions</param>
    /// <param name="declinedPermissions">Declined permissions</param>
    /// <param name="expiredPermissions">Expired permissions</param>
    /// <param name="appId">The app ID.</param>
    /// <param name="userId">The user id</param>
    /// <param name="expirationDate">The optional expiration date (defaults to distantFuture).</param>
    /// <param name="refreshDate">The optional date the token was last refreshed (defaults to today).</param>
    /// <param name="dataAccessExpirationDate">The date which data access will expire for the given user (defaults to distantFuture).</param>
    public AccessToken(string tokenString, string[] grantedPermissions, string[] declinedPermissions, string[] expiredPermissions, string appId, string userId, AccessTokenAndroidExtras androidExtras, DateTimeOffset? expirationDate = null, DateTimeOffset? refreshDate = null, DateTimeOffset? dataAccessExpirationDate = null)
    {
        this.nativeAccessToken = new Facebook.AccessToken(tokenString, appId, userId, grantedPermissions, declinedPermissions, expiredPermissions, androidExtras.Source?.ToNativeTokenSource(), expirationDate.ToNativeDate(), refreshDate.ToNativeDate(), dataAccessExpirationDate.ToNativeDate(), androidExtras.GraphDomain);
        TokenString = tokenString;
        GrantedPermissions = grantedPermissions.ToHashSet<string>();
        DeclinedPermissions = declinedPermissions.ToHashSet<string>();
        ExpiredPermissions = expiredPermissions.ToHashSet<string>();
        AppId = appId;
        UserId = userId;
        AndroidExtras = androidExtras;
        ExpirationDate = expirationDate;
        RefreshDate = refreshDate;
        DataAccessExpirationDate = dataAccessExpirationDate;
    }

    /// <inheritdoc />
    public bool IsActive => Facebook.AccessToken.IsCurrentAccessTokenActive;

    /// <inheritdoc />
    public bool HasGranted(string permission) => nativeAccessToken?.Permissions.Contains(permission) ?? false;
}

/// <inheritdoc />
public sealed partial class AccessTokenAndroidExtras : IAccessTokenAndroidExtras
{
    /// <summary>
    /// The AccessTokenAndroidExtras parameters constructor. Creates the extra parameters needed to create an access token on Android platforms.
    /// </summary>
    /// <param name="source">The access token source.</param>
    /// <param name="graphDomain">The domain to use for the Graph API</param>
    /// <param name="isInstagramToken"><c>true</c> if the token is used for instagram.</param>
    public AccessTokenAndroidExtras(AccessTokenSource source, string? graphDomain, bool isInstagramToken)
    {
        Source = source;
        GraphDomain = graphDomain;
        IsInstagramToken = isInstagramToken;
    }
}