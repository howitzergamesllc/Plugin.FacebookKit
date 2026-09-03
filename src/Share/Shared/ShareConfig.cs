
using Plugin.FacebookKit.Share.Controls;

namespace Plugin.FacebookKit.Share;

/// <summary>
/// Registers Facebook Share Controls.
/// </summary>
public static class ShareConfig
{
    /// <summary>
    /// Registers the Facebook Share SDK Controls and view handlers.
    /// </summary>
    /// <param name="builder">The maui app builder.</param>
    /// <returns>The source maui app builder.</returns>
    public static MauiAppBuilder UseFacebookShareControls(this MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers(handlers =>
        {
#if IOS || MACCATALYST || ANDROID
            handlers.AddHandler(typeof(ShareButton), typeof(ShareButtonHandler));
            handlers.AddHandler(typeof(SendButton), typeof(SendButtonHandler));
#endif
        });

        return builder;
    }
}