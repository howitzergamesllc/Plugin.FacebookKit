
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents an authentication token returned from a login attempt.
/// </summary>
/// <remarks>
/// Authentication tokens are created and managed by the authentication service.
/// Consumers should treat implementations as immutable and use the exposed
/// properties to inspect authentication state.
/// </remarks>
public interface IAuthenticationToken
{
    /// <summary>
    /// Gets the raw token string returned from the authentication response.
    /// </summary>
    string TokenString { get; }

    /// <summary>
    /// Gets the nonce value associated with the authentication response.
    /// </summary>
    /// <remarks>
    /// The nonce is used to validate that the authentication response
    /// corresponds to the original authentication request.
    /// </remarks>
    string Nonce { get; }
    
    /// <summary>
    /// Extra parameters for authentication tokens on apple platforms.
    /// </summary>
    public IAuthenticationTokenAppleExtras? AppleExtras { get; }
    
    /// <summary>
    /// Extra parameters for authentication tokens on android.
    /// </summary>
    public IAuthenticationTokenAndroidExtras? AndroidExtras { get; }

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}

/// <summary>
/// Extra parameters for authentication tokens on apple platforms.
/// </summary>
public interface IAuthenticationTokenAppleExtras
{
    /// <summary>
    /// The Graph API domain that this token is valid for.
    /// </summary>
    string? GraphDomain { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}

/// <summary>
/// Extra parameters for authentication tokens on android.
/// </summary>
public interface IAuthenticationTokenAndroidExtras
{
    /// <summary>
    /// Header component of the AuthenticationToken
    /// </summary>
    IAuthenticationTokenHeader? Header { get; }

    /// <summary>
    /// Payload component of the AuthenticationToken
    /// </summary>
    IAuthenticationTokenClaims? Claims { get; }

    /// <summary>
    /// Signature component of the id_token
    /// </summary>
    string? Signature { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}

/// <summary>
/// This class represents an immutable header for using AuthenticationToken. It includes all metadata or key values of the header
/// WARNING: This feature is currently in development and not intended for external usage.
/// </summary>
public interface IAuthenticationTokenHeader
{
    /// <summary>
    /// Value that represents the algorithm that was used to sign the JWT.
    /// </summary>
    string? ALG { get; }

    /// <summary>
    /// The type of the JWT.
    /// </summary>
    string? TYP { get; }

    /// <summary>
    /// Key identifier used in identifying the key to be used to verify the signature.
    /// </summary>
    string? KID { get; }

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}

/// <summary>
/// This class represents an immutable claims for using AuthenticationToken. It includes all metadata or key values of the claims
/// WARNING: This feature is currently in development and not intended for external usage.
/// </summary>
public interface IAuthenticationTokenClaims
{
    /// <summary>
    /// The unique identifier for the token.
    /// </summary>
    string? JTI { get; }

    /// <summary>
    /// The issuer Identifier for the Issuer of the response.
    /// </summary>
    string? ISS { get; }

    /// <summary>
    /// The audience(s) that this ID Token is intended for.
    /// </summary>
    string? AUD { get; }

    /// <summary>
    /// String value used to associate a Client session with an ID Token, and to mitigate replay attacks.
    /// </summary>
    string? NONCE { get; }

    /// <summary>
    /// Expiration time (in seconds) on or after which the ID Token MUST NOT be accepted for processing.
    /// </summary>
    long EXP { get; }

    /// <summary>
    /// Time (in seconds) at which the JWT was issued.
    /// </summary>
    long IAT { get; }

    /// <summary>
    /// Subject - Identifier for the End-User at the Issuer.
    /// </summary>
    string? SUB { get; }

    /// <summary>
    /// End-User's full name in displayable form including all name parts.
    /// </summary>
    string? NAME { get; }

    /// <summary>
    /// End-User's given name in displayable form
    /// </summary>
    string? GIVENNAME { get; }

    /// <summary>
    /// End-User's middle name in displayable form
    /// </summary>
    string? MIDDLENAME { get; }

    /// <summary>
    /// End-User's family name in displayable form
    /// </summary>
    string? FAMILYNAME { get; }

    /// <summary>
    /// End-User's preferred e-mail address.
    /// </summary>
    string? EMAIL { get; }

    /// <summary>
    /// URL of the End-User's profile picture.
    /// </summary>
    string? PICTURE { get; }

    /// <summary>
    /// End-User's friends.
    /// </summary>
    IReadOnlySet<string>? USERFRIENDS { get; }

    /// <summary>
    /// End-User's birthday
    /// </summary>
    string? USERBIRTHDAY { get; }

    /// <summary>
    /// End-User's age range
    /// </summary>
    IAgeRange? USERAGERANGE { get; }

    /// <summary>
    /// End-User's hometown
    /// </summary>
    ILocation? USERHOMETOWN { get; }

    /// <summary>
    /// End-User's location
    /// </summary>
    ILocation? USERLOCATION { get; }

    /// <summary>
    /// End-User's gender
    /// </summary>
    string? USERGENDER { get; }

    /// <summary>
    /// End-User's link
    /// </summary>
    string? USERLINK { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}