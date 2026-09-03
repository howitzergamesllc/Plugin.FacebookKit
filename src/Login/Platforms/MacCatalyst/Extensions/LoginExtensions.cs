
using Foundation;
using Facebook.Login;
using UIKit;
using Facebook.Core;
using System.ComponentModel;
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Core.Platforms.MacCatalyst.Extensions;

namespace Plugin.FacebookKit.Login.Platforms.MacCatalyst.Extensions;


[Preserve(AllMembers = true)]
internal static class EnumExtensions
{
    internal static LoginBehavior ToAppSwitch(this FBSDKAppSwitch appSwitch)
    {
        return appSwitch switch
        {
            FBSDKAppSwitch.Disabled => LoginBehavior.WebOnly,
            FBSDKAppSwitch.Enabled => LoginBehavior.NativeWithFallback,
            _ => LoginBehavior.Unknown,
        };
    }

    internal static DefaultAudience ToDefualtAudience(this FBSDKDefaultAudience audience)
    {
        return audience switch
        {
            FBSDKDefaultAudience.Friends => DefaultAudience.Friends,
            FBSDKDefaultAudience.OnlyMe => DefaultAudience.OnlyMe,
            FBSDKDefaultAudience.Everyone => DefaultAudience.Everyone,
            _ => DefaultAudience.Unknown,
        };
    }

    internal static LimitedLoginRefreshErrorCode ToLimitedLoginRefreshErrorCode(this FBSDKLimitedLoginRefreshError limitedErrorCode)
    {
        return limitedErrorCode switch
        {
            FBSDKLimitedLoginRefreshError.NoCurrentToken => LimitedLoginRefreshErrorCode.NoCurrentToken,
            FBSDKLimitedLoginRefreshError.NotLimitedLogin => LimitedLoginRefreshErrorCode.NotLimitedLogin,
            FBSDKLimitedLoginRefreshError.LoginRequired => LimitedLoginRefreshErrorCode.LoginRequired,
            FBSDKLimitedLoginRefreshError.ConsentRequired => LimitedLoginRefreshErrorCode.ConsentRequired,
            FBSDKLimitedLoginRefreshError.UserMismatch => LimitedLoginRefreshErrorCode.UserMismatch,
            FBSDKLimitedLoginRefreshError.NetworkError => LimitedLoginRefreshErrorCode.NetworkError,
            FBSDKLimitedLoginRefreshError.Timeout => LimitedLoginRefreshErrorCode.Timeout,
            FBSDKLimitedLoginRefreshError.RateLimited => LimitedLoginRefreshErrorCode.RateLimited,
            FBSDKLimitedLoginRefreshError.InvalidResponse => LimitedLoginRefreshErrorCode.InvalidResponse,
            FBSDKLimitedLoginRefreshError.Cancelled => LimitedLoginRefreshErrorCode.Cancelled,
            FBSDKLimitedLoginRefreshError.FeatureDisabled => LimitedLoginRefreshErrorCode.FeatureDisabled,
            FBSDKLimitedLoginRefreshError.UnsupportedPlatform => LimitedLoginRefreshErrorCode.UnsupportedPlatform,
            FBSDKLimitedLoginRefreshError.NotDPoPBound => LimitedLoginRefreshErrorCode.NotDpopBound,
            FBSDKLimitedLoginRefreshError.DpopKeyGenerationFailed => LimitedLoginRefreshErrorCode.DpopKeyGenerationFailed,
            _ => LimitedLoginRefreshErrorCode.Unknown,
        };
    }
    
    internal static LoginAuthType ToAuthType(this NSString authType)
    {
        if (authType == FBSDKLoginAuthType.Rerequest)
            return LoginAuthType.Rerequest;

        if (authType == FBSDKLoginAuthType.Reauthorize)
            return LoginAuthType.Reauthorize;

        return LoginAuthType.Unknown;
    }    
    
    internal static NSString ToNativeAuthType(this LoginAuthType authType)
    {
        return authType switch
        {
            LoginAuthType.Rerequest => FBSDKLoginAuthType.Rerequest,
            LoginAuthType.Reauthorize => FBSDKLoginAuthType.Reauthorize,
            _ => FBSDKLoginAuthType.Rerequest
        };
    }

