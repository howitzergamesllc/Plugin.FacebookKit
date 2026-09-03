
using Facebook.Core;
using Plugin.FacebookKit.Core.Platforms.iOS.Extensions;
using Plugin.FacebookKit.Login.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
public sealed partial class  AccessToken : IAccessToken
{
    private readonly FBSDKAccessToken? nativeAccessToken;

    internal AccessToken(FBSDKAccessToken nativeAccessToken)
    {
        this.nativeAccessToken = nativeAccessToken;
        TokenString = FBSDKAccessToken.TokenString ?? "";
        GrantedPermissions = nativeAccessToken.Permissions?.ToRawPermissions() ?? new HashSet<string>();
        DeclinedPermissions = nativeAccessToken.DeclinedPermissions?.ToRawPermissions() ?? new HashSet<string>();
        ExpiredPermissions = nativeAccessToken.ExpiredPermissions?.ToRawPermissions() ?? new HashSet<string>();
        AppId = nativeAccessToken.AppID;
        UserId = nativeAccessToken.UserID;
        ExpirationDate = nativeAccessToken.ExpirationDate.ToDateTimeOffset();
        RefreshDate = nativeAccessToken.RefreshDate.ToDateTimeOffset();
        DataAccessExpirationDate = nativeAccessToken.DataAccessExpirationDate.ToDateTimeOffset();
        IsExpired = nativeAccessToken.Expired;
        IsDataAccessExpired = nativeAccessToken.DataAccessExpired;
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
    public AccessToken(string tokenString, string[] grantedPermissions, string[] declinedPermissions, string[] expiredPermissions, string appId, string userId, DateTimeOffset? expirationDate = null, DateTimeOffset? refreshDate = null, DateTimeOffset? dataAccessExpirationDate = null)
    {
        nativeAccessToken = new FBSDKAccessToken(tokenString, grantedPermissions, declinedPermissions, expiredPermissions, appId, userId, 
            expirationDate.ToNSDate(), refreshDate.ToNSDate(), dataAccessExpirationDate.ToNSDate());
            
        TokenString = tokenString;
        GrantedPermissions = grantedPermissions.ToHashSet<string>();
        DeclinedPermissions = declinedPermissions.ToHashSet<string>();
        ExpiredPermissions = expiredPermissions.ToHashSet<string>();
        AppId = appId;
        UserId = userId;
        ExpirationDate = expirationDate;
        RefreshDate = refreshDate;
        DataAccessExpirationDate = dataAccessExpirationDate;
    }

    /// <inheritdoc />
    public bool IsActive => FBSDKAccessToken.CurrentAccessTokenIsActive;

    /// <inheritdoc />
    public bool HasGranted(string permission) => nativeAccessToken?.HasGranted(permission) ?? false;
}