
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Apple Only) Defines the strategy used when refreshing a Limited Login session.
/// </summary>
/// <remarks>
/// The refresh process can use different mechanisms depending on the selected
/// policy. The automatic policy attempts lower-friction refresh methods first
/// and falls back to methods requiring more user interaction when necessary.
/// </remarks>
public enum RefreshFallbackPolicy
{
    /// <summary>
    /// Automatically attempts the available refresh mechanisms in sequence.
    /// </summary>
    /// <remarks>
    /// The SDK attempts a direct refresh first, then falls back to silent
    /// refresh, and finally presents an explicit login flow when required.
    /// </remarks>
    Automatic = 0,

    /// <summary>
    /// Uses only the silent refresh mechanism.
    /// </summary>
    /// <remarks>
    /// Uses a browser-based authentication session without presenting the
    /// Facebook login dialog.
    /// </remarks>
    SilentOnly = 1,

    /// <summary>
    /// Uses only an explicit Limited Login flow.
    /// </summary>
    /// <remarks>
    /// The user is required to complete an interactive authentication flow.
    /// </remarks>
    ExplicitOnly = 2,

    /// <summary>
    /// Uses only the direct silent refresh mechanism.
    /// </summary>
    /// <remarks>
    /// Uses a DPoP-bound refresh request without presenting user interface.
    /// This option is suitable when no user interaction is allowed.
    /// </remarks>
    DirectOnly = 3,

    /// <summary>
    /// The type was unknown. This could be an update to the facebook-ios-sdk.
    /// </summary>
    Unknown = -1,
}