    internal static LoginErrorCode ToLoginErrorCode (this FBSDKLoginError error)
    {
        return error switch
        {
            FBSDKLoginError.Reserved => LoginErrorCode.Reserved,
            FBSDKLoginError.Unknown => LoginErrorCode.Unknown,
            FBSDKLoginError.PasswordChanged => LoginErrorCode.PasswordChanged,
            FBSDKLoginError.UserCheckpointed => LoginErrorCode.UserCheckpointed,
            FBSDKLoginError.UserMismatch => LoginErrorCode.UserMismatch,
            FBSDKLoginError.UnconfirmedUser => LoginErrorCode.UnconfirmedUser,
            FBSDKLoginError.SystemAccountAppDisabled => LoginErrorCode.SystemAccountAppDisabled,
            FBSDKLoginError.SystemAccountUnavailable => LoginErrorCode.SystemAccountUnavailable,
            FBSDKLoginError.BadChallengeString => LoginErrorCode.BadChallengeString,
            FBSDKLoginError.InvalidIDToken => LoginErrorCode.InvalidIdToken,
            FBSDKLoginError.MissingAccessToken => LoginErrorCode.MissingAccessToken,
            _ => LoginErrorCode.Unknown,
        };
    }

    internal static LoginTracking ToLoginTracking (this FBSDKLoginTracking tracking)
    {
        return tracking switch
        {
            FBSDKLoginTracking.Enabled => LoginTracking.Enabled,
            FBSDKLoginTracking.Limited => LoginTracking.Limited,
            _ => LoginTracking.Unknown,
        };
    }

    internal static RefreshFallbackPolicy ToRefreshFallbackPolicy (this FBSDKRefreshFallbackPolicy refreshFallbackPolicy)
    {
        return refreshFallbackPolicy switch
        {
            FBSDKRefreshFallbackPolicy.Automatic => RefreshFallbackPolicy.Automatic,
            FBSDKRefreshFallbackPolicy.SilentOnly => RefreshFallbackPolicy.SilentOnly,
            FBSDKRefreshFallbackPolicy.ExplicitOnly => RefreshFallbackPolicy.ExplicitOnly,
            FBSDKRefreshFallbackPolicy.DirectOnly => RefreshFallbackPolicy.DirectOnly,
            _ => RefreshFallbackPolicy.Unknown,
        };
    }


    internal static DeviceLoginErrorCode ToDeviceLoginErrorCode (this FBSDKDeviceLoginError error)
    {
        return error switch
        {
            FBSDKDeviceLoginError.ExcessivePolling => DeviceLoginErrorCode.ExcessivePolling,
            FBSDKDeviceLoginError.AuthorizationDeclined => DeviceLoginErrorCode.AuthorizationDeclined,
            FBSDKDeviceLoginError.AuthorizationPending => DeviceLoginErrorCode.AuthorizationPending,
            FBSDKDeviceLoginError.CodeExpired => DeviceLoginErrorCode.CodeExpired,
            _ => DeviceLoginErrorCode.Unknown,
        };
    }

    internal static TooltipBehavior ToTooltipBehavior (this FBSDKLoginButtonTooltipBehavior tooltipBehavior)
    {
        return tooltipBehavior switch
        {
            FBSDKLoginButtonTooltipBehavior.Automatic => TooltipBehavior.Automatic,
            FBSDKLoginButtonTooltipBehavior.ForceDisplay => TooltipBehavior.ForceDisplay,
            FBSDKLoginButtonTooltipBehavior.Disable => TooltipBehavior.Disable,
            _ => TooltipBehavior.Unknown,
        };
    }

    internal static TooltipViewArrowDirection ToTooltipDirection (this FBSDKTooltipViewArrowDirection tooltipDirection)
    {
        return tooltipDirection switch
        {
            FBSDKTooltipViewArrowDirection.Down => TooltipViewArrowDirection.Down,
            FBSDKTooltipViewArrowDirection.Up => TooltipViewArrowDirection.Up,
            _ => TooltipViewArrowDirection.Unknown,
        };
    }

    internal static TooltipColorStyle ToTooltipColorStyle (this FBSDKTooltipColorStyle tooltipColorStyle)
    {
        return tooltipColorStyle switch
        {
            FBSDKTooltipColorStyle.FriendlyBlue => TooltipColorStyle.FriendlyBlue,
            FBSDKTooltipColorStyle.NeutralGray => TooltipColorStyle.NeutralGray,
            _ => TooltipColorStyle.Unknown,
        };
    }


    internal static FBSDKAppSwitch ToNativeAppSwitch(this LoginBehavior appSwitch)
    {
        return appSwitch switch
        {
            LoginBehavior.WebOnly => FBSDKAppSwitch.Disabled,
            LoginBehavior.NativeWithFallback => FBSDKAppSwitch.Enabled,
            LoginBehavior.NativeOnly => FBSDKAppSwitch.Enabled,
            LoginBehavior.KatanaOnly => FBSDKAppSwitch.Enabled,
            LoginBehavior.DialogOnly => FBSDKAppSwitch.Enabled,
            LoginBehavior.DeviceAuth => FBSDKAppSwitch.Enabled,
            _ => FBSDKAppSwitch.Enabled,
        };
    }

