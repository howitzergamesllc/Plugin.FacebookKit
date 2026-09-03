

using Graphics = Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Net = Android.Net;
using Views = Android.Views;
using Plugin.FacebookKit.Core.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login.Platforms.Android.Extensions;

internal static class EnumExtensions
{
    internal static LoginBehavior ToLoginBehavior(this Facebook.Login.LoginBehavior loginBehavior)
    {
        if (loginBehavior == Facebook.Login.LoginBehavior.NativeWithFallback) return LoginBehavior.NativeWithFallback;
        if (loginBehavior == Facebook.Login.LoginBehavior.NativeOnly) return LoginBehavior.NativeOnly;
        if (loginBehavior == Facebook.Login.LoginBehavior.KatanaOnly) return LoginBehavior.KatanaOnly;
        if (loginBehavior == Facebook.Login.LoginBehavior.WebOnly) return LoginBehavior.WebOnly;
        if (loginBehavior == Facebook.Login.LoginBehavior.DialogOnly) return LoginBehavior.DialogOnly;
        if (loginBehavior == Facebook.Login.LoginBehavior.DeviceAuth) return LoginBehavior.DeviceAuth;
        return LoginBehavior.Unknown;
    }

    internal static DefaultAudience ToDefualtAudience(this Facebook.Login.DefaultAudience audience)
    {
        if (audience == Facebook.Login.DefaultAudience.Friends) return DefaultAudience.Friends;
        if (audience == Facebook.Login.DefaultAudience.OnlyMe) return DefaultAudience.OnlyMe;
        if (audience == Facebook.Login.DefaultAudience.Everyone) return DefaultAudience.Everyone;
        return DefaultAudience.Unknown;
    }

    internal static LoginTargetApp ToTargetApp(this Facebook.Login.LoginTargetApp targetApp)
    {
        if(targetApp == Facebook.Login.LoginTargetApp.Facebook) return LoginTargetApp.Facebook;
        if(targetApp == Facebook.Login.LoginTargetApp.Instagram) return LoginTargetApp.Instagram;
        return LoginTargetApp.Unknown;
    }

    internal static Facebook.Login.LoginTargetApp ToNativeTargetApp(this LoginTargetApp targetApp)
    {
        return targetApp switch
        {
            LoginTargetApp.Facebook => Facebook.Login.LoginTargetApp.Facebook,
            LoginTargetApp.Instagram => Facebook.Login.LoginTargetApp.Instagram,
            _ => Facebook.Login.LoginTargetApp.Facebook,
        };
    }
    
    internal static LoginAuthType ToAuthType(this string authType)
    {
        if(authType == Facebook.Internal.ServerProtocol.DialogRerequestAuthType)
            return LoginAuthType.Rerequest;

        return LoginAuthType.Unknown;
    }
    
    internal static string ToNativeAuthType(this LoginAuthType authType)
    {
        return authType switch
        {
            LoginAuthType.Rerequest => Facebook.Internal.ServerProtocol.DialogRerequestAuthType,
            _ => Facebook.Internal.ServerProtocol.DialogRerequestAuthType
        };
    }

    internal static AccessTokenSource ToTokenSource(this Facebook.AccessTokenSource source)
    {
        if(source == Facebook.AccessTokenSource.None) return AccessTokenSource.None;
        if(source == Facebook.AccessTokenSource.FacebookApplicationWeb) return AccessTokenSource.FacebookAppWeb;
        if(source == Facebook.AccessTokenSource.FacebookApplicationNative) return AccessTokenSource.FacebookAppNative;
        if(source == Facebook.AccessTokenSource.FacebookApplicationService) return AccessTokenSource.FacebookAppService;
        if(source == Facebook.AccessTokenSource.WebView) return AccessTokenSource.WebView;
        if(source == Facebook.AccessTokenSource.ChromeCustomTab) return AccessTokenSource.ChromeCustomTab;
        if(source == Facebook.AccessTokenSource.TestUser) return AccessTokenSource.TestUser;
        if(source == Facebook.AccessTokenSource.ClientToken) return AccessTokenSource.ClientToken;
        if(source == Facebook.AccessTokenSource.DeviceAuth) return AccessTokenSource.DeviceAuth;
        if(source == Facebook.AccessTokenSource.InstagramApplicationWeb) return AccessTokenSource.InstagramAppWeb;
        if(source == Facebook.AccessTokenSource.InstagramCustomChromeTab) return AccessTokenSource.InstagramChromeTab;
        if(source == Facebook.AccessTokenSource.InstagramWebView) return AccessTokenSource.InstagramWebView;
        return AccessTokenSource.Unknown;
    }

