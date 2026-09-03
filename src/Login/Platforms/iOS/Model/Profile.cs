
using CoreGraphics;
using Facebook.Core;
using Plugin.FacebookKit.Core.Platforms.iOS.Extensions;
using Plugin.FacebookKit.Login.Platforms.iOS.Extensions;

namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class Profile : IProfile
{
    internal readonly FBSDKProfile nativeProfile;
    internal Profile(FBSDKProfile nativeProfile)
    {
        this.nativeProfile = nativeProfile;        
        UserId = nativeProfile.UserID;
        FirstName = nativeProfile.FirstName;
        MiddleName = nativeProfile.MiddleName;
        LastName = nativeProfile.LastName;
        Name = nativeProfile.Name;
        LinkURL = nativeProfile.LinkURL;
        ImageURL = nativeProfile.ImageURL;
        AppleExtras = new ProfileAppleExtras(nativeProfile.RefreshDate.ToDateTimeOffset(), nativeProfile.Email, nativeProfile.FriendIDs?.ToHashSet(), 
            nativeProfile.Birthday?.ToDateTimeOffset(), nativeProfile.AgeRange?.ToAgeRange(), nativeProfile.Hometown?.ToLocation(), 
            nativeProfile.Location?.ToLocation(), nativeProfile.Gender, nativeProfile.Permissions?.ToRawPermissions(), nativeProfile.IsLimited);
    }
    
    /// <inheritdoc />
    public Uri? GetProfilePictureUri(Rect rect, ProfilePictureMode mode) => nativeProfile.GetImageURL(mode.ToNativePictureMode(), CGSize.Empty).ToUri();
}

internal sealed partial class ProfileAppleExtras : IProfileAppleExtras
{
    internal ProfileAppleExtras(DateTimeOffset? refreshDate, string? email, IReadOnlySet<string>? friendIds, DateTimeOffset? birthday,
        IAgeRange? ageRange, ILocation? hometown, ILocation? location, string? gender, IReadOnlySet<string>? grantedPermissions, bool isLimited)
    {
        RefreshDate = refreshDate;
        Email = email;
        FriendIds = friendIds;
        Birthday = birthday;
        AgeRange = ageRange;
        Hometown = hometown;
        Location = location;
        Gender = gender;
        GrantedPermissions = grantedPermissions;
        IsLimited = isLimited;
    }
}