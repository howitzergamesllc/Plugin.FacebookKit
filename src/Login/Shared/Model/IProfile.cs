using Plugin.FacebookKit.Login.Controls;

namespace Plugin.FacebookKit.Login;

/// <summary>
/// Represents an immutable Facebook profile.
/// This class provides a global current profile instance to more easily
/// add social context to your application. When the profile changes, a notification is
/// posted so that you can update relevant parts of your UI. It is persisted to <c>UserDefaults.standard</c>.
/// Typically, you will want to set <c>enableUpdatesOnAccessTokenChange</c> to <c>true</c> so that
/// it automatically observes changes to <see cref="FacebookPluginLogin.CurrentToken"/>
/// You can use this class to build your own <see cref="ProfilePictureView"/> or in place of typical requests to the <c>/me</c> endpoint.
/// </summary>
public interface IProfile
{
    /// <summary>
    /// The user identifier.
    /// </summary>
    string? UserId { get; }

    /// <summary>
    /// The user’s first name.
    /// </summary>
    string? FirstName { get; }

    /// <summary>
    /// The user’s middle name.
    /// </summary>
    string? MiddleName { get; }

    /// <summary>
    /// The user’s last name.
    /// </summary>
    string? LastName { get; }

    /// <summary>
    /// The user’s complete name.
    /// </summary>
    string? Name { get; }

    /// <summary>
    /// A URL to the user’s profile.
    /// important:
    /// This field will only be populated if your user has granted your application the <c>user_link</c> permission.
    /// Consider using <c>AppLinkResolver</c> to resolve this URL to an app link in order to link directly to
    /// the user’s profile in the Facebook app.
    /// </summary>
    Uri? LinkURL { get; }

    /// <summary>
    /// A URL to use for fetching the user’s profile image.
    /// </summary>
    Uri? ImageURL { get; }

    /// <summary>
    /// Extra facebook profile properties on apple platforms.
    /// </summary>
    IProfileAppleExtras? AppleExtras { get; }

    /// <summary>
    /// Returns the profile picture Uri given a <see cref="Rect"/> size and <see cref="ProfilePictureMode"/>.
    /// </summary>
    /// <remarks>
    /// Android only uses the size parameter.
    /// </remarks>
    /// <param name="size">The size to retrieve</param>
    /// <param name="mode">The <see cref="ProfilePictureMode"/> to retrieve</param>
    /// <returns>A Uri for the profile picture.</returns>
    Uri? GetProfilePictureUri(Rect size, ProfilePictureMode mode = ProfilePictureMode.Normal);

    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}

/// <summary>
/// Extra facebook profile properties on apple platforms.
/// </summary> 
public interface IProfileAppleExtras
{
    /// <summary>
    /// The last time the profile data was fetched.
    /// </summary>
    DateTimeOffset? RefreshDate { get; }
    
    /// <summary>
    /// The user’s email address.
    /// important:
    /// This field will only be populated if your user has granted your application the <c>email</c> permission.
    /// </summary>
    string? Email { get; }

    /// <summary>
    /// A list of identifiers of the user’s friends.
    /// important:
    /// This field will only be populated if your user has granted your application
    /// the <c>user_friends</c> permission.
    /// </summary>
    IReadOnlySet<string>? FriendIds { get; }

    /// <summary>
    /// The user’s birthday.
    /// important:
    /// This field will only be populated if your user has granted your application
    /// the <c>user_birthday</c> permission.
    /// </summary>
    DateTimeOffset? Birthday { get; }

    /// <summary>
    /// The user’s age range.
    /// important:
    /// This field will only be populated if your user has granted your application
    /// the <c>user_age_range</c> permission.
    /// </summary>
    IAgeRange? AgeRange { get; }

    /// <summary>
    /// The user’s hometown.
    /// important:
    /// This field will only be populated if your user has granted your application
    /// the <c>user_hometown</c> permission.
    /// </summary>
    ILocation? Hometown { get; }

    /// <summary>
    /// The user’s location.
    /// important:
    /// This field will only be populated if your user has granted your application
    /// the <c>user_location</c> permission.
    /// </summary>
    ILocation? Location { get; }

    /// <summary>
    /// The user’s gender.
    /// important:
    /// This field will only be populated if your user has granted your application
    /// the <c>user_gender</c> permission.
    /// </summary>
    string? Gender { get; }

    /// <summary>
    /// The user’s granted permissions.
    /// important:
    /// This field will only be populated if your user has granted permissions to your
    /// application.
    /// </summary>
    IReadOnlySet<string>? GrantedPermissions { get; }

    /// <summary>
    /// Indicates if the profile was accessed with a limited login.
    /// </summary>
    bool IsLimited { get; }
    
    /// <summary>
    /// Provides string description of all available properties for debugging purposes.
    /// </summary>
    /// <returns>String conataining all property information.</returns>
    string DebugDescription();
}