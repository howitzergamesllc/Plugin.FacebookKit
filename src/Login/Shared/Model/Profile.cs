
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class Profile : IProfile
{
    /// <inheritdoc />
    public string? UserId { get;}

    /// <inheritdoc />
    public string? FirstName { get; }

    /// <inheritdoc />
    public string? MiddleName { get; }

    /// <inheritdoc />
    public string? LastName { get; }

    /// <inheritdoc />
    public string? Name { get; }

    /// <inheritdoc />
    public Uri? LinkURL { get; }

    /// <inheritdoc />
    public Uri? ImageURL { get; }

    /// <inheritdoc />
    public IProfileAppleExtras? AppleExtras { get; }
    
    /// <inheritdoc />
    public string DebugDescription() => $"UserId={UserId}, FirstName={FirstName}, MiddleName={MiddleName}, LastName={LastName}, " +
        $"Name={Name}, LinkURL={LinkURL}, ImageURL={ImageURL}";
}


/// <inheritdoc />
internal sealed partial class ProfileAppleExtras : IProfileAppleExtras
{
    /// <inheritdoc />
    public DateTimeOffset? RefreshDate { get; }
    
    /// <inheritdoc />
    public string? Email { get; }

    /// <inheritdoc />
    public IReadOnlySet<string>? FriendIds { get; }

    /// <inheritdoc />
    public DateTimeOffset? Birthday { get; }

    /// <inheritdoc />
    public IAgeRange? AgeRange { get; }

    /// <inheritdoc />
    public ILocation? Hometown { get; }

    /// <inheritdoc />
    public ILocation? Location { get; }

    /// <inheritdoc />
    public string? Gender { get; }

    /// <inheritdoc />
    public IReadOnlySet<string>? GrantedPermissions { get; }

    /// <inheritdoc />
    public bool IsLimited { get; }
    
    /// <inheritdoc />
    public string DebugDescription() => $"ProfileAppleExtras RefreshDate={RefreshDate}, Email={Email}, " +
        $"AgeRange={AgeRange?.DebugDescription()}, HomeTown={Hometown?.DebugDescription()}, Location={Location?.DebugDescription()}, " +
        $"Gender={Gender}, GrantedPermission={string.Join(", ", GrantedPermissions is null ? [] : GrantedPermissions)}, IsLimited={IsLimited}";
}