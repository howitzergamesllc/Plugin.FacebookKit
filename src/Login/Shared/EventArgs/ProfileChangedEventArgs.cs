
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Provides the updated global static <see cref="FacebookPluginLogin.CurrentProfile"/>.
/// </summary>
public sealed class ProfileChangedEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProfileChangedEventArgs"/> class.
    /// </summary>
    /// <param name="currentProfile">
    /// The global static <see cref="FacebookPluginLogin.CurrentProfile"/>
    /// </param>
    public ProfileChangedEventArgs(IProfile? currentProfile)
    {
        CurrentProfile = currentProfile;
    }

    /// <summary>
    /// The global <see cref="FacebookPluginLogin.CurrentProfile"/>
    /// </summary>
    public IProfile? CurrentProfile { get; }
}