    internal static FBSDKDefaultAudience ToNativeDefaultAudience(this DefaultAudience audience)
    {
        return audience switch
        {
            DefaultAudience.Friends => FBSDKDefaultAudience.Friends,
            DefaultAudience.OnlyMe => FBSDKDefaultAudience.OnlyMe,
            DefaultAudience.Everyone => FBSDKDefaultAudience.Everyone,
            _ => FBSDKDefaultAudience.Friends,
        };
    }
    
    internal static NSString? ToNativeAuthType(this LoginAuthType? authType)
    {
        return authType switch
        {
            LoginAuthType.Rerequest => FBSDKLoginAuthType.Rerequest,
            LoginAuthType.Reauthorize => FBSDKLoginAuthType.Reauthorize,
            _ => FBSDKLoginAuthType.Rerequest
        };
    }

    internal static FBSDKLoginTracking ToNativeLoginTracking (this LoginTracking tracking)
    {
        return tracking switch
        {
            LoginTracking.Enabled => FBSDKLoginTracking.Enabled,
            LoginTracking.Limited => FBSDKLoginTracking.Limited,
            _ => FBSDKLoginTracking.Enabled
        };
    }

    internal static FBSDKRefreshFallbackPolicy ToRefreshFallbackPolicy (this RefreshFallbackPolicy refreshFallbackPolicy)
    {
        return refreshFallbackPolicy switch
        {
            RefreshFallbackPolicy.Automatic => FBSDKRefreshFallbackPolicy.Automatic,
            RefreshFallbackPolicy.SilentOnly => FBSDKRefreshFallbackPolicy.SilentOnly,
            RefreshFallbackPolicy.ExplicitOnly => FBSDKRefreshFallbackPolicy.ExplicitOnly,
            RefreshFallbackPolicy.DirectOnly => FBSDKRefreshFallbackPolicy.DirectOnly,
            _ => throw new InvalidEnumArgumentException("FBSDKRefreshFallbackPolicy requires one of these types (Automatic, SilentOnly, ExplicitOnly, DirectOnly)")
        };
    }


    internal static FBSDKLoginButtonTooltipBehavior ToNativeTooltipBehavior (this TooltipBehavior tooltipBehavior)
    {
        return tooltipBehavior switch
        {
            TooltipBehavior.Automatic => FBSDKLoginButtonTooltipBehavior.Automatic,
            TooltipBehavior.ForceDisplay => FBSDKLoginButtonTooltipBehavior.ForceDisplay,
            TooltipBehavior.Disable => FBSDKLoginButtonTooltipBehavior.Disable,
            _ => FBSDKLoginButtonTooltipBehavior.Automatic,
        };
    }

    internal static FBSDKTooltipViewArrowDirection ToNativeTooltipDirection (this TooltipViewArrowDirection tooltipDirection)
    {
        return tooltipDirection switch
        {
            TooltipViewArrowDirection.Down => FBSDKTooltipViewArrowDirection.Down,
            TooltipViewArrowDirection.Up => FBSDKTooltipViewArrowDirection.Up,
            _ => FBSDKTooltipViewArrowDirection.Up,
        };
    }

    internal static FBSDKTooltipColorStyle ToNativeTooltipColorStyle (this TooltipColorStyle tooltipColorStyle)
    {
        return tooltipColorStyle switch
        {
            TooltipColorStyle.FriendlyBlue => FBSDKTooltipColorStyle.FriendlyBlue,
            TooltipColorStyle.NeutralGray => FBSDKTooltipColorStyle.NeutralGray,
            _ => FBSDKTooltipColorStyle.FriendlyBlue,
        };
    }

    internal static FBSDKProfilePictureMode ToNativePictureMode(this ProfilePictureMode profilePictureMode)
    {
        return profilePictureMode switch
        {
            ProfilePictureMode.Square => FBSDKProfilePictureMode.Square,
            ProfilePictureMode.Normal => FBSDKProfilePictureMode.Normal,
            ProfilePictureMode.Album => FBSDKProfilePictureMode.Album,
            ProfilePictureMode.Small => FBSDKProfilePictureMode.Small,
            ProfilePictureMode.Large => FBSDKProfilePictureMode.Large,
            _ => FBSDKProfilePictureMode.Square,
        };
    }
}

[Preserve(AllMembers = true)]
internal static class LoginExtensions
{
    internal static FBSDKCodeVerifier ToNativeCodeVerifier(this CodeVerifier codeVerifier) =>
        String.IsNullOrEmpty(codeVerifier.Value) ? new FBSDKCodeVerifier() : new FBSDKCodeVerifier(codeVerifier.Value);

