
using Plugin.FacebookKit.Core.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class Profile : IProfile
{
    internal readonly Facebook.Profile nativeProfile;
    internal Profile(Facebook.Profile nativeProfile)
    {
        this.nativeProfile = nativeProfile;        
        UserId = nativeProfile.Id;
        FirstName = nativeProfile.FirstName;
        MiddleName = nativeProfile.MiddleName;
        LastName = nativeProfile.LastName;
        Name = nativeProfile.Name;
        LinkURL = nativeProfile.LinkUri.ToUri();
        ImageURL = nativeProfile.PictureUri.ToUri();

    }

    public Uri? GetProfilePictureUri(Rect size, ProfilePictureMode mode) => 
        nativeProfile.GetProfilePictureUri((int)size.Width, (int)size.Height).ToUri();
}