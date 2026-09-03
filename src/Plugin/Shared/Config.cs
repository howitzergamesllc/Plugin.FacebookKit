
using Plugin.FacebookKit.Login;
using Plugin.FacebookKit.Share;

namespace Plugin.FacebookKit;

/// <summary>
/// Registers All Facebook Controls.
/// </summary>
public static class Config
{
    /// <summary>
    /// Registers all Facebook SDK Controls and view handlers.
    /// </summary>
    /// <param name="builder">The maui app builder.</param>
    /// <returns>The source maui app builder.</returns>
    public static MauiAppBuilder UseFacebookControls(this MauiAppBuilder builder) =>
        builder.UseFacebookLoginControls().UseFacebookShareControls();
}