    internal static Facebook.AccessTokenSource ToNativeTokenSource(this AccessTokenSource source)
    {
        return source switch
        {
            AccessTokenSource.None => Facebook.AccessTokenSource.None,
            AccessTokenSource.FacebookAppWeb => Facebook.AccessTokenSource.FacebookApplicationWeb,
            AccessTokenSource.FacebookAppNative => Facebook.AccessTokenSource.FacebookApplicationNative,
            AccessTokenSource.FacebookAppService => Facebook.AccessTokenSource.FacebookApplicationService,
            AccessTokenSource.WebView => Facebook.AccessTokenSource.WebView,
            AccessTokenSource.ChromeCustomTab => Facebook.AccessTokenSource.ChromeCustomTab,
            AccessTokenSource.TestUser => Facebook.AccessTokenSource.TestUser,
            AccessTokenSource.ClientToken => Facebook.AccessTokenSource.ClientToken,
            AccessTokenSource.DeviceAuth => Facebook.AccessTokenSource.DeviceAuth,
            AccessTokenSource.InstagramAppWeb => Facebook.AccessTokenSource.InstagramApplicationWeb,
            AccessTokenSource.InstagramChromeTab => Facebook.AccessTokenSource.InstagramCustomChromeTab,
            AccessTokenSource.InstagramWebView => Facebook.AccessTokenSource.InstagramWebView,
            _ => Facebook.AccessTokenSource.None
        };
    }

    internal static TooltipColorStyle ToTooltipColorStyle (this Facebook.Login.Widget.ToolTipPopup.Style tooltipColorStyle)
    {
        if(tooltipColorStyle == Facebook.Login.Widget.ToolTipPopup.Style.Blue) return TooltipColorStyle.FriendlyBlue;
        if(tooltipColorStyle == Facebook.Login.Widget.ToolTipPopup.Style.Black) return TooltipColorStyle.NeutralGray;
        return TooltipColorStyle.Unknown;
    }

    internal static TooltipBehavior ToTooltipBehavior (this Facebook.Login.Widget.LoginButton.ToolTipMode toolTipMode)
    {
        if(toolTipMode == Facebook.Login.Widget.LoginButton.ToolTipMode.Automatic) return TooltipBehavior.Automatic;
        if(toolTipMode == Facebook.Login.Widget.LoginButton.ToolTipMode.DisplayAlways) return TooltipBehavior.ForceDisplay;
        if(toolTipMode == Facebook.Login.Widget.LoginButton.ToolTipMode.NeverDisplay) return TooltipBehavior.Disable;
        return TooltipBehavior.Unknown;
    }

    internal static Facebook.Login.Widget.LoginButton.ToolTipMode ToNativeTooltipBehavior (this TooltipBehavior toolTipMode)
    {
        return toolTipMode switch
        {
            TooltipBehavior.Automatic => Facebook.Login.Widget.LoginButton.ToolTipMode.Automatic,
            TooltipBehavior.ForceDisplay => Facebook.Login.Widget.LoginButton.ToolTipMode.DisplayAlways,
            TooltipBehavior.Disable => Facebook.Login.Widget.LoginButton.ToolTipMode.NeverDisplay,
            _ => Facebook.Login.Widget.LoginButton.ToolTipMode.Automatic
        };
    }

    internal static Facebook.Login.LoginBehavior ToNativeLoginBehavior(this LoginBehavior loginBehavior)
    {
        return loginBehavior switch
        {
            LoginBehavior.NativeWithFallback => Facebook.Login.LoginBehavior.NativeWithFallback,
            LoginBehavior.NativeOnly => Facebook.Login.LoginBehavior.NativeOnly,
            LoginBehavior.KatanaOnly => Facebook.Login.LoginBehavior.KatanaOnly,
            LoginBehavior.WebOnly => Facebook.Login.LoginBehavior.WebOnly,
            LoginBehavior.DialogOnly => Facebook.Login.LoginBehavior.DialogOnly,
            LoginBehavior.DeviceAuth => Facebook.Login.LoginBehavior.DeviceAuth,
            _ => Facebook.Login.LoginBehavior.NativeWithFallback,
        };
    }

    internal static Facebook.Login.DefaultAudience ToNativeDefaultAudience(this DefaultAudience audience)
    {
        return audience switch
        {
            DefaultAudience.Friends => Facebook.Login.DefaultAudience.Friends,
            DefaultAudience.OnlyMe => Facebook.Login.DefaultAudience.OnlyMe,
            DefaultAudience.Everyone => Facebook.Login.DefaultAudience.Everyone,
            _ => Facebook.Login.DefaultAudience.None,
        };
    }

    internal static Facebook.Login.Widget.ToolTipPopup.Style ToNativeTooltipColorStyle (this TooltipColorStyle tooltipColorStyle)
    {
        return tooltipColorStyle switch
        {
            TooltipColorStyle.FriendlyBlue => Facebook.Login.Widget.ToolTipPopup.Style.Blue,
            TooltipColorStyle.NeutralGray => Facebook.Login.Widget.ToolTipPopup.Style.Black,
            _ => Facebook.Login.Widget.ToolTipPopup.Style.Blue,
        };
    }

