
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class AuthenticationToken : IAuthenticationToken
{
    internal AuthenticationToken(string tokenString, string nonce, string graphDomain)
    {
        TokenString = tokenString;
        Nonce = nonce;
        AppleExtras = new AuthenticationTokenAppleExtras(graphDomain);
    }    

    internal AuthenticationToken(string tokenString, string nonce, AuthenticationTokenHeader header, AuthenticationTokenClaims payload, string signature)
    {
        TokenString = tokenString;
        Nonce = nonce;
        AndroidExtras = new AuthenticationTokenAndroidExtras(header, payload, signature);
    }
}

internal sealed partial class AuthenticationTokenAppleExtras : IAuthenticationTokenAppleExtras
{
    internal AuthenticationTokenAppleExtras(string graphDomain)
    {
        GraphDomain = graphDomain;
    }
}

/// <inheritdoc />
internal sealed partial class AuthenticationTokenAndroidExtras : IAuthenticationTokenAndroidExtras
{
    internal AuthenticationTokenAndroidExtras(AuthenticationTokenHeader header, AuthenticationTokenClaims claims, string signature)
    {
        Header = header;
        Claims = claims;
        Signature = signature;
    }
}

/// <inheritdoc />
internal sealed partial class AuthenticationTokenHeader : IAuthenticationTokenHeader
{
    internal AuthenticationTokenHeader(string encodedHeaderString)
    {
        if (encodedHeaderString == null)
            throw new ArgumentNullException(nameof(encodedHeaderString));

        if (!IsValidHeader(encodedHeaderString))
            throw new ArgumentException("Invalid Header", nameof(encodedHeaderString));

        var decodedBytes = Android.Util.Base64.Decode(encodedHeaderString, Android.Util.Base64Flags.Default);

        var claimsString = System.Text.Encoding.UTF8.GetString(decodedBytes ?? []);

        var jsonObj = new Org.Json.JSONObject(claimsString);

        ALG = jsonObj.GetString("alg");
        TYP = jsonObj.GetString("typ");
        KID = jsonObj.GetString("kid");
    }    

    internal AuthenticationTokenHeader(string alg, string typ, string kid)
    {
        ALG = alg;
        TYP = typ;
        KID = kid;
    }

    private static bool IsValidHeader(string headerString)
    {
        if (string.IsNullOrEmpty(headerString))
            throw new ArgumentException("encodedHeaderString must not be empty", nameof(headerString));

        byte[]? decodedBytes;

        try
        {
            decodedBytes = Android.Util.Base64.Decode(headerString, Android.Util.Base64Flags.Default);
        }
        catch
        {
            return false;
        }

        if(decodedBytes is null)
            return false;

        var claimsString = System.Text.Encoding.UTF8.GetString(decodedBytes);

        try
        {
            var jsonObj = new Org.Json.JSONObject(claimsString);

            var alg = jsonObj.OptString("alg");
            var validAlg = !string.IsNullOrEmpty(alg) && alg == "RS256";

            var kid = jsonObj.OptString("kid");
            var hasKid = !string.IsNullOrEmpty(kid);

            var typ = jsonObj.OptString("typ");
            var validTyp = !string.IsNullOrEmpty(typ);

            return validAlg && hasKid && validTyp;
        }
        catch (Org.Json.JSONException)
        {
            return false;
        }
    }
}

/// <inheritdoc />
internal sealed partial class AuthenticationTokenClaims : IAuthenticationTokenClaims
{
    internal AuthenticationTokenClaims(string jti, string iss, string aud, string nonce, long exp, long iat, string sub, 
        string? name = null, string? givenName = null, string? middleName = null, string? familyName = null, string? email = null,
        string? picture = null, List<string>? userFriends = null, string? birthday = null, IAgeRange? ageRange = null, 
        ILocation? userHomeTown = null, ILocation? userLocation = null, string? userGender = null, string? userLink = null)
    {
        JTI = jti; ISS = iss; AUD = aud; NONCE = nonce; EXP = exp; IAT = iat; SUB = sub; NAME = name; GIVENNAME = givenName;
        MIDDLENAME = middleName; FAMILYNAME = familyName; EMAIL = email; PICTURE = picture; USERFRIENDS = userFriends?.ToHashSet();
        USERBIRTHDAY = birthday; USERAGERANGE = ageRange; USERHOMETOWN = userHomeTown; USERLOCATION = userLocation; USERGENDER = userGender;
        USERLINK = userLink;
    }
}