    internal static FBSDKPermission[] ToNativePermissions(this IReadOnlySet<string> permissions)
    {
        var rawPermissions = new NSSet<NSString>(permissions.Select(p => new NSString(p)).ToArray());
        return FBSDKPermission.GetPermissions(rawPermissions);
    }

    internal static FBSDKLoginConfiguration ToNativeConfiguration(this LoginConfiguration configuration, LoginBehavior loginBehavior, 
        string? messengerPageId, LoginAuthType authType, LoginTracking loginTracking)
    {
        var permissions = configuration.Permissions.ToNativePermissions();
        var tracking = loginTracking.ToNativeLoginTracking();
        var appSwitch = loginBehavior.ToNativeAppSwitch();
        var type = authType.ToNativeAuthType();

        if (!string.IsNullOrEmpty(configuration.Nonce))
        {
            if (configuration.CodeVerifier is not null)
            {
                return new FBSDKLoginConfiguration(permissions, tracking, configuration.Nonce, messengerPageId, type, 
                    appSwitch, configuration.CodeVerifier.ToNativeCodeVerifier())
                {
                };
            }

            return new FBSDKLoginConfiguration(permissions, tracking, configuration.Nonce, messengerPageId, type, appSwitch);
        }

        return new FBSDKLoginConfiguration(permissions, tracking, messengerPageId, type, appSwitch);
    }

    internal static FBSDKPermission[] ToNativePermissions(this string[] permissions)
    {
        return permissions.Cast<string>().Select(x => x.ToNativePermission()).ToArray();
    }

    internal static FBSDKPermission ToNativePermission(this string permission)
    {
        return new FBSDKPermission(permission);
    }

    internal static FBSDKProfile? ToNativeProfile(this IProfile? profile)
    {
        if(profile is not Profile nativeProfile)
            return null;

        return nativeProfile.nativeProfile;
    }

    internal static ILoginResult ToLoginResult(this FBSDKLoginManagerLoginResult result)
    {
        return new LoginResult(result.Token?.ToToken(), result.AuthenticationToken?.ToAuthenticationToken(), new LoginResultAppleExtras(result.IsCancelled),
            result.GrantedPermissions.ToRawPermissions(), result.DeclinedPermissions.ToRawPermissions());
    }

    internal static IDeviceLoginCodeInfo ToCodeInfo(this FBSDKDeviceLoginCodeInfo codeInfo)
    {
        return new DeviceLoginCodeInfo(codeInfo.Identifier, codeInfo.LoginCode, codeInfo.VerificationURL, 
            codeInfo.ExpirationDate.ToDateTimeOffset(), codeInfo.PollingInterval.ToTimeSpanFromSeconds());
    }

    internal static ILoginResult ToDeviceLoginResult(this FBSDKDeviceLoginManagerResult result) =>
        new LoginResult(result.AccessToken?.ToToken(), null, new LoginResultAppleExtras(result.IsCancelled), null, null);

    internal static LoginException ToLoginException(this NSError error)
    {
        if (error.Domain == "com.facebook.sdk.login")
        {
            var code = ((FBSDKLoginError)error.Code).ToLoginErrorCode();
            return new LoginException(code, error.LocalizedDescription, new NSErrorException(error));
        }

        return new LoginException(LoginErrorCode.Unknown, error.LocalizedDescription, new NSErrorException(error));
    }

    internal static DeviceLoginException ToDeviceLoginException(this NSError error)
    {
        if (error.Domain == "com.facebook.sdk.login")
        {
            var code = ((FBSDKDeviceLoginError)error.Code).ToDeviceLoginErrorCode();
            return new DeviceLoginException(code, error.LocalizedDescription, new NSErrorException(error));
        }

        return new DeviceLoginException(DeviceLoginErrorCode.Unknown, error.LocalizedDescription, new NSErrorException(error));
    }

    internal static IAccessToken? ToToken(this FBSDKAccessToken? token)
    {
        if(token is null)
            return null;

        return new AccessToken(token);
    }

    internal static IProfile? ToProfile(this FBSDKProfile? profile)
    {
        if(profile is null)
            return null;

        return new Profile(profile);
    }

    internal static IAgeRange ToAgeRange(this FBSDKUserAgeRange ageRange) =>
        new AgeRange(ageRange.Min?.Int32Value, ageRange.Max?.Int32Value);

    internal static ILocation ToLocation(this FBSDKLocation location) =>
        new Location(location.Id, location.Name);

    internal static IAuthenticationToken ToAuthenticationToken(this FBSDKAuthenticationToken token) =>
        new AuthenticationToken(token.TokenString, token.Nonce, new AuthenticationTokenAppleExtras(token.GraphDomain));

    internal static IReadOnlySet<string> ToRawPermissions(this NSSet<NSString> permissions) =>
        permissions.Cast<NSString>().Select(x => x.ToString()).ToHashSet();
}
