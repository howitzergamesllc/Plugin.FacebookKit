
using Plugin.FacebookKit.Login.Controls;

namespace Plugin.FacebookKit.Login;

/// <summary>
/// Registers Facebook Login Controls.
/// </summary>
public static class LoginConfig
{
    /// <summary>
    /// Registers the Facebook Login SDK Controls and view handlers.
    /// </summary>
    /// <param name="builder">The maui app builder.</param>
    /// <returns>The source maui app builder.</returns>
    public static MauiAppBuilder UseFacebookLoginControls(this MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers(handlers =>
        {
#if IOS || MACCATALYST || ANDROID
            handlers.AddHandler(typeof(LoginButton), typeof(LoginButtonHandler));
            handlers.AddHandler(typeof(ProfilePictureView), typeof(ProfilePictureViewHandler));
            handlers.AddHandler(typeof(LoginTooltipView), typeof(LoginTooltipViewHandler));
#endif
        });

        return builder;
    }
}