    internal static int ToNativePictureMode(this ProfilePictureMode profilePictureMode)
    {
        return profilePictureMode switch
        {
            ProfilePictureMode.Normal => Facebook.Login.Widget.ProfilePictureView.Normal,
            ProfilePictureMode.Small => Facebook.Login.Widget.ProfilePictureView.Small,
            ProfilePictureMode.Large => Facebook.Login.Widget.ProfilePictureView.Large,
            _ => Facebook.Login.Widget.ProfilePictureView.Normal,
        };
    }
}

internal static class LoginExtensions
{
    internal static string? ToNativeCodeVerifier(this CodeVerifier codeVerifier) =>
        System.String.IsNullOrEmpty(codeVerifier.Value) ? null : codeVerifier.Value;

    internal static Facebook.Login.LoginConfiguration ToNativeConfiguration(this LoginConfiguration configuration)
    {
        var permissions = configuration.Permissions;

        if (!string.IsNullOrEmpty(configuration.Nonce))
        {
            return new Facebook.Login.LoginConfiguration(permissions.ToArray(), configuration.Nonce, configuration.CodeVerifier?.ToNativeCodeVerifier());
        }

        return new Facebook.Login.LoginConfiguration(permissions.ToArray());
    }

    internal static Facebook.Profile? ToNativeProfile(this IProfile? profile)
    {
        if(profile is not Profile nativeProfile)
            return null;

        return nativeProfile.nativeProfile;
    }

    internal static ILoginResult ToLoginResult(this Facebook.Login.LoginResult result)
    {
        return new LoginResult(result.AccessToken?.ToToken(), result.AuthenticationToken?.ToAuthenticationToken(),
            result.RecentlyGrantedPermissions.ToRawPermissions(), result.RecentlyDeniedPermissions.ToRawPermissions());
    }

    internal static IAccessToken? ToToken(this Facebook.AccessToken? token)
    {
        if(token is null)
            return null;

        return new AccessToken(token);
    }

    internal static IProfile? ToProfile(this Facebook.Profile? profile)
    {
        if(profile is null)
            return null;

        return new Profile(profile);
    }

    internal static IAgeRange? ToAgeRange(this IReadOnlyDictionary<string, int>? ageRange) =>
        AgeRange.FromDictionary(ageRange);

    internal static ILocation? ToLocation(this IReadOnlyDictionary<string, string>? location) => 
        Location.FromDictionary(location);

    internal static IAuthenticationToken ToAuthenticationToken(this Facebook.AuthenticationToken token) =>
        new AuthenticationToken(token.Token, token.ExpectedNonce, token.Header.ToAuthenticationHeader(), token.Claims.ToAuthenticationClaims(), token.Signature);
        
    internal static AuthenticationTokenHeader ToAuthenticationHeader(this Facebook.AuthenticationTokenHeader header) =>
        new AuthenticationTokenHeader(header.Alg, header.Typ, header.Kid);

    internal static AuthenticationTokenHeader ToAuthenticationHeader(this string header) =>
        new AuthenticationTokenHeader(header);

    internal static AuthenticationTokenClaims ToAuthenticationClaims(this Facebook.AuthenticationTokenClaims claims) =>
        new AuthenticationTokenClaims(claims.Jti, claims.Iss, claims.Aud, claims.Nonce, claims.Exp, claims.Iat, claims.Sub, claims.Name,
        claims.GivenName, claims.MiddleName, claims.FamilyName, claims.Email, claims.Picture, claims.UserFriends?.ToList(), claims.UserBirthday,
        claims.UserAgeRange?.ToDictionary()?.ToAgeRange(), claims.UserHometown?.ToDictionary()?.ToLocation(), claims.UserLocation?.ToDictionary()?.ToLocation(), 
        claims.UserGender, claims.UserLink);

    internal static IReadOnlySet<string> ToRawPermissions(this ICollection<string> permissions) =>
        permissions.Cast<string>().Select(x => x.ToString()).ToHashSet();

    internal static Net.Uri? LoadContentUri(this Net.Uri destination)
	{
        if(destination is null || System.String.IsNullOrEmpty(destination.ToString()) || destination.EncodedPath is null)
            return null;

        var file = new Java.IO.File(destination.EncodedPath.ToString());
        var context = Platform.AppContext;
        return FileProvider.GetUriForFile(context, $"{context.PackageName}.fileprovider", file);
	}
    
    internal static Views.View? ToPlatform(this Microsoft.Maui.IView view)
    {
        return view.Handler?.PlatformView is Views.View nativeView ? nativeView : null;
    }

    internal static Graphics.Bitmap? ToNativeImage(this Image image)
    {
        var imageView = image.Handler?.PlatformView as ImageView;

        if (imageView?.Drawable is not BitmapDrawable bitmapDrawable)
            return null;

        return bitmapDrawable.Bitmap;
    }
}
