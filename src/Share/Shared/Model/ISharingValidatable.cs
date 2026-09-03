
namespace Plugin.FacebookKit.Share;

/// <summary>
/// (Apple only)An interface for validatable content and media.
/// </summary>
public interface ISharingValidatable
{
#if IOS || MACCATALYST
    /// <summary>
    /// Validate that this content or media contains valid values.
    /// </summary>
    /// <param name="options">The <see cref="ShareBridgeOptions"/> to use for validation.</param>
    /// <param name="error">throws: If the values are not valid.</param>
    /// <returns><c>true</c> if the sharing instance is valid.</returns>
    bool Validate (ShareBridgeOptions options, out Exception? error);
#endif
}